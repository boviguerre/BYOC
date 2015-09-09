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
using System.Data.Linq;
using System.Data.Common;

namespace buildacomputer.Models
{
    public class Build
    {

        #region Constructors

        public Build()
        {
            reseedPotential();
        }
        #endregion

        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        public int buildID { get; set; }
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
        public int iterator { get; set; }  //how many times this build has been built
        public DateTime BuildTime { get; set; }
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

        public void subtractPart(string id)
        {
            if (id == "xmb")
                this.motherboard_id = null;
            else if (id == "xpr")
                this.processor_id = null;
            else if (id == "xme")
                this.memory_id = null;
            else if (id == "xhd")
                this.hard_drive_id = null;
            else if (id == "xsc")
                this.sound_card_id = null;
            else if (id == "xva")
                this.video_adapter_id = null;
            else if (id == "xod")
                this.optical_drive_id = null;
            else if (id == "xps")
                this.power_supply_id = null;
            else if (id == "xcc")
                this.computer_case_id = null;
            reseedPotential();
            if (motherboard_id != null)
            {
                addMotherboardHelper();
                motherboard_ids.Clear();
                motherboard_ids.Add((long)motherboard_id);
            }
            if (processor_id != null)
                if (motherboard_id == null)
                    Processor_Motherboard();
                else
                    MotherBoard_Processor();
            if (memory_id != null)
                if (motherboard_id == null)
                    Memory_Motherboard();
                else
                    MotherBoard_Memories();
            if (hard_drive_id != null)
                if (motherboard_id == null)
                    HardDrive_Motherboard();
                else
                    MotherBoard_HardDrive();
            if (sound_card_id != null)
                if (motherboard_id == null)
                    SoundCard_Motherboard();
                else
                    MotherBoard_SoundCard();
            if (video_adapter_id != null)
                if (motherboard_id == null)
                    VideoAdapter_Motherboard();
                else
                    MotherBoard_VideoAdapter();
            if (optical_drive_id != null)
                if (motherboard_id == null)
                    OpticalDrive_Motherboard();
                else
                    MotherBoard_OpticalDrive();
            if (power_supply_id != null)
                if (motherboard_id == null)
                    PowerSupply_Motherboard();
                else
                    MotherBoard_PowerSupply();
            if (computer_case_id != null)
                if (motherboard_id == null)
                    Case_Motherboard();
                else
                    MotherBoard_Case();
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
            motherboard_ids.Add((long)x);
            addMotherboardHelper();
        }
        public void addComputer_case_id(long? x)
        {
            computer_case_id = x;
            computer_case_ids.Clear();
            computer_case_ids.Add((long)x);
            Case_Motherboard();
        }
        public void addHard_drive_id(long? x)
        {
            hard_drive_id = x;
            hard_drive_ids.Clear();
            hard_drive_ids.Add((long)x);
            HardDrive_Motherboard();
        }
        public void addOptical_drive_id(long? x)
        {
            optical_drive_id = x;
            optical_drive_ids.Clear();
            optical_drive_ids.Add((long)x);
            OpticalDrive_Motherboard();
        }
        public void addPower_supply_id(long? x)
        {
            power_supply_id = x;
            power_supply_ids.Clear();
            power_supply_ids.Add((long)x);
            PowerSupply_Motherboard();
        }
        public void addProcessor_id(long? x)
        {
            processor_id = x;
            processor_ids.Clear();
            processor_ids.Add((long)x);
            Processor_Motherboard();
        }
        public void addSound_card_id(long? x)
        {
            sound_card_id = x;
            sound_card_ids.Clear();
            sound_card_ids.Add((long)x);
            SoundCard_Motherboard();
        }
        public void addVideo_adapter_id(long? x)
        {
            video_adapter_id = x;
            video_adapter_ids.Clear();
            video_adapter_ids.Add((long)x);
            VideoAdapter_Motherboard();
        }
        public void addMemory_id(long? x)
        {
            memory_id = x;
            memory_ids.Clear();
            memory_ids.Add((long)x);
            Memory_Motherboard();
        }
        #endregion

        private void reseedPotential()
        {
            motherboard_ids = db.motherboards.Select(m => m.motherboard_id).ToList();
            processor_ids = db.processors.Select(p => p.processor_id).ToList();
            memory_ids = db.memories.Select(m => m.memory_id).ToList();
            hard_drive_ids = db.hard_drives.Select(h => h.hard_drive_id).ToList();
            sound_card_ids = db.sound_cards.Select(s => s.sound_card_id).ToList();
            video_adapter_ids = db.video_adapters.Select(v => v.video_adapter_id).ToList();
            optical_drive_ids = db.optical_drives.Select(o => o.optical_drive_id).ToList();
            power_supply_ids = db.power_supplies.Select(p => p.power_supply_id).ToList();
            computer_case_ids = db.computer_cases.Select(c => c.computer_case_id).ToList();
        }

        #region
        private void MotherBoard_Processor()
        {
            if (motherboard_id != null)
            {
                List<long> NewProcessor = new List<long>();
                long[] processor_ID = db.processors.Select(s => s.processor_socket_id).ToArray();
                long[] processor_ID2 = db.motherboards.Where(m => m.motherboard_id == (long)motherboard_id).Select(s => s.processor_socket_id).ToArray();
                foreach (long x in processor_ID)
                    foreach (long y in processor_ID2)
                        if (x == y)
                        {
                            NewProcessor.AddRange(db.processors.Where(s => s.processor_socket_id == x && !NewProcessor.Contains(s.processor_id))
                                                               .Select(s => s.processor_id).ToList()
                                                  );
                        }
                processor_ids = NewProcessor;
            }
            else
            {
                List<long> NewProcessor = new List<long>();
                foreach (long item in motherboard_ids)
                {
                    long[] processor_ID = db.processors.Select(s => s.processor_socket_id).ToArray();
                    long[] processor_ID2 = db.motherboards.Where(m => m.motherboard_id == item)
                                                       .Select(s => s.processor_socket_id).ToArray();
                    foreach (long x in processor_ID)
                        foreach (long y in processor_ID2)
                            if (x == y)
                            {
                                    NewProcessor.AddRange(db.processors.Where(s => s.processor_socket_id == x && !NewProcessor.Contains(s.processor_id))
                                                                  .Select(s => s.processor_id).ToList()
                                                      );
                            }
                }
                processor_ids = NewProcessor;
            }
        }
        private void MotherBoard_Memories()
        {
            if (motherboard_id != null)
            {
                List<long> NewMemory = new List<long>();
                long[] memory_ID = db.memories.Select(s => s.memory_type_id).ToArray();
                long[] memory_ID2 = db.motherboards.Where(m => m.motherboard_id == (long)motherboard_id).Select(s => s.memory_type_id).ToArray();
                foreach (long x in memory_ID)
                    foreach (long y in memory_ID2)
                        if (x == y)
                        {
                            NewMemory.AddRange(db.memories.Where(s => s.memory_type_id == x)
                                                          .Select(s => s.memory_id).ToList()
                                              );
                        }
                memory_ids = NewMemory;
            }
            else
            {
                List<long> NewMemory = new List<long>();
                foreach (long item in motherboard_ids)
                {
                    long[] memory_ID = db.memories.Select(s => s.memory_type_id).ToArray();
                    long[] memory_ID2 = db.motherboards.Where(m => m.motherboard_id == item)
                                                       .Select(s => s.memory_type_id).ToArray();
                    foreach (long x in memory_ID)
                        foreach (long y in memory_ID2)
                            if (x == y)
                            {
                                    NewMemory.AddRange(db.memories.Where(s => s.memory_type_id == x && !NewMemory.Contains(s.memory_id))
                                                                  .Select(s => s.memory_id).ToList()
                                                      );
                            }
                    }
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
                            NewHard.AddRange(db.hard_drives.Where(s => s.bus_interface_id == x && !NewHard.Contains(s.hard_drive_id))
                                                           .Select(s => s.hard_drive_id).ToList()
                                            );
                        }
                hard_drive_ids = NewHard;
            }
            else
            {
                List<long> NewHardDrive = new List<long>();
                foreach (long item in motherboard_ids)
                {
                    long[] HardDrive_ID = db.hard_drives.Select(s => s.bus_interface_id).ToArray();
                    long[] HardDrive_ID2 = db.l_motherboard_bus_interfaces.Where(m => m.motherboard_id == item && m.bus_interface_count > 0)
                                                       .Select(s => s.bus_interface_id).ToArray();
                    foreach (long x in HardDrive_ID)
                        foreach (long y in HardDrive_ID2)
                            if (x == y)
                            {
                                    NewHardDrive.AddRange(db.hard_drives.Where(s => s.bus_interface_id == x && !NewHardDrive.Contains(s.hard_drive_id))
                                                                  .Select(s => s.hard_drive_id).ToList()
                                                      );
                            }
                }
                hard_drive_ids = NewHardDrive;
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
                            NewSound.AddRange(db.sound_cards.Where(s => s.expansion_slot_id == x && !NewSound.Contains(s.sound_card_id))
                                                               .Select(s => s.sound_card_id).ToList()
                                                  );
                        }
                sound_card_ids = NewSound;
            }
            else
            {
                List<long> NewSound = new List<long>();
                foreach (long item in motherboard_ids)
                {
                    long[] sound_ID = db.expansion_slots.Select(s => s.expansion_slot_id).ToArray();
                    long[] sound_ID2 = db.l_motherboards_expansion_slots.Where(m => m.motherboard_id == item && m.expansion_slot_count > 0)
                                                       .Select(s => s.expansion_slot_id).ToArray();
                    foreach (long x in sound_ID)
                        foreach (long y in sound_ID2)
                            if (x == y)
                            {
                                    NewSound.AddRange(db.sound_cards.Where(s => s.expansion_slot_id == x && !NewSound.Contains(s.sound_card_id))
                                                                  .Select(s => s.sound_card_id).ToList()
                                                      );
                            }
                }
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
                            NewVideo.AddRange(db.video_adapters.Where(s => s.expansion_slot_id == x && !NewVideo.Contains(s.video_adapter_id))
                                                               .Select(s => s.video_adapter_id).ToList()
                                                  );
                        }
                video_adapter_ids = NewVideo;
            }
            else
            {
                List<long> NewVideo = new List<long>();
                foreach (long item in motherboard_ids)
                {
                    long[] video_ID = db.expansion_slots.Select(s => s.expansion_slot_id).ToArray();
                    long[] video_ID2 = db.l_motherboards_expansion_slots.Where(m => m.motherboard_id == item && m.expansion_slot_count > 0)
                                                       .Select(s => s.expansion_slot_id).ToArray();
                    foreach (long x in video_ID)
                        foreach (long y in video_ID2)
                            if (x == y)
                            {
                                    NewVideo.AddRange(db.video_adapters.Where(s => s.expansion_slot_id == x && !NewVideo.Contains(s.video_adapter_id))
                                                                  .Select(s => s.video_adapter_id).ToList()
                                                      );
                            }
                }
                video_adapter_ids = NewVideo;
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
                            NewOptical.AddRange(db.optical_drives.Where(s => s.bus_interface_id == x && !NewOptical.Contains(s.optical_drive_id))
                                                           .Select(s => s.optical_drive_id).ToList()
                                            );
                        }
                optical_drive_ids = NewOptical;
            }
            else
            {
                List<long> NewOptical = new List<long>();
                foreach (long item in motherboard_ids)
                {
                    long[] optical_ID = db.optical_drives.Select(s => s.bus_interface_id).ToArray();
                    long[] optical_ID2 = db.l_motherboard_bus_interfaces.Where(m => m.motherboard_id == item && m.bus_interface_count > 0)
                                                       .Select(s => s.bus_interface_id).ToArray();
                    foreach (long x in optical_ID)
                        foreach (long y in optical_ID2)
                            if (x == y)
                            {
                                    NewOptical.AddRange(db.optical_drives.Where(s => s.bus_interface_id == x && !NewOptical.Contains(s.optical_drive_id))
                                                                  .Select(s => s.optical_drive_id).ToList()
                                                      );
                            }
                }
                optical_drive_ids = NewOptical;
            }
        }
        private void MotherBoard_PowerSupply()
        {
            if (motherboard_id != null)
            {
                List<long> NewPower = new List<long>();
                long[] power_ID = db.power_supplies.Select(s => s.power_supply_standard_id).ToArray();
                long[] power_ID2 = db.motherboards.Where(m => m.motherboard_id == (long)motherboard_id)
                                                  .Select(s => s.power_supply_standard_id).ToArray();
                foreach (long x in power_ID)
                    foreach (long y in power_ID2)
                        if (x == y)
                        {
                            NewPower.AddRange(db.power_supplies.Where(s => s.power_supply_standard_id == x && !NewPower.Contains(s.power_supply_id) && s.motherboard_form_factor_id == db.motherboards.Where(m => m.motherboard_id == motherboard_id)
                                                                                                                                                                                                      .Select(m => m.motherboard_form_factor_id).FirstOrDefault())
                                                               .Select(s => s.power_supply_id).ToList()
                                                  );
                        }
                power_supply_ids = NewPower;
            }
            else
            {
                List<long> NewPower = new List<long>();
                foreach (long item in motherboard_ids)
                {
                    long[] power_ID = db.power_supplies.Select(s => s.power_supply_standard_id).ToArray();
                    long[] power_ID2 = db.motherboards.Where(m => m.motherboard_id == item)
                                                       .Select(s => s.power_supply_standard_id).ToArray();
                    foreach (long x in power_ID)
                        foreach (long y in power_ID2)
                            if (x == y)
                            {
                                if (!NewPower.Contains(x))
                                {
                                    NewPower.AddRange(db.power_supplies.Where(s => s.power_supply_standard_id == x && !NewPower.Contains(s.power_supply_id) && s.motherboard_form_factor_id == db.motherboards.Where(m => m.motherboard_id == item)
                                                                                                                                                                                                      .Select(m => m.motherboard_form_factor_id).FirstOrDefault())
                                                                  .Select(s => s.power_supply_id).ToList()
                                                      );
                                }
                            }
                }
                power_supply_ids = NewPower;
            }
        }
        private void MotherBoard_Case()
        {
            if (motherboard_id != null)
            {
                List<long> NewCase = new List<long>();
                long[] case_ID = db.computer_cases.Select(s => s.motherboard_form_factor_id).ToArray();
                long[] case_ID2 = db.motherboards.Where(m => m.motherboard_id == (long)motherboard_id)
                                                 .Select(s => s.motherboard_form_factor_id).ToArray();
                foreach (long x in case_ID)
                    foreach (long y in case_ID2)
                        if (x == y)
                        {
                            NewCase.AddRange(db.computer_cases.Where(s => s.motherboard_form_factor_id == x && !NewCase.Contains(s.computer_case_id))
                                                               .Select(s => s.computer_case_id).ToList()
                                                  );
                        }
                computer_case_ids = NewCase;
            }
            else
            {
                List<long> NewCase = new List<long>();
                foreach (long item in motherboard_ids)
                {
                    long[] case_ID = db.motherboard_form_factors.Select(s => s.motherboard_form_factor_id).ToArray();
                    long[] case_ID2 = db.motherboards.Where(m => m.motherboard_id == item)
                                                       .Select(s => s.motherboard_form_factor_id).ToArray();
                    foreach (long x in case_ID)
                        foreach (long y in case_ID2)
                            if (x == y)
                            {
                                if (!NewCase.Contains(x))
                                {
                                    NewCase.AddRange(db.computer_cases.Where(s => s.motherboard_form_factor_id == x && !NewCase.Contains(s.computer_case_id))
                                                                  .Select(s => s.computer_case_id).ToList()
                                                      );
                                }
                            }
                }
                computer_case_ids = NewCase;
            }
        }
        private void Processor_Motherboard()
        {
            if (motherboard_id == null)
            {
                List<long> NewMB = new List<long>();
                long[] mb_ID = db.motherboards.Select(s => s.processor_socket_id).ToArray();
                long mb_ID2 = db.processors.Where(s => s.processor_id == processor_id)
                                           .Select(s => s.processor_socket_id)
                                           .Single();
                foreach (long x in mb_ID)
                    if (x == mb_ID2)
                    {
                        NewMB.AddRange(db.motherboards.Where(s => s.processor_socket_id == x && motherboard_ids.Contains(s.motherboard_id) && !NewMB.Contains(s.motherboard_id))
                                                      .Select(s => s.motherboard_id).ToList()
                                          );
                    }
                motherboard_ids = NewMB;
                MotherBoard_Memories();
                MotherBoard_HardDrive();
                MotherBoard_SoundCard();
                MotherBoard_VideoAdapter();
                MotherBoard_OpticalDrive();
                MotherBoard_PowerSupply();
                MotherBoard_Case();
            }
        }
        private void Memory_Motherboard()
        {
            if (motherboard_id == null)
            {
                List<long> NewMB = new List<long>();
                long[] memory_ID = db.motherboards.Select(s => s.memory_type_id).ToArray();
                long memory_ID2 = db.memories.Where(s => s.memory_id == memory_id)
                                               .Select(s => s.memory_type_id).Single();
                foreach (long x in memory_ID)
                        if (x == memory_ID2)
                        {
                            NewMB.AddRange(db.motherboards.Where(s => s.memory_type_id == x && motherboard_ids.Contains(s.motherboard_id) && !NewMB.Contains(s.motherboard_id))
                                                          .Select(s => s.motherboard_id).ToList()
                                              );
                        }
                motherboard_ids = NewMB;
                MotherBoard_Processor();
                MotherBoard_HardDrive();
                MotherBoard_SoundCard();
                MotherBoard_VideoAdapter();
                MotherBoard_OpticalDrive();
                MotherBoard_PowerSupply();
                MotherBoard_Case();
            }
        }
        private void HardDrive_Motherboard()
        {
            if (motherboard_id == null)
            {
                List<long> NewMB = new List<long>();
                long[] hard_drive_ID = db.l_motherboard_bus_interfaces.Select(s => s.bus_interface_id).ToArray();
                long hard_drive_ID2 = db.hard_drives.Where(s => s.hard_drive_id == hard_drive_id)
                                                   .Select(s => s.bus_interface_id).Single();
                foreach (long x in hard_drive_ID)
                    if (x == hard_drive_ID2)
                    {
                        NewMB.AddRange(db.l_motherboard_bus_interfaces.Where(s => s.bus_interface_id == x && motherboard_ids.Contains(s.motherboard_id) && !NewMB.Contains(s.motherboard_id) && !NewMB.Contains(s.motherboard_id))
                                                      .Select(s => s.motherboard_id).ToList()
                                          );
                    }
                motherboard_ids = NewMB;
                MotherBoard_Processor();
                MotherBoard_Memories();
                MotherBoard_SoundCard();
                MotherBoard_VideoAdapter();
                MotherBoard_OpticalDrive();
                MotherBoard_PowerSupply();
                MotherBoard_Case();
            }
        }
        private void SoundCard_Motherboard()
        {
            if (motherboard_id == null)
            {
                List<long> NewMB = new List<long>();
                long[] sound_ID = db.motherboards.Select(s => s.sound_chip_id).ToArray();
                long sound_ID2 = db.sound_cards.Where(s => s.sound_card_id == sound_card_id)
                                               .Select(s => s.sound_chip_id).Single();
                foreach (long x in sound_ID)
                    if (x == sound_ID2)
                    {
                        NewMB.AddRange(db.motherboards.Where(s => s.sound_chip_id == x && motherboard_ids.Contains(db.motherboards.Where(m => m.sound_chip_id == db.sound_cards.Where(c => c.sound_card_id == sound_card_id)
                                                                                                                                                                               .Select(c => c.sound_chip_id).Single())
                                                                                                                                  .Select(m => m.motherboard_id).Single()) && !NewMB.Contains(s.motherboard_id))
                                                      .Select(s => s.motherboard_id).ToList()
                                          );
                    }
                motherboard_ids = NewMB;
                MotherBoard_Processor();
                MotherBoard_Memories();
                MotherBoard_HardDrive();
                MotherBoard_VideoAdapter();
                MotherBoard_OpticalDrive();
                MotherBoard_PowerSupply();
                MotherBoard_Case();
            }
        }
        private void VideoAdapter_Motherboard()
        {
            if (motherboard_id == null)
            {
                List<long> NewMB = new List<long>();
                long[] mb_ID = db.l_motherboards_expansion_slots.Select(s => s.expansion_slot_id).ToArray();
                long mb_ID2 = db.video_adapters.Where(v => v.video_adapter_id == video_adapter_id)
                                           .Select(s => s.expansion_slot_id)
                                           .Single();
                foreach (long x in mb_ID)
                    if (x == mb_ID2)
                    {
                        NewMB.AddRange(db.l_motherboards_expansion_slots.Where(s => s.expansion_slot_id == x && motherboard_ids.Contains(s.motherboard_id) && !NewMB.Contains(s.motherboard_id) && !NewMB.Contains(s.motherboard_id))
                                                      .Select(s => s.motherboard_id).ToList()
                                          );
                    }
                motherboard_ids = NewMB;
                MotherBoard_Processor();
                MotherBoard_Memories();
                MotherBoard_HardDrive();
                MotherBoard_SoundCard();
                MotherBoard_OpticalDrive();
                MotherBoard_PowerSupply();
                MotherBoard_Case();
            }
        }
        private void OpticalDrive_Motherboard()
        {
            if (motherboard_id == null)
            {
                List<long> NewMB = new List<long>();
                long[] mb_ID = db.l_motherboard_bus_interfaces.Where(s => s.bus_interface_count > 0).Select(s => s.bus_interface_id).ToArray();
                long mb_ID2 = db.optical_drives.Where(s => s.optical_drive_id == optical_drive_id)
                                           .Select(s => s.bus_interface_id)
                                           .Single();
                foreach (long x in mb_ID)
                    if (x == mb_ID2)
                    {
                        NewMB.AddRange(db.l_motherboard_bus_interfaces.Where(s => s.bus_interface_id == x && motherboard_ids.Contains(s.motherboard_id) && !NewMB.Contains(s.motherboard_id))
                                                      .Select(s => s.motherboard_id).ToList()
                                          );
                    }
                motherboard_ids = NewMB;
                MotherBoard_Processor();
                MotherBoard_Memories();
                MotherBoard_HardDrive();
                MotherBoard_SoundCard();
                MotherBoard_VideoAdapter();
                MotherBoard_PowerSupply();
                MotherBoard_Case();
            }
        }
        private void PowerSupply_Motherboard()
        {
            if (motherboard_id == null)
            {
                List<long> NewMB = new List<long>();
                long[] mb_ID = db.motherboards.Select(s => s.power_supply_standard_id).ToArray();
                long mb_ID2 = db.power_supplies.Where(s => s.power_supply_id == power_supply_id)
                                           .Select(s => s.power_supply_standard_id)
                                           .Single();
                foreach (long x in mb_ID)
                    if (x == mb_ID2)
                    {
                        NewMB.AddRange(db.motherboards.Where(s => s.power_supply_standard_id == x && motherboard_ids.Contains(s.motherboard_id) && !NewMB.Contains(s.motherboard_id))
                                                      .Select(s => s.motherboard_id).ToList()
                                          );
                    }
                motherboard_ids = NewMB;
                MotherBoard_Processor();
                MotherBoard_Memories();
                MotherBoard_HardDrive();
                MotherBoard_SoundCard();
                MotherBoard_VideoAdapter();
                MotherBoard_OpticalDrive();
                MotherBoard_Case();
            }
        }
        private void Case_Motherboard()
        {
            if (motherboard_id == null)
            {
                List<long> NewMB = new List<long>();
                long[] mb_ID = db.motherboards.Select(s => s.motherboard_form_factor_id).ToArray();
                long mb_ID2 = db.computer_cases.Where(s => s.computer_case_id == computer_case_id)
                                           .Select(s => s.motherboard_form_factor_id)
                                           .Single();
                foreach (long x in mb_ID)
                    if (x == mb_ID2)
                    {
                        NewMB.AddRange(db.motherboards.Where(s => s.motherboard_form_factor_id == x && motherboard_ids.Contains(s.motherboard_id) && !NewMB.Contains(s.motherboard_id))
                                                      .Select(s => s.motherboard_id).ToList()
                                          );
                    }
                motherboard_ids = NewMB;
                MotherBoard_Processor();
                MotherBoard_Memories();
                MotherBoard_HardDrive();
                MotherBoard_SoundCard();
                MotherBoard_VideoAdapter();
                MotherBoard_OpticalDrive();
                MotherBoard_PowerSupply();
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