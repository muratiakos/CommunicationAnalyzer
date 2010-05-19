package caEmailBufferer;

import java.util.*;
import java.io.*;
import java.sql.*;
import java.sql.PreparedStatement;

/**
 * <h2>EmailFileImporter osztály</h2>
 * <p>Ez az osztály végzi a megadott mappában található e-mail fájlok beolvasását és
 * beszúrását az átmeneti MAIL_BUFFER adatbázis táblába.</p>
 *
 * <p>Az main osztálytól kapott beállítások alapján a megadott mappábából
 * az mbox típusú email fájlok tartalmát beolvasás után az alapértelmezett vagy megadott beállításoknak
 * megfelelően beszúrja a MAIL_BUFFER táblába, amennyiben az még nem szerepel benne.
 * Beszúráskor az elsődleges kulcs a teljes fájl tartalma alapján számítódik ki md5 hash algoritmus alapján,
 * mellyel ?elkerülhető? a levelek többszörös feldolgozása is.
 * </p>
 *
 * <h2>Kérdések</h2>
 * <ul>
 * <li>Mi legyen a már feldolgozott fájlokkal? - <br /> Töröljük őket, átnevezzük?</li>
 * <li>Autocommit maradjon?</li>
 * </ul>
 * <h2>Felvetés</h2>
 * <ul>
 * <li>A fájlok tartalmának beolvasásának sebességét esetlegesen még lehet javítani, ha a reader objektumok
 * alapból CLOB-ba teszik a beolvasott értékeket. Érdemes szétnézni, mi lehet még gyorsabb</li>
 * <li>Érdemes lenne-e eleve az Oracle Datapump fájlstrukturájába felépíteni az inserteket?</li>
 * <li>Valamiféle service-ekkel vezérelhetővé kellene tenni - EJB - köv félévre felvéve szakmaiként</li>
 * </ul>
 *
 *  <h2>Puffer tábla</h2>
 * <pre>
 *  CREATE TABLE "MAIL_BUFFER"
 *  (
 *      "BUFFERID" VARCHAR2(500 BYTE) NOT NULL ENABLE,
 *      "MAIL" CLOB,
 *      "PROCESSED" NUMBER(1,0),
 *      CONSTRAINT "MAIL_BUFFER_PK" PRIMARY KEY ("BUFFERID")
 *  );
 * </pre>
 */
public class EmailFileImporter {

    Properties p = null;

    public EmailFileImporter(Properties _p) {
        p = _p;
    }

    /**
     * A beállításokban megadott mappában találhatő összes fájlt listába gyűjti, majd
     * ezen a listán egyenként végighaladva beolvassa annak tartalmát, amit beszúr a csatlakozási paraméterekben
     * megadott adatbázisban lévő MAIL_BUFFER táblába a tartalomból generált md5 hash alapján.
     * A beszúrt rekordok feldolgozásra váró státusszal kerülnek felvételre.
     * </p>
     *
     * <p>A beszúráskor nincs külön ellenőrzés, ha az md5 kulcs nem egyedi, az adatbázis megkötése miatt
     * az a rekord alapból el lesz dobva.</p>
     *
     *
     */
    public int Import(boolean deletePuffered) {
        int rV = 1;
        List<File> files = null;
        Connection conn = null;
        PreparedStatement ps = null;

        //adatbázis csatlakozás

        try {
            Class.forName(p.getProperty("db_driver"));
            String url = p.getProperty("db_url");
            String user = p.getProperty("db_user");
            String pass = p.getProperty("db_pass");


            conn = DriverManager.getConnection(url, user, pass);
            conn.setAutoCommit(true);

            ps = conn.prepareStatement(p.getProperty("mail_insert", "INSERT INTO CAD_RAWDATA (BUFFER_ID, DATA, STATUS) VALUES ( ?, ?, 0)"));

        } catch (Exception e) {
            //bármi adatbázis vagy hiba esetén kilépünk
            if (V()) {
                P("~ERROR: Database Connect Failed");
                e.printStackTrace();
            }
            rV = -1;
            return rV;
        }

        //Fájlista felépítése
        try {
            File startingDirectory = new File(p.getProperty("mail_folder"));
            files = FileListing.getFileListing(startingDirectory);
        } catch (Exception e) {
            //bármi fajllista hiba eseten kilepunk
            if (V()) {
                P("~ERROR: Invalid folder. Could not create filelist");
                e.printStackTrace();
            }
            rV = -2;
            return rV;
        }


        //Fájlonként beszúrás, ha még nincs feldolgozva
        for (File file : files) {
            VP("@BUFFERING: " + file);
            String rawData = null;
            String bufferId = null;
            boolean success = true;

            //fájl tartalmának beolvasása
            try {
                rawData = ReadFile(file);
                //string hash vagy md5?
                //guid = Integer.toString(mailStr.hashCode()); //new RandomGUID().toString();
                bufferId = SimpleMD5.MD5(rawData);
                VP(" -HASH:" + bufferId);
            } catch (Exception e) {
                VP(" ~ERROR: Reading file - " + e.toString());
                success = false;
            }

            //Beszúrás a bufferbe
            if (success) {
                try {

                    ps.setString(1, bufferId);
                    //Mail string to Clob
                    StringReader clobData = new StringReader(rawData);
                    ps.setCharacterStream(2, clobData, rawData.length());
                    ps.executeUpdate();
                } catch (SQLIntegrityConstraintViolationException e) {
                    if (e.getErrorCode() == 1) {
                        VP(" ~MAIL ALREADY EXIST in Database");
                    } else {
                        P(" ~ERROR: SQL - " + e.toString());
                        rV = -9;
                        success = false;
                    }
                } catch (Exception e) { //SQLException
                    P(" ~ERROR: SQL - " + e.toString());
                    rV = -9;
                    success = false;
                }
            }

            //Ha eddig minden sikeres, akkor torlunk
            if (success && deletePuffered) {
                DeleteFile(file);
            }
        }
        return rV;
    }

    /**
     * <p>Ez a függvény olvassa be a paraméterként átadott mbox formátumú email fájl
     * tartalmát, melyet Stringként ad vissza.
     * </p>
     *
     *
     * @param aFile A beolvasandó fájl
     * @return a beolvasott fájl tartalmával tér vissza
     */
    public String ReadFile(File aFile) {
        StringBuilder contents = new StringBuilder();

        try {
            BufferedReader input = new BufferedReader(new FileReader(aFile));
            try {
                String line = null;
                while ((line = input.readLine()) != null) {
                    contents.append(line);
                    contents.append(System.getProperty("line.separator"));
                }
            } finally {
                input.close();
            }
        } catch (Exception e) {
            if (V()) {
                P(" ~~ERROR: Reading file content");
                e.printStackTrace();
            }
        }

        return contents.toString();
    }

    /**
     * <p>Ez a függvény törli a paraméterként megkapott fájl objektumot, amennyiben az nem egy mappa.
     * </p>
     *
     *
     * @param aFile A törlenő fájl
     * @return Törlés sikeressége
     */
    public boolean DeleteFile(File aFile) {
        boolean retVal = true;

        if (!aFile.exists()) {
            VP(" ~~DELETE: File doesn't exist");
            retVal = false;
        }
        if (!aFile.canWrite()) {
            VP(" ~~DELETE: Not enough userright");
            retVal = false;
        }
        if (aFile.isDirectory()) { //Mappa
            VP(" ~~DELETE: Skipping Folder deletion");
            retVal = false;
        }

        //Ha eddig minden okes, akkor torlunk
        if (retVal) {
            retVal = aFile.delete();
        }
        if (!retVal) {
            P(" ~~DELETE: Deletion aborted");
        } else {
            VP(" ~~File deleted successfully");
        }

        return retVal;
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
     * Beszédes módot kérdezi le a main osztályból, ez is csak rövidítés miatt
     * @return main.verbose
     */
    public boolean V() {
        return main.verbose;
    }
}
