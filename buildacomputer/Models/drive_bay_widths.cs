using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using buildacomputer.Models;
using System.ComponentModel.DataAnnotations;

namespace buildacomputer.Models
{
    public class drive_bay_widths
    {
        [Key]
        public long drive_bay_width_id { get; set; }

        public string drive_bay_width_name { get; set; }

        public virtual ICollection<hard_drives> hard_drives { get; set; }
        public virtual ICollection<optical_drives> optical_drives { get; set; }
        public virtual ICollection<l_computer_cases_drive_bay_widths> l_computer_cases_drive_bay_widths { get; set; }
    }
}