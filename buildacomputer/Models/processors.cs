using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace buildacomputer.Models
{
    public class processors
    {
        [Key]
        public long processor_id { get; set; }

        public string processor_name { get; set; }

        public long frequency_mhz { get; set; }

        public long processor_power_consumption_w { get; set; }

        public long manufacturer_id { get; set; }

        public long processor_socket_id { get; set; }

        public long processor_core_id { get; set; }

        public virtual manufacturers manufacturers { get; set; }
        public virtual processor_sockets processor_sockets { get; set; }
        public virtual processor_cores processor_cores { get; set; }
    }
}