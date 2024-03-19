using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace WebApplication7.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Users = "petar.petrovic@gmail.com,admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Stranica1()
        {
            ViewBag.Message = "Vasa prva stranica.";

            return View();
        }
      
        public ActionResult Stranica2()
        {
            ViewBag.Message = "Vasa druga stranica.";

            return View();
        }
    }
}
