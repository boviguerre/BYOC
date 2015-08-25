using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using buildacomputer.Models;
using System.ComponentModel.DataAnnotations;

namespace buildacomputer.Models
{
    public class bus_interfaces
    {
      [Key]
        public long bus_interface_id { get; set; }

        public string bus_interface_name { get; set; }

        public virtual ICollection<hard_drives> hard_drives { get; set; }
        public virtual ICollection<optical_drives> optical_drives { get; set; }
        public virtual ICollection<l_motherboard_bus_interfaces> l_motherboard_bus_interfaces { get; set; }
    }
}