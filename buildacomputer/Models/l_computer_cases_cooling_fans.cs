using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace buildacomputer.Models
{
    public class l_computer_cases_cooling_fans
    {
        [Key]
        [Column (Order=1)]
        public long computer_case_id { get; set; }

        [Key]
        [Column(Order=2)]
        public long cooling_fan_size_id { get; set; }

        public long cooling_fan_size_count { get; set; }

        public virtual computer_cases computer_cases { get; set; }
        public virtual cooling_fan_sizes cooling_fan_sizes { get; set; }
    }
}