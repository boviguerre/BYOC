using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace buildacomputer.Models
{
    public class lan_chips
    {
        [Key]
        public long lan_chip_id { get; set; }

        public string lan_chip_name { get; set; }

        public long manufacturer_id { get; set; }

        public long ethernet_standard_id { get; set; }

        public virtual ethernet_standards ethernet_standards { get; set; }
        public virtual manufacturers manufacturers { get; set; }
        public virtual ICollection<motherboards> motherboards { get; set; }
    }
}