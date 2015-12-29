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
        public ArrayList getmarksbymschemeid(string mschemeid)
        {
            return manager.Getmarksbymarkingid(mschemeid);
        }
        public bool Addmarks(markingscheme markingscheme)
        {
            return manager.Addmarks(markingscheme);
        }
        public bool Updatemarks(markingscheme markingscheme)
        {
            return manager.Updatemarks(markingscheme);
        }
        public bool Deletemarks(string mschemeid)
        {
            return manager.Deletemarks(mschemeid);
        }
    }
}