namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class motherboard
    {
        public motherboard()
        {
            l_motherboard_bus_interfaces = new HashSet<l_motherboard_bus_interfaces>();
            l_motherboard_peripheral_interfaces = new HashSet<l_motherboard_peripheral_interfaces>();
            l_motherboards_expansion_slots = new HashSet<l_motherboards_expansion_slots>();
        }

        [Key]
        public long motherboard_id { get; set; }

        [Required]
        [StringLength(100)]
        public string motherboard_name { get; set; }

        public long manufacturer_id { get; set; }

        public long motherboard_nb_chipset_id { get; set; }

        public long motherboard_sb_chipset_id { get; set; }

        public long processor_socket_id { get; set; }

        public long memory_type_id { get; set; }

        public long motherboard_form_factor_id { get; set; }

        public long? gpu_id { get; set; } //nullable foreign key

        public long power_supply_standard_id { get; set; }

        public long lan_chip_id { get; set; }

        public long sound_chip_id { get; set; }

        public long front_usb_header_count { get; set; }

        public virtual gpu gpus { get; set; }
        public virtual ICollection<l_motherboard_bus_interfaces> l_motherboard_bus_interfaces { get; set; }
        public virtual ICollection<l_motherboard_peripheral_interfaces> l_motherboard_peripheral_interfaces { get; set; }
        public virtual ICollection<l_motherboards_expansion_slots> l_motherboards_expansion_slots { get; set; }
        public virtual lan_chips lan_chips { get; set; }
        public virtual manufacturer manufacturer { get; set; }
        public virtual memory_types memory_types { get; set; }
        public virtual motherboard_form_factors motherboard_form_factors { get; set; }
        public virtual motherboard_nb_chipsets motherboard_nb_chipsets { get; set; }
        public virtual motherboard_sb_chipsets motherboard_sb_chipsets { get; set; }
        public virtual sound_chips sound_chips { get; set; }
        public virtual processor_sockets processor_sockets { get; set; }
        public virtual power_supply_standards power_supply_standards { get; set; }
    }
}