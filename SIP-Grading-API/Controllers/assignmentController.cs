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

        public ArrayList getmschemebyassignmentid(int assignid)
        {
            return manager.Getmschemebyassignmentid(assignid);
        }

        public ArrayList getmarkingschemebystudentid(int studid)
        {
            return manager.Getmarkingschemebystudentid(studid);
        }

        public ArrayList Getmarkingschemebymschemeid(int mschemeid)
        {
            return manager.Getmschemebymschemeid(mschemeid);
        }

        [HttpPost]
        public bool Addassignment(assignment addAssignment)
        {
            return manager.Addassignment(addAssignment);
        }

        [HttpPut]
        public bool Updateassignment(int assignid, assignment updateAssignment)
        {
            return manager.Updateassignment(assignid, updateAssignment);
        }

        [HttpDelete]
        public bool Deleteassignment(int assignid)
        {
            return manager.Deleteassignment(assignid);
        }
    }
}
