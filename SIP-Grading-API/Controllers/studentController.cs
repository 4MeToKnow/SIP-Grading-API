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

        public ArrayList getstudbystudid(int studid)
        {
            return manager.Getstudbystudid(studid);
        }

        [HttpPost]
        public bool addstud(student addStud)
        {
            return manager.Addstud(addStud);
        }

        [HttpPut]
        public bool updatestudent(int studid, student updateStud)
        {
            return manager.Updatestud(studid, updateStud);
        }

        [HttpDelete]
        public bool deletestudent(int studid)
        {
            return manager.Deletestud(studid);
        }
    }
}
