namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class processor_sockets
    {
        public processor_sockets()
        {
            motherboards = new HashSet<motherboard>();
            processors = new HashSet<processor>();
        }

        [Key]
        public long processor_socket_id { get; set; }

        [Required]
        [StringLength(100)]
        public string processor_socket_name { get; set; }

        public virtual ICollection<motherboard> motherboards { get; set; }
        public virtual ICollection<processor> processors { get; set; }
    }
}