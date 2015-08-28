namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class memory_types
    {
        public memory_types()
        {
            memories = new HashSet<memory>();
            motherboards = new HashSet<motherboard>();
            video_adapters = new HashSet<video_adapters>();
        }
        [Key]
        public long memory_type_id { get; set; }

        [Required]
        [StringLength(100)]
        public string memory_type_name { get; set; }

        public virtual ICollection<motherboard> motherboards { get; set; }
        public virtual ICollection<memory> memories { get; set; }
        public virtual ICollection<video_adapters> video_adapters { get; set; }
    }
}