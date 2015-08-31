namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cooling_fan_sizes
    {
        public cooling_fan_sizes()
        {
            l_computer_cases_cooling_fans = new HashSet<l_computer_cases_cooling_fans>();
            power_supplies = new HashSet<power_supplies>();
        }

        [Key]
        public long cooling_fan_size_id { get; set; }

        public int cooling_fan_size_diameter_mm { get; set; }

        public virtual ICollection<l_computer_cases_cooling_fans> l_computer_cases_cooling_fans { get; set; }
        
        public virtual ICollection<power_supplies> power_supplies { get;  set; }
    }
}