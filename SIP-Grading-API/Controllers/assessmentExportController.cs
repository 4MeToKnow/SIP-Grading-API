using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SIP_Grading_API.Models;
using System.Collections;

namespace SIP_Grading_API.Controllers
{
    public class assessmentExportController : ApiController
    {
        private static assessmentExportDBManager manager = new assessmentExportDBManager();

        [HttpGet]
        public ArrayList getExportAll()
        {
            return manager.exportAll();
        }

        [HttpGet]
        public object exportByStudentId(int studentId)
        {
            return manager.exportSingleStudent(studentId);
        }

        [HttpGet]
        public ArrayList exportByMarkingScheme(int markingSchemeId)
        {
            return manager.exportByMarkingScheme(markingSchemeId);
        }
    }
}
