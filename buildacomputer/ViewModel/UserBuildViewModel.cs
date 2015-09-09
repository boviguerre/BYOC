using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using buildacomputer.Models;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace buildacomputer.ViewModel
{
    public class UserBuildViewModel
    {
        [Display(Name = "Enter a name for your build: ")]
        [Required]
        public string buildName { get; set; }

        [Display(Name = "What type of build is this? ")]
        [Required]
        public string buildType { get; set; }

        public DateTime buildTime { get; set; }
    }
}