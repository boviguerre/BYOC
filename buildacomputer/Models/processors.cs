namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class processor
    {
        [Key]
        public long processor_id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string processor_name { get; set; }

        public long frequency_mhz { get; set; }

        public int processor_power_consumption_w { get; set; }

        public long manufacturer_id { get; set; }

        public long processor_socket_id { get; set; }

        public long processor_core_id { get; set; }

        public virtual manufacturer manufacturer { get; set; }
        public virtual processor_sockets processor_sockets { get; set; }
        public virtual processor_cores processor_cores { get; set; }
    }
}