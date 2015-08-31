namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ethernet_standards
    {
        public ethernet_standards()
        {
            lan_chips = new HashSet<lan_chips>();
        }

        [Key]
        public long ethernet_standard_id { get; set; }

        [Required]
        [StringLength(100)]
        public string ethernet_standard_name { get; set; }

        public virtual ICollection<lan_chips> lan_chips { get; set; }
    }
}