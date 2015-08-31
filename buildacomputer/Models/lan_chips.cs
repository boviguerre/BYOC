namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class lan_chips
    {
        public lan_chips()
        {
            motherboards = new HashSet<motherboard>();
        }

        [Key]
        public long lan_chip_id { get; set; }

        [Required]
        [StringLength(100)]
        public string lan_chip_name { get; set; }

        public long manufacturer_id { get; set; }

        public long ethernet_standard_id { get; set; }

        public virtual ethernet_standards ethernet_standards { get; set; }
        public virtual manufacturer manufacturer { get; set; }
        public virtual ICollection<motherboard> motherboards { get; set; }
    }
}