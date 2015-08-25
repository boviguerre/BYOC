using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using buildacomputer.Models;
using System.ComponentModel.DataAnnotations;

namespace buildacomputer.Models
{
    public class optical_drive_features
    {
        [Key]
        public long optical_drive_feature_id { get; set; }

        public string optical_drive_feature_name { get; set; }

        public virtual ICollection<l_optical_drives_optical_drive_features> l_optical_drives_optical_drive_features { get; set; }
    }
}