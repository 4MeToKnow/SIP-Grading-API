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

        public ArrayList getassignmentbyassignmentid(int assignmentid)
        {
            return manager.Getassignmentbyassignmentid(assignmentid);
        }
        //
        public ArrayList getstudentsbystaffid(int staffid)
        {
            return manager.Getstudentsbystaffid(staffid);
        }

        public ArrayList getmschemebyassignmentid(int assignmentid)
        {
            return manager.Getmschemebyassignmentid(assignmentid);
        }

        public ArrayList getmarkingschemebystudentid(int studid)
        {
            return manager.Getmarkingschemebystudentid(studid);
        }

        [HttpPost]
        public bool Addassignment(assignment addAssignment)
        {
            return manager.Addassignment(addAssignment);
        }

        [HttpPut]
        public bool Updateassignment(int assignmentid, assignment updateAssignment)
        {
            return manager.Updateassignment(assignmentid, updateAssignment);
        }

        [HttpDelete]
        public bool Deleteassignment(int assignmentid)
        {
            return manager.Deleteassignment(assignmentid);
        }
    }
}
