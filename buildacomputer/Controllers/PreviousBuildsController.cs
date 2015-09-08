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

namespace buildacomputer.Controllers
{
    public class PreviousBuildsController : Controller
    {
        private PartsAndUsersContext db = new PartsAndUsersContext();


        // GET: PreviousBuilds
        public async Task<ActionResult> Index()
        {
            string currentUser = (string)Membership.GetUser().ProviderUserKey;
            List<int> oldBuild = db.UserBuilds.Where(u => u.userID == currentUser).Select(b => b.buildID).ToList();

            List<Build> displayBuilds = new List<Build>();

            foreach(int inOldBuilds in oldBuild)
            {
                displayBuilds.Add(db.Builds.Where(b => b.buildID == inOldBuilds).Select(b => b).Single<Build>()); //should it be first? it sounds like .Single will throw an exception if there's more than one build matching the id, which theoretically is something that could happen.
            }

            return View(displayBuilds);
        }
    }
}
