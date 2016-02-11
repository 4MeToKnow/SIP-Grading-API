using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIP_Grading_API.Models
{
    public class markingscheme
    {
        public int mschemeid { get; set; }
        public string name { get; set; }
        public string createdby { get; set; }
        public string mscheme { get; set; }
    }
}