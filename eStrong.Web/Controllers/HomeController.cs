using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eStrong.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult Classes()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View(); 
        }
        public ActionResult OurTeam()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
        }
        public ActionResult ClassesTimetable()
        {
            return View();
        }
    }
}