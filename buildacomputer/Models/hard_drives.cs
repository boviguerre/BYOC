namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class hard_drives
    {
        public hard_drives()
        {
            hard_drive_features = new HashSet<hard_drive_features>();
        }

        [Key]
        public long hard_drive_id { get; set; }

        [Required]
        [StringLength(100)]
        public string hard_drive_name { get; set; }

        public long buffer_kb { get; set; }

        public long capacity_gb { get; set; }

        public long manufacturer_id { get; set; }

        public long bus_interface_id { get; set; }

        public long drive_bay_width_id { get; set; }

<<<<<<< HEAD
        public virtual ICollection<hard_drive_features> hard_drive_features { get; set; }
        public virtual manufacturer manufacturer { get; set; }
=======
        public virtual ICollection<l_hard_drives_hard_drive_features> l_hard_drives_hard_drive_features { get; set; }
>>>>>>> 7d4e9739d98793ae6193b452ae12b7058f98595c
        public virtual bus_interfaces bus_interfaces { get; set; }
        public virtual drive_bay_widths drive_bay_widths { get; set; }
    }
}