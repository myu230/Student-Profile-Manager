using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentProfileManagementApp
{
    public partial class ClassMonitorForm : Form
    {
        private GradeDAO m_gdao;

        public ClassMonitorForm(GradeDAO gdao)
        {
            InitializeComponent();
            m_gdao = gdao;

            m_gdao.AverageGradeChanged += m_gdao_AverageGradeChanged;
            m_gdao.StudentCountChanged += m_gdao_StudentCountChanged;
        }

        private void ClassMonitorForm_Load(object sender, EventArgs e)
        {
            lbNumOfStudentsDisplay.Text = Convert.ToString(m_gdao.GradeCount);

            if (m_gdao.AverageGrade == null)
            {
                lbClassAvgDisplay.Text = " ";
            }
            else
            {
                lbClassAvgDisplay.Text = String.Format("{0:F1} %", m_gdao.AverageGrade);
            }
        }

        private void m_gdao_AverageGradeChanged(object sender, EventArgs e)
        {
            if (m_gdao.AverageGrade == null)
            {
                lbClassAvgDisplay.Text = " ";
            }
            else
            {
                lbClassAvgDisplay.Text = String.Format("{0:F1} %", m_gdao.AverageGrade);
            }
        }

        private void m_gdao_StudentCountChanged(object sender, EventArgs e)
        {
            lbNumOfStudentsDisplay.Text = Convert.ToString(m_gdao.GradeCount);
        }

    }
}
