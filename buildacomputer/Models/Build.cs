using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Data.Entity;

namespace buildacomputer.Models
{
    public class Build
    {
        public Build()
        {

        }
        public Build(List<long> mb, List<long> pr, List<long> me, List<long> hd, List<long> sc, List<long> va, List<long> od, List<long> ps, List<long> cc)
        {
            //import all possible parts
            foreach (long x in mb)
                motherboard_ids.Add(x);
            defValues.Add(motherboard_ids);
            foreach (long x in pr)
                processer_ids.Add(x);
            defValues.Add(processer_ids);
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

        [Key]
        public long? buildID { get; set; }
        public long? motherboard_id { get; set; }
        public long? computer_case_id { get; set; }
        public long? hard_drive_id { get; set; }
        public long? optical_drive_id { get; set; }
        public long? power_supply_id { get; set; }
        public long? processer_id { get; set; }
        public long? sound_card_id { get; set; }
        public long? video_adapter_id { get; set; }
        public long? memory_id { get; set; }
        public string buildType { get; set; }
        public int iterator { get; set; }
        public DateTime BuildTime { get; set; }
        private List<List<long>> defValues;
        private PartsAndUsersContext db = new PartsAndUsersContext();

        #region Possible parts
        public List<long> motherboard_ids { get; set; }
        public List<long> computer_case_ids { get; set; }
        public List<long> hard_drive_ids { get; set; }
        public List<long> optical_drive_ids { get; set; }
        public List<long> power_supply_ids { get; set; }
        public List<long> processer_ids { get; set; }
        public List<long> sound_card_ids { get; set; }
        public List<long> video_adapter_ids { get; set; }
        public List<long> memory_ids { get; set; }
        #endregion

        public virtual ICollection<UserBuilds> UserBuilds { get; set; }
        public virtual motherboards motherboards { get; set; }
        public virtual computer_cases computer_cases { get; set; }
        public virtual hard_drives hard_drives { get; set; }
        public virtual optical_drives optical_drives { get; set; }
        public virtual power_supplies power_supplies { get; set; }
        public virtual processors processors { get; set; }
        public virtual sound_cards sound_cards { get; set; }
        public virtual video_adapters video_adapters { get; set; }
        public virtual memories memories { get; set; }

        #region Public Add Parts
        public void addMotherboard(long x)
        {
            motherboard_id = x;
            addMotherboardHelper(x);
        }
        public void addComputer_case_id(long x)
        {
            computer_case_id = x;
        }
        public void addHard_drive_id(long x)
        {
            hard_drive_id = x;
        }
        public void addOptical_drive_id(long x)
        {
            optical_drive_id = x;
        }
        public void addPower_supply_id(long x)
        {
            power_supply_id = x;
        }
        public void addProcessor_id(long x)
        {
            processer_id = x;
        }
        public void addSound_card_id(long x)
        {
            sound_card_id = x;
        }
        public void addVideo_adapter_id(long x)
        {
            video_adapter_id = x;
        }
        public void addMemory_id(long x)
        {
            memory_id = x;
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
            else if (this.processer_id == id)
                this.processer_id = null;
            else if (this.sound_card_id == id)
                this.sound_card_id = null;
            else if (this.video_adapter_id == id)
                this.video_adapter_id = null;
            else if (this.memory_id == id)
                this.memory_id = null;
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
                    processer_ids.Clear();
                    foreach (long x in defValues[i])
                        processer_ids.Add(x);
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

        #region Private Helpers
        private void addMotherboardHelper(long? id)
        {
            if (id != null)
            {
                
            }
        }
        #endregion
    }
}