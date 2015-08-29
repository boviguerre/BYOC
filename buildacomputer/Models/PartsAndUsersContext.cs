namespace buildacomputer.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using System.Web;

    public partial class PartsAndUsersContext : DbContext
    {
        public PartsAndUsersContext()
            : base("name=computer_hardware")
        {
        }
        
        public virtual DbSet<C_MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<bus_interfaces> bus_interfaces { get; set; }
        public virtual DbSet<computer_case_sizes> computer_case_sizes { get; set; }
        public virtual DbSet<computer_cases> computer_cases { get; set; }
        public virtual DbSet<Build> Builds { get; set; }
        public virtual DbSet<cooling_fan_sizes> cooling_fan_sizes { get; set; }
        public virtual DbSet<drive_bay_widths> drive_bay_widths { get; set; }
        public virtual DbSet<ethernet_standards> ethernet_standards { get; set; }
        public virtual DbSet<expansion_slots> expansion_slots { get; set; }
        public virtual DbSet<gpu> gpus { get; set; }
        public virtual DbSet<hard_drive_features> hard_drive_features { get; set; }
        public virtual DbSet<hard_drives> hard_drives { get; set; }
        public virtual DbSet<l_computer_cases_cooling_fans> l_computer_cases_cooling_fans { get; set; }
        public virtual DbSet<l_computer_cases_drive_bay_widths> l_computer_cases_drive_bay_widths { get; set; }
        //public virtual DbSet<l_hard_drives_hard_drive_features> l_hard_drives_hard_drive_features { get; set; }
        public virtual DbSet<l_motherboard_bus_interfaces> l_motherboard_bus_interfaces { get; set; }
        public virtual DbSet<l_motherboard_peripheral_interfaces> l_motherboard_peripheral_interfaces { get; set; }
        public virtual DbSet<l_motherboards_expansion_slots> l_motherboards_expansion_slots { get; set; }
        public virtual DbSet<l_optical_drives_optical_disk_formats> l_optical_drives_optical_disk_formats { get; set; }
        //public virtual DbSet<l_optical_drives_optical_drive_features> l_optical_drives_optical_drive_features { get; set; }
        public virtual DbSet<lan_chips> lan_chips { get; set; }
        public virtual DbSet<manufacturer> manufacturers { get; set; }
        public virtual DbSet<memory> memories { get; set; }
        public virtual DbSet<memory_types> memory_types { get; set; }
        public virtual DbSet<motherboard_form_factors> motherboard_form_factors { get; set; }
        public virtual DbSet<motherboard_nb_chipsets> motherboard_nb_chipsets { get; set; }
        public virtual DbSet<motherboard_sb_chipsets> motherboard_sb_chipsets { get; set; }
        public virtual DbSet<motherboard> motherboards { get; set; }
        public virtual DbSet<optical_disk_formats> optical_disk_formats { get; set; }
        public virtual DbSet<optical_drive_features> optical_drive_features { get; set; }
        public virtual DbSet<optical_drives> optical_drives { get; set; }
        public virtual DbSet<peripheral_interfaces> peripheral_interfaces { get; set; }
        public virtual DbSet<power_supplies> power_supplies { get; set; }
        public virtual DbSet<power_supply_standards> power_supply_standards { get; set; }
        public virtual DbSet<processor_cores> processor_cores { get; set; }
        public virtual DbSet<processor_sockets> processor_sockets { get; set; }
        public virtual DbSet<processor> processors { get; set; }
        public virtual DbSet<sound_cards> sound_cards { get; set; }
        public virtual DbSet<sound_channel_standards> sound_channel_standards { get; set; }
        public virtual DbSet<sound_chips> sound_chips { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserBuilds> UserBuilds { get; set; }
        public virtual DbSet<video_adapters> video_adapters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasOptional(e => e.User)
                .WithRequired(e => e.AspNetUser)
                .WillCascadeOnDelete();

            modelBuilder.Entity<bus_interfaces>()
                .HasMany(e => e.hard_drives)
                .WithRequired(e => e.bus_interfaces)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<bus_interfaces>()
                .HasMany(e => e.l_motherboard_bus_interfaces)
                .WithRequired(e => e.bus_interfaces)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<bus_interfaces>()
                .HasMany(e => e.optical_drives)
                .WithRequired(e => e.bus_interfaces)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<computer_case_sizes>()
                .HasMany(e => e.computer_cases)
                .WithRequired(e => e.computer_case_sizes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<computer_cases>()
                .HasMany(e => e.l_computer_cases_cooling_fans)
                .WithRequired(e => e.computer_cases)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<computer_cases>()
                .HasMany(e => e.l_computer_cases_drive_bay_widths)
                .WithRequired(e => e.computer_cases)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Build>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Builds)
                .Map(m => m.ToTable("Users_Builds").MapLeftKey("BuildId").MapRightKey("UserId"));

            modelBuilder.Entity<cooling_fan_sizes>()
                .HasMany(e => e.l_computer_cases_cooling_fans)
                .WithRequired(e => e.cooling_fan_sizes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cooling_fan_sizes>()
                .HasMany(e => e.power_supplies)
                .WithRequired(e => e.cooling_fan_sizes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<drive_bay_widths>()
                .HasMany(e => e.hard_drives)
                .WithRequired(e => e.drive_bay_widths)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<drive_bay_widths>()
                .HasMany(e => e.l_computer_cases_drive_bay_widths)
                .WithRequired(e => e.drive_bay_widths)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<drive_bay_widths>()
                .HasMany(e => e.optical_drives)
                .WithRequired(e => e.drive_bay_widths)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ethernet_standards>()
                .HasMany(e => e.lan_chips)
                .WithRequired(e => e.ethernet_standards)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<expansion_slots>()
                .HasMany(e => e.l_motherboards_expansion_slots)
                .WithRequired(e => e.expansion_slots)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<expansion_slots>()
                .HasMany(e => e.sound_cards)
                .WithRequired(e => e.expansion_slots)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<expansion_slots>()
                .HasMany(e => e.video_adapters)
                .WithRequired(e => e.expansion_slots)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<gpu>()
                .HasMany(e => e.video_adapters)
                .WithRequired(e => e.gpu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<hard_drives>()
                .HasMany(e => e.hard_drive_features)
                .WithMany(e => e.hard_drives)
                .Map(m => m.ToTable("l_hard_drives_hard_drive_features").MapLeftKey("hard_drive_id").MapRightKey("hard_drive_feature_id"));

            modelBuilder.Entity<lan_chips>()
                .HasMany(e => e.motherboards)
                .WithRequired(e => e.lan_chips)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<manufacturer>()
                .HasMany(e => e.computer_cases)
                .WithRequired(e => e.manufacturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<manufacturer>()
                .HasMany(e => e.gpus)
                .WithRequired(e => e.manufacturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<manufacturer>()
                .HasMany(e => e.hard_drives)
                .WithRequired(e => e.manufacturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<manufacturer>()
                .HasMany(e => e.lan_chips)
                .WithRequired(e => e.manufacturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<manufacturer>()
                .HasMany(e => e.memories)
                .WithRequired(e => e.manufacturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<manufacturer>()
                .HasMany(e => e.motherboard_nb_chipsets)
                .WithRequired(e => e.manufacturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<manufacturer>()
                .HasMany(e => e.motherboard_sb_chipsets)
                .WithRequired(e => e.manufacturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<manufacturer>()
                .HasMany(e => e.motherboards)
                .WithRequired(e => e.manufacturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<manufacturer>()
                .HasMany(e => e.optical_drives)
                .WithRequired(e => e.manufacturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<manufacturer>()
                .HasMany(e => e.power_supplies)
                .WithRequired(e => e.manufacturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<manufacturer>()
                .HasMany(e => e.processors)
                .WithRequired(e => e.manufacturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<manufacturer>()
                .HasMany(e => e.sound_cards)
                .WithRequired(e => e.manufacturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<manufacturer>()
                .HasMany(e => e.sound_chips)
                .WithRequired(e => e.manufacturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<manufacturer>()
                .HasMany(e => e.video_adapters)
                .WithRequired(e => e.manufacturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<memory_types>()
                .HasMany(e => e.memories)
                .WithRequired(e => e.memory_types)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<memory_types>()
                .HasMany(e => e.motherboards)
                .WithRequired(e => e.memory_types)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<memory_types>()
                .HasMany(e => e.video_adapters)
                .WithRequired(e => e.memory_types)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<motherboard_form_factors>()
                .HasMany(e => e.computer_cases)
                .WithRequired(e => e.motherboard_form_factors)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<motherboard_form_factors>()
                .HasMany(e => e.motherboards)
                .WithRequired(e => e.motherboard_form_factors)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<motherboard_form_factors>()
                .HasMany(e => e.power_supplies)
                .WithRequired(e => e.motherboard_form_factors)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<motherboard_nb_chipsets>()
                .HasMany(e => e.motherboards)
                .WithRequired(e => e.motherboard_nb_chipsets)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<motherboard_sb_chipsets>()
                .HasMany(e => e.motherboards)
                .WithRequired(e => e.motherboard_sb_chipsets)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<motherboard>()
                .HasMany(e => e.l_motherboard_bus_interfaces)
                .WithRequired(e => e.motherboard)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<motherboard>()
                .HasMany(e => e.l_motherboard_peripheral_interfaces)
                .WithRequired(e => e.motherboard)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<motherboard>()
                .HasMany(e => e.l_motherboards_expansion_slots)
                .WithRequired(e => e.motherboard)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<optical_disk_formats>()
                .HasMany(e => e.l_optical_drives_optical_disk_formats)
                .WithRequired(e => e.optical_disk_formats)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<optical_drives>()
                .HasMany(e => e.l_optical_drives_optical_disk_formats)
                .WithRequired(e => e.optical_drives)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<optical_drives>()
                .HasMany(e => e.optical_drive_features)
                .WithMany(e => e.optical_drives)
                .Map(m => m.ToTable("l_optical_drives_optical_drive_features").MapLeftKey("optical_drive_id").MapRightKey("optical_drive_feature_id"));

            modelBuilder.Entity<peripheral_interfaces>()
                .HasMany(e => e.l_motherboard_peripheral_interfaces)
                .WithRequired(e => e.peripheral_interfaces)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<power_supply_standards>()
                .HasMany(e => e.motherboards)
                .WithRequired(e => e.power_supply_standards)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<power_supply_standards>()
                .HasMany(e => e.power_supplies)
                .WithRequired(e => e.power_supply_standards)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<power_supply_standards>()
                .HasMany(e => e.video_adapters)
                .WithRequired(e => e.power_supply_standards)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<processor_cores>()
                .HasMany(e => e.processors)
                .WithRequired(e => e.processor_cores)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<processor_sockets>()
                .HasMany(e => e.motherboards)
                .WithRequired(e => e.processor_sockets)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<processor_sockets>()
                .HasMany(e => e.processors)
                .WithRequired(e => e.processor_sockets)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sound_channel_standards>()
                .HasMany(e => e.sound_chips)
                .WithRequired(e => e.sound_channel_standards)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sound_chips>()
                .HasMany(e => e.motherboards)
                .WithRequired(e => e.sound_chips)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sound_chips>()
                .HasMany(e => e.sound_cards)
                .WithRequired(e => e.sound_chips)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.SecurityQuestion)
                .IsUnicode(false);
        }
    }
}
