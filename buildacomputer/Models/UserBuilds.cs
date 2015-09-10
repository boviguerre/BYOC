using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace buildacomputer.Models
{
    public class UserBuilds
    {
        [Key]
        [Column(Order=1)]
        public string UserId { get; set; }
        
        [Key]
        [Column(Order=2)]
        public int buildID { get; set; }
        
        public string buildName { get; set; }

        public virtual Build Build { get; set; }
        public virtual Users User {get; set; }
    }
}