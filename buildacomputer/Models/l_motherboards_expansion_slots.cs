namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class l_motherboards_expansion_slots
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long motherboard_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long expansion_slot_id { get; set; }

        public int expansion_slot_count { get; set; }

        public virtual motherboard motherboard { get; set; }
        public virtual expansion_slots expansion_slots { get; set; }
    }
}