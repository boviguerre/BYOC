namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class drive_bay_widths
    {
        public drive_bay_widths()
        {
            hard_drives = new HashSet<hard_drives>();
            l_computer_cases_drive_bay_widths = new HashSet<l_computer_cases_drive_bay_widths>();
            optical_drives = new HashSet<optical_drives>();
        }

        [Key]
        public long drive_bay_width_id { get; set; }

        [Required]
        [StringLength(100)]
        public string drive_bay_width_name { get; set; }

        public virtual ICollection<hard_drives> hard_drives { get; set; }

        public virtual ICollection<optical_drives> optical_drives { get; set; }

        public virtual ICollection<l_computer_cases_drive_bay_widths> l_computer_cases_drive_bay_widths { get; set; }
    }
}