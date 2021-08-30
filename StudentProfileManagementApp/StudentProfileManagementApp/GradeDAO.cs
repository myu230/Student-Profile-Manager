using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace StudentProfileManagementApp
{
    public class GradeDAO
    {
        private SqlConnection m_conn = new SqlConnection("Data Source =.\\SQLEXPRESS;Database=School;User=sa;Password=access");
        private SqlConnection Connection { get { return m_conn; } }
        private int m_gradeCount;
        private double? m_avgGrade;

        public event EventHandler StudentCountChanged;
        public event EventHandler AverageGradeChanged;

        public int GradeCount
        {
            get
            {
                GetGradeTotals();
                return m_gradeCount;
            }
            private set { }
        }

        public double? AverageGrade
        {
            get
            {
                GetGradeTotals();
                return m_avgGrade;
            }
            private set { }
        }
        
        private void GetGradeTotals()
        {
            SqlCommand sqlcmdProfiles = new SqlCommand("SELECT Count(Grade) As NumGrades, Avg(Grade) As AvgGrade FROM Profiles", Connection);
            SqlDataAdapter sqldaProfiles = new SqlDataAdapter(sqlcmdProfiles);
            DataSet dsProfiles = new DataSet();

            sqldaProfiles.Fill(dsProfiles, "Totals");

            m_gradeCount = Convert.ToInt32(dsProfiles.Tables["Totals"].Rows[0]["NumGrades"]);

            if (dsProfiles.Tables["Totals"].Rows[0].IsNull("AvgGrade"))
                m_avgGrade = null;
            else
                m_avgGrade = Convert.ToDouble(dsProfiles.Tables["Totals"].Rows[0]["AvgGrade"]);
        }

        private void CheckUpdate()
        {
            int d_count = m_gradeCount;
            double? d_grades = m_avgGrade;

            if (d_count != GradeCount && StudentCountChanged != null)
            {
                StudentCountChanged(this, new EventArgs());
            }

            if (d_grades != AverageGrade && AverageGradeChanged != null)
            {
                AverageGradeChanged(this, new EventArgs());
            }
        }

        public string GetName(int stuNo)
        {
            SqlCommand sqlcmdProfile = new SqlCommand("SELECT StudentNumber, StudentName, Grade FROM Profiles WHERE StudentNumber = @SearchStudentNumber", Connection); // Connects to SqlConnection object
            SqlDataAdapter sqldaProfile = new SqlDataAdapter(sqlcmdProfile); // Connects to SqlCommand object
            DataTable dtProfile = new DataTable();

            sqlcmdProfile.Parameters.Add("SearchStudentNumber", SqlDbType.Int).Value = stuNo;

            sqldaProfile.Fill(dtProfile);

            if (dtProfile.Rows.Count > 0)
            {
                if (dtProfile.Rows[0].IsNull("StudentName"))
                {
                    return string.Empty;
                }
                else
                {
                    return Convert.ToString(dtProfile.Rows[0]["StudentName"]);
                }
            }
            else
            {
                throw new ArgumentException(String.Format("Student number not found."));
            }
        }

        public double GetGrade(int stuNo)
        {
            SqlCommand sqlcmdProfile = new SqlCommand("SELECT StudentNumber, StudentName, Grade FROM Profiles WHERE StudentNumber = @SearchStudentNumber", Connection); // Connects to SqlConnection object
            SqlDataAdapter sqldaProfile = new SqlDataAdapter(sqlcmdProfile); // Connects to SqlCommand object
            DataTable dtProfile = new DataTable();

            sqlcmdProfile.Parameters.Add("SearchStudentNumber", SqlDbType.Int).Value = stuNo;

            sqldaProfile.Fill(dtProfile);

            if (dtProfile.Rows.Count > 0)
            {
                return Convert.ToDouble(dtProfile.Rows[0]["Grade"]);
            }
            else
            {
                throw new ArgumentException(String.Format("Student number not found."));
            }
        }

        public void SetStudentProfile(int stuNo, string stuName, double stuGrade)
        {
            SqlCommand sqlcmdProfile = new SqlCommand("SELECT StudentNumber, StudentName, Grade FROM Profiles WHERE StudentNumber = @SearchStudentNumber", Connection); // Connects to SqlConnection object
            SqlDataAdapter sqldaProfile = new SqlDataAdapter(sqlcmdProfile); // Connects to SqlCommand object
            SqlCommandBuilder sqlcmdbldProfile = new SqlCommandBuilder(sqldaProfile);
            DataTable dtProfile = new DataTable();

            sqlcmdProfile.Parameters.Add("SearchStudentNumber", SqlDbType.Int).Value = stuNo;

            sqldaProfile.Fill(dtProfile);

           if (dtProfile.Rows.Count > 0)
            {
                try
                {
                    DataRow dr = dtProfile.Rows[0];
                    if (string.IsNullOrEmpty(stuName))
                        dr["StudentName"] = DBNull.Value;
                    else
                        dr["StudentName"] = stuName;

                    dr["Grade"] = stuGrade;
                    sqldaProfile.Update(dtProfile);
                }
                catch (Exception)
                {
                    dtProfile.RejectChanges();
                }
            }
            else
            {
                DataRow drProfile;

                sqldaProfile.FillSchema(dtProfile, SchemaType.Source);

                try
                {
                    drProfile = dtProfile.NewRow();
                    drProfile["StudentNumber"] = stuNo;
                    if (string.IsNullOrEmpty(stuName))
                        drProfile["StudentName"] = DBNull.Value;
                    else
                        drProfile["StudentName"] = stuName;

                    drProfile["Grade"] = stuGrade;
                    dtProfile.Rows.Add(drProfile);
                    sqldaProfile.Update(dtProfile);
                }
                catch (Exception)
                {
                    dtProfile.RejectChanges();
                }
            }

            CheckUpdate();
        }

        public void DeleteStudentProfile(int stuNo)
        {
            SqlCommand sqlcmdProfile = new SqlCommand("SELECT StudentNumber, StudentName, Grade FROM Profiles WHERE StudentNumber = @SearchStudentNumber", Connection); // Connects to SqlConnection object
            SqlDataAdapter sqldaProfile = new SqlDataAdapter(sqlcmdProfile); // Connects to SqlCommand object
            SqlCommandBuilder sqlcmdbldProfile = new SqlCommandBuilder(sqldaProfile);
            DataTable dtProfile = new DataTable();

            sqlcmdProfile.Parameters.Add("SearchStudentNumber", SqlDbType.Int).Value = stuNo;

            sqldaProfile.Fill(dtProfile);

            if (dtProfile.Rows.Count > 0)
            {
                try
                {
                    DataRow dr = dtProfile.Rows[0];
                    dr.Delete();
                    sqldaProfile.Update(dtProfile);
                }
                catch (Exception)
                {
                    dtProfile.RejectChanges();
                }
            }

            CheckUpdate();
        }
    }
}
