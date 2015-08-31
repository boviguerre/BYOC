namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sound_chips
    {
        public sound_chips()
        {
            motherboards = new HashSet<motherboard>();
            sound_cards = new HashSet<sound_cards>();
        }

        [Key]
        public long sound_chip_id { get; set; }

        [Required]
        [StringLength(100)]
        public string sound_chip_name { get; set; }

        public long manufacturer_id { get; set; }

        public long sound_channel_standard_id { get; set; }

        public virtual sound_channel_standards sound_channel_standards { get; set; }
<<<<<<< HEAD
        public virtual manufacturer manufacturer { get; set; }
=======
>>>>>>> 7d4e9739d98793ae6193b452ae12b7058f98595c
        public virtual ICollection<sound_cards> sound_cards { get; set; }
        public virtual ICollection<motherboard> motherboards { get; set; }
    }
}