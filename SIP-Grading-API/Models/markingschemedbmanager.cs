using DatabaseHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SIP_Grading_API.Models
{
    public class markingschemedbmanager
    {
        public bool Addmarks(markingscheme ms)
        {

            DatabaseInsertQuery newmarks = new DatabaseInsertQuery("markingscheme");

            newmarks.AddData("mschemeid", ms.mschemeid);
            newmarks.AddData("createdby", ms.createdby);
            newmarks.AddData("mscheme", ms.mscheme);

            return newmarks.RunQuery();
        }

        public ArrayList Getmarksbymarkingid(string mschemeid)
        {

            DatabaseRetriveQuery retrievemarks = new DatabaseRetriveQuery("markingscheme");

            retrievemarks.AddRestriction("mschemeid = " + mschemeid);

            SqlDataReader dr = retrievemarks.RunQuery();

            ArrayList result = new ArrayList();

            while (dr.Read())
            {
                markingscheme ms = new markingscheme();
                ms.mschemeid = (string)dr["mschemeid"];
                ms.createdby = (string)dr["createdby"];
                ms.mscheme = (string)dr["mscheme"];
                result.Add(ms);
            }

            return result;
        }

        public ArrayList Getallmarks()
        {
            DatabaseRetriveQuery retrieveallmarks = new DatabaseRetriveQuery("markingscheme");

            SqlDataReader dr = retrieveallmarks.RunQuery();

            ArrayList result = new ArrayList();

            while (dr.Read())
            {
                markingscheme ms = new markingscheme();
                ms.mschemeid = (string)dr["mschemeid"];
                ms.createdby = (string)dr["createdby"];
                ms.mscheme = (string)dr["mscheme"];
                result.Add(ms);
            }

            return result;
        }

        public bool Updatemarks(markingscheme ms)
        {
            DatabaseUpdateQuery updatemarks = new DatabaseUpdateQuery("marks", "mschemeid=" + ms.mschemeid);
            updatemarks.AddData("mschemeid", ms.mschemeid);
            updatemarks.AddData("createdby", ms.createdby);
            updatemarks.AddData("mscheme", ms.mscheme);

            return updatemarks.RunQuery();
        }

        public bool Deletemarks(string mschemeid)
        {
            DatabaseDeleteQuery deletemarks = new DatabaseDeleteQuery("markingscheme", "mschemeid=" + mschemeid);
            return deletemarks.RunQuery();
        }

    }
}