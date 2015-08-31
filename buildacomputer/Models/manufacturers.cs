namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class manufacturer
    {
        public manufacturer()
        {
            computer_cases = new HashSet<computer_cases>();
            gpus = new HashSet<gpu>();
            hard_drives = new HashSet<hard_drives>();
            lan_chips = new HashSet<lan_chips>();
            memories = new HashSet<memory>();
            motherboard_nb_chipsets = new HashSet<motherboard_nb_chipsets>();
            motherboard_sb_chipsets = new HashSet<motherboard_sb_chipsets>();
            motherboards = new HashSet<motherboard>();
            optical_drives = new HashSet<optical_drives>();
            power_supplies = new HashSet<power_supplies>();
            processors = new HashSet<processor>();
            sound_cards = new HashSet<sound_cards>();
            sound_chips = new HashSet<sound_chips>();
            video_adapters = new HashSet<video_adapters>();
        }
        [Key]
        public long manufacturer_id { get; set; }

        [Required]
        [StringLength(100)]
        public string manufacturer_name { get; set; }

        public virtual ICollection<computer_cases> computer_cases { get; set; }
        public virtual ICollection<gpu> gpus { get; set; }
        public virtual ICollection<hard_drives> hard_drives { get; set; }
        public virtual ICollection<lan_chips> lan_chips { get; set; }
        public virtual ICollection<memory> memories { get; set; }
        public virtual ICollection<motherboard_nb_chipsets> motherboard_nb_chipsets { get; set; }
        public virtual ICollection<motherboard_sb_chipsets> motherboard_sb_chipsets { get; set; }
        public virtual ICollection<motherboard> motherboards { get; set; }
        public virtual ICollection<optical_drives> optical_drives { get; set; }
        public virtual ICollection<power_supplies> power_supplies { get; set; }
        public virtual ICollection<processor> processors { get; set; }
        public virtual ICollection<sound_cards> sound_cards { get; set; }
        public virtual ICollection<sound_chips> sound_chips { get; set; }
        public virtual ICollection<video_adapters> video_adapters { get; set; }   
    }
}