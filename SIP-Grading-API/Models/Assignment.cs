using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIP_Grading_API.Models
{
    public class assignment
    {
        public int assignmentid { get; set; }
        public int studentid { get; set; }
        public int staffid { get; set; }
        public int mschemeid { get; set; }
        public int componentid { get; set; }
    }
}