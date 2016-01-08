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

        public ArrayList getstaffbystaffid(string staffid)
        {
            return manager.Getstaffbystaffid(staffid);
        }

        [HttpPost]
        public bool Addstaff(staff addStaff)
        {
            return manager.Addstaff(addStaff);
        }

        [HttpPut]
        public bool Updatestaff(string staffid, staff updateStaff)
        {
            return manager.Updatestaff(staffid, updateStaff);
        }

        [HttpDelete]
        public bool Deletestaff(string staffid)
        {
            return manager.Deletestaff(staffid);
        }
    }
}
