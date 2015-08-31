namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class optical_disk_formats
    {
        public optical_disk_formats()
        {
            l_optical_drives_optical_disk_formats = new HashSet<l_optical_drives_optical_disk_formats>();
        }

        [Key]
        public long optical_disk_format_id { get; set; }

        [Required]
        [StringLength(100)]
        public string optical_disk_format_name { get; set; }

        public virtual ICollection<l_optical_drives_optical_disk_formats> l_optical_drives_optical_disk_formats { get; set; }
    }
}