using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using testWebshop.logic;
using testITIN22.data;

namespace testWebshop.test
{
    [TestClass]
    public class UT_BenutzerVerwaltung
    {
        public const string BENUTZERNAME_RICHTIG = "max.muster";
        public const string BENUTZERNAME_FALSCH = "maxi.muster";
        public const string PASSWORT_RICHTIG = "123user!";
        public const string PASSWORT_FALSCH = "1234user!";

        [TestMethod]
        public void Anmeldung_Erfolgreich()
        {
            Assert.AreEqual(BenutzerVerwaltung.Anmelden(BENUTZERNAME_RICHTIG, PASSWORT_RICHTIG), AnmeldenErgebnis.Erfolgreich);
        }

        [TestMethod]
        public void Anmeldung_PasswortFalsch()
        {
            Assert.AreEqual(BenutzerVerwaltung.Anmelden(BENUTZERNAME_RICHTIG, PASSWORT_FALSCH), AnmeldenErgebnis.PasswortFalsch);
        }

        [TestMethod]
        public void Anmeldung_BenutzernameUnbekannt()
        {
            Assert.AreEqual(BenutzerVerwaltung.Anmelden(BENUTZERNAME_FALSCH, PASSWORT_RICHTIG), AnmeldenErgebnis.BenutzerNameUnbekannt);
        }
    }
}
