using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace buildacomputer.Models
{
    public class l_hard_drives_hard_drive_features
    {
        [Key]
        [Column(Order = 1)]
        public long hard_drive_id { get; set; }

        [Key]
        [Column(Order = 2)]
        public long hard_drive_feature_id { get; set; }

        public virtual hard_drives hard_drives { get; set; }
        public virtual hard_drive_features hard_drive_features { get; set; }
    }
}