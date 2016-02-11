using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIP_Grading_API.Models
{
    public class newAssignment
    {
        public int markingschemeId {get; set;}
        public int studentId { get; set; }
        public List<newAssignmentAssignedStaff> assignedStaff { get; set; }
        
    }

    public class newAssignmentAssignedStaff
    {
        public int staffId { get; set; }
        public string componentsAssigned { get; set; }
    }
}