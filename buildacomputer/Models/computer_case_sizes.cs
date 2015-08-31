namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class computer_case_sizes
    {
        public computer_case_sizes()
        {
            computer_cases = new HashSet<computer_cases>();
        }

        [Key]
        public long computer_case_size_id { get; set; }

        [Required]
        [StringLength(100)]
        public string computer_case_size_name { get; set; }

        public virtual ICollection<computer_cases> computer_cases { get; set; }
    }
}