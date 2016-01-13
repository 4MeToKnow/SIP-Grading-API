using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIP_Grading_API.Controllers
{
    public class loginController : ApiController
    {
        /*
        //Login with SALT
        public static bool Login(string input_username, string input_password)
        {
            bool successful = false;

            //Gets the salt based on the username
            ArrayList u = GetRegistrationBy(new string[,] { { "username", "=", input_username } });

            if (u.Count == 0)
            {
                successful = false;
            }
            else
            {
                Registration r = (Registration)u[0];
                input_password = TJAHelper.getSHA512(r.salt + "" + input_password);


                if (input_password == r.password && input_username == r.username)
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
        public static bool Login(string username, string password)
        {
            DatabaseSelectQuery sel = new DatabaseSelectQuery("VoyagerUser");
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

        }


        //API Controller for Login (In another class)
        public bool GetUser(string username, string password)
        {
            return repository.Login(username, password);
        }
        */
    }
}
