namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class l_motherboard_bus_interfaces
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long motherboard_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long bus_interface_id { get; set; }

        public int bus_inteface_count { get; set; }

        public virtual motherboard motherboard { get; set; }
        public virtual bus_interfaces bus_interfaces { get; set; }
    }
}