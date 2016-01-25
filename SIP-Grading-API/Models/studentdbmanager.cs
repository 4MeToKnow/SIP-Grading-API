using DatabaseHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SIP_Grading_API.Models
{
    public class studentdbmanager
    {
        public bool Addstud(student s)
        {
            DatabaseInsertQuery newstudent = new DatabaseInsertQuery("student");

           
            newstudent.AddData("name", s.name);
            newstudent.AddData("dip", s.dip);
            newstudent.AddData("matricno", s.matricno);

            return newstudent.RunQuery();
        }

        public ArrayList Getstudbystudid(int studid)
        {
            DatabaseRetriveQuery retrievestud = new DatabaseRetriveQuery("student");

            retrievestud.AddRestriction("studid", "=", studid.ToString());

            SqlDataReader dr = retrievestud.RunQuery();

            ArrayList result = new ArrayList();

            while (dr.Read())
            {
                student s = new student();
                s.studid = (int)dr["studid"];
                s.name = (string)dr["name"];
                s.dip = (string)dr["dip"];
                s.matricno = (string)dr["matricno"];
                result.Add(s);
            }
            
            return result;
        }


        /*public String Getstudbystudid(int studid)
        {
            DatabaseRetriveQuery retrievestud = new DatabaseRetriveQuery("student");

            retrievestud.AddRestriction("studid", "=", studid.ToString());

            SqlDataReader dr = retrievestud.RunQuery();

            String result = "";

            while (dr.Read())
            {
                student s = new student();
                s.studid = (int)dr["studid"];
                s.name = (string)dr["name"];
                s.dip = (string)dr["dip"];
                s.matricno = (string)dr["matricno"];
                result = ("studid: " +Convert.ToString(s.studid)+",name: "+ s.name+",dip: " +s.dip+",matricno: " + s.matricno +",");
            }

            return result;
        }*/
        public ArrayList Getallstud()
        {
            DatabaseRetriveQuery retrievestud = new DatabaseRetriveQuery("student");

            SqlDataReader dr = retrievestud.RunQuery();

            ArrayList result = new ArrayList();

            while (dr.Read())
            {
                student s = new student();
                s.studid = (int)dr["studid"];
                s.name = (string)dr["name"];
                s.dip = (string)dr["dip"];
                s.matricno = (string)dr["matricno"];

                result.Add(s);
            }

            return result;
        }

        public bool Updatestud(int studid, student s)
        {
            DatabaseUpdateQuery updatestud = new DatabaseUpdateQuery("student", "studid= '" + studid + "'");

           
            updatestud.AddData("name", s.name);
            updatestud.AddData("dip", s.dip);
            updatestud.AddData("matricno", s.matricno);

            return updatestud.RunQuery();
        }

        public bool Deletestud(int studid)
        {
            DatabaseDeleteQuery deletestud = new DatabaseDeleteQuery("student", "studid= " + studid);
            
            return deletestud.RunQuery();
        }
    }
}