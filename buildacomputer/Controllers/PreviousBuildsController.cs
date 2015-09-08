using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using buildacomputer.Models;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace buildacomputer.Controllers
{
    public class PreviousBuildsController : Controller
    {
        private PartsAndUsersContext db = new PartsAndUsersContext();
        private static Dictionary<string, List<string>> previousBuildsDictionary = new Dictionary<string, List<string>>();
        private static List<Build> displayBuilds = new List<Build>();

        // GET: PreviousBuilds
        public async Task<ActionResult> Index()
        {
            string currentUserID = User.Identity.GetUserId();
            List<int> oldBuild = db.UserBuilds.Where(u => u.userID == currentUserID).Select(b => b.buildID).ToList();
            if(displayBuilds.Any())
            {
                displayBuilds.Clear();
            }

            foreach(int inOldBuilds in oldBuild)
            {
                displayBuilds.Add(db.Builds.Where(b => b.buildID == inOldBuilds).Select(b => b).Include(b => b.motherboard).Include(b => b.processor).Include(b => b.memory).Include(b => b.hard_drives).Include(b => b.sound_cards).Include(b => b.video_adapters).Include(b => b.optical_drives).Include(b => b.power_supplies).Include(b => b.computer_cases).SingleOrDefault());
            }

            return View(displayBuilds);
        }
    }
}

