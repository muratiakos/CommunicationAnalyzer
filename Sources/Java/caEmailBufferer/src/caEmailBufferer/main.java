package caEmailBufferer;

import java.util.*;
import java.util.Calendar;
import java.io.*;

/**
 * E-mail Bufferer futtató osztálya
 * 
 * @author makos
 */
public class main {

    static boolean verbose = false;

    /**
     * <p>Az EmailFileImporter indító függvénye, ez példányosítja a pufferelést végző
     * osztályt a parancssori paraméterek és a beolvasott property-fájl alapján.</p>
     *
     * <h2>Parancssori paraméterek</h2>
     * <ul>
     *  <li>-property [fájlnév] : megadott fájlnevű property fájl beolvasása és alkalmazása</li>
     *  <li>-folder [mappa]: a megadott mappában található fájlok beolvasása</li>
     * </ul>
     * <p>A parancssorban megadott beállítások a legerősebbek, vagyis felülbírálják a property fájlok és az alapértelmezett
     * beállításokat</p>
     *
     * <h2>Alapértelmezett property</h2>
     * <pre>
     * db_driver=oracle.jdbc.driver.OracleDriver
     * db_url=jdbc\:oracle\:thin\:@grid9.tmit.bme.hu\:1521\:student
     * db_user=mailer
     * db_pass=haho
     * mail_insert=INSERT INTO MAIL_BUFFER (BUFFERID, MAIL, PROCESSED) VALUES ( ?, ?, 0)
     * mail_folder=../mail_folder/
     * </pre>
     *
     * 
     * @param aArgs
     * @throws java.io.FileNotFoundException
     * @throws java.lang.ClassNotFoundException
     *
     *
     */
    public static void main(String... aArgs) throws ClassNotFoundException {

        //Alapértelmezett beálltások
        Properties pd = new Properties();
        pd.setProperty("db_driver", "oracle.jdbc.driver.OracleDriver");
        pd.setProperty("db_url", "jdbc:oracle:thin:@localhost:1521:XE");
        pd.setProperty("db_user", "EMA_ADMIN");
        pd.setProperty("db_pass", "ema_admin");
        pd.setProperty("mail_insert", "INSERT INTO CAD_RAWDATA (BUFFER_ID, DATA, STATUS) VALUES ( ?, ?, 0)");
        pd.setProperty("mail_folder", "../_Mails/"); //-mail_folder "D:\BME\Önálló labor\8. félév\_JavaSource\email"
        pd.setProperty("delete_buffered", "0"); //-mail_folder "D:\BME\Önálló labor\8. félév\_JavaSource\email"
        pd.setProperty("verbose", "0"); //-mail_folder "D:\BME\Önálló labor\8. félév\_JavaSource\email"

        Properties pf = new Properties(pd);

        Calendar cal = Calendar.getInstance();
        String mail_folder = null;
        String property_file = null;
        boolean deleteBufferedFile = false;

        //Argumentumok feldolgozasa
        int i = 0;
        for (i = 0; i < aArgs.length; i++) {
            if (aArgs[i].equals("-mail_folder")) {
                mail_folder = aArgs[++i];
            } else if (aArgs[i].equals("-property")) {
                property_file = aArgs[++i];
            } else if (aArgs[i].equals("-verbose")) {
                verbose = true;
            } else if (aArgs[i].equals("-delete_buffered")) {
                deleteBufferedFile = true;
            }
        }

        VP("BUFFERING START: " + cal.getTime().toString());

        //Propertyk beolvasása fájlból
        try {
            if (!(property_file == null || property_file.isEmpty())) {
                VP("-PROPERTY FILE:" + property_file);
                pf.load(new FileInputStream(property_file));
                //VP(pf.toString());
            }
        } catch (Exception e) {
            P("~ERROR: Error reading property file: " + property_file);
            System.exit(-1);
        }

        //Property-k beálítása
        //Verbose felüldefiniálása
        if (verbose || pf.getProperty("verbose", "1").equals("1")) //ha ki lett toltve a beszedes mod
        {
            verbose = true; //fajlbeli propertyt felülvágja
            VP("-PROPERTY: Verbose MODE is ON");
        }

        if (mail_folder != null && mail_folder.isEmpty() == false) //ha ki lett toltve parancssorbol
        {
            pf.setProperty("mail_folder", mail_folder); //fajlbeli propertyt felülvágja
            VP("-PROPERTY: Mail folder has set from command-line: " + mail_folder);
        }

        //Delete felüldefiniálása
        if (pf.getProperty("delete_buffered", "1").equals("1")) //ha ki lett toltve konfigfájlból
        {
            deleteBufferedFile = true; //fajlbeli propertyt felülvágja
            VP("-PROPERTY: delete_buffered is ON");
        }

        VP("");
        //Feldolgozás méréséhez
        cal = Calendar.getInstance();
        long tStart = cal.getTimeInMillis();

        //Importer példányosítása és futtatása
        EmailFileImporter efi = new EmailFileImporter(pf);
        int rV = efi.Import(deleteBufferedFile);

        cal = Calendar.getInstance();
        long tStop = cal.getTimeInMillis();
        tStop -= tStart;

        VP("BUFFERING STOP: " + cal.getTime().toString() + " ( total processing: " + tStop + " ms)");
        System.exit(rV);
    }

    /**
     * Kiíratást végző függvény, rövidebb, mint a System.out.pr :)
     * @param _out
     */
    public static void P(String _out) {
        System.out.println(_out);
    }

    /**
     * Feltételes kiíratás, ha beszédes módban vagyunk
     * @param _out Kiírandó szöveg
     */
    public static void VP(String _out) {
        if (verbose) {
            P(_out);
        }
    }
}
