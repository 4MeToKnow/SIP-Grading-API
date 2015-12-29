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

            newstudent.AddData("studid", s.studid);
            newstudent.AddData("name", s.name);
            newstudent.AddData("dip", s.dip);
            newstudent.AddData("matricno", s.matricno);


            return newstudent.RunQuery();

        }
        public ArrayList Getstudbystudid(string studid)
        {

            DatabaseRetriveQuery retrievestud = new DatabaseRetriveQuery("student");

            retrievestud.AddRestriction("studid = " + studid);

            SqlDataReader dr = retrievestud.RunQuery();

            ArrayList result = new ArrayList();

            while (dr.Read())
            {
                student m = new student();
                m.studid = (string)dr["studid"];
                m.name = (string)dr["name"];
                m.dip = (string)dr["dip"];
                m.matricno = (string)dr["matricno"];

                result.Add(m);
            }

            return result;
        }
        public ArrayList Getallstud()
        {

            DatabaseRetriveQuery retrievestud = new DatabaseRetriveQuery("student");

            SqlDataReader dr = retrievestud.RunQuery();

            ArrayList result = new ArrayList();

            while (dr.Read())
            {
                student m = new student();
                m.studid = (string)dr["studid"];
                m.name = (string)dr["name"];
                m.dip = (string)dr["dip"];
                m.matricno = (string)dr["matricno"];

                result.Add(m);
            }

            return result;


        }
        public bool Updatestud(student m)
        {

            DatabaseUpdateQuery updatestud = new DatabaseUpdateQuery("student", "studid=" + m.studid);
            updatestud.AddData("studid", m.studid);
            updatestud.AddData("name", m.name);
            updatestud.AddData("dip", m.dip);
            updatestud.AddData("matricno", m.matricno);


            return updatestud.RunQuery();

        }
        public bool Deletestud(string studid)
        {

            DatabaseDeleteQuery deletestud = new DatabaseDeleteQuery("student", "studid=" + studid);
            return deletestud.RunQuery();

        }
    }
}