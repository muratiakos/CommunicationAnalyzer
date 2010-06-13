package caEmailBufferer;

import java.util.*;
import java.util.Calendar;
import java.io.*;

/**
 * caEmailBufferer futtató osztálya, amely egy mabbában található e-mail fájlokat betölt a rendszer puffertáblájába
 * 
 * @author Muráti Ákos
 */
public class main {
    //beszédes mód
    static boolean verbose = false;

    /**
     * <p>A caEmailBufferer indító függvénye, ami példányosítja a pufferelést végző
     * osztályt a parancssori paraméterek és a beolvasott property-fájl alapján.</p>
     *
     * <h2>Parancssori paraméterek</h2>
     * <ul>
     *  <li>-property [fájlnév] : megadott fájlnevű property fájl beolvasása és alkalmazása</li>
     *  <li>-mail_folder [mappa]: a megadott mappában található fájlok beolvasása</li>
     *  <li>-delete_buffered: Sikeresen pufferelt emailek törlése</li>
     *  <li>-verbose: Beszédes mód, futás közbeni statisztikai és egyéb vezérlési infók kiírása</li>
     * </ul>
     * <p>A parancssorban megadott beállítások felülbírálják a property fájlokat és az alapértelmezett
     * beállításokat</p>
     *
     * <h2>Alapértelmezett property</h2>
     * <pre>
     * db_driver=oracle.jdbc.driver.OracleDriver
     * db_url=jdbc:oracle:thin:@localhost:1521:XE
     * db_user=EMA_ADMIN
     * db_pass=ema_admin
     * mail_insert=INSERT INTO CAD_RAWDATA (BUFFER_ID, DATA, STATUS) VALUES ( ?, ?, 0)
     * mail_folder=../Mails/
     * delete_buffered=0
     * verbose=0
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

        //Property osztály és egyéb futásidejű osztály példányosítása
        Properties pf = new Properties(pd);
        Calendar cal = Calendar.getInstance();
        String mail_folder = null;
        String property_file = null;
        boolean deleteBufferedFile = false;

        //Argumentumok feldolgozása parancssorból
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

        //E-mail mappa felüldefiniálása
        if (mail_folder != null && mail_folder.isEmpty() == false) //ha ki lett toltve parancssorbol
        {
            pf.setProperty("mail_folder", mail_folder); //fajlbeli propertyt felülvágja
            VP("-PROPERTY: Mail folder has set from command-line: " + mail_folder);
        }

        //Törlési mód felüldefiniálása
        if (pf.getProperty("delete_buffered", "1").equals("1")) //ha ki lett toltve konfigfájlból
        {
            deleteBufferedFile = true; //fajlbeli propertyt felülvágja
            VP("-PROPERTY: delete_buffered is ON");
        }

        VP("");
        //Statisztikához aktuális időpillanat lekérdezése
        cal = Calendar.getInstance();
        long tStart = cal.getTimeInMillis();

        //A Fájl Importer példányosítása, ami a mappa végigolvasásáért felelős
        EmailFileImporter efi = new EmailFileImporter(pf);
        int rV = efi.Import(deleteBufferedFile);

        //Befejezés időpillanatának lekérdezése és delt a számítása
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
     * Feltételes kiíratás eljárása, ha beszédes módban vagyunk, kiírja az átadott szöveget.
     * @param _out Kiírandó szöveg
     */
    public static void VP(String _out) {
        if (verbose) {
            P(_out);
        }
    }
}
