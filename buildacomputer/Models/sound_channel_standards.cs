namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sound_channel_standards
    {
        public sound_channel_standards()
        {
            sound_chips = new HashSet<sound_chips>();
        }

        [Key]
        public long sound_channel_standard_id { get; set; }

        [Required]
        [StringLength(100)]
        public string sound_channel_standard_name { get; set; }

        public virtual ICollection<sound_chips> sound_chips { get; set; }
    }
}