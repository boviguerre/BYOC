namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class processor_cores
    {
        public processor_cores()
        {
            processors = new HashSet<processor>();
        }

        [Key]
        public long processor_core_id { get; set; }

        [Required]
        [StringLength(100)]
        public string processor_core_name { get; set; }

        public int processor_core_count { get; set; }

        public int processor_core_l1cache_kb { get; set; }

        public int processor_core_l2cache_kb { get; set; }
               
        public int processor_core_l3cache_kb { get; set; }
               
        public int processor_core_manufacturing_technology_nm { get; set; }

        public ICollection<processor> processors { get; set; }
    }
}