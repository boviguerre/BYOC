namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class motherboard_form_factors
    {
        public motherboard_form_factors()
        {
            computer_cases = new HashSet<computer_cases>();
            motherboards = new HashSet<motherboard>();
            power_supplies = new HashSet<power_supplies>();
        }

        [Key]
        public long motherboard_form_factor_id { get; set; }

        [Required]
        [StringLength(100)]
        public string motherboard_form_factor_name { get; set; }

        public virtual ICollection<motherboard> motherboards { get; set; }
        public virtual ICollection<power_supplies> power_supplies { get; set; }
        public virtual ICollection<computer_cases> computer_cases { get; set; }
    }
}