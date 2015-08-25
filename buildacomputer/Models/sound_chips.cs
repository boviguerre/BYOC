using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace buildacomputer.Models
{
    public class sound_chips
    {
        [Key]
        public long sound_chip_id { get; set; }

        public string sound_chip_name { get; set; }

        public long manufacturer_id { get; set; }

        public long sound_channel_standard_id { get; set; }

        public virtual sound_channel_standards sound_channel_standards { get; set; }
        public virtual manufacturers manufacturers { get; set; }
        public virtual ICollection<sound_cards> sound_cards { get; set; }
        public virtual ICollection<motherboards> motherboards { get; set; }
    }
}