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
        public ArrayList getstaffbystaffid(string staffID)
        {
            return manager.Getstaffbystaffid(staffID);
        }
        public bool Addstaff(staff staff)
        {
            return manager.Addstaff(staff);
        }
        public bool Updatestaff(staff staff)
        {
            return manager.Updatestaff(staff);
        }
        public bool Deletestaff(string staffid)
        {
            return manager.Deletestaff(staffid);
        }

    }
}
