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
    public class studentController : ApiController
    {
        private static studentdbmanager manager = new studentdbmanager();

        public ArrayList getallstud()
        {
            return manager.Getallstud();
        }
        public ArrayList getstudbystudid(student student)
        {
            return manager.Getstudbystudid(student.studid);
        }
        public bool Addstud(student student)
        {
            return manager.Addstud(student);
        }
        public bool Updatestudent(student student)
        {
            return manager.Updatestud(student);
        }
        public bool Deletestaff(student student)
        {
            return manager.Deletestud(student.studid);
        }
    }
}
