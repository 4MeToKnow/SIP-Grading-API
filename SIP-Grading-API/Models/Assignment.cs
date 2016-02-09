using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIP_Grading_API.Models
{
    public class assignment
    {
        public int assignid { get; set; }
        public int studid { get; set; }
        public int staffid { get; set; }
        public int mschemeid { get; set; }
        public string componentid { get; set; }
        public string assessmsub { get; set; }
    }
}