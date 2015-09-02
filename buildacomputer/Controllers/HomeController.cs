using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using buildacomputer.Models;

namespace buildacomputer.Controllers
{
    public class HomeController : Controller
    {
        private static PartsAndUsersContext db = new PartsAndUsersContext();
        private static List<Build> recentBuilds = new List<Build>();
        
        public ActionResult Index()
        {
            //Get top 5 entries, ordered by DateTime
            
            recentBuilds = db.builds.Select(m => m.build )
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}