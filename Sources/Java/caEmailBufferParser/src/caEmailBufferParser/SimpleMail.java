package caEmailBufferParser;

import java.io.ByteArrayInputStream;
import java.util.Properties;
import javax.mail.Address;
import javax.mail.BodyPart;
import javax.mail.Message.RecipientType;
import javax.mail.Multipart;
import javax.mail.Session;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;
import javax.mail.util.*;

/**
 * <p>A javax.mail szolgáltatásai fölé épített egyszerűsített E-mail osztály</p>
 * @author Muráti Ákos
 */
public class SimpleMail {
    //Változók
    public String m_bufferId;   //buffer ID
    public String m_commId; //messageId
    public SimpleAddress m_from; //Kitől
    public SimpleAddress[] m_recipients; //Kiknek
    public MimeMessage m_mail;     //Valódi MIME üzenet osztály a javax.mail-ből

    public SimpleMail() {
        m_mail = null;
        m_bufferId = null;
    }

    /**
     * String-ből példányosítandó levél konstruktora, ami végül a bytetömbként hív tovább
     * @param _bufferId
     * @param strSource
     */
    public SimpleMail(String _bufferId, String strSource) {
        this(_bufferId, strSource.getBytes());
    }

    /**
     * Bytetömbből példányosítandó e-mail konstruktora
     *
     * @param _bufferId
     * @param rawDataBytes
     */
    public SimpleMail(String _bufferId, byte[] rawDataBytes) {
        m_bufferId = _bufferId;

        ByteArrayInputStream bais = new ByteArrayInputStream(rawDataBytes);

        Properties props = new Properties();
        props.put("mail.debug", "false"); //debug

        //Ténylegese javax.mail MimeMessage példányosítása
        try {
            Session s = Session.getDefaultInstance(props);
            m_mail = new MimeMessage(s, bais);

            //Levél szereplőinek betöltése
            LoadAddresses();
            m_commId = m_mail.getMessageID();
        } catch (Exception e) {
        }
    }

    /**
     * Annak meghatározására szolgál, hogy Content-Type mező tartalmazza-e a megadott Type stringet.
     *( SZintén csak egyszerűsítés miatt, dekóderekhez.)
     * @param strCT
     * @param Type
     * @return
     */
    private boolean io(String strCT, String Type) {
        if (strCT.toLowerCase().indexOf(Type, 0) > -1) {
            return true;
        } else {
            return false;
        }
    }

    /**
     * <p>Egy levél teljes szöveges tartalmát visszaadó függvény, beleértve a levél címét, tartalmát és szöveges csatolmányait is
     * konkatenálva. A levél tartalmának feltérképezését a BodyContent rekurzív függvénnyel járja be.</p>
     */
    public String getAllContent() {
        String tmpC = null;
        try {
            tmpC = m_mail.getSubject() + "\n";
            tmpC += getBodyContent(m_mail.getContentType(), m_mail.getContent());
        } catch (Exception e) {
        }
        return tmpC.toLowerCase(); //MInden kisbetűsre a könnyebb kereshetőségért
    }

    /**
     * <p>Egy levél BodyContentjét bejárva komplett tartalmát visszaadó függvény, beleértve a levél tartalmát és szöveges csatolmányait is
     * konkatenálva.</p>
     *
     * <p>
     * A levélen javax.mail MIMEMessage Content szolgáltatásai fölé írt eljárás, ami rekurzívan bejárja a Content fát, és annak
     * objektumainak szöveges részeit becsatolja a tartalomba.
     * <br />
     * Ezt a függvényt kell bővíteni, ha más content-eket is szeretnénk tudni értelmezni, például pdf vagy doc szövegeinek, vagy mondjuk
     * zip fájlok kitömörítését, fájllista kiírását,  stb  befűzését is itt kell megoldani, a content type-ok feldolgozásával.
     * </p>
     */
    public String getBodyContent(String CT, Object C) {
        String retVal = "";
        CT = CT.toLowerCase();

        try {
            //Multipart email - többféle típusú tartalom
            if (io(CT, "multipart/mixed") || io(CT, "multipart/related")) {
                Multipart M = (Multipart) C;
                for (int i = 0; i < M.getCount(); i++) {
                    BodyPart P = M.getBodyPart(i);
                    retVal += getBodyContent(P.getContentType(), P.getContent());
                }
            } //Alternate szövegekből - csak az elsőt használjuk
            else if (io(CT, "multipart/alternative")) {
                Multipart M = (Multipart) C;
                BodyPart P = M.getBodyPart(0);
                retVal = getBodyContent(P.getContentType(), P.getContent());
            } //Sima szöveges tartalom
            else if (io(CT, "text/")) {
                retVal = C.toString(); //.getContent().toString();
            } //Képek feldolgáza
            else if (io(CT, "image/")) {
                retVal = "### Image ### - " + CT;
            } //Byte-tömb tartalom
            else if (io(CT, "octet-stream")) {
                SharedByteArrayInputStream bais = (SharedByteArrayInputStream) C; //P.getContent();
                int a = -1;
                int i = 0;
                String s = "";

                a = bais.read();
                while (a != -1) {
                    s += (char) a;
                    a = bais.read();
                    i++;
                }
                retVal = s;
            } //Ami kimaradt -- implementálandó
            else {
                retVal = "### IMPLEMENTALANDO DEKODER ###\n" + CT + "\n" + C.toString() + "\n ### ---------------------- ###\n";
            }
        } catch (Exception e) {
        }

        return retVal + "\n"; // + "----- EOP -----\n";
    }

    /**
     * From mező kiszedésére - csak csomagolás, egyszerűsítés
     * @return
     */
    public String getFrom() {
        /*InternetAddress a = null;
        try {
        Address[] al = m_mail.getFrom();
        a = new InternetAddress(al[0].toString());
        } catch (Exception e) { }
         */
        return m_from.toString(); // a.getAddress();
    }

    /**
     * Összes szereplő (TO, CC, BCC) e-mailjének betöltése a SimpleMail címzett tömjébe
     */
    public void LoadAddresses() {
        InternetAddress a = null;
        Address[] alf = null;
        Address[] al_to = null;
        Address[] al_cc = null;
        Address[] al_bcc = null;

        //From mezo
        try {
            alf = m_mail.getFrom();
            a = new InternetAddress(alf[0].toString());
            m_from = new SimpleAddress(a, -1);
        } catch (Exception e) {
        }


        //Minden egyeb cimzett mezo
        try {
            al_to = m_mail.getRecipients(RecipientType.TO);
            int al_to_c = 0;
            al_cc = m_mail.getRecipients(RecipientType.CC);
            int al_cc_c = 0;
            al_bcc = m_mail.getRecipients(RecipientType.BCC);
            int al_bcc_c = 0;

            try {
                al_to_c = al_to.length;
            } catch (Exception ex) {
            }
            try {
                al_cc_c = al_cc.length;
            } catch (Exception ex) {
            }
            try {
                al_bcc_c = al_bcc.length;
            } catch (Exception ex) {
            }

           //Listák összefűzése egy tömbbe
            m_recipients = new SimpleAddress[al_to_c + al_cc_c + al_bcc_c];
            int db = 0;

            for (int i = 0; i < al_to_c; i++) {
                db++;
                a = new InternetAddress(al_to[i].toString());
                m_recipients[i] = new SimpleAddress(a, 0); //TO
            }

            for (int i = 0; i < al_cc_c; i++) {
                db++;
                a = new InternetAddress(al_cc[i + db].toString());
                m_recipients[i + db] = new SimpleAddress(a, 1); //CC
            }

            for (int i = 0; i < al_bcc_c; i++) {
                db++;
                a = new InternetAddress(al_bcc[i + db].toString());
                m_recipients[i + db] = new SimpleAddress(a, 2); //BCC
            }

        } catch (Exception e) {
            int i = 0;
        }

    }

    /**
     * A szalban az aktuális üzenet megelőző e-mail (amire válasz vagy továbbított) messageID-ját visszadó függvény
     * @return előző üzenet m_commId-ja
     */
    public String getPreviousMessageId() {
        String retVal = null;
        try {
            String[] _mIds;
            _mIds = m_mail.getHeader("In-reply-to");
            if (_mIds == null) {
                _mIds = m_mail.getHeader("References");
            }
            if (_mIds != null) {
                retVal = _mIds[0]; //csak az elsőt vesszük figyelembe
            }
            //Ha valamiért több lenne egy mezőben, megpróbáljuk tovább bontani
            if (retVal != null) {
                String[] _mIds2 = retVal.split(">");
                if (_mIds2.length > 0) {
                    retVal = _mIds2[0] + ">";
                }
            }

        } catch (Exception e) {
        }
        return retVal;
    }

    /**
     * Azt adja vissza, hogy a szalban levo elozo üzenetre válaszoltunk (1) vagy csak hivatkozunk rá (0)
     * @return 0-Referenced, 1= Reply
     */
    public int getPreviousLinkMode() {
        int retVal = 0;
        try {
            String[] h = null;
            h = m_mail.getHeader("In-reply-to");
            if (h != null) {
                retVal = 1;
            }
        } catch (Exception e) {
        }
        return retVal;
    }
}
