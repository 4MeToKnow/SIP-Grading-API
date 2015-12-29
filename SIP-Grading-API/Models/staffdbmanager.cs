using DatabaseHelper;
using System.Collections;
using System.Data.SqlClient;

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

            retrievestaff.AddRestriction("staffid = " + staffid);

            SqlDataReader dr = retrievestaff.RunQuery();

            ArrayList result = new ArrayList();

            while (dr.Read())
            {
                staff m = new staff();
                m.staffid = (string)dr["staffid"];
                m.username = (string)dr["username"];
                m.passw = (string)dr["passw"];
                m.salt = (string)dr["salt"];
                m.permssn = (string)dr["permssn"];
                result.Add(m);
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
                staff m = new staff();
                m.staffid = (string)dr["staffid"];
                m.username = (string)dr["username"];
                m.passw = (string)dr["passw"];
                m.salt = (string)dr["salt"];
                m.permssn = (string)dr["permssn"];
                result.Add(m);
            }

            return result;


        }
        public bool Updatestaff(staff m)
        {
	
        DatabaseUpdateQuery updatestaff = new DatabaseUpdateQuery("staff","staffid="+m.staffid);
	        updatestaff.AddData("staffid", m.staffid);
	        updatestaff.AddData("username", m.username);
	        updatestaff.AddData("passw", m.passw);
            updatestaff.AddData("salt", m.salt);
            updatestaff.AddData("permssn", m.permssn);

            return updatestaff.RunQuery();

        }
        public bool Deletestaff(string staffid)
        {
	
	        DatabaseDeleteQuery deletestaff = new DatabaseDeleteQuery("staff","staffid="+staffid);
            return deletestaff.RunQuery();

        }
    }
}