using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace buildacomputer.Models
{
    public class l_optical_drives_optical_drive_features
    {
        [Key]
        [Column(Order = 1)]
        public long optical_drive_id { get; set; }

        [Key]
        [Column(Order = 2)]
        public long optical_drive_feature_id { get; set; }

        public virtual optical_drive_features optical_drive_features { get; set; }
        public virtual optical_drives optical_drives { get; set; }
    }
}