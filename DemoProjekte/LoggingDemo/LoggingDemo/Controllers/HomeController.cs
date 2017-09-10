using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoggingDemo.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public ActionResult Index()
        {
            log.Debug("GET - Index");
            return View();
        }

        public ActionResult About()
        {
            log.Debug("GET - About");
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            log.Debug("GET - Contact");
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}