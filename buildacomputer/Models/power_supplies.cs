using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace buildacomputer.Models
{
    public class power_supplies
    {
        [Key]
        public long power_supply_id { get; set; }

        public string power_supply_name { get; set; }

        public long total_power_w { get; set; }

        public long energy_efficiency_percentage { get; set; }

        public long manufacturer_id { get; set; }

        public long motherboard_form_factor_id { get; set; }

        public long power_supply_standard_id { get; set; }

        public long cooling_fan_size_id { get; set; }

        public virtual manufacturers manufacturers { get; set; }
        public virtual motherboard_form_factors motherboard_for_factors { get; set; }
        public virtual power_supply_standards power_supply_standards { get; set; }
        public virtual cooling_fan_sizes cooling_fan_sizes { get; set; }
    }
}