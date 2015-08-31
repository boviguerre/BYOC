namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class optical_drives
    {
        public optical_drives()
        {
            l_optical_drives_optical_disk_formats = new HashSet<l_optical_drives_optical_disk_formats>();
            optical_drive_features = new HashSet<optical_drive_features>();
        }

        [Key]
        public long optical_drive_id { get; set; }

        [Required]
        [StringLength(100)]
        public string optical_drive_name { get; set; }

        public long buffer_kb { get; set; }

        public long manufacturer_id { get; set; }

        public long bus_interface_id { get; set; }

        public long drive_bay_width_id { get; set; }

<<<<<<< HEAD
        public virtual manufacturer manufacturer { get; set; }
=======
>>>>>>> 7d4e9739d98793ae6193b452ae12b7058f98595c
        public virtual bus_interfaces bus_interfaces { get; set; }
        public virtual drive_bay_widths drive_bay_widths { get; set; }
        public virtual ICollection<l_optical_drives_optical_disk_formats> l_optical_drives_optical_disk_formats {get; set;}
        public virtual ICollection<optical_drive_features> optical_drive_features { get; set; }
    }
}