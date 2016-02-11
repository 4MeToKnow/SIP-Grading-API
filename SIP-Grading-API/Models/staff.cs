using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIP_Grading_API.Models
{
    public class staff
    {
        public int staffid { get; set; } //removed set
        public string username { get; set; }
        public string name { get; set; }
        public string passw { get; set; }
        public string salt { get; set; }
        public string permssn { get; set; }
    }
}