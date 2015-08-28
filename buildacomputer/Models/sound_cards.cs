namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sound_cards
    {
        [Key]
        public long sound_card_id { get; set; }

        [Required]
        [StringLength(100)]
        public string sound_card_name { get; set; }

        public long manufacturer_id { get; set; }

        public long expansion_slot_id { get; set; }

        public long sound_chip_id { get; set; }

        public virtual manufacturer manufacturer { get; set; }
        public virtual expansion_slots expansion_slots { get; set; }
        public virtual sound_chips sound_chips { get; set; }
    }
}