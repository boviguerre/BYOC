using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace buildacomputer.Models
{
    public class UserBuilds
    {
        [Key]
        public string userID { get; set; }
        public int buildID { get; set; }

        public virtual Build Build { get; set; }
        public virtual User User {get; set;}
    }
}