using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace buildacomputer.Models
{
    public class memories
    {
        [Key]
        public long memory_id { get; set; }

        public string memory_name { get; set; }

        public long memory_speed_mhz { get; set; }

        public long memory_size_mb { get; set; }

        public long manufacturer_id { get; set; }

        public long memory_type_id { get; set; }

        public virtual memory_types memory_types { get; set; }
        public virtual manufacturers manufacturers { get; set; }
    }
}