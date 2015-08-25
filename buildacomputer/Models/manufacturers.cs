using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using buildacomputer.Models;
using System.ComponentModel.DataAnnotations;

namespace buildacomputer.Models
{
    public class manufacturers
    {
        [Key]
        public long manufacturer_id { get; set; }

        public string manufacturer_name { get; set; }

        public virtual ICollection<gpus> gpus { get; set; }
        public virtual ICollection<video_adapters> video_adapters { get; set; }
        public virtual ICollection<optical_drives> optical_drives { get; set; }
        public virtual ICollection<hard_drives> hard_drives { get; set; }
        public virtual ICollection<motherboard_sb_chipsets> motherboard_sb_chipsets { get; set; }
        public virtual ICollection<motherboard_nb_chipsets> motherboard_nb_chipsets { get; set; }
        public virtual ICollection<processors> processors { get; set; }
        public virtual ICollection<lan_chips> lan_chips { get; set; }
        public virtual ICollection<motherboards> motherboards { get; set; }
        public virtual ICollection<memories> memories { get; set; }
        public virtual ICollection<power_supplies> power_supplies { get; set; }
        public virtual ICollection<computer_cases> computer_cases { get; set; }
        public virtual ICollection<sound_chips> sound_chips { get; set; }
        public virtual ICollection<sound_cards> sound_cards { get; set; }
    }
}