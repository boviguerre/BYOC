using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace buildacomputer.Models
{
    public class processor_cores
    {
        [Key]
        public long processor_core_id { get; set; }

        public string processor_core_name { get; set; }

        public long processor_core_count { get; set; }

        public long processor_core_l1cache_kb { get; set; }

        public long processor_core_l2cache_kb { get; set; }

        public long processor_core_l3cache_kb { get; set; }

        public long processor_core_manufacturing_technology_nm { get; set; }

        public ICollection<processors> processors { get; set; }
    }
}