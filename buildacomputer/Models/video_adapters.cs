namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class video_adapters
    {
        [Key]
        public long video_adapter_id { get; set; }

        [Required]
        [StringLength(100)]
        public string video_adapter_name { get; set; }

        public int video_adapter_memory_mb { get; set; }

        public long manufacturer_id { get; set; }

        public long expansion_slot_id { get; set; }

        public long gpu_id { get; set; }

        public long power_supply_standard_id { get; set; }

        public long memory_type_id { get; set; }

        public virtual manufacturer manufacturer { get; set; }
        public virtual expansion_slots expansion_slots { get; set; }
        public virtual gpu gpu { get; set; }
        public virtual power_supply_standards power_supply_standards { get; set; }
        public virtual memory_types memory_types { get; set; }
    }
}