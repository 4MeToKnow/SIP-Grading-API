using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIP_Grading_API.DBHelper
{
    class DatabaseHelperSettings
    {
        public string dbHost;
        public string dbUsername;
        public string dbPassword;
        public string dbName;

        public DatabaseHelperSettings()
        {
            dbHost = "localhost";
            dbUsername = "chengkai1";
            dbPassword = "chengkai1";
            dbName = "SIGrading";
        }
    }
}
