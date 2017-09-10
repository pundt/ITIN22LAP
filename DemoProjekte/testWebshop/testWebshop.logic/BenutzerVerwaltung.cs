using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testITIN22.data;

namespace testWebshop.logic
{
    public enum AnmeldenErgebnis
    {
        Erfolgreich,
        BenutzerNameUnbekannt,
        PasswortFalsch,
        BenutzerGesperrt,
        Fehler
    }

    public class BenutzerVerwaltung
    {
        public static AnmeldenErgebnis Anmelden(string benutzerName, string passwort)
        {
            Debug.WriteLine("BenutzerVerwaltung - AnmeldenErgebnis Anmelden(string benutzerName, string passwort)");
            Debug.Indent();

            AnmeldenErgebnis ergebnis = AnmeldenErgebnis.BenutzerNameUnbekannt;

            if (string.IsNullOrEmpty(benutzerName))
            {
                throw new ArgumentNullException(nameof(benutzerName));
            }
            else if (string.IsNullOrEmpty(passwort))
            {
                throw new ArgumentNullException(nameof(passwort));
            }
            else
            {
                try
                {
                    Benutzer benutzer = null;
                    using (var context = new dbTestITIN22Entities())
                    {
                        benutzer = context.AlleBenutzer.Where(x => x.BenutzerName == benutzerName).FirstOrDefault();
                    }

                    if (benutzer == null)
                    {
                        Debug.WriteLine($"Benutzername {benutzerName} unbekannt!");
                        ergebnis = AnmeldenErgebnis.BenutzerNameUnbekannt;
                    }
                    else if (!benutzer.Aktiv)
                    {
                        Debug.WriteLine($"Benutzername {benutzerName} gesperrt!");
                        ergebnis = AnmeldenErgebnis.BenutzerGesperrt;
                    }
                    else if (!Tools.ErmittleHashWert(passwort).SequenceEqual(benutzer.Passwort))
                    {
                        Debug.WriteLine($"Passwort für {benutzerName} falsch!");
                        ergebnis = AnmeldenErgebnis.PasswortFalsch;
                    }
                    else
                    {
                        Debug.WriteLine($"Anmeldung für Benutzername {benutzerName} erfolgreich");
                        ergebnis = AnmeldenErgebnis.Erfolgreich;
                    }
                }
                catch (Exception ex)
                {
                    Debug.Indent();
                    Debug.WriteLine("Fehler in Anmelden(..)");
                    Debug.WriteLine(ex.Message);
                    if (ex.InnerException!=null)
                    {
                        Debug.Indent();
                        Debug.WriteLine(ex.InnerException.Message);
                        Debug.Unindent();
                    }
                    Debugger.Break();
                    Debug.Unindent();
                }
            }

            Debug.Unindent();
            return ergebnis;
        }
    }
}
