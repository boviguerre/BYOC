namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class optical_drive_features
    {
        public optical_drive_features()
        {
            optical_drives = new HashSet<optical_drives>();
        }

        [Key]
        public long optical_drive_feature_id { get; set; }

        [Required]
        [StringLength(100)]
        public string optical_drive_feature_name { get; set; }

        public virtual ICollection<optical_drives> optical_drives { get; set; }
    }
}