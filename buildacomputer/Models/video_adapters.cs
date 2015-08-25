using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace buildacomputer.Models
{
    public class video_adapters
    {
        [Key]
        public long video_adapter_id { get; set; }

        public string video_adapter_name { get; set; }

        public long video_adapter_memory_mb { get; set; }

        public long manufacturer_id { get; set; }

        public long expansion_slot_id { get; set; }

        public long gpu_id { get; set; }

        public long power_supply_standard_id { get; set; }

        public long memory_type_id { get; set; }

        public virtual manufacturers manufacturers { get; set; }
        public virtual expansion_slots expansion_slots { get; set; }
        public virtual gpus gpus { get; set; }
        public virtual power_supply_standards power_supply_standards { get; set; }
        public virtual memory_types memory_types { get; set; }
    }
}