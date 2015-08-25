using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using buildacomputer.Models;
using System.ComponentModel.DataAnnotations;

namespace buildacomputer.Models
{
    public class ethernet_standards
    {
        [Key]
        public long ethernet_standard_id { get; set; }

        public string ethernet_standard_name { get; set; }

        public virtual ICollection<lan_chips> lan_chips { get; set; }
    }
}