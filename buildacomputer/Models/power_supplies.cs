namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class power_supplies
    {
        [Key]
        public long power_supply_id { get; set; }

        [Required]
        [StringLength(100)]
        public string power_supply_name { get; set; }

        public long total_power_w { get; set; }

        public long energy_efficiency_percentage { get; set; }

        public long manufacturer_id { get; set; }

        public long motherboard_form_factor_id { get; set; }

        public long power_supply_standard_id { get; set; }

        public long cooling_fan_size_id { get; set; }

<<<<<<< HEAD
        public virtual manufacturer manufacturer { get; set; }
        public virtual motherboard_form_factors motherboard_form_factors { get; set; }
=======
        public virtual motherboard_form_factors motherboard_for_factors { get; set; }
>>>>>>> 7d4e9739d98793ae6193b452ae12b7058f98595c
        public virtual power_supply_standards power_supply_standards { get; set; }
        public virtual cooling_fan_sizes cooling_fan_sizes { get; set; }
    }
}