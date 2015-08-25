using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace buildacomputer.Models
{
    public class expansion_slots
    {
        [Key]
        public long expansion_slot_id { get; set; }

        public string expansion_slot_name { get; set; }

        public virtual ICollection<video_adapters> video_adapters { get; set; }
        public virtual ICollection<sound_cards> sound_cards { get; set; }
    }
}