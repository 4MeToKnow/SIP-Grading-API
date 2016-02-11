using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using DatabaseHelper;
using Newtonsoft.Json;

namespace SIP_Grading_API.Models
{
    public class assessmentExportDBManager
    {

        public ArrayList exportSingleStudent(int studentId)
        {
            exportRestriction studentRes = new exportRestriction();
            studentRes.colName = "studid";
            studentRes.expectedValue = studentId.ToString();
            List<exportRestriction> compiledRes = new List<exportRestriction>();
            compiledRes.Add(studentRes);
            ArrayList exportS = exportMarks(compiledRes);
            if (exportS.Count > 0)
            {
                return exportS;
            }
            else
            {
                return null;
            }
           
        }

        public ArrayList exportByMarkingScheme(int markingSchemeID)
        {
            exportRestriction studentRes = new exportRestriction();
            studentRes.colName = "mschemeassigned";
            studentRes.expectedValue = markingSchemeID.ToString();
            List<exportRestriction> compiledRes = new List<exportRestriction>();
            compiledRes.Add(studentRes);
            ArrayList exportS = exportMarks(compiledRes);
            if (exportS.Count > 0)
            {
                return exportS;
            }
            else
            {
                return null;
            }
        }

        public ArrayList exportAll()
        {
            return exportMarks();
        }


        private ArrayList exportMarks(List<exportRestriction> res = null)
        {
            //Get all the marking schemes
            DatabaseRetriveQuery getAllStudent = new DatabaseRetriveQuery("student");

            if (res != null)
            {
                foreach (exportRestriction r in res)
                {
                    getAllStudent.AddRestriction(r.colName, "=", r.expectedValue);
                }
            }

            SqlDataReader studDr = getAllStudent.RunQuery();
            ArrayList listOfStudents = new ArrayList();

            while (studDr.Read())
            {
                specialStudent ss = new specialStudent();
                ss.studentId = (int)studDr["studid"];
                ss.diploma = (string)studDr["dip"];
                ss.admissionNo = (string)studDr["matricno"];
                ss.name = (string)studDr["name"];

                DatabaseRetriveQuery getMarkingScheme = new DatabaseRetriveQuery("markingscheme");
                getMarkingScheme.AddRestriction("mschemeid", "=", studDr["mschemeassigned"].ToString());
                SqlDataReader msdr = getMarkingScheme.RunQuery();

                if (msdr.Read())
                {
                    markingScheme tmp = new markingScheme();
                    tmp.markingSchemeId = (int)msdr["mschemeid"];
                    tmp.name = (string)msdr["name"];
                    DatabaseRetriveQuery staffRet = new DatabaseRetriveQuery("staff");
                    staffRet.AddRestriction("staffid", "=", msdr["createdby"].ToString());
                    SqlDataReader sdr = staffRet.RunQuery();
                    if (sdr.Read())
                    {
                        tmp.createdBy = (string)sdr["name"];
                    }

                    string componentString = (string)msdr["mscheme"];

                    List<markingSchemeComponents> componentlist = JsonConvert.DeserializeObject<List<markingSchemeComponents>>(componentString);



                    DatabaseRetriveQuery resDr = new DatabaseRetriveQuery("markingassign");
                    resDr.AddRestriction("studid", "=", ss.studentId.ToString());
                    resDr.AddRestriction("mschemeid", "=", tmp.markingSchemeId.ToString());
                    SqlDataReader resD = resDr.RunQuery();


                    List<markingSchemeResults> finalResultList = new List<markingSchemeResults>();
                    while (resD.Read())
                    {
                        string resultString = "";

                        if (resD["assessmsub"] != DBNull.Value)
                        {
                            resultString = (string)resD["assessmsub"];
                        }

                        string componentsAssigned = (string)resD["componentid"];
                        string[] componentsSplit = componentsAssigned.Split(',');
                        List<markingSchemeResults> componentsToResult = new List<markingSchemeResults>();
                        for (int xy = 0; xy < componentsSplit.Length; xy++)
                        {
                            markingSchemeResults msrTmp = new markingSchemeResults();
                            msrTmp.componentID = Convert.ToInt32(componentsSplit[xy]);
                            msrTmp.staffId = (int)resD["staffid"];
                            DatabaseRetriveQuery staffResultRet = new DatabaseRetriveQuery("staff");
                            staffResultRet.AddRestriction("staffid", "=", resD["staffid"].ToString());
                            SqlDataReader staffResultDr = staffResultRet.RunQuery();
                            if (staffResultDr.Read())
                            {
                                msrTmp.staffName = (string)staffResultDr["name"];
                            }

                            componentsToResult.Add(msrTmp);
                        }
                        List<markingSchemeResults> resultList = JsonConvert.DeserializeObject<List<markingSchemeResults>>(resultString);

                        foreach (markingSchemeResults componentsToResultsJ in componentsToResult)
                        {
                            markingSchemeResults tmpMsr = new markingSchemeResults();
                            tmpMsr.componentID = componentsToResultsJ.componentID;
                            tmpMsr.staffId = componentsToResultsJ.staffId;
                            tmpMsr.staffName = componentsToResultsJ.staffName;
                            try
                            {
                                foreach (markingSchemeResults resultListJ in resultList)
                                {
                                    if (resultListJ.componentID == componentsToResultsJ.componentID)
                                    {
                                        tmpMsr.score = resultListJ.score;
                                        tmpMsr.remarks = resultListJ.remarks;
                                        tmpMsr.submitted = true;
                                    }
                                }
                            }
                            catch (Exception) {
                                tmpMsr.submitted = false;
                            }
                            finalResultList.Add(tmpMsr);

                        }
                    }



                    List<markingSchemeComponents> markingComponentsFinal = new List<markingSchemeComponents>();

                    foreach (markingSchemeComponents markingSchemeCom in componentlist)
                    {
                        List<markingSchemeResults> resultListFinal = new List<markingSchemeResults>();

                        foreach (markingSchemeResults msr in finalResultList)
                        {
                            if (markingSchemeCom.Id == msr.componentID)
                            {
                                resultListFinal.Add(msr);
                            }
                        }

                        markingSchemeCom.results = resultListFinal;

                        markingComponentsFinal.Add(markingSchemeCom);
                    }


                    tmp.components = markingComponentsFinal;

                    ss.markingScheme = tmp;

                    listOfStudents.Add(ss);
                }
            }


            return listOfStudents;
        }

        public class exportRestriction
        {
            public string colName { get; set; }
            public string expectedValue { get; set; }
        }

        public class specialStudent
        {
            public int studentId { get; set; }
            public string name { get; set; }
            public string diploma { get; set; }
            public string admissionNo { get; set; }
            public markingScheme markingScheme { get; set; }
        }

        public class markingScheme
        {
            public int markingSchemeId { get; set; }
            public string name { get; set; }
            public string createdBy { get; set; }
            public List<markingSchemeComponents> components { get; set; }
        }

        public class markingSchemeComponents
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Min { get; set; }
            public int Max { get; set; }
            public float Weightage { get; set; }
            public List<markingSchemeResults> results { get; set; }
        }

        public class markingSchemeResults
        {
            public int staffId { get; set; }
            public string staffName { get; set; }
            public int componentID { get; set; }
            public int score { get; set; }
            public string remarks { get; set; }
            public bool submitted { get; set; }
        }
    }
}