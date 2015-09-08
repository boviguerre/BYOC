//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using buildacomputer.Models;

//namespace buildacomputer.Controllers
//{
//    public class HomeController : Controller
//    {
//        private PartsAndUsersContext db = new PartsAndUsersContext();

//        // GET: AllBuilds
//        public ActionResult Index()
//        {
//            var builds = db.Builds.Include(b => b.motherboard).Include(b => b.processor).Include(b => b.memory).Include(b => b.hard_drives).Include(b => b.sound_cards).Include(b => b.video_adapters).Include(b => b.optical_drives).Include(b => b.power_supplies).Include(b => b.computer_cases);
//            return View(builds.ToList());
//        }

//        // GET: AllBuilds/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Build build = db.Builds.Find(id);
//            if (build == null)
//            {
//                return HttpNotFound();
//            }
//            return View(build);
//        }

//        // GET: AllBuilds/Create
//        public ActionResult Create()
//        {
//            ViewBag.computer_case_id = new SelectList(db.computer_cases, "computer_case_id", "computer_case_name");
//            ViewBag.hard_drive_id = new SelectList(db.hard_drives, "hard_drive_id", "hard_drive_name");
//            ViewBag.memory_id = new SelectList(db.memories, "memory_id", "memory_name");
//            ViewBag.motherboard_id = new SelectList(db.motherboards, "motherboard_id", "motherboard_name");
//            ViewBag.optical_drive_id = new SelectList(db.optical_drives, "optical_drive_id", "optical_drive_name");
//            ViewBag.power_supply_id = new SelectList(db.power_supplies, "power_supply_id", "power_supply_name");
//            ViewBag.processor_id = new SelectList(db.processors, "processor_id", "processor_name");
//            ViewBag.sound_card_id = new SelectList(db.sound_cards, "sound_card_id", "sound_card_name");
//            ViewBag.video_adapter_id = new SelectList(db.video_adapters, "video_adapter_id", "video_adapter_name");
//            return View();
//        }

//        // POST: AllBuilds/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "buildID,motherboard_id,computer_case_id,hard_drive_id,optical_drive_id,power_supply_id,processor_id,sound_card_id,video_adapter_id,memory_id,buildType,iterator,BuildTime")] Build build)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Builds.Add(build);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.computer_case_id = new SelectList(db.computer_cases, "computer_case_id", "computer_case_name", build.computer_case_id);
//            ViewBag.hard_drive_id = new SelectList(db.hard_drives, "hard_drive_id", "hard_drive_name", build.hard_drive_id);
//            ViewBag.memory_id = new SelectList(db.memories, "memory_id", "memory_name", build.memory_id);
//            ViewBag.motherboard_id = new SelectList(db.motherboards, "motherboard_id", "motherboard_name", build.motherboard_id);
//            ViewBag.optical_drive_id = new SelectList(db.optical_drives, "optical_drive_id", "optical_drive_name", build.optical_drive_id);
//            ViewBag.power_supply_id = new SelectList(db.power_supplies, "power_supply_id", "power_supply_name", build.power_supply_id);
//            ViewBag.processor_id = new SelectList(db.processors, "processor_id", "processor_name", build.processor_id);
//            ViewBag.sound_card_id = new SelectList(db.sound_cards, "sound_card_id", "sound_card_name", build.sound_card_id);
//            ViewBag.video_adapter_id = new SelectList(db.video_adapters, "video_adapter_id", "video_adapter_name", build.video_adapter_id);
//            return View(build);
//        }

//        // GET: AllBuilds/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Build build = db.Builds.Find(id);
//            if (build == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.computer_case_id = new SelectList(db.computer_cases, "computer_case_id", "computer_case_name", build.computer_case_id);
//            ViewBag.hard_drive_id = new SelectList(db.hard_drives, "hard_drive_id", "hard_drive_name", build.hard_drive_id);
//            ViewBag.memory_id = new SelectList(db.memories, "memory_id", "memory_name", build.memory_id);
//            ViewBag.motherboard_id = new SelectList(db.motherboards, "motherboard_id", "motherboard_name", build.motherboard_id);
//            ViewBag.optical_drive_id = new SelectList(db.optical_drives, "optical_drive_id", "optical_drive_name", build.optical_drive_id);
//            ViewBag.power_supply_id = new SelectList(db.power_supplies, "power_supply_id", "power_supply_name", build.power_supply_id);
//            ViewBag.processor_id = new SelectList(db.processors, "processor_id", "processor_name", build.processor_id);
//            ViewBag.sound_card_id = new SelectList(db.sound_cards, "sound_card_id", "sound_card_name", build.sound_card_id);
//            ViewBag.video_adapter_id = new SelectList(db.video_adapters, "video_adapter_id", "video_adapter_name", build.video_adapter_id);
//            return View(build);
//        }

//        // POST: AllBuilds/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "buildID,motherboard_id,computer_case_id,hard_drive_id,optical_drive_id,power_supply_id,processor_id,sound_card_id,video_adapter_id,memory_id,buildType,iterator,BuildTime")] Build build)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(build).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.computer_case_id = new SelectList(db.computer_cases, "computer_case_id", "computer_case_name", build.computer_case_id);
//            ViewBag.hard_drive_id = new SelectList(db.hard_drives, "hard_drive_id", "hard_drive_name", build.hard_drive_id);
//            ViewBag.memory_id = new SelectList(db.memories, "memory_id", "memory_name", build.memory_id);
//            ViewBag.motherboard_id = new SelectList(db.motherboards, "motherboard_id", "motherboard_name", build.motherboard_id);
//            ViewBag.optical_drive_id = new SelectList(db.optical_drives, "optical_drive_id", "optical_drive_name", build.optical_drive_id);
//            ViewBag.power_supply_id = new SelectList(db.power_supplies, "power_supply_id", "power_supply_name", build.power_supply_id);
//            ViewBag.processor_id = new SelectList(db.processors, "processor_id", "processor_name", build.processor_id);
//            ViewBag.sound_card_id = new SelectList(db.sound_cards, "sound_card_id", "sound_card_name", build.sound_card_id);
//            ViewBag.video_adapter_id = new SelectList(db.video_adapters, "video_adapter_id", "video_adapter_name", build.video_adapter_id);
//            return View(build);
//        }

//        // GET: AllBuilds/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Build build = db.Builds.Find(id);
//            if (build == null)
//            {
//                return HttpNotFound();
//            }
//            return View(build);
//        }

//        // POST: AllBuilds/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            Build build = db.Builds.Find(id);
//            db.Builds.Remove(build);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using buildacomputer.Models;
using System.Data.Entity;

namespace buildacomputer.Controllers
{
    public class HomeController : Controller
    {
        private static PartsAndUsersContext db = new PartsAndUsersContext();
        //private static List<Build> recentBuilds = new List<Build>();
        //private static Dictionary<string, List<string>> recentBuildDictionary = new Dictionary<string, List<string>>();

        public ActionResult Index()
        {
            //Get top 5 entries, ordered by DateTime
            var recentBuilds = db.Builds.OrderByDescending(b => b.BuildTime).Select(b => b).Take(5).Include(b => b.motherboard).Include(b => b.processor).Include(b => b.memory).Include(b => b.hard_drives).Include(b => b.sound_cards).Include(b => b.video_adapters).Include(b => b.optical_drives).Include(b => b.power_supplies).Include(b => b.computer_cases).ToList<Build>();

            var popularBuilds = db.Builds.OrderByDescending(b => b.iterator).Select(b => b).Take(5).Include(b => b.motherboard).Include(b => b.processor).Include(b => b.memory).Include(b => b.hard_drives).Include(b => b.sound_cards).Include(b => b.video_adapters).Include(b => b.optical_drives).Include(b => b.power_supplies).Include(b => b.computer_cases).ToList<Build>();

            ViewData["Recent Builds"] = recentBuilds;
            ViewData["Popular Builds"] = popularBuilds;

            return View();

            ////Lists for original view, before objects and viewModel
            //List<string> motherboards = new List<string>();
            //List<string> processors = new List<string>();
            //List<string> memories = new List<string>();
            //List<string> hardDrives = new List<string>();
            //List<string> soundCards = new List<string>();
            //List<string> videoAdapters = new List<string>();
            //List<string> opticalDrives = new List<string>();
            //List<string> powerSupplies = new List<string>();
            //List<string> computerCases = new List<string>();

            ////Temporary seed method for lists
            //for (int i = 0; i < 5; i++)
            //{
            //motherboards.Add((from motherboard in db.motherboards
            //                  where motherboard.motherboard_id == element.motherboard_id
            //                  select motherboard.motherboard_name).ToString());

            //processors.Add((from processor in db.processors
            //                where processor.processor_id == element.processor_id
            //                select processor.processor_name).ToString());

            //memories.Add((from memory in db.memories
            //              where memory.memory_id == element.memory_id
            //              select memory.memory_name).ToString());

            //hardDrives.Add((from hard_drive in db.hard_drives
            //                where hard_drive.hard_drive_id == element.hard_drive_id
            //                select hard_drive.hard_drive_name).ToString());

            //soundCards.Add((from sound_card in db.sound_cards
            //                where sound_card.sound_card_id == element.sound_card_id
            //                select sound_card.sound_card_name).ToString());

            //videoAdapters.Add((from video_adapter in db.video_adapters
            //                   where video_adapter.video_adapter_id == element.video_adapter_id
            //                   select video_adapter.video_adapter_name).ToString());

            //opticalDrives.Add((from optical_drive in db.optical_drives
            //                   where optical_drive.optical_drive_id == element.optical_drive_id
            //                   select optical_drive.optical_drive_name).ToString());

            //powerSupplies.Add((from power_supply in db.power_supplies
            //                   where power_supply.power_supply_id == element.power_supply_id
            //                   select power_supply.power_supply_name).ToString());

            //computerCases.Add((from computer_case in db.computer_cases
            //                   where computer_case.computer_case_id == element.computer_case_id
            //                   select computer_case.computer_case_name).ToString());
            //    motherboards.Add("Motherboard " + i);
            //    processors.Add("Processor " + i);
            //    memories.Add("Memory " + i);
            //    hardDrives.Add("Hard Drive " + i);
            //    soundCards.Add("Sound Card " + i);
            //    videoAdapters.Add("Video Adapter " + i);
            //    opticalDrives.Add("Optical Drive " + i);
            //    powerSupplies.Add("Power Supply " + i);
            //    computerCases.Add("Computer Case " + i);
            //}

            ////Populates each list with the build components in order
            //foreach (Build element in recentBuilds)
            //{
            //    var current_motherboard = db.motherboards.Where(m => m.motherboard_id == element.motherboard_id).Select(m => m.motherboard_name).SingleOrDefault();
            //    motherboards.Add(current_motherboard);

            //    var current_processor = (from processor in db.processors
            //                             where processor.processor_id == element.processor_id
            //                             select processor.processor_name).SingleOrDefault();
            //    processors.Add(current_processor);

            //    var current_memory = (from memory in db.memories
            //                          where memory.memory_id == element.memory_id
            //                          select memory.memory_name).SingleOrDefault();
            //    memories.Add(current_memory);

            //    var current_hardDrive = (from hard_drive in db.hard_drives
            //                             where hard_drive.hard_drive_id == element.hard_drive_id
            //                             select hard_drive.hard_drive_name).SingleOrDefault();
            //    hardDrives.Add(current_hardDrive);

            //    var current_soundCard = (from sound_card in db.sound_cards
            //                             where sound_card.sound_card_id == element.sound_card_id
            //                             select sound_card.sound_card_name).SingleOrDefault();
            //    soundCards.Add(current_soundCard);

            //    var current_videoAdapter = (from video_adapter in db.video_adapters
            //                                where video_adapter.video_adapter_id == element.video_adapter_id
            //                                select video_adapter.video_adapter_name).SingleOrDefault();
            //    videoAdapters.Add(current_videoAdapter);

            //    var current_opticalDrive = (from optical_drive in db.optical_drives
            //                                where optical_drive.optical_drive_id == element.optical_drive_id
            //                                select optical_drive.optical_drive_name).SingleOrDefault();
            //    opticalDrives.Add(current_opticalDrive);

            //    var current_powerSupply = (from power_supply in db.power_supplies
            //                               where power_supply.power_supply_id == element.power_supply_id
            //                               select power_supply.power_supply_name).SingleOrDefault();
            //    powerSupplies.Add(current_powerSupply);

            //    var current_copmuterCase = (from computer_case in db.computer_cases
            //                                where computer_case.computer_case_id == element.computer_case_id
            //                                select computer_case.computer_case_name).SingleOrDefault();
            //    computerCases.Add(current_copmuterCase);
            //}

            ////Adds each list of components to the dictionary of recent builds
            //if (!recentBuildDictionary.ContainsKey("Motherboard"))
            //{
            //    recentBuildDictionary.Add("Motherboard", motherboards);
            //    recentBuildDictionary.Add("Processor", processors);
            //    recentBuildDictionary.Add("Memory", memories);
            //    recentBuildDictionary.Add("Hard Drive", hardDrives);
            //    recentBuildDictionary.Add("Sound Card", soundCards);
            //    recentBuildDictionary.Add("Video Adapter", videoAdapters);
            //    recentBuildDictionary.Add("Optical Drive", opticalDrives);
            //    recentBuildDictionary.Add("Power Supply", powerSupplies);
            //    recentBuildDictionary.Add("Computer Case", computerCases);
            //}

            //ViewData["Five Recent"] = recentBuildDictionary;
            //return View();
            //return View(recentBuildDictionary);
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