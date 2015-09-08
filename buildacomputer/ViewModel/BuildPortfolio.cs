using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using buildacomputer.Models;

namespace buildacomputer.ViewModel
{
    public class BuildPortfolio
    {
        public Build build { get; set; }
        public computer_cases computer_cases { get; set; }
        public hard_drives hard_drives { get; set; }
        public memory memory { get; set; } //the model class itself is called "memories", but "memory" is what's recognized by VS. Is this because of the auto class generation the database did?
        public motherboard motherboard { get; set; } //same issue as with "memory" above?
        public optical_drives optical_drives { get; set; }
        public power_supplies power_supplies { get; set; }
        public processor processor { get; set; } //same issue as with "memory" and "motherboard" above?
        public sound_cards sound_cards { get; set; }
        public video_adapters video_adapters { get; set; }
    }
}