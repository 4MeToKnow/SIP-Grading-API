using SIP_Grading_API.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIP_Grading_API.Controllers
{
    public class staffController : ApiController
    {
        private static staffdbmanager manager = new staffdbmanager();

        public ArrayList getallstaff()
        {
            return manager.Getallstaff();
        }

        public object getstaffbyusername(string username)
        {
            return manager.GetStaffByUsernamePublic(username);
        }

        public object getstaffbystaffid(int staffid)
        {
            return manager.Getstaffbystaffid(staffid);
        }


        [HttpPost]
        public bool Addstaff(staff addStaff)
        {
            return manager.Addstaff(addStaff);
        }

        [HttpPut]
        public bool Updatestaff(staff updateStaff, int staffid)
        {
            return manager.Updatestaff(staffid, updateStaff);
        }

        [HttpDelete]
        public bool Deletestaff(int staffid)
        {
            return manager.Deletestaff(staffid);
        }
    }
}
