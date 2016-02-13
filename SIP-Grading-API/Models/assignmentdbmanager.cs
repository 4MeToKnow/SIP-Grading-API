using DatabaseHelper;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            newassignment.AddData("assessmsub", a.assessmsub.ToString());

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
                a.componentid = (string)dr["componentid"];

                if (dr["assessmsub"] != DBNull.Value)
                {
                    a.assessmsub = (string)dr["assessmsub"];
                }
               
                result.Add(a);
            }

            return result;
        }

        public bool Updateassignment(assessmentSubmission submission)
        {
            DatabaseUpdateQuery updateassignment = new DatabaseUpdateQuery("markingassign", "assignid= '" + submission.AssignmentID + "'");
            updateassignment.AddData("assessmsub", submission.Components);
            return updateassignment.RunQuery();
        }

        public bool Deleteassignment(int assignid)
        {
            DatabaseDeleteQuery deleteassignment = new DatabaseDeleteQuery("markingassign", "assignid=" + assignid);
            return deleteassignment.RunQuery();
        }

        #region unused methods ***DELETE BEFORE SUBMISSION!!!**
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
        /*public ArrayList Getmschemebyassignmentid(int assignid)
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
        }*/
        //This method is before updating and after updating
        /*public ArrayList Getmarkingschemebystudentid(int studid)
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
        }*/
        #endregion
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
                if (dr["assessmsub"].ToString().Length == 0)
                {
                    a.assessmentSubmitted = false;
                }
                else
                {
                    a.assessmentSubmitted = true;
                }
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

        public Object Getmschemebystudentid(int studentid)
        {
            ArrayList returnList = new ArrayList();

           // var tmpList = new { Student="", MarkingScheme="",StaffAssigned=""};

            DatabaseRetriveQuery studentMarkingScheme = new DatabaseRetriveQuery("student");
            studentMarkingScheme.AddRestriction("studid", "=", studentid.ToString());
            SqlDataReader dr = studentMarkingScheme.RunQuery();
            student studentData = new student();
            while (dr.Read())
            {
                studentData.studid = (int)dr["studid"];
                studentData.name = (string) dr["name"];
                studentData.dip = (string)dr["dip"];
                studentData.matricno = (string)dr["matricno"];
                studentData.mschemeassigned = (string) dr["mschemeassigned"].ToString();
            }

            
            //tmpList.Student = studentData;

            DatabaseRetriveQuery markingSchemeAssignedToStudent = new DatabaseRetriveQuery("markingscheme");
            markingSchemeAssignedToStudent.AddRestriction("mschemeid", "=", studentData.mschemeassigned);
            SqlDataReader msdr = markingSchemeAssignedToStudent.RunQuery();
            List<component> componentlist = new List<component>();
            string markingSchemeName = "";
            while (msdr.Read())
            {
                markingSchemeName = (string)msdr["name"];
                componentlist = JsonConvert.DeserializeObject<List<component>>((string) msdr["mscheme"]);
            }

            var markingScheme = new { name = markingSchemeName, components = componentlist };
            //tmpList.MarkingScheme = componentlist

            DatabaseRetriveQuery staffAssignedToStudent = new DatabaseRetriveQuery("markingassign");
            staffAssignedToStudent.AddRestriction("studid", "=", studentid.ToString());
            SqlDataReader sdr = staffAssignedToStudent.RunQuery();
            ArrayList staffAssignedToStudentList = new ArrayList();
            while (sdr.Read())
            {
                string componentId = (string)(sdr["componentid"]);
                var tmp = new { staffID = sdr["staffid"], componentID = componentId.Split(',') };
                staffAssignedToStudentList.Add(tmp);
            }

            return new { student = studentData, markingScheme = markingScheme, staffAssigned = staffAssignedToStudentList };

            
        }

        public bool ProcessNewAssignment(newAssignment assignment)
        {
            for (int x = 0; x < assignment.assignedStaff.Count; x++)
            {
                DatabaseRetriveQuery countofstaff = new DatabaseRetriveQuery("markingassign");
                countofstaff.AddRestriction("studid","=",assignment.studentId.ToString());
                countofstaff.AddRestriction("staffid", "=", assignment.assignedStaff[x].staffId.ToString());
                countofstaff.AddRestriction("mschemeid", "=", assignment.markingschemeId.ToString());
                int count = countofstaff.NumRows();
                if (count == 0)
                {
                    DatabaseInsertQuery insertAssessment = new DatabaseInsertQuery("markingassign");
                    insertAssessment.AddData("studid", assignment.studentId.ToString());
                    insertAssessment.AddData("staffid", assignment.assignedStaff[x].staffId.ToString());
                    insertAssessment.AddData("mschemeid", assignment.markingschemeId.ToString());
                    insertAssessment.AddData("componentid", assignment.assignedStaff[x].componentsAssigned);
                    insertAssessment.RunQuery();
                }
                else
                {
                    DatabaseUpdateQuery updateAssessment = new DatabaseUpdateQuery("markingassign","studid = '"+assignment.studentId+"' AND staffid = '"+assignment.assignedStaff[x].staffId+"' AND mschemeid = '"+assignment.markingschemeId+"'");
                    updateAssessment.AddData("componentid", assignment.assignedStaff[x].componentsAssigned);
                    updateAssessment.AddData("assessmsub", "");
                    updateAssessment.RunQuery();
                }
            }

            DatabaseRetriveQuery listOfStaffAssigned = new DatabaseRetriveQuery("markingassign");
            listOfStaffAssigned.AddRestriction("studid", "=", assignment.studentId.ToString());
            listOfStaffAssigned.AddRestriction("mschemeid", "=", assignment.markingschemeId.ToString());
            SqlDataReader dr = listOfStaffAssigned.RunQuery();

            List<newAssignmentAssignedStaff> listOfStaffAssignedNow = new List<newAssignmentAssignedStaff>();

            while (dr.Read())
            {
                newAssignmentAssignedStaff tmp = new newAssignmentAssignedStaff();
                tmp.staffId = (int)dr["staffid"];
                tmp.componentsAssigned = (string)dr["componentid"];
                listOfStaffAssignedNow.Add(tmp);
            }

            for (int x = 0; x < listOfStaffAssignedNow.Count; x++)
            {
                bool found = false;
                for (int y = 0; y < assignment.assignedStaff.Count; y++)
                {
                    if (listOfStaffAssignedNow[x].staffId == assignment.assignedStaff[y].staffId)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    DatabaseDeleteQuery deleteAssignment = new DatabaseDeleteQuery("markingassign","studid = '"+assignment.studentId+"' AND staffid = '"+listOfStaffAssignedNow[x].staffId+"'");
                    deleteAssignment.RunQuery();
                }
            }
            
            return true;
        }

        public hybriddata1 Getmschemebymschemeid(int mschemeid)
        {
            DatabaseRetriveQuery retrieveassignment = new DatabaseRetriveQuery("markingassign");
            //retrieveassignment.AddColumn("studid");
            retrieveassignment.AddRestriction("assignid", "=", mschemeid.ToString());

            SqlDataReader dr = retrieveassignment.RunQuery();
            ArrayList componentassigned = new ArrayList();
            ArrayList result = new ArrayList();
            string componentid = "";
            string msscript = "";
            hybriddata1 one = new hybriddata1();

            int idstud = 0;

            while (dr.Read())
            {

                componentid = (string)dr["componentid"];

                one.MarkingSchemeID = (int)dr["mschemeid"];
                one.AssignmentID = (int)dr["assignid"];
                idstud = (int)dr["studid"];
                string[] components = componentid.Split(',');
                DatabaseRetriveQuery retrievemscheme = new DatabaseRetriveQuery("markingscheme");
                retrieveassignment.AddRestriction("mschemeid", "=", mschemeid.ToString());

                SqlDataReader td = retrievemscheme.RunQuery();
                while (td.Read())
                {

                    msscript = (string)td["mscheme"];
                }

                
                 List<component> componentlist = JsonConvert.DeserializeObject<List<component>>(msscript);

                 foreach (component item in componentlist)
                 {
                     foreach (string componentInd in components)
                     {
                         if (item.Id == Convert.ToInt32(componentInd))
                         {
 
                             componentassigned.Add(item);
                         }
                     }
                 }
            }

            studentdbmanager studm = new studentdbmanager();
            one.Student = studm.Getstudbystudid(idstud);


            one.ComponentAssigned = componentassigned;
            return one;
        }

        public object getAssessmentReview(int assessmentId)
        {
            DatabaseRetriveQuery drq = new DatabaseRetriveQuery("markingassign");
            drq.AddRestriction("assignid", "=", assessmentId.ToString());
            SqlDataReader dr = drq.RunQuery();
            string reviewMarks = "";
            if (dr.Read())
            {
                if (dr["assessmsub"] != DBNull.Value)
                {
                    reviewMarks = (string)dr["assessmsub"];

                }
                
            }

            return new { assignmentId = assessmentId, submittedAssessment = reviewMarks };
        }

        public class hybriddata
        {
            public int assignid { get; set; }
            public int studid { get; set; }
            public string name { get; set; }
            public string dip { get; set; }
            public string matricno { get; set; }
            public bool assessmentSubmitted { get; set; }

        }
        public class component
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Min { get; set; }
            public int Max { get; set; }
            public float Weightage { get; set; }

        }
        public class hybriddata1
        {
            public student Student { get; set; }
            public int MarkingSchemeID { get; set; }
            public int AssignmentID { get; set; }
            public ArrayList ComponentAssigned { get; set; }

        }

        
    }
}