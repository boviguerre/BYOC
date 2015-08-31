namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class l_optical_drives_optical_disk_formats
    {

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long optical_drive_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long optical_disk_format_id { get; set; }

        public int optical_disk_format_write_speed { get; set; }

        public virtual optical_disk_formats optical_disk_formats { get; set; }
        public virtual optical_drives optical_drives { get; set; }
    }
}