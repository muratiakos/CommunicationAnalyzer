package caEmailBufferParser;

import java.io.StringReader;
import java.util.Date;
import java.text.SimpleDateFormat;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Calendar;

/**
 * A SimpleMail-t kiterjesztő osztály az adatbázisban tároláshoz és
 * feldolgozáshoz.
 * 
 * @author makos
 */
public class SimpleMailDatabaseObject extends SimpleMail {

    public boolean debugMode = false;
    Connection conn;
    //SQL utasítások u=UPDATE, i=INSERT
    PreparedStatement ps_u_RAWDATA;
    PreparedStatement ps_i_COMM;
    PreparedStatement ps_i_SUBCOMM;
    PreparedStatement ps_i_PARTICIPANT;
    PreparedStatement ps_i_PARTICIPANTADDRESS;
    PreparedStatement ps_i_THREAD;
    PreparedStatement ps_i_DATE;
    PreparedStatement ps_i_TIME;
    //Mezők
    String m_fromString;    //feladó e-mailje szövegesen
    String m_fromParticipant;      //Feladó adatbázis ID-ja
    String m_toParticipantString;        //Címzettek DB ID set-je SEP: SZÓKÖZ
    String m_toString;      //Címzettek emailjei szöveges mezőként SEP: SZÓKÖZ
    Date m_receivedDate;         //Recieved date
    Date m_sentDate;         //Sent date
    int m_delay = -1;          //Szálban megelőző levélhez képest késleltetés M1.SentDate - M0.RecievedDate
    String m_previousCommId;    //szálban megelőző üzenet m_commId-ja
    int m_previousLinkMode;    //szálban megelőző üzenet m_commId-ja
    String m_threadId;          //szál ID

    /**
     * Konstruktor az adatbázis kapcsolat és az SQL utasítások eltárolásához. Később property-síthető.
     *
     * @param _conn Kapcsolat
     * @param _bufferId
     * @param _rawDataString
     */
    public SimpleMailDatabaseObject(Connection _conn, String _bufferId, String _rawDataString) {
        super(_bufferId, _rawDataString);
        //m_bufferId = _bufferId;
        conn = _conn;

        try {
            ps_u_RAWDATA = conn.prepareStatement("UPDATE CAD_RAWDATA SET STATUS=1, COMM_ID=? WHERE BUFFER_ID=?");
            ps_i_COMM = conn.prepareStatement("INSERT INTO CAD_COMM (COMM_ID, CONTENT, THREAD_ID) VALUES ( ?, ?, ?)");
            ps_i_SUBCOMM = conn.prepareStatement("INSERT INTO CAD_SUBCOMM (SUBCOMM_ID, SUBCATEGORY, FROM_PARTICIPANT, TO_PARTICIPANT, SENT_TIME, RECEIVED_TIME, COMM_ID, PREV_COMM_ID, PREV_DELAY_SEC, PREV_LINKMODE, THREAD_ID, DATE_KEY, TIME_KEY) VALUES ( ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)");
            ps_i_PARTICIPANTADDRESS = conn.prepareStatement("INSERT INTO CAD_PARTICIPANTADDRESS (PARTICIPANT_ID, ADDRESS) VALUES ( ?, ? )");
            ps_i_PARTICIPANT = conn.prepareStatement("INSERT INTO CAD_PARTICIPANT (PARTICIPANT_ID, NAME, STATUS) VALUES ( ?, ?, 0)");
            ps_i_THREAD = conn.prepareStatement("INSERT INTO CAD_THREAD (THREAD_ID, NAME) VALUES ( ?, ?)");
            ps_i_DATE = conn.prepareStatement("INSERT INTO CAD_DATE (DATE_KEY, YEAR, MONTH, DAY, DAY_OF_WEEK) VALUES ( ?, ?, ?, ?, ?)");
            ps_i_TIME = conn.prepareStatement("INSERT INTO CAD_TIME (TIME_KEY, HOUR, MINUTE, SECOND) VALUES ( ?, ?, ?, ?)");

        } catch (Exception e) {
        }

    }

    /**
     * A levél objektum letárolását végzi az adatbázisban az előfeldolgozást követően
     *
     * @return A letárolás sikerességével tér vissza
     */
    public Boolean store() {
        boolean siker = true;
        boolean updateMode = false;

        //########## Megvizsgálni van-e már ez a levél az adatbázisban messageID alapján
        try {
            PreparedStatement ps = conn.prepareStatement("SELECT COUNT(*) FROM CAD_RAWDATA WHERE COMM_ID=?");
            ps.setString(1, m_commId);
            updateMode = (CountRecord(ps) > 0);
            ps.close();

        } catch (Exception e) {
            siker = false;
            D(" ~ERROR: " + e.toString());
        }

        //Ha van, akkor mit tegyünk?
        if (updateMode) {
            //Egyelőre csak kilépünk, de ide lehet írni a frissítő rutin elágazását
            CloseStatements();
            return true;
        }

        //Előzményekhez viszonyítás, szál előző levele
        m_previousCommId = this.getPreviousMessageId();
        m_previousLinkMode = this.getPreviousLinkMode();
        m_threadId = m_commId; //Az új thread azonosító a sajátja alapértelmezésben, ha később nem lenne meg az előzmény szála


        //########## Megvizsgálni van-e már előzmény és ha igen, mikor lett fogadva
        Date _previousReceivedDate = null;
        try {
            PreparedStatement ps = conn.prepareStatement("SELECT SC.RECEIVED_TIME, C.THREAD_ID FROM CAD_SUBCOMM SC, CAD_COMM C WHERE SC.COMM_ID=C.COMM_ID AND C.COMM_ID=?");
            ps.setString(1, m_previousCommId);
            ResultSet rs = ps.executeQuery();
            if (rs.next()) { //van előzmény
                _previousReceivedDate = rs.getDate(1); //, annak fogadási dátuma
                //String _tmpThreadId = rs.getString(2); //csak akkor változtatunk az eredeti ThreadID-n, ha az nem üres
                //if (_tmpThreadId!=null && !_tmpThreadId.trim().equals(""))
                m_threadId = rs.getString(2); //_tmpThreadId;
            }

            m_receivedDate = this.m_mail.getReceivedDate();
            m_sentDate = this.m_mail.getSentDate();

            try {
                rs.close();
                ps.close();
            } catch (Exception e) {
            }

        } catch (Exception e) {
            siker = false;
            D(" ~ERROR: " + e.toString());
        }

        //Előzőhöz képes ksleltetés számítás számítás
        if (_previousReceivedDate != null) {
            m_delay = 2; //egyelőre konstans, de a két idő különbsége kellene ide
        }

        //Dátum számítás
        m_receivedDate = setDateD1D2Now(m_receivedDate, m_sentDate);
        m_sentDate = setDateD1D2Now(m_sentDate, m_receivedDate);

        //Dátum mentése
        try {
            InsertDateTimeRecord(m_sentDate);
        } catch (Exception ex) {
            D(" ~ERROR: DATE-TIME Dimension - " + ex.getMessage());
            siker = false;
        }

        //COMM mentés
        try {
            //("INSERT INTO CAD_COMM (COMM_ID, CONTENT, THREAD_ID) VALUES ( ?, ?, ?)");
            conn.setAutoCommit(false);
            m_threadId = InsertThread(m_threadId);
            String _contentText = this.getAllContent();
            ps_i_COMM.clearParameters();
            ps_i_COMM.setString(1, m_commId);
            ps_i_COMM.setClob(2, convertStringToClob(_contentText), _contentText.length());
            ps_i_COMM.setString(3, m_threadId);
            ps_i_COMM.execute();
            conn.commit();
        } catch (Exception e) { //RAWDATA mentés meghiúsult
            siker = false;
            try {
                conn.rollback();
            } catch (SQLException ex) {
                D(ex.getMessage());
            }
            D(" ~ERROR: " + e.toString());
        }

        //FROM Felhasználó és csoportok lekérdezése
        try {
            m_fromString = this.getFrom();
            m_fromParticipant = InsertParticipantAddress(m_fromString, "");
        } catch (Exception e) {
            siker = false;
            D(" ~ERROR: " + e.toString());
        }

        // TO, CC, BCC lekérdezés
        // SUBCOMM mentés
        try {
            conn.setAutoCommit(false);

            m_toString = "";
            m_toParticipantString = "";
            int subcommCount = 0;
            for (int i = 0; i < m_recipients.length; i++) {
                subcommCount++;
                String _toParticipant = InsertParticipantAddress(m_recipients[i].eAddress, m_recipients[i].eName);

                //ÖSSZEFŰZÉS
                if (m_toParticipantString.indexOf(_toParticipant) == -1) {
                    if (m_toParticipantString.length() > 1) {
                        m_toParticipantString = m_toParticipantString + ", ";
                    }
                    m_toParticipantString = m_toParticipantString + _toParticipant;
                }
                m_toString = m_toParticipantString;

                //SUBCOMM tényadatok mentése
                try {
                    // CAD_SUBCOMM (SUBCOMM_ID, SUBCATEGORY, FROM_PARTICIPANT, TO_PARTICIPANT, SENT_TIME, RECEIVED_TIME, COMM_ID, PREV_COMM_ID, PREV_DELAY_SEC, PREV_LINKMODE)
                    ps_i_SUBCOMM.clearParameters();
                    ps_i_SUBCOMM.setString(1, this.m_bufferId + "-" + subcommCount);
                    ps_i_SUBCOMM.setInt(2, m_recipients[i].eRecipientMode);
                    ps_i_SUBCOMM.setString(3, m_fromParticipant);
                    ps_i_SUBCOMM.setString(4, _toParticipant);
                    ps_i_SUBCOMM.setDate(5, convertDateToSqlDate(m_sentDate));
                    ps_i_SUBCOMM.setDate(6, convertDateToSqlDate(m_receivedDate));
                    ps_i_SUBCOMM.setString(7, m_commId);
                    ps_i_SUBCOMM.setString(8, m_previousCommId);
                    if (m_delay > -1) {
                        ps_i_SUBCOMM.setInt(9, m_delay); //NULL vagy DELAY
                    } else {
                        ps_i_SUBCOMM.setNull(9, 0);
                    }
                    ps_i_SUBCOMM.setInt(10, m_previousLinkMode);
                    ps_i_SUBCOMM.setString(11, m_threadId);
                    ps_i_SUBCOMM.setString(12, getFormatedDateTime(m_sentDate, "yyyyMMdd"));
                    ps_i_SUBCOMM.setString(13, getFormatedDateTime(m_sentDate, "HHmmss"));

                    ps_i_SUBCOMM.execute();

                } catch (SQLException sqlEx) {
                    int code = sqlEx.getErrorCode();
                    if (code != 1) {
                        siker = false;
                    }
                    D(sqlEx.toString());
                } catch (Exception ex) {
                    siker = false;
                    D(" ~ERROR: " + ex.toString());
                }
            }
            conn.commit();
        } catch (Exception e) { //Valami más hiba címzett lekérésnél
            siker = false;
            try {
                conn.rollback();
            } catch (SQLException ex) {
                //Már itt is ciki lehet, de hagyjuk
            }
            D(" ~ERROR: " + e.toString());
        }

        try { //RAWDATA beállítása
            conn.setAutoCommit(false);

            //("UPDATE CAD_RAWDATA SET STATUS=1, COMM_ID=? WHERE BUFFER_ID=?");
            ps_u_RAWDATA.clearParameters();
            ps_u_RAWDATA.setString(1, m_commId);
            ps_u_RAWDATA.setString(2, m_bufferId);
            ps_u_RAWDATA.execute();

            conn.commit();

        } catch (Exception e) { //RAWDATA mentés meghiúsult
            siker = false;
            try {
                conn.rollback();
            } catch (SQLException ex) {
                //Már itt is ciki lehet, de hagyjuk
            }
            D(" ~ERROR: " + e.toString());
        }

        return siker;
    }

    private void D(String _out) {
        if (debugMode) {
            System.out.println(_out);
        }
    }

    /**
     * <p>Emailcímhez Usereket rendelő függvény</p>
     * <p>Amennyiben az e-mail már tárolva van, úgy visszaadja annak a usernek a DB ID-ját,
     * ha pedig még nincs, beszúrja azt a címet ismeretlen userként és annak az ID-ját adja
     * vissza, ami az U0 .</p>
     *
     * @param _address E-mail cím
     * @param _name Név
     * @return visszatér az e-mailhez tartozó user ID-val
     */
    private String InsertParticipantAddress(String _address, String _name) {
        String retVal = "U0-" + _address;
        try {
            PreparedStatement ps = conn.prepareStatement("SELECT PARTICIPANT_ID FROM CAD_PARTICIPANTADDRESS WHERE ADDRESS=?");
            ps.setString(1, _address);

            ResultSet rs = ps.executeQuery();
            if (rs.next()) { //van találat
                retVal = rs.getString(1);
                try {
                    rs.close();
                    ps.close();
                } catch (Exception e) {
                }
            } else { //ha nincs, beszúrandó

                ps_i_PARTICIPANTADDRESS.setString(2, _address);
                ps_i_PARTICIPANTADDRESS.setString(1, retVal);
                ps_i_PARTICIPANTADDRESS.execute();
                //ps_i_PARTICIPANTADDRESS.close();

                ps_i_PARTICIPANT.setString(1, retVal);
                ps_i_PARTICIPANT.setString(2, _name + " (" + _address + ")");
                ps_i_PARTICIPANT.execute();
                //ps_i_PARTICIPANT.close();

            }
        } catch (SQLException sqlE) {
            if (sqlE.getErrorCode() > 1) {
                D(" ~ERROR: SQL - " + sqlE.toString());
                retVal = "U0";
            }
        } catch (Exception e) {
            D(" ~ERROR: " + e.toString());
            retVal = "U0";
        }

        return retVal; //felhasználó ID-ja kell, hogy visszatérjen
    }

    /**
     * <p>Emailcímhez Usereket rendelő függvény</p>
     * <p>Amennyiben az e-mail már tárolva van, úgy visszaadja annak a usernek a DB ID-ját,
     * ha pedig még nincs, beszúrja azt a címet ismeretlen userként és annak az ID-ját adja
     * vissza, ami az U0 .</p>
     *
     * @param _address E-mail cím
     * @param _name Név
     * @return visszatér az e-mailhez tartozó user ID-val
     */
    private String InsertThread(String _threadId) {
        String retVal = _threadId; //amit kapunk
        if (retVal.isEmpty()) {
            retVal = m_commId; //CommID - Message ID
        }
        if (retVal.isEmpty()) {
            retVal = m_bufferId; //Csak buffer maradt
        }
        try {
            PreparedStatement ps = conn.prepareStatement("SELECT THREAD_ID FROM CAD_THREAD WHERE THREAD_ID=?");
            ps.setString(1, retVal);

            ResultSet rs = ps.executeQuery();
            if (rs.next()) { //van már ilyen
                try {
                    rs.close();
                    ps.close();
                } catch (Exception e) {
                }
                return retVal;
            } else { //ha nincs, beszúrandó
                ps_i_THREAD.setString(1, retVal);
                ps_i_THREAD.setString(2, "Auto generated by " + retVal);
                ps_i_THREAD.execute();

                return retVal;
            }
        } catch (Exception e) {
            D(" ~ERROR: " + e.toString());
        }
        return retVal;
    }

    /**
     * <p>Dátum és Idő dimenziók beszúrása, ha még nincs olyan</p>
     *
     * @param dt Dimenzió táblába szúrandó dátum
     * @return BOOL visszatér a sikerességgel
     */
    private String getFormatedDateTime(Date dt, String f) {
        SimpleDateFormat sdf = new SimpleDateFormat(f);
        return sdf.format(dt);
    }

    private boolean InsertDateTimeRecord(Date dt) {
        boolean retVal = true;

        String dkey = getFormatedDateTime(dt, "yyyyMMdd");
        String tkey = getFormatedDateTime(dt, "HHmmss");

        Calendar cDateTime = Calendar.getInstance();
        cDateTime.setTime(dt);

        //van-e ilyen dátum? Ha nincs beszúrás
        try {
            PreparedStatement psd = conn.prepareStatement("SELECT DATE_KEY FROM CAD_DATE WHERE DATE_KEY=?");
            psd.setString(1, dkey);
            if (CountRecord(psd) < 1) {
                ps_i_DATE.setString(1, dkey);
                ps_i_DATE.setLong(2, cDateTime.get(Calendar.YEAR));
                ps_i_DATE.setString(3, getFormatedDateTime(dt, "MM")); //setLong(3, cDateTime.get(Calendar.MONTH));
                ps_i_DATE.setLong(4, cDateTime.get(Calendar.DAY_OF_MONTH));
                ps_i_DATE.setLong(5, cDateTime.get(Calendar.DAY_OF_WEEK));
                ps_i_DATE.execute();
            }
        } catch (Exception e) {
            D(" ~ERROR: " + e.toString());
            retVal = false;
        }

        //van-e ilyen időpont? Ha nincs beszúrás
        try {
            PreparedStatement pst = conn.prepareStatement("SELECT TIME_KEY FROM CAD_TIME WHERE TIME_KEY=?");
            pst.setString(1, tkey);
            if (CountRecord(pst) < 1) {
                ps_i_TIME.setString(1, tkey);
                ps_i_TIME.setString(2, getFormatedDateTime(dt, "HH")); //setLong(2, cDateTime.get(Calendar.HOUR));
                ps_i_TIME.setLong(3, cDateTime.get(Calendar.MINUTE));
                ps_i_TIME.setLong(4, cDateTime.get(Calendar.SECOND));
                ps_i_TIME.execute();
            }
        } catch (Exception e) {
            D(" ~ERROR: " + e.toString());
            retVal = false;
        }

        return retVal;
    }

    /**
     * Counter Selectek darabszámát adja vissza, feltéve, ha az első paraméter tartalmazza a
     * darabszámot. Csak egyszerűsítéshez.
     *
     * @param _select Előkészített SQL SELECT COUNT()
     * @return darabszám
     */
    private int CountRecord(PreparedStatement _select) {
        int retVal = -1; //error
        try {
            ResultSet rs = _select.executeQuery();
            rs.next();
            //D(rs.getString(1));
            retVal = rs.getInt(1);
            try {
                rs.close();
                _select.close();
            } catch (Exception e) {
            }

        } catch (Exception e) {
        }

        return retVal;
    }

    /**
     * Beszúrást vagy updatet végző függvény
     *
     * @param _select
     * @param _insert
     * @param _update
     * @return
     */
    private String InsertOrUpdate(PreparedStatement _select, PreparedStatement _insert, PreparedStatement _update) {
        String retVal = null;
        try {
            if (CountRecord(_select) > 0) { //van(nak) mar ilyen rekord(ok)
                _update.execute();

            } else { //Még nincsenek
                _insert.execute();
            }


        } catch (Exception e) {
        }
        return retVal;
    }

    /**
     * Java Date értéket konvertál SQL date-re. csak egyszerűsítésre
     * @param _d Dátum
     * @return SQL Date dátum
     */
    public java.sql.Date convertDateToSqlDate(Date _d) {
        if (_d != null) {
            return new java.sql.Date(_d.getTime());
        } else {
            return null;
        }
    }

    /**
     * Null-t nem tartalmazható dátumok kitöltésére használt függvény. d1, d2 vagy Now() közül az egyiket
     * betölti a visszaadandó Date-be.
     *
     * @param d1 Első dátum
     * @param d2 Második dátum
     * @return d1 vagy d2 vagy Now()
     */
    public Date setDateD1D2Now(Date d1, Date d2) {
        Date retVal = d1;
        if (d1 == null) {
            retVal = d2;
        } else if (d2 == null) {
            retVal = new Date();
        }
        return retVal;
    }

    /**
     * String-ből CLOB-ba konvertál
     *
     * @param _s Bemeneti szöveg
     * @return Kimeneti CLOB
     */
    public StringReader convertStringToClob(String _s) {
        return new StringReader(_s);
    }

    /**
     * Ez a függvény állítja a bufferbeli RAW példányt feldolgozott állapotúra
     */
    public void CloseStatements() {
        try {
            //ps_u_RAWDATA.setString(1, m_bufferId);
            //ps_u_RAWDATA.execute();
            //conn.commit();

            ps_i_COMM.close();
            ps_i_SUBCOMM.close();
            ps_i_PARTICIPANT.close();
            ps_i_PARTICIPANTADDRESS.close();
            ps_u_RAWDATA.close();
            ps_i_THREAD.close();

        } catch (Exception e) {
            D(" ~ERROR: " + e.toString());
        }
    }
}
