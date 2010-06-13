/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package caEmailBufferParser;

import javax.mail.internet.InternetAddress;

/**
 * A javax.mail library InternetAddress osztályának egyszerűsítése
 *
 * @author Muráti Ákos
 */
public class SimpleAddress {

    public String eAddress;
    public String eName;
    public int eRecipientMode;

    public SimpleAddress() {
        eAddress = "";
        eName = "";
        eRecipientMode = 0;
    }

    /**
     * Osztály konstruktora, ami egy IntrnetMessage osztály alapján példányosítja önmagát
     *
     * @author Muráti Ákos
     */
    public SimpleAddress(InternetAddress a) {
        eAddress = a.getAddress();
        eName = a.getPersonal();
        eRecipientMode = 0;
    }

    public SimpleAddress(InternetAddress a, int eR) {
        eAddress = a.getAddress();
        eName = a.getPersonal();
        eRecipientMode = eR;
    }

    @Override
    public String toString() {
        return eAddress;
    }
}
