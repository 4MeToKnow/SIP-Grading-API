using DatabaseHelper;
using SIP_Grading_API.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;

namespace SIP_Grading_API.Controllers
{
    public class loginController : ApiController
    {
      
        
        //Login with SALT
        [HttpPost]
        public bool Login(string input_username, string input_password)
        {
            bool successful = false;
            staffdbmanager manager = new staffdbmanager();
            //Gets the salt based on the username
            //Get username from db 
            //ArrayList u = GetRegistrationBy(new string[,] { { "username", "=", input_username } });
            ArrayList u = manager.Getstaffbyusername(input_username);

            if (u.Count == 0)
            {
                successful = false;
            }
            else
            {
                staff r = (staff)u[0];
                input_password = SIPGradingHelper.getSHA512(r.salt + "" + input_password);


                if (input_password == r.passw && input_username == r.username)
                {
                    successful = true;
                }
                else
                {
                    successful = false;
                }
            }

            return successful;

        }

        //API Login DB Manager
       /* public static bool Login(string username, string password)
        {
            DatabaseRetriveQuery sel = new DatabaseRetriveQuery("");
            sel.AddRestriction("Username", "=", username);
            sel.AddRestriction("Password", "=", password);
            SqlDataReader d = sel.RunQuery();
            if (d.Read())
            {
                return true;
            }
            else
            {
                return false;
            }

        }*/

        

 

        
    }
}
