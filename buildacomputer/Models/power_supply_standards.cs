using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using buildacomputer.Models;
using System.ComponentModel.DataAnnotations;

namespace buildacomputer.Models
{
    public class power_supply_standards
    {
        [Key]
        public long power_supply_standard_id { get; set; }

        public string power_supply_standard_name { get; set; }

        public virtual ICollection<power_supplies> power_supplies { get; set; }
        public virtual ICollection<motherboards> motherboards { get; set; }
        public virtual ICollection<video_adapters> video_adapters { get; set; }
    }
}