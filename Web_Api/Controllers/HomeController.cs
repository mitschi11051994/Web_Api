using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult IndexClient() { 

            return View();
        }

        public ActionResult IndexReunion()
        {

            return View();
        }

        public ActionResult IndexContact()
        {

            return View();
        }

        public ActionResult IndexSuportTiket()
        {

            return View();
        }
    }
}
