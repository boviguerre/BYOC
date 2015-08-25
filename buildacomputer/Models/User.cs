using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace buildacomputer.Models //creates the model used for users
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public string title { get; set; }

        public virtual ICollection<UserBuilds> UserBuilds { get; set; }
    }
}