using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMapperDemo.Models
{
    public class ShopModel
    {
        public int ID { get; set; }
        public string WarenBezeichnung { get; set; }
        public string KategorieBezeichnung { get; set; }
        public double Preis { get; set; }
    }
}