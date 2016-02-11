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
            dbHost = "SHAWNEEE1EA4\\SQLEXPRESS";
            dbUsername = "shawnnneee";
            dbPassword = "1234";
            dbName = "SIGrading";
        }
    }
}
