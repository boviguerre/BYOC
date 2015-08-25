using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using buildacomputer.Models;
using System.ComponentModel.DataAnnotations;

namespace buildacomputer.Models
{
    public class optical_disk_formats
    {
        [Key]
        public long optical_disk_format_id { get; set; }

        public string optical_disk_format_name { get; set; }

        public virtual ICollection<l_optical_drives_optical_disk_formats> l_optical_drives_optical_disk_formats { get; set; }
    }
}