using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace buildacomputer.Models
{
    public class l_motherboards_expansion_slots
    {
        [Key]
        [Column(Order = 1)]
        public long motherboard_id { get; set; }

        [Key]
        [Column(Order = 2)]
        public long expansion_slot_id { get; set; }

        public long expansion_slot_count { get; set; }

        public virtual motherboards motherboards { get; set; }
        public virtual expansion_slots expansion_slots { get; set; }
    }
}