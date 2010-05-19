package caEmailBufferParser;

import java.io.*;
import java.sql.*;
import java.io.Reader;
import java.util.Properties;

/**
 * <h2>Email Parser osztály</h2>
 * <p>Ez az osztály felel a puffer  táblában lévő, még feldolgozatlan levelek parsolásáért, felbontásáért, a
 * feladók, címzettek és csoportok adatbázisisból történő beazonosításáért, valamint a levelek tartalmának és
 * szöveges csatolmányainak összesítéséért. </p>
 *
 * <p>Az komplett alkalmazás és osztályai a javax.mail Java Library szolgáltatásaira támaszkodik, ami az mbox és más struktúrában tárolt
 * leveleket képes példányosítani, de akár lekérdezni is postafiókokból és még sok egyéb mást is, érdemes bogarászni:
 * <a href="http://java.sun.com/products/javamail/" target="_blank">http://java.sun.com/products/javamail/</a>
 * </p>
 *
 * @author Muráti Ákos
 */
public class ParseMailBuffer {

    Properties p;

    public ParseMailBuffer(Properties _p) {
        p = _p;
    }

    /**
     * A bufferben lévő még feldolgozatlan levelekett kérdezi le a main-től kapott
     * beállítások alapján és a SimpleMailDatabaseObject példányosításával megkísérli azok feldolgozását
     * majd letárolását
     */
    public int Process() {
        int rV = 1;

        Connection conn = null;
        PreparedStatement ps = null;

        //adatbázis csatlakozás
        try {
            Class.forName(p.getProperty("db_driver"));
            String url = p.getProperty("db_url");
            String user = p.getProperty("db_user");
            String pass = p.getProperty("db_pass");


            conn = DriverManager.getConnection(url, user, pass);

            Statement s = conn.createStatement();
            ResultSet rs = s.executeQuery(p.getProperty("mail_select", "SELECT * FROM CAD_RAWDATA WHERE STATUS=0 AND CATEGORY=0"));

            //Lekérdezett rekordok feldolgozasa
            while (rs.next()) {
                //Bufferbol beolvasas
                String bufferId = rs.getString("BUFFER_ID");
                Clob rawData = rs.getClob("DATA");
                VP("@PARSING: " + bufferId);
                Reader reader = rawData.getCharacterStream();
                CharArrayWriter writer = new CharArrayWriter();
                int i = -1;
                while ((i = reader.read()) != -1) {
                    writer.write(i);
                }
                String rawDataString = writer.toString(); //.toCharArray().toString();

                SimpleMailDatabaseObject m = new SimpleMailDatabaseObject(conn, bufferId, rawDataString);
                m.debugMode = V();
                boolean success = m.store();
                //Ha minden okés, updatelni a buffert
                if (success) {
                    conn.commit();
                }
                m.CloseStatements();

            }
            try {
                rs.close();
                conn.close();
            } catch (Exception e) {
            }


        } catch (Exception e) {
            //bármi adatbázis vagy hiba esetén kilépünk
            if (V()) {
                P("~ERROR: Database Connect Failed");
                e.printStackTrace();
            }
            rV = -1;
            return rV;
        }
        return rV;
    }

    /**
     * Kiiratásaiért felelős függvény System.out.println(...) helyett. Csak kényelmi szempontól
     * @param _out Kiírandó string
     */
    public void P(String _out) {
        main.P(_out);
    }

    /**
     * Beszédes módban kiiratásaiért felelős függvény System.out.println(...) helyett. Csak kényelmi szempontól
     * @param _out Kiírandó string
     */
    public void VP(String _out) {
        main.VP(_out);
    }

    /**
     * Beszédes módot kérdezi le a main osztályból
     * @return main.verbose
     */
    public boolean V() {
        return main.verbose;
    }
}
