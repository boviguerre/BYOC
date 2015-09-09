using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using buildacomputer.Models;

namespace buildacomputer.ViewModel
{
    public class BuildPortfolio
    {
       
    }

    public class UserBuilds
    {

        public string userID { get; set; }
        public int buildID { get; set; }
        public string buildName { get; set; }

        public virtual Build Build { get; set; }
        public virtual Users Users { get; set; }
    }
}