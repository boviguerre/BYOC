using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace buildacomputer.Models
{
    public class Build
    {

        #region Constructors

        public Build()
        {
            motherboard_ids     = db.motherboards.Select(m => m.motherboard_id).ToList();
            processor_ids       = db.processors.Select(p => p.processor_id).ToList();
            memory_ids          = db.memories.Select(m => m.memory_id).ToList();
            hard_drive_ids      = db.hard_drives.Select(h => h.hard_drive_id).ToList();
            sound_card_ids      = db.sound_cards.Select(s => s.sound_card_id).ToList();
            video_adapter_ids   = db.video_adapters.Select(v => v.video_adapter_id).ToList();
            optical_drive_ids   = db.optical_drives.Select(o => o.optical_drive_id).ToList();
            power_supply_ids    = db.power_supplies.Select(p => p.power_supply_id).ToList();
            computer_case_ids   = db.computer_cases.Select(c => c.computer_case_id).ToList();
            //import all possible parts
            defValues.Add(motherboard_ids);
            defValues.Add(processor_ids);
            defValues.Add(memory_ids);
            defValues.Add(hard_drive_ids);
            defValues.Add(sound_card_ids);
            defValues.Add(video_adapter_ids);
            defValues.Add(optical_drive_ids);
            defValues.Add(power_supply_ids);
            defValues.Add(computer_case_ids);
        }
        #endregion

        [Key]
        public long? buildID { get; set; }
        public long? motherboard_id { get; set; }
        public long? computer_case_id { get; set; }
        public long? hard_drive_id { get; set; }
        public long? optical_drive_id { get; set; }
        public long? power_supply_id { get; set; }
        public long? processor_id { get; set; }
        public long? sound_card_id { get; set; }
        public long? video_adapter_id { get; set; }
        public long? memory_id { get; set; }
        public string buildType { get; set; }
        public int iterator { get; set; }
        public DateTime BuildTime { get; set; }
        private List<List<long>> defValues = new List<List<long>>();
        private PartsAndUsersContext db = new PartsAndUsersContext();

        public virtual ICollection<UserBuilds> UserBuilds { get; set; }
        public virtual motherboard motherboard { get; set; }
        public virtual computer_cases computer_cases { get; set; }
        public virtual hard_drives hard_drives { get; set; }
        public virtual optical_drives optical_drives { get; set; }
        public virtual power_supplies power_supplies { get; set; }
        public virtual processor processor { get; set; }
        public virtual sound_cards sound_cards { get; set; }
        public virtual video_adapters video_adapters { get; set; }
        public virtual memory memory { get; set; }

        public int subtractPart(int id)
        {
            id--;
            if (id == 0)
                this.motherboard_id = null;
            else if (id == 1)
                this.processor_id = null;
            else if (id == 2)
                this.memory_id = null;
            else if (id == 3)
                this.hard_drive_id = null;
            else if (id == 4)
                this.sound_card_id = null;
            else if (id == 5)
                this.video_adapter_id = null;
            else if (id == 6)
                this.optical_drive_id = null;
            else if (id == 7)
                this.power_supply_id = null;
            else if (id == 8)
                this.computer_case_id = null;
            reseedPotential();
            if (motherboard_id != null)
            {
                addMotherboardHelper();
                motherboard_ids.Clear();
            }
            return id;
        }

        #region Possible parts
        public List<long> motherboard_ids { get; set; }
        public List<long> computer_case_ids { get; set; }
        public List<long> hard_drive_ids { get; set; }
        public List<long> optical_drive_ids { get; set; }
        public List<long> power_supply_ids { get; set; }
        public List<long> processor_ids { get; set; }
        public List<long> sound_card_ids { get; set; }
        public List<long> video_adapter_ids { get; set; }
        public List<long> memory_ids { get; set; }
        #endregion

        #region Public Add Parts
        public void addMotherboard(long? x)
        {
            motherboard_id = x;
            motherboard_ids.Clear();
            addMotherboardHelper();
        }
        public void addComputer_case_id(long? x)
        {
            computer_case_id = x;
            computer_case_ids.Clear();
        }
        public void addHard_drive_id(long? x)
        {
            hard_drive_id = x;
            hard_drive_ids.Clear();
        }
        public void addOptical_drive_id(long? x)
        {
            optical_drive_id = x;
            optical_drive_ids.Clear();
        }
        public void addPower_supply_id(long? x)
        {
            power_supply_id = x;
            power_supply_ids.Clear();
        }
        public void addProcessor_id(long? x)
        {
            processor_id = x;
        }
        public void addSound_card_id(long? x)
        {
            sound_card_id = x;
            sound_card_ids.Clear();
        }
        public void addVideo_adapter_id(long? x)
        {
            video_adapter_id = x;
            video_adapter_ids.Clear();
        }
        public void addMemory_id(long? x)
        {
            memory_id = x;
            memory_ids.Clear();
        }
        #endregion

        public void substractPart(long id)
        {
            if (this.motherboard_id == id)
                this.motherboard_id = null;
            else if (this.computer_case_id == id)
                this.computer_case_id = null;
            else if (this.hard_drive_id == id)
                this.hard_drive_id = null;
            else if (this.optical_drive_id == id)
                this.optical_drive_id = null;
            else if (this.power_supply_id == id)
                this.power_supply_id = null;
            else if (this.processor_id == id)
                this.processor_id = null;
            else if (this.sound_card_id == id)
                this.sound_card_id = null;
            else if (this.video_adapter_id == id)
                this.video_adapter_id = null;
            else if (this.memory_id == id)
                this.memory_id = null;
        }
        private void reseedPotential()
        {
            for (int i = 0; i < defValues.Count; i++)
            {
                if (i == 0)
                {
                    motherboard_ids.Clear();
                    foreach (long x in defValues[i])
                        motherboard_ids.Add(x);
                }
                if (i == 1)
                {
                    processor_ids.Clear();
                    foreach (long x in defValues[i])
                        processor_ids.Add(x);
                }
                if (i == 2)
                {
                    memory_ids.Clear();
                    foreach (long x in defValues[i])
                        memory_ids.Add(x);
                }
                if (i == 3)
                {
                    hard_drive_ids.Clear();
                    foreach (long x in defValues[i])
                        hard_drive_ids.Add(x);
                }
                if (i == 4)
                {
                    sound_card_ids.Clear();
                    foreach (long x in defValues[i])
                        sound_card_ids.Add(x);
                }
                if (i == 5)
                {
                    video_adapter_ids.Clear();
                    foreach (long x in defValues[i])
                        video_adapter_ids.Add(x);
                }
                if (i == 6)
                {
                    optical_drive_ids.Clear();
                    foreach (long x in defValues[i])
                        optical_drive_ids.Add(x);
                }
                if (i == 7)
                {
                    power_supply_ids.Clear();
                    foreach (long x in defValues[i])
                        power_supply_ids.Add(x);
                }
                if (i == 8)
                {
                    computer_case_ids.Clear();
                    foreach (long x in defValues[i])
                        computer_case_ids.Add(x);
                }
            }
        }
        #region
        private void MotherBoard_Processor()
        {
            if (motherboard_id != null)
            {
                List<long> NewProcessor = new List<long>();
                long[] processor_ID = db.processors.Select(s => s.processor_socket_id).ToArray();
                long[] processor_ID2 = db.motherboards.Select(s => s.processor_socket_id).ToArray();
                foreach (long x in processor_ID)
                    foreach (long y in processor_ID2)
                        if (x == y)
                        {
                            NewProcessor.AddRange(db.processors.Where(s => s.processor_socket_id == x)
                                                               .Select(s => s.processor_id).ToList()
                                                  );
                        }
                processor_ids.Clear();
                processor_ids = NewProcessor;
            }
        }
        private void MotherBoard_Memories()
        {
            if (motherboard_id != null)
            {
                List<long> NewMemory = new List<long>();
                long[] memory_ID = db.memories.Select(s => s.memory_type_id).ToArray();
                long[] memory_ID2 = db.motherboards.Select(s => s.memory_type_id).ToArray();
                foreach (long x in memory_ID)
                    foreach (long y in memory_ID2)
                        if (x == y)
                        {
                            NewMemory.AddRange(db.memories.Where(s => s.memory_type_id == x)
                                                          .Select(s => s.memory_id).ToList()
                                              );
                        }
                memory_ids.Clear();
                memory_ids = NewMemory;
            }
        }
        private void MotherBoard_HardDrive()
        {
            if (motherboard_id != null)
            {
                List<long> NewHard= new List<long>();
                long[] hard_ID = db.hard_drives.Select(s => s.bus_interface_id).ToArray();
                long[] hard_ID2 = db.l_motherboard_bus_interfaces.Where(s => s.motherboard_id == motherboard_id)
                                                                 .Select(s => s.bus_interface_id).ToArray();
                foreach (long x in hard_ID)
                    foreach (long y in hard_ID2)
                        if (x == y)
                        {
                            NewHard.AddRange(db.hard_drives.Where(s => s.bus_interface_id == x)
                                                           .Select(s => s.hard_drive_id).ToList()
                                            );
                        }
                hard_drive_ids.Clear();
                hard_drive_ids = NewHard;
            }
        }
        private void MotherBoard_SoundCard()
        {
            if (motherboard_id != null)
            {
                List<long> NewSound = new List<long>();
                long[] sound_ID = db.sound_cards.Select(s => s.expansion_slot_id).ToArray();
                long[] sound_ID2 = db.l_motherboards_expansion_slots.Where(s => s.motherboard_id == motherboard_id)
                                                                    .Select(s => s.expansion_slot_id).ToArray();
                foreach (long x in sound_ID)
                    foreach (long y in sound_ID2)
                        if (x == y)
                        {
                            NewSound.AddRange(db.sound_cards.Where(s => s.expansion_slot_id == x)
                                                               .Select(s => s.sound_card_id).ToList()
                                                  );
                        }
                sound_card_ids.Clear();
                sound_card_ids = NewSound;
            }
        }
        private void MotherBoard_VideoAdapter()
        {
            if (motherboard_id != null)
            {
                List<long> NewVideo = new List<long>();
                long[] video_ID = db.video_adapters.Select(s => s.expansion_slot_id).ToArray();
                long[] video_ID2 = db.l_motherboards_expansion_slots.Where(s => s.motherboard_id == motherboard_id)
                                                                    .Select(s => s.expansion_slot_id).ToArray();
                foreach (long x in video_ID)
                    foreach (long y in video_ID2)
                        if (x == y)
                        {
                            NewVideo.AddRange(db.video_adapters.Where(s => s.expansion_slot_id == x)
                                                               .Select(s => s.video_adapter_id).ToList()
                                                  );
                        }
                processor_ids.Clear();
                processor_ids = NewVideo;
            }
        }
        private void MotherBoard_OpticalDrive()
        {
            if (motherboard_id != null)
            {
                List<long> NewOptical = new List<long>();
                long[] optical_ID = db.optical_drives.Select(s => s.bus_interface_id).ToArray();
                long[] optical_ID2 = db.l_motherboard_bus_interfaces.Where(s => s.motherboard_id == motherboard_id)
                                                                 .Select(s => s.bus_interface_id).ToArray();
                foreach (long x in optical_ID)
                    foreach (long y in optical_ID2)
                        if (x == y)
                        {
                            NewOptical.AddRange(db.optical_drives.Where(s => s.bus_interface_id == x)
                                                           .Select(s => s.optical_drive_id).ToList()
                                            );
                        }
                optical_drive_ids.Clear();
                hard_drive_ids = NewOptical;
            }
        }
        private void MotherBoard_PowerSupply()
        {
            if (motherboard_id != null)
            {
                List<long> NewPower = new List<long>();
                long[] power_ID = db.power_supplies.Select(s => s.power_supply_standard_id).ToArray();
                long[] power_ID2 = db.motherboards.Select(s => s.power_supply_standard_id).ToArray();
                foreach (long x in power_ID)
                    foreach (long y in power_ID2)
                        if (x == y)
                        {
                            NewPower.AddRange(db.power_supplies.Where(s => s.power_supply_standard_id == x)
                                                               .Select(s => s.power_supply_id).ToList()
                                                  );
                        }
                processor_ids.Clear();
                processor_ids = NewPower;
            }
        }
        private void MotherBoard_Case()
        {
            if (motherboard_id != null)
            {
                List<long> NewCase = new List<long>();
                long[] case_ID = db.computer_cases.Select(s => s.motherboard_form_factor_id).ToArray();
                long[] case_ID2 = db.motherboards.Select(s => s.motherboard_form_factor_id).ToArray();
                foreach (long x in case_ID)
                    foreach (long y in case_ID2)
                        if (x == y)
                        {
                            NewCase.AddRange(db.computer_cases.Where(s => s.motherboard_form_factor_id == x)
                                                               .Select(s => s.computer_case_id).ToList()
                                                  );
                        }
                processor_ids.Clear();
                processor_ids = NewCase;
            }
        }
        private void addMotherboardHelper()
        {

            MotherBoard_Processor();
            MotherBoard_Case();
            MotherBoard_HardDrive();
            MotherBoard_Memories();
            MotherBoard_PowerSupply();
            MotherBoard_SoundCard();
            MotherBoard_VideoAdapter();
            MotherBoard_OpticalDrive();
        }
        #endregion
    }
}