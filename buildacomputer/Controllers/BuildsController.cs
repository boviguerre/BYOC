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
    public class BuildsController : Controller
    {
        private static PartsAndUsersContext db = new PartsAndUsersContext();
        private Build build = new Build();
        private int iterator = 0;

        // GET: Builds
        //public ActionResult Index(long? id_number = null)
        public ActionResult Index(long? id_number)
        {
            List<Object> ViewList = new List<Object>();
            //Switch that uses selection to identify which list to show
            switch (iterator)
            {
                //Turns motherboards held in build into a list of strings
                case 0:
                    foreach (long item in build.motherboard_ids)
                    {
                        ViewList.Add(db.motherboards.Where(m => m.motherboard_id == item).ToList<motherboards>());
                    }
                    ViewBag.mb = ViewList;
                    ViewBag.i = iterator;
                    iterator += 1;
                    break;
                //Adds selected motherboard
                case 1:
                    build.addMotherboard(id_number);
                    ViewList.Clear();
                    foreach (long item in build.processor_ids)
                    {
                        ViewList.Add(db.processors.Where(p => p.processor_id == item).ToList<processors>());
                    }
                    ViewBag.pr = ViewList;
                    ViewBag.i = iterator;
                    iterator += 1;
                    break;
                case 2:
                    build.addProcessor_id(id_number);
                    ViewList.Clear();
                    foreach (long item in build.memory_ids)
                    {
                        ViewList.Add(db.memories.Where(m => m.memory_id == item).ToList<memories>());
                    }
                    ViewBag.me = ViewList;
                    ViewBag.i = iterator;
                    iterator += 1;
                    break;
                case 3:
                    build.addMemory_id(id_number);
                    ViewList.Clear();
                    foreach (long item in build.hard_drive_ids)
                    {
                        ViewList.Add(db.hard_drives.Where(h => h.hard_drive_id == item).ToList<hard_drives>());
                    }
                    ViewBag.hd = ViewList;
                    ViewBag.i = iterator;
                    iterator += 1;
                    break;
                case 4:
                    build.addHard_drive_id(id_number);
                    ViewList.Clear();
                    foreach (long item in build.sound_card_ids)
                    {
                        ViewList.Add(db.sound_cards.Where(s => s.sound_card_id == item).ToList<sound_cards>());
                    }
                    ViewBag.sc = ViewList;
                    ViewBag.i = iterator;
                    iterator += 1;
                    break;
                case 5:
                    build.addSound_card_id(id_number);
                    ViewList.Clear();
                    foreach (long item in build.video_adapter_ids)
                    {
                        ViewList.Add(db.video_adapters.Where(v => v.video_adapter_id == item).ToList<video_adapters>());
                    }
                    ViewBag.va = ViewList;
                    ViewBag.i = iterator;
                    iterator += 1;
                    break;
                case 6:
                    build.addVideo_adapter_id(id_number);
                    ViewList.Clear();
                    foreach (long item in build.optical_drive_ids)
                    {
                        ViewList.Add(db.optical_drives.Where(o => o.optical_drive_id == item).ToList<optical_drives>());
                    }
                    ViewBag.od = ViewList;
                    ViewBag.i = iterator;
                    iterator += 1;
                    break;
                case 7:
                    build.addOptical_drive_id(id_number);
                    ViewList.Clear();
                    foreach (long item in build.power_supply_ids)
                    {
                        ViewList.Add(db.power_supplies.Where(p => p.power_supply_id == item).ToList<power_supplies>());
                    }
                    ViewBag.ps = ViewList;
                    ViewBag.i = iterator;
                    iterator += 1;
                    break;
                case 8:
                    build.addPower_supply_id(id_number);
                    ViewList.Clear();
                    foreach (long item in build.computer_case_ids)
                    {
                        ViewList.Add(db.computer_cases.Where(c => c.computer_case_id == item).ToList<computer_cases>());
                    }
                    ViewBag.cc = ViewList;
                    ViewBag.i = iterator;
                    iterator += 1;
                    break;
                case 9:
                    build.addComputer_case_id(id_number);
                    ViewList.Clear();
                    iterator += 1;
                    break;
                default:
                    iterator += 1;
                    Index(null);
                    break;
            }

            //Returns the list of motherboard strings to the view
            return View();
        }

        //// GET: Builds/Details/5
        //public ActionResult Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Build build = db.Build.Find(id);
        //    if (build == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(build);
        //}

        //// GET: Builds/Create
        //public ActionResult Create()
        //{
        //    ViewBag.computer_case_id = new SelectList(db.computer_cases, "computer_case_id", "color");
        //    ViewBag.hard_drive_id = new SelectList(db.hard_drives, "hard_drive_id", "hard_drive_name");
        //    ViewBag.memory_id = new SelectList(db.memories, "memory_id", "memory_name");
        //    ViewBag.motherboard_id = new SelectList(db.motherboards, "motherboard_id", "motherboard_name");
        //    ViewBag.optical_drive_id = new SelectList(db.optical_drives, "optical_drive_id", "optical_drive_name");
        //    ViewBag.power_supply_id = new SelectList(db.power_supplies, "power_supply_id", "power_supply_name");
        //    ViewBag.sound_card_id = new SelectList(db.sound_cards, "sound_card_id", "sound_card_name");
        //    ViewBag.video_adapter_id = new SelectList(db.video_adapters, "video_adapter_id", "video_adapter_name");
        //    return View();
        //}

        //// POST: Builds/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "buildID,motherboard_id,computer_case_id,hard_drive_id,optical_drive_id,power_supply_id,processer_id,sound_card_id,video_adapter_id,memory_id,buildType,iterator,BuildTime")] Build build)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Build.Add(build);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.computer_case_id = new SelectList(db.computer_cases, "computer_case_id", "color", build.computer_case_id);
        //    ViewBag.hard_drive_id = new SelectList(db.hard_drives, "hard_drive_id", "hard_drive_name", build.hard_drive_id);
        //    ViewBag.memory_id = new SelectList(db.memories, "memory_id", "memory_name", build.memory_id);
        //    ViewBag.motherboard_id = new SelectList(db.motherboards, "motherboard_id", "motherboard_name", build.motherboard_id);
        //    ViewBag.optical_drive_id = new SelectList(db.optical_drives, "optical_drive_id", "optical_drive_name", build.optical_drive_id);
        //    ViewBag.power_supply_id = new SelectList(db.power_supplies, "power_supply_id", "power_supply_name", build.power_supply_id);
        //    ViewBag.sound_card_id = new SelectList(db.sound_cards, "sound_card_id", "sound_card_name", build.sound_card_id);
        //    ViewBag.video_adapter_id = new SelectList(db.video_adapters, "video_adapter_id", "video_adapter_name", build.video_adapter_id);
        //    return View(build);
        //}

        //// GET: Builds/Edit/5
        //public ActionResult Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Build build = db.Build.Find(id);
        //    if (build == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.computer_case_id = new SelectList(db.computer_cases, "computer_case_id", "color", build.computer_case_id);
        //    ViewBag.hard_drive_id = new SelectList(db.hard_drives, "hard_drive_id", "hard_drive_name", build.hard_drive_id);
        //    ViewBag.memory_id = new SelectList(db.memories, "memory_id", "memory_name", build.memory_id);
        //    ViewBag.motherboard_id = new SelectList(db.motherboards, "motherboard_id", "motherboard_name", build.motherboard_id);
        //    ViewBag.optical_drive_id = new SelectList(db.optical_drives, "optical_drive_id", "optical_drive_name", build.optical_drive_id);
        //    ViewBag.power_supply_id = new SelectList(db.power_supplies, "power_supply_id", "power_supply_name", build.power_supply_id);
        //    ViewBag.sound_card_id = new SelectList(db.sound_cards, "sound_card_id", "sound_card_name", build.sound_card_id);
        //    ViewBag.video_adapter_id = new SelectList(db.video_adapters, "video_adapter_id", "video_adapter_name", build.video_adapter_id);
        //    return View(build);
        //}

        //// POST: Builds/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "buildID,motherboard_id,computer_case_id,hard_drive_id,optical_drive_id,power_supply_id,processer_id,sound_card_id,video_adapter_id,memory_id,buildType,iterator,BuildTime")] Build build)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(build).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.computer_case_id = new SelectList(db.computer_cases, "computer_case_id", "color", build.computer_case_id);
        //    ViewBag.hard_drive_id = new SelectList(db.hard_drives, "hard_drive_id", "hard_drive_name", build.hard_drive_id);
        //    ViewBag.memory_id = new SelectList(db.memories, "memory_id", "memory_name", build.memory_id);
        //    ViewBag.motherboard_id = new SelectList(db.motherboards, "motherboard_id", "motherboard_name", build.motherboard_id);
        //    ViewBag.optical_drive_id = new SelectList(db.optical_drives, "optical_drive_id", "optical_drive_name", build.optical_drive_id);
        //    ViewBag.power_supply_id = new SelectList(db.power_supplies, "power_supply_id", "power_supply_name", build.power_supply_id);
        //    ViewBag.sound_card_id = new SelectList(db.sound_cards, "sound_card_id", "sound_card_name", build.sound_card_id);
        //    ViewBag.video_adapter_id = new SelectList(db.video_adapters, "video_adapter_id", "video_adapter_name", build.video_adapter_id);
        //    return View(build);
        //}

        //// GET: Builds/Delete/5
        //public ActionResult Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Build build = db.Build.Find(id);
        //    if (build == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(build);
        //}

        //// POST: Builds/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(long id)
        //{
        //    Build build = db.Build.Find(id);
        //    db.Build.Remove(build);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
