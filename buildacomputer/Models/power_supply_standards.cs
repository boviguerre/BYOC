namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class power_supply_standards
    {
        public power_supply_standards()
        {
            motherboards = new HashSet<motherboard>();
            power_supplies = new HashSet<power_supplies>();
            video_adapters = new HashSet<video_adapters>();
        }

        [Key]
        public long power_supply_standard_id { get; set; }

        [Required]
        [StringLength(100)]
        public string power_supply_standard_name { get; set; }

        public virtual ICollection<power_supplies> power_supplies { get; set; }
        public virtual ICollection<motherboard> motherboards { get; set; }
        public virtual ICollection<video_adapters> video_adapters { get; set; }
    }
}