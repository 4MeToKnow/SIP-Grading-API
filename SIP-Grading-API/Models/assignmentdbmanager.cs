using DatabaseHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;


namespace SIP_Grading_API.Models
{
    public class assignmentdbmanager
    {
        public bool Addassignment(assignment a)
        {
            DatabaseInsertQuery newassignment = new DatabaseInsertQuery("markingassign");

          
            newassignment.AddData("studid", a.studid.ToString());
            newassignment.AddData("staffid", a.staffid.ToString());
            newassignment.AddData("mschemeid", a.mschemeid.ToString());
            newassignment.AddData("componentid", a.componentid.ToString());

            return newassignment.RunQuery();
        }

       /* public ArrayList Getassignmentbyassignmentid(int assignid)
        {
            DatabaseRetriveQuery retrieveassignment = new DatabaseRetriveQuery("markingassign");

            retrieveassignment.AddRestriction("assignid", "=", assignid.ToString());

            SqlDataReader dr = retrieveassignment.RunQuery();

            ArrayList result = new ArrayList();

            while (dr.Read())
            {
                assignment a = new assignment();
                a.assignid = (int)dr["assignid"];
                a.studid = (int)dr["studid"];
                a.staffid = (int)dr["staffid"];
                a.mschemeid = (int)dr["mschemeid"];
                a.componentid = (int)dr["componentid"];
                result.Add(a);
            }

            return result;
        }
        */
        public ArrayList Getallassignment()
        {
            DatabaseRetriveQuery retrieveallassignment = new DatabaseRetriveQuery("markingassign");

            SqlDataReader dr = retrieveallassignment.RunQuery();

            ArrayList result = new ArrayList();

            while (dr.Read())
            {
                assignment a = new assignment();
                a.assignid = (int)dr["assignid"];
                a.studid = (int)dr["studid"];
                a.staffid = (int)dr["staffid"];
                a.mschemeid = (int)dr["mschemeid"];
                a.componentid = (int)dr["componentid"];
                result.Add(a);
            }

            return result;
        }

        public bool Updateassignment(int assignid, assignment a)
        {
            DatabaseUpdateQuery updateassignment = new DatabaseUpdateQuery("markingassign", "assignid= '" + assignid + "'");


            updateassignment.AddData("studid", a.studid.ToString());
            updateassignment.AddData("staffid", a.staffid.ToString());
            updateassignment.AddData("mschemeid", a.mschemeid.ToString());
            updateassignment.AddData("componentid", a.componentid.ToString());

            return updateassignment.RunQuery();
        }

        public bool Deleteassignment(int assignid)
        {
            DatabaseDeleteQuery deleteassignment = new DatabaseDeleteQuery("markingassign", "assignid=" + assignid);
            return deleteassignment.RunQuery();
        }

        //ADDED METHODS
        /*public ArrayList Getstudentsbystaffid(int staffid)
        {
            DatabaseRetriveQuery retrieveassignment = new DatabaseRetriveQuery("markingassign");
            //retrieveassignment.AddColumn("studid");
            retrieveassignment.AddRestriction("staffid", "=", staffid.ToString());

            SqlDataReader dr = retrieveassignment.RunQuery();
            
            ArrayList result = new ArrayList();

            while (dr.Read())
            {
                assignment a = new assignment();
                a.studid = (int)dr["studid"];
                a.assignid = (int)dr["assignid"];
                studentdbmanager manager = new studentdbmanager();
                result.Add(manager.Getstudbystudid(a.studid));
                
            }

            return result;
        }*/
        public ArrayList Getmschemebyassignmentid(int assignid)
        {
            DatabaseRetriveQuery retrieveassignment = new DatabaseRetriveQuery("markingassign");

            retrieveassignment.AddRestriction("assignid", "=", assignid.ToString());

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
public ArrayList Getstudentsbystaffid(int staffid)
        {
            DatabaseRetriveQuery retrieveassignment = new DatabaseRetriveQuery("markingassign");
            //retrieveassignment.AddColumn("studid");
            retrieveassignment.AddRestriction("staffid", "=", staffid.ToString());

            SqlDataReader dr = retrieveassignment.RunQuery();
            
            ArrayList result = new ArrayList();

            while (dr.Read())
            {
                hybriddata a = new hybriddata();
                a.studid = (int)dr["studid"];
                a.assignid = (int)dr["assignid"];
                DatabaseRetriveQuery retrievestud = new DatabaseRetriveQuery("student");

                retrievestud.AddRestriction("studid", "=", a.studid.ToString());

                SqlDataReader td = retrievestud.RunQuery();


                while (td.Read())
                {
                    a.name = (string)td["name"];
                    a.dip = (string)td["dip"];
                    a.matricno = (string)td["matricno"];
                }
                result.Add(a);               
            }

            return result;
        }


    }
    public class hybriddata
    {
        public int assignid { get; set; }
        public int studid { get; set; }
        public string name { get; set; }
        public string dip { get; set; }
        public string matricno { get; set; }

    }
}