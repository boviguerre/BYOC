namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class memory
    {
        [Key]
        public long memory_id { get; set; }

        [Required]
        [StringLength(100)]
        public string memory_name { get; set; }

        public int memory_speed_mhz { get; set; }

        public int memory_size_mb { get; set; }

        public long manufacturer_id { get; set; }

        public long memory_type_id { get; set; }

        public virtual memory_types memory_types { get; set; }
<<<<<<< HEAD
        public virtual manufacturer manufacturer { get; set; }
=======
>>>>>>> 7d4e9739d98793ae6193b452ae12b7058f98595c
    }
}