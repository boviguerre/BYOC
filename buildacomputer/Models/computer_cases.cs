namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class computer_cases
    {
        public computer_cases()
        {
            l_computer_cases_cooling_fans = new HashSet<l_computer_cases_cooling_fans>();
            l_computer_cases_drive_bay_widths = new HashSet<l_computer_cases_drive_bay_widths>();
        }

        [Key]
        public long computer_case_id { get; set; }

        [Required]
        [StringLength(100)]
        public string computer_case_name { get; set; }

        public long manufacturer_id { get; set; }
        
        public long motherboard_form_factor_id { get; set; }

        public long computer_case_size_id { get; set; }
        
        public int front_usb_connector_count { get; set; }

        public int depth_mm { get; set; }

        public int width_mm { get; set; }

        public int height_mm { get; set; }
        
        public float weight_kg { get; set; }
        
        [Required]
        [StringLength(100)]
        public string color { get; set; }

        public virtual manufacturer manufacturer { get; set; }
        
        public virtual motherboard_form_factors motherboard_form_factors { get; set; }
        
        public virtual computer_case_sizes computer_case_sizes { get; set; }

        public virtual ICollection<l_computer_cases_cooling_fans> l_computer_cases_cooling_fans { get; set; }

        public virtual ICollection<l_computer_cases_drive_bay_widths> l_computer_cases_drive_bay_widths { get; set; }
    }
}