namespace buildacomputer.Models
{
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

    public partial class Build
    {

        #region Constructors
        public Build()
        {
            Users = new HashSet<User>();
        }

        public Build(List<long> mb, List<long> pr, List<long> me, List<long> hd, List<long> sc, List<long> va, List<long> od, List<long> ps, List<long> cc)
        {
            //import all possible parts
            foreach (long x in mb)
                this.motherboard_ids.Add(x);
            defValues.Add(motherboard_ids);
            foreach (long x in pr)
                processor_ids.Add(x);
            defValues.Add(processor_ids);
            foreach (long x in me)
                memory_ids.Add(x);
            defValues.Add(memory_ids);
            foreach (long x in hd)
                hard_drive_ids.Add(x);
            defValues.Add(hard_drive_ids);
            foreach (long x in sc)
                sound_card_ids.Add(x);
            defValues.Add(sound_card_ids);
            foreach (long x in va)
                video_adapter_ids.Add(x);
            defValues.Add(video_adapter_ids);
            foreach (long x in od)
                optical_drive_ids.Add(x);
            defValues.Add(optical_drive_ids);
            foreach (long x in ps)
                power_supply_ids.Add(x);
            defValues.Add(power_supply_ids);
            foreach (long x in cc)
                computer_case_ids.Add(x);
            defValues.Add(computer_case_ids);
        }
        #endregion

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public long? ComputerCase { get; set; }
        public long? HardDrive { get; set; }
        public long? Memory { get; set; }
        public long? Motherboard { get; set; }
        public long? OpticalDrive { get; set; }
        public long? PowerSupply { get; set; }
        public long? Processor { get; set; }
        public long? SoundCard { get; set; }
        public long? VideoAdapter { get; set; }
        
        [StringLength(256)]
        public string BuildType { get; set; }

        public int Iterator { get; set; }
        public DateTime BuildTime { get; set; }

        private List<List<long>> defValues = new List<List<long>>();
        
        private PartsAndUsersContext db = new PartsAndUsersContext();

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<UserBuilds> UserBuilds { get; set; }
        public virtual motherboard motherboards { get; set; }
        public virtual computer_cases computer_cases { get; set; }
        public virtual hard_drives hard_drives { get; set; }
        public virtual optical_drives optical_drives { get; set; }
        public virtual power_supplies power_supplies { get; set; }
        public virtual processor processors { get; set; }
        public virtual sound_cards sound_cards { get; set; }
        public virtual video_adapters video_adapters { get; set; }
        public virtual memory memories { get; set; }

        public int subtractPart(int id)
        {
            id--;
            if (id == 0)
                this.Motherboard = null;
            else if (id == 1)
                this.Processor = null;
            else if (id == 2)
                this.Memory = null;
            else if (id == 3)
                this.HardDrive = null;
            else if (id == 4)
                this.SoundCard = null;
            else if (id == 5)
                this.VideoAdapter = null;
            else if (id == 6)
                this.OpticalDrive = null;
            else if (id == 7)
                this.PowerSupply = null;
            else if (id == 8)
                this.ComputerCase = null;
            reseedPotential();
            if (Motherboard != null)
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
            Motherboard = x;
            motherboard_ids.Clear();
            addMotherboardHelper();
        }
        public void addComputer_case_id(long? x)
        {
            ComputerCase = x;
            computer_case_ids.Clear();
        }
        public void addHard_drive_id(long? x)
        {
            HardDrive = x;
            hard_drive_ids.Clear();
        }
        public void addOptical_drive_id(long? x)
        {
            OpticalDrive = x;
            optical_drive_ids.Clear();
        }
        public void addPower_supply_id(long? x)
        {
            PowerSupply = x;
            power_supply_ids.Clear();
        }
        public void addProcessor_id(long? x)
        {
            Processor = x;
        }
        public void addSound_card_id(long? x)
        {
            SoundCard = x;
            sound_card_ids.Clear();
        }
        public void addVideo_adapter_id(long? x)
        {
            VideoAdapter = x;
            video_adapter_ids.Clear();
        }
        public void addMemory_id(long? x)
        {
            Memory = x;
            memory_ids.Clear();
        }
        #endregion

        public void substractPart(long id)
        {
            if (this.Motherboard == id)
                this.Motherboard = null;
            else if (this.ComputerCase == id)
                this.ComputerCase = null;
            else if (this.HardDrive == id)
                this.HardDrive = null;
            else if (this.OpticalDrive == id)
                this.OpticalDrive = null;
            else if (this.PowerSupply == id)
                this.PowerSupply = null;
            else if (this.Processor == id)
                this.Processor = null;
            else if (this.SoundCard == id)
                this.SoundCard = null;
            else if (this.VideoAdapter == id)
                this.VideoAdapter = null;
            else if (this.Memory == id)
                this.Memory = null;
        }
        public void reseedPotential()
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
            if (Motherboard != null)
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
            if (Motherboard != null)
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
            if (Motherboard != null)
            {
                List<long> NewHard= new List<long>();
                long[] hard_ID = db.hard_drives.Select(s => s.bus_interface_id).ToArray();
                long[] hard_ID2 = db.l_motherboard_bus_interfaces.Where(s => s.motherboard_id == Motherboard)
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
            if (Motherboard != null)
            {
                List<long> NewSound = new List<long>();
                long[] sound_ID = db.sound_cards.Select(s => s.expansion_slot_id).ToArray();
                long[] sound_ID2 = db.l_motherboards_expansion_slots.Where(s => s.motherboard_id == Motherboard)
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
            if (Motherboard != null)
            {
                List<long> NewVideo = new List<long>();
                long[] video_ID = db.video_adapters.Select(s => s.expansion_slot_id).ToArray();
                long[] video_ID2 = db.l_motherboards_expansion_slots.Where(s => s.motherboard_id == Motherboard)
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
            if (Motherboard != null)
            {
                List<long> NewOptical = new List<long>();
                long[] optical_ID = db.optical_drives.Select(s => s.bus_interface_id).ToArray();
                long[] optical_ID2 = db.l_motherboard_bus_interfaces.Where(s => s.motherboard_id == Motherboard)
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
            if (Motherboard != null)
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
            if (Motherboard != null)
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