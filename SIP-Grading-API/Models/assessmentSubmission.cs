using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIP_Grading_API.Models
{
    public class assessmentSubmission
    {
        public int AssignmentID { get; set; }
        public int UserID {get; set;}
        public string Components {get; set;}
    }
}