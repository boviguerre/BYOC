using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace buildacomputer.Models
{
    public class l_motherboard_bus_interfaces
    {
        [Key]
        [Column(Order = 1)]
        public long motherboard_id { get; set; }

        [Key]
        [Column(Order = 2)]
        public long bus_interface_id { get; set; }

        public long bus_inteface_count { get; set; }

        public virtual motherboards motherboards { get; set; }
        public virtual bus_interfaces bus_interfaces { get; set; }
    }
}