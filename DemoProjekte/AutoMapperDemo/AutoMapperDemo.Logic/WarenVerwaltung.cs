using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperDemo.Logic
{
    public class Ware
    {
        public int ID { get; set; }
        public string Bezeichnung { get; set; }
        public double Preis { get; set; }

        public Kategorie Kategorie { get; set; }
    }
    public class Kategorie
    {
        public int ID { get; set; }
        public string Bezeichnung { get; set; }
    }

    public class WarenVerwaltung
    {
        public static List<Ware> LadeAlleWaren()
        {
            #region Lade die Daten aus der Datenbank (fake!)
            List<Kategorie> alleKategorien = new List<Kategorie>();

            for (int i = 0; i < 5; i++)
            {
                alleKategorien.Add(new Kategorie()
                {
                    ID = i, 
                    Bezeichnung = "Kategorie " + i
                });
            }

            List<Ware> alleWaren = new List<Ware>();

            

            for (int i = 0; i < 100; i++)
            {
                alleWaren.Add(new Ware()
                {
                    ID = i,
                    Bezeichnung = "Ware " + i,
                    Preis = 1000+i*200,
                    Kategorie = alleKategorien[i%5]
                });
            }
            #endregion

            return alleWaren;
        }
    }
}
