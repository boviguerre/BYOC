namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class gpu
    {
        public gpu()
        {
            motherboards = new HashSet<motherboard>();
            video_adapters = new HashSet<video_adapters>();
        }

        [Key]
        public long gpu_id { get; set; }

        [Required]
        [StringLength(100)]
        public string gpu_name { get; set; }

        [Required]
        [StringLength(100)]
        public string gpu_core_name { get; set; }

        [Required]
        [StringLength(100)]
        public string gpu_directx_version { get; set; }

        [Required]
        [StringLength(100)]
        public string gpu_opengl_version { get; set; }

        public long manufacturer_id { get; set; }

<<<<<<< HEAD
        public virtual manufacturer manufacturer { get; set; }
        public virtual ICollection<motherboard> motherboards { get; set; }
=======
        public virtual ICollection<motherboards> motherboards { get; set; }
>>>>>>> 7d4e9739d98793ae6193b452ae12b7058f98595c
        public virtual ICollection<video_adapters> video_adapters { get; set; }
    }
}