using SIP_Grading_API.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIP_Grading_API.Controllers
{
    public class assignmentController : ApiController
    {
        private static assignmentdbmanager manager = new assignmentdbmanager();

        public ArrayList getallassignment()
        {
            return manager.Getallassignment();
        }

        /*public ArrayList getassignmentbyassignmentid(int assignid)
        {
            return manager.Getassignmentbyassignmentid(assignid);
        }*/
        
        public IEnumerable getstudentsbystaffid(int staffid)
        {
            return manager.Getstudentsbystaffid(staffid);
        }

        public object getmschemebyassignmentid(int assignid)
        {
            return manager.Getmschemebymschemeid(assignid);
        }

        public Object getmschemebystudentid(int studentid)
        {
            return manager.Getmschemebystudentid(studentid);
        }

        public object getSubmittedAssessment(int submittedAssessmentId)
        {
            return manager.getAssessmentReview(submittedAssessmentId);
        }

        public object Getmarkingschemebymschemeid(int mschemeid)
        {
            return manager.Getmschemebymschemeid(mschemeid);
        }

        [HttpPost]
        public bool Addassignment(newAssignment assignment)
        {
            //return object_;
            return manager.ProcessNewAssignment(assignment);
        }

        [HttpPut]
        public bool Updateassignment(assessmentSubmission updateAssignment)
        {
            return manager.Updateassignment(updateAssignment);
        }

        [HttpDelete]
        public bool Deleteassignment(int assignid)
        {
            return manager.Deleteassignment(assignid);
        }
    }
}
