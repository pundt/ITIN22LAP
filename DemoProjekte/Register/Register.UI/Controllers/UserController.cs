using Register.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Register.UI.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]  // NUR wenn ein Formular übertragen wird
        [ValidateAntiForgeryToken()]  /// ich möchte, dass der Absender der Formular-Daten
            // zuvor meine Webseite erhalten hat und KEIN BOT ist
        public ActionResult Register(RegisterModel model)
        {
            // prüfe auch Serverseitig ob die Model Annotations
            // auch eingehalten wurden
            if (ModelState.IsValid)
            {
                /// do some funny stuff
                /// 

            }
            return View();
        }
    }
}