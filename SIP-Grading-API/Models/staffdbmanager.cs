using DatabaseHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SIP_Grading_API.Models
{
    public class staffdbmanager
    {
        public bool Addstaff(staff s)
        {
            DatabaseInsertQuery newstaff = new DatabaseInsertQuery("staff");
            String newSalt = SIPGradingHelper.generateSalt(10);
            String password = SIPGradingHelper.getSHA512(newSalt + "" + s.passw);

            
            newstaff.AddData("username", s.username);
            newstaff.AddData("passw", password);
            newstaff.AddData("salt", newSalt);
            newstaff.AddData("permssn", s.permssn);

            return newstaff.RunQuery();
        }


        public ArrayList Getstaffbyusername(string username)
        {
            DatabaseRetriveQuery retrievestaff = new DatabaseRetriveQuery("staff");

            retrievestaff.AddRestriction("username", "=", username.ToString());

            SqlDataReader dr = retrievestaff.RunQuery();

            ArrayList result = new ArrayList();

            while (dr.Read())
            {
                staff s = new staff();
                // s.staffid = (int)dr["staffid"];
                s.username = (string)dr["username"];
                s.passw = (string)dr["passw"];
                s.salt = (string)dr["salt"];
                s.permssn = (string)dr["permssn"];
                result.Add(s);
            }

            return result;
        }
        public ArrayList Getstaffbystaffid(int staffid)
        {
            DatabaseRetriveQuery retrievestaff = new DatabaseRetriveQuery("staff");

            retrievestaff.AddRestriction("staffid", "=", staffid.ToString());

            SqlDataReader dr = retrievestaff.RunQuery();

            ArrayList result = new ArrayList();

            while (dr.Read())
            {
                staff s = new staff();
//removed s.staffid
                s.username = (string)dr["username"];
                s.passw = (string)dr["passw"];
                s.salt = (string)dr["salt"];
                s.permssn = (string)dr["permssn"];
                result.Add(s);
            }

            return result;
        }

        public ArrayList Getallstaff()
        {
            DatabaseRetriveQuery retrievestaff = new DatabaseRetriveQuery("staff");

            SqlDataReader dr = retrievestaff.RunQuery();

            ArrayList result = new ArrayList();

            while (dr.Read())
            {
                staff s = new staff();
               // s.staffid = (int)dr["staffid"];
                s.username = (string)dr["username"];
                s.passw = (string)dr["passw"];
                s.salt = (string)dr["salt"];
                s.permssn = (string)dr["permssn"];
                result.Add(s);
            }

            return result;
        }

        public bool Updatestaff(int staffid, staff s)
        {
            DatabaseUpdateQuery updatestaff = new DatabaseUpdateQuery("staff", "staffid= '" + staffid +"'");
            /* String newSalt = SIPGradingHelper.generateSalt(10);
                        String password = SIPGradingHelper.getSHA512(newSalt + "" + s.passw);

            
                        newstaff.AddData("username", s.username);
                        newstaff.AddData("passw", password);
                        newstaff.AddData("salt", newSalt);
                        newstaff.AddData("permssn", s.permssn);*/
            String newSalt = SIPGradingHelper.generateSalt(10);
            String password = SIPGradingHelper.getSHA512(newSalt + "" + s.passw);
	        updatestaff.AddData("username", s.username);
	        updatestaff.AddData("passw", password);
            updatestaff.AddData("salt", newSalt);
            updatestaff.AddData("permssn", s.permssn);

            return updatestaff.RunQuery();
        }

        public bool Deletestaff(int staffid)
        {
	        DatabaseDeleteQuery deletestaff = new DatabaseDeleteQuery("staff", "staffid= " + staffid);
            
            return deletestaff.RunQuery();
        }
    }
}