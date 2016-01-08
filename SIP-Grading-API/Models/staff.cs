using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIP_Grading_API.Models
{
    public class staff
    {
        public string staffid { get; set; }
        public string username { get; set; }
        public string passw { get; set; }
        public string salt { get; set; }
        public string permssn { get; set; }
    }
}