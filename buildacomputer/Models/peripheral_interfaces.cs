namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class peripheral_interfaces
    {
        public peripheral_interfaces()
        {
            l_motherboard_peripheral_interfaces = new HashSet<l_motherboard_peripheral_interfaces>();
        }

        [Key]
        public long peripheral_interface_id { get; set; }

        [Required]
        [StringLength(100)]
        public string peripheral_interface_name { get; set; }

        public virtual ICollection<l_motherboard_peripheral_interfaces> l_motherboard_peripheral_interfaces { get; set; }
    }
}