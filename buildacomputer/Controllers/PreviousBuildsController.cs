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
        private static Dictionary<string, List<string>> previousBuildsDictionary = new Dictionary<string, List<string>>();
        private static List<Build> displayBuilds = new List<Build>();

        // GET: PreviousBuilds
        public async Task<ActionResult> Index()
        {
            string currentUser = User.Identity.ToString();
            List<int> oldBuild = db.UserBuilds.Where(u => u.userID == currentUser).Select(b => b.buildID).ToList();

            List<string> motherboards = new List<string>();
            List<string> processors = new List<string>();
            List<string> memories = new List<string>();
            List<string> hardDrives = new List<string>();
            List<string> soundCards = new List<string>();
            List<string> videoAdapters = new List<string>();
            List<string> opticalDrives = new List<string>();
            List<string> powerSupplies = new List<string>();
            List<string> computerCases = new List<string>();

            foreach(int inOldBuilds in oldBuild)
            {
                displayBuilds.Add(db.Builds.Where(b => b.buildID == inOldBuilds).Select(b => b).Single<Build>());
            }

            foreach(Build display in displayBuilds)
            {
                motherboards.Add((from motherboard in db.motherboards
                                  where motherboard.motherboard_id == display.motherboard_id
                                  select motherboard.motherboard_name).ToString());

                processors.Add((from processor in db.processors
                                where processor.processor_id == display.processor_id
                                select processor.processor_name).ToString());

                memories.Add((from memory in db.memories
                              where memory.memory_id == display.memory_id
                              select memory.memory_name).ToString());

                hardDrives.Add((from hard_drive in db.hard_drives
                                where hard_drive.hard_drive_id == display.hard_drive_id
                                select hard_drive.hard_drive_name).ToString());

                soundCards.Add((from sound_card in db.sound_cards
                                where sound_card.sound_card_id == display.sound_card_id
                                select sound_card.sound_card_name).ToString());

                videoAdapters.Add((from video_adapter in db.video_adapters
                                   where video_adapter.video_adapter_id == display.video_adapter_id
                                   select video_adapter.video_adapter_name).ToString());

                opticalDrives.Add((from optical_drive in db.optical_drives
                                   where optical_drive.optical_drive_id == display.optical_drive_id
                                   select optical_drive.optical_drive_name).ToString());

                powerSupplies.Add((from power_supply in db.power_supplies
                                   where power_supply.power_supply_id == display.power_supply_id
                                   select power_supply.power_supply_name).ToString());

                computerCases.Add((from computer_case in db.computer_cases
                                   where computer_case.computer_case_id == display.computer_case_id
                                   select computer_case.computer_case_name).ToString());
            };

            if (!previousBuildsDictionary.ContainsKey("Motherboard"))
            {
                previousBuildsDictionary.Add("Motherboard", motherboards);
                previousBuildsDictionary.Add("Processor", processors);
                previousBuildsDictionary.Add("Memory", memories);
                previousBuildsDictionary.Add("Hard Drive", hardDrives);
                previousBuildsDictionary.Add("Sound Card", soundCards);
                previousBuildsDictionary.Add("Video Adapter", videoAdapters);
                previousBuildsDictionary.Add("Optical Drive", opticalDrives);
                previousBuildsDictionary.Add("Power Supply", powerSupplies);
                previousBuildsDictionary.Add("Computer Case", computerCases);
            };

            return View(previousBuildsDictionary);
        }
    }
}

