namespace buildacomputer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial; //creates the model used for users

    public partial class Users
    {

        public string Id { get; set; }
        
        [Required]
        [StringLength(256)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(256)]
        public string LastName { get; set; }

        [Column(TypeName = "text")]
        public string SecurityQuestion { get; set; }
        
        [StringLength(256)]
        public string SecurityAnswer { get; set; }
        
        [StringLength(256)]
        public string Title { get; set; }
    }
}