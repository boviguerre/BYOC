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
        //private static List<Build> recentBuilds = new List<Build>();
        private static Dictionary<string, List<string>> recentBuildDictionary = new Dictionary<string, List<string>>();
        
        public ActionResult Index()
        {
            //Get top 5 entries, ordered by DateTime
            var recentBuilds = (from build in db.Builds
                                orderby build.BuildTime
                                select build).Take(5);

            List<string> motherboards = new List<string>();
            List<string> processors = new List<string>();
            List<string> memories = new List<string>();
            List<string> hardDrives = new List<string>();
            List<string> soundCards = new List<string>();
            List<string> videoAdapters = new List<string>();
            List<string> opticalDrives = new List<string>();
            List<string> powerSupplies = new List<string>();
            List<string> computerCases = new List<string>();

            //Temporary seed method for lists
            for (int i = 0; i < 5; i++)
            {
                motherboards.Add("Motherboard " + i);
                processors.Add("Processor " + i);
                memories.Add("Memory " + i);
                hardDrives.Add("Hard Drive " + i);
                soundCards.Add("Sound Card " + i);
                videoAdapters.Add("Video Adapter " + i);
                opticalDrives.Add("Optical Drive " + i);
                powerSupplies.Add("Power Supply " + i);
                computerCases.Add("Computer Case " + i);
            }

            //Populates each list with the build components in order
            //foreach (Build element in recentBuilds)
            //{
            //    motherboards.Add((from motherboard in db.motherboards
            //                      where motherboard.motherboard_id == element.motherboard_id
            //                      select motherboard.motherboard_name).ToString());

            //    processors.Add((from processor in db.processors
            //                    where processor.processor_id == element.processor_id
            //                    select processor.processor_name).ToString());

            //    memories.Add((from memory in db.memories
            //                  where memory.memory_id == element.memory_id
            //                  select memory.memory_name).ToString());

            //    hardDrives.Add((from hard_drive in db.hard_drives
            //                    where hard_drive.hard_drive_id == element.hard_drive_id
            //                    select hard_drive.hard_drive_name).ToString());

            //    soundCards.Add((from sound_card in db.sound_cards
            //                    where sound_card.sound_card_id == element.sound_card_id
            //                    select sound_card.sound_card_name).ToString());

            //    videoAdapters.Add((from video_adapter in db.video_adapters
            //                       where video_adapter.video_adapter_id == element.video_adapter_id
            //                       select video_adapter.video_adapter_name).ToString());

            //    opticalDrives.Add((from optical_drive in db.optical_drives
            //                       where optical_drive.optical_drive_id == element.optical_drive_id
            //                       select optical_drive.optical_drive_name).ToString());

            //    powerSupplies.Add((from power_supply in db.power_supplies
            //                       where power_supply.power_supply_id == element.power_supply_id
            //                       select power_supply.power_supply_name).ToString());

            //    computerCases.Add((from computer_case in db.computer_cases
            //                       where computer_case.computer_case_id == element.computer_case_id
            //                       select computer_case.computer_case_name).ToString());
            //}

                //Adds each list of components to the dictionary of recent builds
            recentBuildDictionary.Add("Motherboard", motherboards);
            recentBuildDictionary.Add("Processor", processors);
            recentBuildDictionary.Add("Memory", memories);
            recentBuildDictionary.Add("Hard Drive", hardDrives);
            recentBuildDictionary.Add("Sound Card", soundCards);
            recentBuildDictionary.Add("Video Adapter", videoAdapters);
            recentBuildDictionary.Add("Optical Drive", opticalDrives);
            recentBuildDictionary.Add("Power Supply", powerSupplies);
            recentBuildDictionary.Add("Computer Case", computerCases);

            //ViewData["Five Recent"] = recentBuildDictionary;
            //return View();
            return View(recentBuildDictionary);
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