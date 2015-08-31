namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class motherboard_sb_chipsets
    {
        public motherboard_sb_chipsets()
        {
            motherboards = new HashSet<motherboard>();
        }

        [Key]
        public long motherboard_sb_chipset_id { get; set; }

        [Required]
        [StringLength(100)]
        public string motherboard_sb_chipset_name { get; set; }

        public long manufacturer_id { get; set; }

<<<<<<< HEAD
        public virtual ICollection<motherboard> motherboards { get; set; }
        public virtual manufacturer manufacturer { get; set; }
=======
        public virtual ICollection<motherboards> motherboards { get; set; }
>>>>>>> 7d4e9739d98793ae6193b452ae12b7058f98595c
    }
}