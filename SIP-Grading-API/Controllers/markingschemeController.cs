using SIP_Grading_API.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SIP_Grading_API.Controllers
{
    public class markingschemeController : ApiController
    {
        private static markingschemedbmanager manager = new markingschemedbmanager();

        public ArrayList getallmarks()
        {
            return manager.Getallmarks();
        }

        public ArrayList getmarksbymschemeid(int mschemeid)
        {
            return manager.Getmarksbymarkingid(mschemeid);
        }

        [HttpPost]
        public bool Addmarks(markingscheme addMarks)
        {
            return manager.Addmarks(addMarks);
        }

        [HttpPut]
        public bool Updatemarks(int mschemeid, markingscheme updateMarks)
        {
            return manager.Updatemarks(mschemeid, updateMarks);
        }

        [HttpDelete]
        public bool Deletemarks(int mschemeid)
        {
            return manager.Deletemarks(mschemeid);
        }
    }
}