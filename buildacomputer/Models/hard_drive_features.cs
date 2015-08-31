namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class hard_drive_features
    {
        public hard_drive_features()
        {
            hard_drives = new HashSet<hard_drives>();
        }

        [Key]
        public long hard_drive_feature_id { get; set; }

        [Required]
        [StringLength(100)]
        public string hard_drive_feature_name { get; set; }

        public virtual ICollection<hard_drives> hard_drives { get; set; }
    }
}