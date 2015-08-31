namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class bus_interfaces
    {
        public bus_interfaces()
        {
            hard_drives = new HashSet<hard_drives>();
            l_motherboard_bus_interfaces = new HashSet<l_motherboard_bus_interfaces>();
            optical_drives = new HashSet<optical_drives>();
        }

        [Key]
        public long bus_interface_id { get; set; }

        [Required]
        [StringLength(100)]
        public string bus_interface_name { get; set; }

        public virtual ICollection<hard_drives> hard_drives { get; set; }

        public virtual ICollection<optical_drives> optical_drives { get; set; }

        public virtual ICollection<l_motherboard_bus_interfaces> l_motherboard_bus_interfaces { get; set; }
    }
}