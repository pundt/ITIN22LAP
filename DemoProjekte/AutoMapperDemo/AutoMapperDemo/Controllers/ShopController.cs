using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AutoMapperDemo.Logic;
using AutoMapperDemo.Models;

namespace AutoMapperDemo.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            List<Ware> alleWaren = WarenVerwaltung.LadeAlleWaren();

            List<ShopModel> alleShopModels = new List<ShopModel>();

            /// die große Frage hier:
            /// wie bilde ich alle Objekte in der List<Ware>
            /// auf Objekte in der List<ShopModel> ab ...

            /// Variante Warmduscher
            ///     manuell
            //foreach (var ware in alleWaren)
            //{
            //    alleShopModels.Add(new ShopModel()
            //    {
            //        ID = ware.ID,
            //        KategorieBezeichnung = ware.Kategorie.Bezeichnung,
            //        WarenBezeichnung = ware.Bezeichnung,
            //        Preis = ware.Preis
            //    });
            //}

            /// Variante AutoMapper - (h)eiskalt - warum führst du mich in die ..
            /// 
            alleShopModels = AutoMapperConfig.CommonMapper.Map <List<ShopModel>> (alleWaren);

            return View(alleShopModels);
        }
    }
}