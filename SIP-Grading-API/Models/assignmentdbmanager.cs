using DatabaseHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SIP_Grading_API.Models
{
    public class assignmentdbmanager
    {
        public bool Addassignment(assignment a)
        {
            DatabaseInsertQuery newassignment = new DatabaseInsertQuery("markingassign");

            newassignment.AddData("assignmentid", a.assignmentid.ToString());
            newassignment.AddData("studentid", a.studentid.ToString());
            newassignment.AddData("staffid", a.staffid.ToString());
            newassignment.AddData("mschemeid", a.mschemeid.ToString());
            newassignment.AddData("componentid", a.componentid.ToString());

            return newassignment.RunQuery();
        }

        public ArrayList Getassignmentbyassignmentid(int assignmentid)
        {
            DatabaseRetriveQuery retrieveassignment = new DatabaseRetriveQuery("markingassign");

            retrieveassignment.AddRestriction("assignmentid", "=", assignmentid.ToString());

            SqlDataReader dr = retrieveassignment.RunQuery();

            ArrayList result = new ArrayList();

            while (dr.Read())
            {
                assignment a = new assignment();
                a.assignmentid = (int)dr["assignmentid"];
                a.studentid = (int)dr["studentid"];
                a.staffid = (int)dr["staffid"];
                a.mschemeid = (int)dr["mschemeid"];
                a.componentid = (int)dr["componentid"];
                result.Add(a);
            }

            return result;
        }

        public ArrayList Getallassignment()
        {
            DatabaseRetriveQuery retrieveallassignment = new DatabaseRetriveQuery("markingassign");

            SqlDataReader dr = retrieveallassignment.RunQuery();

            ArrayList result = new ArrayList();

            while (dr.Read())
            {
                assignment a = new assignment();
                a.assignmentid = (int)dr["assignmentid"];
                a.studentid = (int)dr["studentid"];
                a.staffid = (int)dr["staffid"];
                a.mschemeid = (int)dr["mschemeid"];
                a.componentid = (int)dr["componentid"];
                result.Add(a);
            }

            return result;
        }

        public bool Updateassignment(int assignmentid, assignment a)
        {
            DatabaseUpdateQuery updateassignment = new DatabaseUpdateQuery("markingassign", "assignmentid= '" + a.assignmentid + "'");

            updateassignment.AddData("assignmentid", a.assignmentid.ToString());
            updateassignment.AddData("studentid", a.studentid.ToString());
            updateassignment.AddData("staffid", a.staffid.ToString());
            updateassignment.AddData("mschemeid", a.mschemeid.ToString());
            updateassignment.AddData("componentid", a.componentid.ToString());

            return updateassignment.RunQuery();
        }

        public bool Deleteassignment(int assignmentid)
        {
            DatabaseDeleteQuery deleteassignment = new DatabaseDeleteQuery("assignment", "assignmentid=" + assignmentid);
            return deleteassignment.RunQuery();
        }
        public ArrayList Getstudentsbystaffid(int staffid)
        {
            DatabaseRetriveQuery retrieveassignment = new DatabaseRetriveQuery("markingassign");
            //retrieveassignment.AddColumn("studid");
            retrieveassignment.AddRestriction("staffid", "=", staffid.ToString());

            SqlDataReader dr = retrieveassignment.RunQuery();

            ArrayList result = new ArrayList();

            while (dr.Read())
            {
                assignment a = new assignment();
                a.studentid = (int)dr["studentid"];

                studentdbmanager manager = new studentdbmanager();

                result.Add(manager.Getstudbystudid(a.studentid));

            }

            return result;
        }
        public ArrayList Getmschemebyassignmentid(int assignmentid)
        {
            DatabaseRetriveQuery retrieveassignment = new DatabaseRetriveQuery("markingassign");

            retrieveassignment.AddRestriction("assignmentid", "=", assignmentid.ToString());

            SqlDataReader dr = retrieveassignment.RunQuery();

            ArrayList result = new ArrayList();

            while (dr.Read())
            {
                assignment a = new assignment();

                a.mschemeid = (int)dr["mschemeid"];
                markingschemedbmanager manager = new markingschemedbmanager();

                result.Add(manager.Getmarksbymarkingid(a.mschemeid));
            }

            return result;
        }
//This method is before updating and after updating
        public ArrayList Getmarkingschemebystudentid(int studid)
        {
            DatabaseRetriveQuery retrieveassignment = new DatabaseRetriveQuery("markingassign");

            retrieveassignment.AddRestriction("studid", "=", studid.ToString());

            SqlDataReader dr = retrieveassignment.RunQuery();

            ArrayList result = new ArrayList();

            while (dr.Read())
            {
                assignment a = new assignment();

                a.mschemeid = (int)dr["mschemeid"];
                markingschemedbmanager manager = new markingschemedbmanager();

                result.Add(manager.Getmarksbymarkingid(a.mschemeid));
            }

            return result;
        }



    }
}