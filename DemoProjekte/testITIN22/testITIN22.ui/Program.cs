using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testITIN22.data;
using System.Data.Entity;

namespace testITIN22.ui
{
    class Program
    {
        static void Main(string[] args)
        {
            //EinfacheAbfrage();
            //NavigationsEigenschaftAuslesen();
            //LazyLoading();
            //LazyLoading_Fehler();
            EagerLoading();
            Console.ReadLine();
        }

        private static void LazyLoading()
        {
            /// mache eine Verbindung auf
            using (var context = new dbTestITIN22Entities())
            {
                /// hier werden eben NUR die Waren geladen
                Ware ware = context.AlleWaren.First();

                /// dh: solange die Verbindung offen ist
                /// kann ich - ohne Probleme - andere Objekte nachladen
                /// => Lazy Loading!
                /// hier wird also die Kategorie nachgeladen
                Console.WriteLine(ware.Kategorie.Bezeichnung);


            } /// hier wird der Context verworfen UND die Verbindung geschlossen

        }

        private static void LazyLoading_Fehler()
        {
            Ware ware = null;

            /// mache eine Verbindung auf
            using (var context = new dbTestITIN22Entities())
            {
                /// hier werden eben NUR die Waren geladen
                ware = context.AlleWaren.First();
            } /// hier wird der Context verworfen UND die Verbindung geschlossen

            /// dh: solange die Verbindung offen ist
            /// kann ich - ohne Probleme - andere Objekte nachladen
            /// => Lazy Loading!
            /// hier wird also die Kategorie nachgeladen
            Console.WriteLine(ware.Kategorie.Bezeichnung);
        }

        private static void EagerLoading()
        {
            Ware ware = null;

            /// mache eine Verbindung auf
            using (var context = new dbTestITIN22Entities())
            {
                /// hier werden eben NUR die Waren geladen
                ///     .Include(NAME_DER_NAVIGATIONS_EIGENSCHAFT)
                /// ist zwar technisch möglich, aber äußerst Fehler anfällig
                /// Stichwort: MAGIC STRING
                //ware = context.AlleWaren.Include("Kategorie").First();

                /// Lösung: man kann hier auch eine Lambda Expression 
                /// (TYPE SAFE!) verwenden, muss dazu allerdings einen 
                /// zusätzlichen namespace einbauen
                ware = context.AlleWaren.Include(x => x.Kategorie).First();
            } /// hier wird der Context verworfen UND die Verbindung geschlossen

            /// da ich die Kategorie allerdings mit EAGER Loading (noch vor dem Schließen der Verbindung)
            /// geladen habe, kann ich hier auf diese zugreifen
            Console.WriteLine(ware.Kategorie.Bezeichnung);
        }

        private static void NavigationsEigenschaftAuslesen()
        {
            Debug.WriteLine("NavigationsEigenschaftAuslesen");

            try
            {
                using (var context = new dbTestITIN22Entities())
                {
                    var benutzer = context.AlleBenutzer.FirstOrDefault();

                    Console.WriteLine($"Waren des Benutzers {benutzer.Nachname}");
                    foreach (var rechnung in benutzer.AlleRechnungen)
                    {
                        foreach (var rechnungsWare in rechnung.AlleRechnungsWaren)
                        {
                            Console.WriteLine($"\t{rechnungsWare.Ware.Bezeichnung}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in NavigationsEigenschaftAuslesen");
                Debug.WriteLine("\t" + ex.Message);
                if (ex.InnerException != null)
                {
                    Debug.WriteLine("\t\t" + ex.InnerException.Message);
                }
                Debugger.Break();
            }
        }

        private static void EinfacheAbfrage()
        {
            Debug.WriteLine("Einfache Abfrage");

            try
            {

                using (var context = new dbTestITIN22Entities())
                {
                    foreach (var rolle in context.AlleRollen)
                    {
                        Console.WriteLine($"Rolle {rolle.Bezeichnung} ({rolle.ID})");
                    }
                    Debug.WriteLine($"Anzahl Rollen {context.AlleRollen.Count()}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in EinfacheAbfrage");
                Debug.WriteLine("\t" + ex.Message);
                if (ex.InnerException!=null)
                {
                    Debug.WriteLine("\t\t" + ex.InnerException.Message);
                }
                Debugger.Break();
            }
        }
    }
}
