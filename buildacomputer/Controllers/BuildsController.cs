using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using buildacomputer.Models;
using System.Web.Services;

namespace buildacomputer.Controllers
{
    public class BuildsController : Controller
    {
        private static PartsAndUsersContext db = new PartsAndUsersContext();
        private static Build build = new Build();

        // GET: Builds
        //public ActionResult Method_Motherboard(long? id_number = null)
        public ActionResult Method_Motherboard(string obj, long? id_number)
        {
            if (obj == "mb")
                {   
                    build.addMotherboard(id_number);
                    #region Recreate Lists
                    ViewBag.mb.Clear();
                    foreach (var x in build.processor_ids)
                    {
                        ViewBag.mb.AddRange(db.motherboards.Where(m => m.motherboard_id == x));
                    }
                    ViewBag.pr.Clear();
                    foreach (var x in build.processor_ids)
                    {
                        ViewBag.pr.AddRange(db.processors.Where(m => m.processor_id == x));
                    }
                    ViewBag.me.Clear();
                    foreach (var x in build.memory_ids)
                    {
                        ViewBag.me.AddRange(db.memories.Where(m => m.memory_id == x));
                    }
                    ViewBag.hd.Clear();
                    foreach (var x in build.hard_drive_ids)
                    {
                        ViewBag.hd.AddRange(db.hard_drives.Where(m => m.hard_drive_id == x));
                    }
                    ViewBag.sc.Clear();
                    foreach (var x in build.sound_card_ids)
                    {
                        ViewBag.sc.AddRange(db.sound_cards.Where(m => m.sound_card_id == x));
                    }
                    ViewBag.va.Clear();
                    foreach (var x in build.video_adapter_ids)
                    {
                        ViewBag.va.AddRange(db.video_adapters.Where(m => m.video_adapter_id == x));
                    }
                    ViewBag.od.Clear();
                    foreach (var x in build.optical_drive_ids)
                    {
                        ViewBag.od.AddRange(db.optical_drives.Where(m => m.optical_drive_id == x));
                    }
                    ViewBag.ps.Clear();
                    foreach (var x in build.power_supply_ids)
                    {
                        ViewBag.ps.AddRange(db.power_supplies.Where(m => m.power_supply_id == x));
                    }
                    ViewBag.cc.Clear();
                    foreach (var x in build.computer_case_ids)
                    {
                        ViewBag.cc.AddRange(db.computer_cases.Where(m => m.computer_case_id == x));
                    }
                    #endregion
                    Url.Action("Method_Motherboard", "#pr");
                }
            return View();
            }
                
        public ActionResult Method_Processor(string obj, long? id_number)
        {

            if (obj == "pr")
                {
                    build.addProcessor_id(id_number);
                    #region Recreate Lists
                    ViewBag.mb.Clear();
                    foreach (var x in build.processor_ids)
                    {
                        ViewBag.mb.AddRange(db.motherboards.Where(m => m.motherboard_id == x));
                    }
                    ViewBag.pr.Clear();
                    foreach (var x in build.processor_ids)
                    {
                        ViewBag.pr.AddRange(db.processors.Where(m => m.processor_id == x));
                    }
                    ViewBag.me.Clear();
                    foreach (var x in build.memory_ids)
                    {
                        ViewBag.me.AddRange(db.memories.Where(m => m.memory_id == x));
                    }
                    ViewBag.hd.Clear();
                    foreach (var x in build.hard_drive_ids)
                    {
                        ViewBag.hd.AddRange(db.hard_drives.Where(m => m.hard_drive_id == x));
                    }
                    ViewBag.sc.Clear();
                    foreach (var x in build.sound_card_ids)
                    {
                        ViewBag.sc.AddRange(db.sound_cards.Where(m => m.sound_card_id == x));
                    }
                    ViewBag.va.Clear();
                    foreach (var x in build.video_adapter_ids)
                    {
                        ViewBag.va.AddRange(db.video_adapters.Where(m => m.video_adapter_id == x));
                    }
                    ViewBag.od.Clear();
                    foreach (var x in build.optical_drive_ids)
                    {
                        ViewBag.od.AddRange(db.optical_drives.Where(m => m.optical_drive_id == x));
                    }
                    ViewBag.ps.Clear();
                    foreach (var x in build.power_supply_ids)
                    {
                        ViewBag.ps.AddRange(db.power_supplies.Where(m => m.power_supply_id == x));
                    }
                    ViewBag.cc.Clear();
                    foreach (var x in build.computer_case_ids)
                    {
                        ViewBag.cc.AddRange(db.computer_cases.Where(m => m.computer_case_id == x));
                    }
                    #endregion
                    if (build.motherboard_id == null)
                        Url.Action("Method_Motherboard", "#mb");
                    else
                        Url.Action("Method_Motherboard", "#me");
                }
            return View();
        }
        
        //public ActionResult Method_Memories(string obj, long? id_number)
        //{
        //    if (obj == "me")
        //        {
        //            build.addMemory_id(id_number);
        //            #region Recreate Lists
        //            ViewBag.mb.Clear();
        //            foreach (var x in build.processor_ids)
        //            {
        //                ViewBag.mb.AddRange(db.motherboards.Where(m => m.motherboard_id == x));
        //            }
        //            ViewBag.pr.Clear();
        //            foreach (var x in build.processor_ids)
        //            {
        //                ViewBag.pr.AddRange(db.processors.Where(m => m.processor_id == x));
        //            }
        //            ViewBag.me.Clear();
        //            foreach (var x in build.memory_ids)
        //            {
        //                ViewBag.me.AddRange(db.memories.Where(m => m.memory_id == x));
        //            }
        //            ViewBag.hd.Clear();
        //            foreach (var x in build.hard_drive_ids)
        //            {
        //                ViewBag.hd.AddRange(db.hard_drives.Where(m => m.hard_drive_id == x));
        //            }
        //            ViewBag.sc.Clear();
        //            foreach (var x in build.sound_card_ids)
        //            {
        //                ViewBag.sc.AddRange(db.sound_cards.Where(m => m.sound_card_id == x));
        //            }
        //            ViewBag.va.Clear();
        //            foreach (var x in build.video_adapter_ids)
        //            {
        //                ViewBag.va.AddRange(db.video_adapters.Where(m => m.video_adapter_id == x));
        //            }
        //            ViewBag.od.Clear();
        //            foreach (var x in build.optical_drive_ids)
        //            {
        //                ViewBag.od.AddRange(db.optical_drives.Where(m => m.optical_drive_id == x));
        //            }
        //            ViewBag.ps.Clear();
        //            foreach (var x in build.power_supply_ids)
        //            {
        //                ViewBag.ps.AddRange(db.power_supplies.Where(m => m.power_supply_id == x));
        //            }
        //            ViewBag.cc.Clear();
        //            foreach (var x in build.computer_case_ids)
        //            {
        //                ViewBag.cc.AddRange(db.computer_cases.Where(m => m.computer_case_id == x));
        //            }
        //            #endregion
        //            if (build.motherboard_id == null)
        //                Url.Action("Method_Motherboard", "#mb");
        //            else
        //                Url.Action("Method_Motherboard", "#hd");
        //        }
        //    return View();
        //}

        //public ActionResult Method_HardDrive(string obj, long? id_number)
        //{
        //        if (obj == "hd")
        //        {
        //            build.addHard_drive_id(id_number);
        //            #region Recreate Lists
        //            ViewBag.mb.Clear();
        //            foreach (var x in build.processor_ids)
        //            {
        //                ViewBag.mb.AddRange(db.motherboards.Where(m => m.motherboard_id == x));
        //            }
        //            ViewBag.pr.Clear();
        //            foreach (var x in build.processor_ids)
        //            {
        //                ViewBag.pr.AddRange(db.processors.Where(m => m.processor_id == x));
        //            }
        //            ViewBag.me.Clear();
        //            foreach (var x in build.memory_ids)
        //            {
        //                ViewBag.me.AddRange(db.memories.Where(m => m.memory_id == x));
        //            }
        //            ViewBag.hd.Clear();
        //            foreach (var x in build.hard_drive_ids)
        //            {
        //                ViewBag.hd.AddRange(db.hard_drives.Where(m => m.hard_drive_id == x));
        //            }
        //            ViewBag.sc.Clear();
        //            foreach (var x in build.sound_card_ids)
        //            {
        //                ViewBag.sc.AddRange(db.sound_cards.Where(m => m.sound_card_id == x));
        //            }
        //            ViewBag.va.Clear();
        //            foreach (var x in build.video_adapter_ids)
        //            {
        //                ViewBag.va.AddRange(db.video_adapters.Where(m => m.video_adapter_id == x));
        //            }
        //            ViewBag.od.Clear();
        //            foreach (var x in build.optical_drive_ids)
        //            {
        //                ViewBag.od.AddRange(db.optical_drives.Where(m => m.optical_drive_id == x));
        //            }
        //            ViewBag.ps.Clear();
        //            foreach (var x in build.power_supply_ids)
        //            {
        //                ViewBag.ps.AddRange(db.power_supplies.Where(m => m.power_supply_id == x));
        //            }
        //            ViewBag.cc.Clear();
        //            foreach (var x in build.computer_case_ids)
        //            {
        //                ViewBag.cc.AddRange(db.computer_cases.Where(m => m.computer_case_id == x));
        //            }
        //            #endregion
        //            if (build.motherboard_id == null)
        //                Url.Action("Method_Motherboard", "#mb");
        //            else
        //                Url.Action("Method_Motherboard", "#sc");
        //        }
        //    return View();
        //}

        //public ActionResult Method_SoundCard(string obj, long? id_number)
        //{
        //        if (obj == "sc")
        //        {
        //            build.addSound_card_id(id_number);
        //            #region Recreate Lists
        //            ViewBag.mb.Clear();
        //            foreach (var x in build.processor_ids)
        //            {
        //                ViewBag.mb.AddRange(db.motherboards.Where(m => m.motherboard_id == x));
        //            }
        //            ViewBag.pr.Clear();
        //            foreach (var x in build.processor_ids)
        //            {
        //                ViewBag.pr.AddRange(db.processors.Where(m => m.processor_id == x));
        //            }
        //            ViewBag.me.Clear();
        //            foreach (var x in build.memory_ids)
        //            {
        //                ViewBag.me.AddRange(db.memories.Where(m => m.memory_id == x));
        //            }
        //            ViewBag.hd.Clear();
        //            foreach (var x in build.hard_drive_ids)
        //            {
        //                ViewBag.hd.AddRange(db.hard_drives.Where(m => m.hard_drive_id == x));
        //            }
        //            ViewBag.sc.Clear();
        //            foreach (var x in build.sound_card_ids)
        //            {
        //                ViewBag.sc.AddRange(db.sound_cards.Where(m => m.sound_card_id == x));
        //            }
        //            ViewBag.va.Clear();
        //            foreach (var x in build.video_adapter_ids)
        //            {
        //                ViewBag.va.AddRange(db.video_adapters.Where(m => m.video_adapter_id == x));
        //            }
        //            ViewBag.od.Clear();
        //            foreach (var x in build.optical_drive_ids)
        //            {
        //                ViewBag.od.AddRange(db.optical_drives.Where(m => m.optical_drive_id == x));
        //            }
        //            ViewBag.ps.Clear();
        //            foreach (var x in build.power_supply_ids)
        //            {
        //                ViewBag.ps.AddRange(db.power_supplies.Where(m => m.power_supply_id == x));
        //            }
        //            ViewBag.cc.Clear();
        //            foreach (var x in build.computer_case_ids)
        //            {
        //                ViewBag.cc.AddRange(db.computer_cases.Where(m => m.computer_case_id == x));
        //            }
        //            #endregion
        //            if (build.motherboard_id == null)
        //                Url.Action("Method_Motherboard", "#mb");
        //            else
        //                Url.Action("Method_Motherboard", "#va");
        //        }
        //    return View();
        //}

        //public ActionResult Method_VideoAdapter(string obj, long? id_number)
        //{
        //        if (obj == "va")
        //        {
        //            build.addVideo_adapter_id(id_number);
        //            #region Recreate Lists
        //            ViewBag.mb.Clear();
        //            foreach (var x in build.processor_ids)
        //            {
        //                ViewBag.mb.AddRange(db.motherboards.Where(m => m.motherboard_id == x));
        //            }
        //            ViewBag.pr.Clear();
        //            foreach (var x in build.processor_ids)
        //            {
        //                ViewBag.pr.AddRange(db.processors.Where(m => m.processor_id == x));
        //            }
        //            ViewBag.me.Clear();
        //            foreach (var x in build.memory_ids)
        //            {
        //                ViewBag.me.AddRange(db.memories.Where(m => m.memory_id == x));
        //            }
        //            ViewBag.hd.Clear();
        //            foreach (var x in build.hard_drive_ids)
        //            {
        //                ViewBag.hd.AddRange(db.hard_drives.Where(m => m.hard_drive_id == x));
        //            }
        //            ViewBag.sc.Clear();
        //            foreach (var x in build.sound_card_ids)
        //            {
        //                ViewBag.sc.AddRange(db.sound_cards.Where(m => m.sound_card_id == x));
        //            }
        //            ViewBag.va.Clear();
        //            foreach (var x in build.video_adapter_ids)
        //            {
        //                ViewBag.va.AddRange(db.video_adapters.Where(m => m.video_adapter_id == x));
        //            }
        //            ViewBag.od.Clear();
        //            foreach (var x in build.optical_drive_ids)
        //            {
        //                ViewBag.od.AddRange(db.optical_drives.Where(m => m.optical_drive_id == x));
        //            }
        //            ViewBag.ps.Clear();
        //            foreach (var x in build.power_supply_ids)
        //            {
        //                ViewBag.ps.AddRange(db.power_supplies.Where(m => m.power_supply_id == x));
        //            }
        //            ViewBag.cc.Clear();
        //            foreach (var x in build.computer_case_ids)
        //            {
        //                ViewBag.cc.AddRange(db.computer_cases.Where(m => m.computer_case_id == x));
        //            }
        //            #endregion
        //            if (build.motherboard_id == null)
        //                Url.Action("Method_Motherboard", "#mb");
        //            else
        //                Url.Action("Method_Motherboard", "#od");
        //        }
        //    return View();
        //}

        //public ActionResult Method_OpticalDrives(string obj, long? id_number)
        //{
        //        if (obj == "od")
        //        {
        //            build.addOptical_drive_id(id_number);
        //            #region Recreate Lists
        //            ViewBag.mb.Clear();
        //            foreach (var x in build.processor_ids)
        //            {
        //                ViewBag.mb.AddRange(db.motherboards.Where(m => m.motherboard_id == x));
        //            }
        //            ViewBag.pr.Clear();
        //            foreach (var x in build.processor_ids)
        //            {
        //                ViewBag.pr.AddRange(db.processors.Where(m => m.processor_id == x));
        //            }
        //            ViewBag.me.Clear();
        //            foreach (var x in build.memory_ids)
        //            {
        //                ViewBag.me.AddRange(db.memories.Where(m => m.memory_id == x));
        //            }
        //            ViewBag.hd.Clear();
        //            foreach (var x in build.hard_drive_ids)
        //            {
        //                ViewBag.hd.AddRange(db.hard_drives.Where(m => m.hard_drive_id == x));
        //            }
        //            ViewBag.sc.Clear();
        //            foreach (var x in build.sound_card_ids)
        //            {
        //                ViewBag.sc.AddRange(db.sound_cards.Where(m => m.sound_card_id == x));
        //            }
        //            ViewBag.va.Clear();
        //            foreach (var x in build.video_adapter_ids)
        //            {
        //                ViewBag.va.AddRange(db.video_adapters.Where(m => m.video_adapter_id == x));
        //            }
        //            ViewBag.od.Clear();
        //            foreach (var x in build.optical_drive_ids)
        //            {
        //                ViewBag.od.AddRange(db.optical_drives.Where(m => m.optical_drive_id == x));
        //            }
        //            ViewBag.ps.Clear();
        //            foreach (var x in build.power_supply_ids)
        //            {
        //                ViewBag.ps.AddRange(db.power_supplies.Where(m => m.power_supply_id == x));
        //            }
        //            ViewBag.cc.Clear();
        //            foreach (var x in build.computer_case_ids)
        //            {
        //                ViewBag.cc.AddRange(db.computer_cases.Where(m => m.computer_case_id == x));
        //            }
        //            #endregion
        //            if (build.motherboard_id == null)
        //                Url.Action("Method_Motherboard", "#mb");
        //            else
        //                Url.Action("Method_Motherboard", "#ps");
        //        }
        //    return View();
        //}

        //public ActionResult Method_PowerSupply(string obj, long? id_number)
        //{
        //        if (obj == "ps")
        //        {
        //            build.addPower_supply_id(id_number);
        //            #region Recreate Lists
        //            ViewBag.mb.Clear();
        //            foreach (var x in build.processor_ids)
        //            {
        //                ViewBag.mb.AddRange(db.motherboards.Where(m => m.motherboard_id == x));
        //            }
        //            ViewBag.pr.Clear();
        //            foreach (var x in build.processor_ids)
        //            {
        //                ViewBag.pr.AddRange(db.processors.Where(m => m.processor_id == x));
        //            }
        //            ViewBag.me.Clear();
        //            foreach (var x in build.memory_ids)
        //            {
        //                ViewBag.me.AddRange(db.memories.Where(m => m.memory_id == x));
        //            }
        //            ViewBag.hd.Clear();
        //            foreach (var x in build.hard_drive_ids)
        //            {
        //                ViewBag.hd.AddRange(db.hard_drives.Where(m => m.hard_drive_id == x));
        //            }
        //            ViewBag.sc.Clear();
        //            foreach (var x in build.sound_card_ids)
        //            {
        //                ViewBag.sc.AddRange(db.sound_cards.Where(m => m.sound_card_id == x));
        //            }
        //            ViewBag.va.Clear();
        //            foreach (var x in build.video_adapter_ids)
        //            {
        //                ViewBag.va.AddRange(db.video_adapters.Where(m => m.video_adapter_id == x));
        //            }
        //            ViewBag.od.Clear();
        //            foreach (var x in build.optical_drive_ids)
        //            {
        //                ViewBag.od.AddRange(db.optical_drives.Where(m => m.optical_drive_id == x));
        //            }
        //            ViewBag.ps.Clear();
        //            foreach (var x in build.power_supply_ids)
        //            {
        //                ViewBag.ps.AddRange(db.power_supplies.Where(m => m.power_supply_id == x));
        //            }
        //            ViewBag.cc.Clear();
        //            foreach (var x in build.computer_case_ids)
        //            {
        //                ViewBag.cc.AddRange(db.computer_cases.Where(m => m.computer_case_id == x));
        //            }
        //            #endregion
        //            if (build.motherboard_id == null)
        //                Url.Action("Method_Motherboard", "#mb");
        //            else
        //                Url.Action("Method_Motherboard", "#hd");
        //        }
        //    return View();
        //}

        //public ActionResult Method_ComputerCase(string obj, long? id_number)
        //{
        //        if (obj == "cc")
        //        {
        //            build.addComputer_case_id(id_number);
        //            #region Recreate Lists
        //            ViewBag.mb.Clear();
        //            foreach (var x in build.processor_ids)
        //            {
        //                ViewBag.mb.AddRange(db.motherboards.Where(m => m.motherboard_id == x));
        //            }
        //            ViewBag.pr.Clear();
        //            foreach (var x in build.processor_ids)
        //            {
        //                ViewBag.pr.AddRange(db.processors.Where(m => m.processor_id == x));
        //            }
        //            ViewBag.me.Clear();
        //            foreach (var x in build.memory_ids)
        //            {
        //                ViewBag.me.AddRange(db.memories.Where(m => m.memory_id == x));
        //            }
        //            ViewBag.hd.Clear();
        //            foreach (var x in build.hard_drive_ids)
        //            {
        //                ViewBag.hd.AddRange(db.hard_drives.Where(m => m.hard_drive_id == x));
        //            }
        //            ViewBag.sc.Clear();
        //            foreach (var x in build.sound_card_ids)
        //            {
        //                ViewBag.sc.AddRange(db.sound_cards.Where(m => m.sound_card_id == x));
        //            }
        //            ViewBag.va.Clear();
        //            foreach (var x in build.video_adapter_ids)
        //            {
        //                ViewBag.va.AddRange(db.video_adapters.Where(m => m.video_adapter_id == x));
        //            }
        //            ViewBag.od.Clear();
        //            foreach (var x in build.optical_drive_ids)
        //            {
        //                ViewBag.od.AddRange(db.optical_drives.Where(m => m.optical_drive_id == x));
        //            }
        //            ViewBag.ps.Clear();
        //            foreach (var x in build.power_supply_ids)
        //            {
        //                ViewBag.ps.AddRange(db.power_supplies.Where(m => m.power_supply_id == x));
        //            }
        //            ViewBag.cc.Clear();
        //            foreach (var x in build.computer_case_ids)
        //            {
        //                ViewBag.cc.AddRange(db.computer_cases.Where(m => m.computer_case_id == x));
        //            }
        //            #endregion
        //            #region To Save
        //            if (build.motherboard_id != null && build.processor_id != null && build.memory_id != null &&
        //                build.hard_drive_id != null && (db.motherboards.Where(m => m.motherboard_id == build.motherboard_id)
        //                .Select(m => m.gpu_id) != null || build.video_adapter_id != null) && build.power_supply_id != null &&
        //                build.computer_case_id != null)
        //                Url.Action("Save");
        //            #endregion
        //            #region Redirects
        //            else if (build.motherboard_id == null)
        //                Url.Action("Method_Motherboard", "#mb");
        //            else if (build.processor_id == null)
        //                Url.Action("Method_Motherboard", "#pr");
        //            else if (build.memory_id == null)
        //                Url.Action("Method_Motherboard", "#me");
        //            else if (build.hard_drive_id == null)
        //                Url.Action("Method_Motherboard", "#hd");
        //            else if (db.motherboards.Where(m => m.motherboard_id == build.motherboard_id)
        //                                    .Select(m => m.gpu_id) != null || build.video_adapter_id != null)
        //                Url.Action("Method_Motherboard", "#va");
        //            else if (build.power_supply_id == null)
        //                Url.Action("Method_Motherboard", "#ps");
        //            else
        //                Url.Action("Method_Motherboard", "#cc");
        //            #endregion
        //        }
        //        return View();
        //   }


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
        //        return RedirectToAction("Method_Motherboard");
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
        //        return RedirectToAction("Method_Motherboard");
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
        //    return RedirectToAction("Method_Motherboard");
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
