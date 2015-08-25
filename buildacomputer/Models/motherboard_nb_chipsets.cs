using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace buildacomputer.Models
{
    public class motherboard_nb_chipsets
    {
        [Key]
        public long motherboard_nb_chipset_id { get; set; }

        public string motherboard_nb_chipset_name { get; set; }

        public long manufacturer_id { get; set; }

        public virtual ICollection<motherboards> motherboards { get; set; }
        public virtual manufacturers manufacturers { get; set; }
    }
}