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

            newstaff.AddData("staffid", s.staffid);
            newstaff.AddData("username", s.username);
            newstaff.AddData("passw", s.passw);
            newstaff.AddData("salt", s.salt);
            newstaff.AddData("permssn", s.permssn);

            return newstaff.RunQuery();
        }

        public ArrayList Getstaffbystaffid(string staffid)
        {
            DatabaseRetriveQuery retrievestaff = new DatabaseRetriveQuery("staff");

            retrievestaff.AddRestriction("staffid", "=", staffid);

            SqlDataReader dr = retrievestaff.RunQuery();

            ArrayList result = new ArrayList();

            while (dr.Read())
            {
                staff s = new staff();
                s.staffid = (string)dr["staffid"];
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
                s.staffid = (string)dr["staffid"];
                s.username = (string)dr["username"];
                s.passw = (string)dr["passw"];
                s.salt = (string)dr["salt"];
                s.permssn = (string)dr["permssn"];
                result.Add(s);
            }

            return result;
        }

        public bool Updatestaff(string staffID, staff s)
        {
            DatabaseUpdateQuery updatestaff = new DatabaseUpdateQuery("staff", "staffid= '" + s.staffid +"'");
            
            updatestaff.AddData("staffid", s.staffid);
	        updatestaff.AddData("username", s.username);
	        updatestaff.AddData("passw", s.passw);
            updatestaff.AddData("salt", s.salt);
            updatestaff.AddData("permssn", s.permssn);

            return updatestaff.RunQuery();
        }

        public bool Deletestaff(string staffid)
        {
	        DatabaseDeleteQuery deletestaff = new DatabaseDeleteQuery("staff", "staffid= " + staffid);
            
            return deletestaff.RunQuery();
        }
    }
}