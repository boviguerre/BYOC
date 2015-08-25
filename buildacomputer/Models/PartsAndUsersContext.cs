using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace buildacomputer.Models
{
    public class PartsAndUsersContext : DbContext
    {
        public DbSet<Build> Build { get; set; }
        public DbSet<bus_interfaces> bus_interfaces { get; set; }
        public DbSet<computer_case_sizes> computer_case_sizes { get; set; }
        public DbSet<computer_cases> computer_cases { get; set; }
        public DbSet<cooling_fan_sizes> cooling_fan_sizes { get; set; }
        public DbSet<drive_bay_widths> drive_bay_widths { get; set; }
        public DbSet<ethernet_standards> ethernet_standards { get; set; }
        public DbSet<expansion_slots> expansion_slots { get; set; }
        public DbSet<gpus> gpus { get; set; }
        public DbSet<hard_drive_features> hard_drive_features { get; set; }
        public DbSet<hard_drives> hard_drives { get; set; }
        public DbSet<l_computer_cases_cooling_fans> l_computer_cases_cooling_fans { get; set; }
        public DbSet<l_computer_cases_drive_bay_widths> l_computer_cases_drive_bay_widths { get; set; }
        public DbSet<l_hard_drives_hard_drive_features> l_hard_drives_hard_drive_features { get; set; }
        public DbSet<l_motherboard_bus_interfaces> l_motherboard_bus_interfaces { get; set; }
        public DbSet<l_motherboard_peripheral_interfaces> l_motherboard_peripheral_interfaces { get; set; }
        public DbSet<l_motherboards_expansion_slots> l_motherboards_expansion_slots { get; set; }
        public DbSet<l_optical_drives_optical_disk_formats> l_optical_drives_optical_disk_formats { get; set; }
        public DbSet<l_optical_drives_optical_drive_features> l_optical_drives_optical_drive_features { get; set; }
        public DbSet<lan_chips> lan_chips { get; set; }
        public DbSet<manufacturers> manufacturers { get; set; }
        public DbSet<memories> memories { get; set; }
        public DbSet<memory_types> memory_types { get; set; }
        public DbSet<motherboard_form_factors> motherboard_form_factors { get; set; }
        public DbSet<motherboard_nb_chipsets> motherboard_nb_chipsets { get; set; }
        public DbSet<motherboard_sb_chipsets> motherboard_sb_chipsets { get; set; }
        public DbSet<motherboards> motherboards { get; set; }
        public DbSet<optical_disk_formats> optical_disk_formats { get; set; }
        public DbSet<optical_drive_features> optical_drive_features { get; set; }
        public DbSet<optical_drives> optical_drives { get; set; }
        public DbSet<peripheral_interfaces> peripheral_interfaces { get; set; }
        public DbSet<power_supplies> power_supplies { get; set; }
        public DbSet<power_supply_standards> power_supply_standards { get; set; }
        public DbSet<processor_sockets> processor_sockets { get; set; }
        public DbSet<processor_cores> processor_cores { get; set; }
        public DbSet<processors> processors { get; set; }
        public DbSet<sound_cards> sound_cards { get; set; }
        public DbSet<sound_channel_standards> sound_channel_standards { get; set; }
        public DbSet<sound_chips> sound_chips { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserBuilds> UserBuilds { get; set; }
        public DbSet<video_adapters> video_adapters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}