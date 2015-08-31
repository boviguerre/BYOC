namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class expansion_slots
    {
        public expansion_slots()
        {
            l_motherboards_expansion_slots = new HashSet<l_motherboards_expansion_slots>();
            sound_cards = new HashSet<sound_cards>();
            video_adapters = new HashSet<video_adapters>();
        }

        [Key]
        public long expansion_slot_id { get; set; }

        [Required]
        [StringLength(100)]
        public string expansion_slot_name { get; set; }

        public virtual ICollection<l_motherboards_expansion_slots> l_motherboards_expansion_slots { get; set; }
        public virtual ICollection<video_adapters> video_adapters { get; set; }
        public virtual ICollection<sound_cards> sound_cards { get; set; }
    }
}