using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace buildacomputer.Models
{
    public class peripheral_interfaces
    {
        [Key]
        public long peripheral_interface_id { get; set; }

        public string peripheral_interface_name { get; set; }

        public virtual ICollection<l_motherboard_peripheral_interfaces> l_motherboard_peripheral_interfaces { get; set; }
    }
}