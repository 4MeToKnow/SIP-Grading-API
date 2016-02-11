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

        public bool Addstud(List<student> s)
        {
            for (int x = 0; x < s.Count; x++)
            {
                Addstud(s[x]);
            }
            return true;
        }

        public bool Addstud(student s)
        {
            DatabaseInsertQuery newstudent = new DatabaseInsertQuery("student");

           
            newstudent.AddData("name", s.name);
            newstudent.AddData("dip", s.dip);
            newstudent.AddData("matricno", s.matricno);
            newstudent.AddData("mschemeassigned", s.mschemeassigned);

            return newstudent.RunQuery();
        }

        public student Getstudbystudid(int studid)
        {
            DatabaseRetriveQuery retrievestud = new DatabaseRetriveQuery("student");

            retrievestud.AddRestriction("studid", "=", studid.ToString());

            SqlDataReader dr = retrievestud.RunQuery();

            student s = new student();
            while (dr.Read())
            {
                
                s.studid = (int)dr["studid"];
                s.name = (string)dr["name"];
                s.dip = (string)dr["dip"];
                s.matricno = (string)dr["matricno"];

                if (dr["mschemeassigned"] != DBNull.Value)
                {
                    s.mschemeassigned = (string)dr["mschemeassigned"].ToString();
                }
                
                
            }
            
            return s;
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
        /*public ArrayList Getallstud()
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
                s.mschemeassigned = (string)dr["mschemeassigned"];
                result.Add(s);
            }

            return result;
        }*/

        public ArrayList Getallstud()
        {
            /*DatabaseRetriveQuery retrievestud = new DatabaseRetriveQuery("student");

            retrievestud.AddOpend("ORDER BY mschemeassigned DESC");

            SqlDataReader dr = retrievestud.RunQuery();
            
            ArrayList result = new ArrayList();

            while (dr.Read())
            {
                student s = new student();
                s.studid = (int)dr["studid"];
                s.name = (string)dr["name"];
                s.dip = (string)dr["dip"];
                s.matricno = (string)dr["matricno"];
                s.mschemeassigned = (string)dr["mschemeassigned"];
                result.Add(s);
            }*/

            ArrayList markingSchemes = (new markingschemedbmanager()).Getallmarks();
            ArrayList studentsByMarkingScheme = new ArrayList();
            for (int x = 0; x < markingSchemes.Count; x++)
            {
                markingscheme currentms =(markingscheme) markingSchemes[x];
                ArrayList listOfStudentsInMarkingScheme = new ArrayList();
                DatabaseRetriveQuery stuRet = new DatabaseRetriveQuery("student");
                stuRet.AddRestriction("mschemeassigned", "=",currentms.mschemeid.ToString());
                SqlDataReader dr = stuRet.RunQuery();

                ArrayList result = new ArrayList();

                while (dr.Read())
                {
                    student s = new student();
                    s.studid = (int)dr["studid"];
                    s.name = (string)dr["name"];
                    s.dip = (string)dr["dip"];
                    s.matricno = (string)dr["matricno"];
                    s.mschemeassigned = (string)dr["mschemeassigned"].ToString();
                    result.Add(s);
                }

                studentsByMarkingScheme.Add(new { markingScheme = currentms,students = result});
            }

            return studentsByMarkingScheme;
        }

        public bool Updatestud(int studid, student s)
        {
            student studentInitial = Getstudbystudid(studid);
            if (studentInitial.mschemeassigned != s.mschemeassigned)
            {
                DatabaseDeleteQuery del = new DatabaseDeleteQuery("markingassign", "studid = '" + studid + "' AND mschemeid = '" + studentInitial.mschemeassigned + "'");
                del.RunQuery();
            }

            DatabaseUpdateQuery updatestud = new DatabaseUpdateQuery("student", "studid= '" + studid + "'");
            updatestud.AddData("name", s.name);
            updatestud.AddData("dip", s.dip);
            updatestud.AddData("matricno", s.matricno);
            updatestud.AddData("mschemeassigned", s.mschemeassigned);
            return updatestud.RunQuery();


        }

        public bool Deletestud(int studid)
        {
            DatabaseDeleteQuery deletestud = new DatabaseDeleteQuery("student", "studid= " + studid);
            deletestud.RunQuery();

            DatabaseDeleteQuery delAssm = new DatabaseDeleteQuery("markingassign", "studid='" + studid + "'");
            delAssm.RunQuery();

            return true;
        }
    }
}