using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using buildacomputer.Models;
using System.ComponentModel.DataAnnotations;

namespace buildacomputer.Models
{
    public class sound_channel_standards
    {
        [Key]
        public long sound_channel_standard_id { get; set; }

        public string sound_channel_standard_name { get; set; }

        public virtual ICollection<sound_chips> sound_chips { get; set; }
    }
}