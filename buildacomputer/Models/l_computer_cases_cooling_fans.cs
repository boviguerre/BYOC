namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class l_computer_cases_cooling_fans
    {
        [Key]
        [Column (Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long computer_case_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long cooling_fan_size_id { get; set; }

        public int cooling_fan_size_count { get; set; }

        public virtual computer_cases computer_cases { get; set; }
        public virtual cooling_fan_sizes cooling_fan_sizes { get; set; }
    }
}