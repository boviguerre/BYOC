using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace buildacomputer.Models
{
    public class optical_drives
    {
        [Key]
        public long optical_drive_id { get; set; }

        public string optical_drive_name { get; set; }

        public long buffer_kb { get; set; }

        public long manufacturer_id { get; set; }

        public long bus_interface_id { get; set; }

        public long drive_bay_width_id { get; set; }

        public virtual manufacturers manufacturers { get; set; }
        public virtual bus_interfaces bus_interfaces { get; set; }
        public virtual drive_bay_widths drive_bay_widths { get; set; }
        public virtual ICollection<l_optical_drives_optical_disk_formats> l_optical_drives_optical_disk_formats {get; set;}
        public virtual ICollection<l_optical_drives_optical_drive_features> l_optical_drives_optical_drive_features { get; set; }
    }
}