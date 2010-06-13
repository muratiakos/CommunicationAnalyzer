package caEmailBufferParser;

import java.util.*;
import java.io.*;

/**
 * Puffer táblában várakozó e-mailek foldolgozásáért felelős projekt
 * @author Muráti Ákos
 */
public class main {

    static boolean verbose = false;

    /**
     * <p>Az caEmailBufferParser indító függvénye, ez példányosítja ParseMailBuffer
     * osztályt a parancssori paraméterek és beolvasott beállítások alapján.</p>
     *
     * <h2>Parancssori paraméterek</h2>
     * <ul>
     *  <li>-property [fájlnév] : megadott fájlnevű property fájl beolvasása és alkalmazása</li>
     *  <li>-verbose: beszédes mód statisztikai és vezérlési információk kiíratásához</li>
     * </ul>
     * <p>A parancssorban megadott beállítások felülbírálják a property fájlok és az alapértelmezett
     * beállításokat</p>
     *
     * <pre>
     *
     * </pre>
     * @param aArgs
     * @throws java.lang.ClassNotFoundException
     *
     */
    public static void main(String... aArgs) throws ClassNotFoundException {

        //Alapértelmezett beálltások
        Properties pd = new Properties();

        pd.setProperty("db_driver", "oracle.jdbc.driver.OracleDriver");
        pd.setProperty("db_url", "jdbc:oracle:thin:@localhost:1521:XE");
        pd.setProperty("db_user", "EMA_ADMIN");
        pd.setProperty("db_pass", "ema_admin");
        pd.setProperty("mail_select", "SELECT * FROM CAD_RAWDATA WHERE STATUS=0 AND CATEGORY=0");

        //Kezdeti időpillanat lekérdezése
        Calendar cal = Calendar.getInstance();
        Properties pf = new Properties(pd);
        String property_file = null;

        //Parancssor argumentumok feldolgozasa
        int i = 0;
        for (i = 0; i < aArgs.length; i++) {
            if (aArgs[i].equals("-property")) {
                property_file = aArgs[++i];
            } else if (aArgs[i].equals("-verbose")) {
                verbose = true;
            }
        }

        VP("PARSING START: " + cal.getTime().toString());

        //Propertyk beolvasása fájlból
        try {
            if (!(property_file == null || property_file.isEmpty())) {
                VP("-PROPERTY FILE:" + property_file);
                pf.load(new FileInputStream(property_file));
            }

        } catch (Exception e) {
            P("~ERROR: Error reading property file: " + property_file);
        }

        //Beszédes mód
        if (verbose || pf.getProperty("verbose", "1").equals("1")) //ha ki lett toltve a beszedes mod
        {
            verbose = true; //fajlbeli propertyt felülvágja
            VP("-PROPERTY: Verbose MODE is ON");
        }

        VP("");
        //Feldolgozás méréséhez
        cal = Calendar.getInstance();
        long tStart = cal.getTimeInMillis();

        //Feldolgozó osztály példányosítása
        ParseMailBuffer mb = new ParseMailBuffer(pf);
        int rV = mb.Process();

        //Feldolgozás befejezésének lekérdezése és idő delta számítása
        cal = Calendar.getInstance();
        long tStop = cal.getTimeInMillis();
        tStop -= tStart;

        VP("PARSING STOP: " + cal.getTime().toString() + " ( total processing: " + tStop + " ms)");
        System.exit(rV);
    }

    /**
     * Kiíratást végző függvény, rövidebb, mint a System.out.pr... :)
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
