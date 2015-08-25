using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace buildacomputer.Models
{
    public class hard_drives
    {
        [Key]
        public long hard_drive_id { get; set; }

        public string hard_drive_name { get; set; }

        public long buffer_kb { get; set; }

        public long capacity_gb { get; set; }

        public long manufacturer_id { get; set; }

        public long bus_interface_id { get; set; }

        public long drive_bay_width_id { get; set; }

        public virtual ICollection<l_hard_drives_hard_drive_features> l_hard_drives_hard_drive_features { get; set; }
        public virtual manufacturers manufacturers { get; set; }
        public virtual bus_interfaces bus_interfaces { get; set; }
        public virtual drive_bay_widths drive_bay_widths { get; set; }
    }
}