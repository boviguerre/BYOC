using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using buildacomputer.Models;

namespace buildacomputer.Controllers
{
    public class AnimationController : Controller
    {
        private PartsAndUsersContext db = new PartsAndUsersContext();

        // GET: Animation
        public ActionResult Index()
        {
            
            return View();
        }
    }
}

//        // GET: Animation/Details/5
//        public ActionResult Details(long? id)
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

//        // GET: Animation/Create
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

//        // POST: Animation/Create
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

//        // GET: Animation/Edit/5
//        public ActionResult Edit(long? id)
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

//        // POST: Animation/Edit/5
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

//        // GET: Animation/Delete/5
//        public ActionResult Delete(long? id)
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

//        // POST: Animation/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(long id)
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
