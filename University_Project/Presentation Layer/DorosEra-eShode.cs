using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_Project
{
    public partial class DorosEra_eShode : Form
    {
        #region Instance
        DataTable DT;
        Student_MainFrm Student_Main;

        String Command;
        public event Action Address;
        #endregion

        public DorosEra_eShode(Student_MainFrm SMF)
        {
            InitializeComponent();

            this.Student_Main = SMF;
        }

        private void GetDataTable()
        {
            Command = "SELECT FK.Teacherr.Name, FK.Teacherr.Lname, FK.Dars.Name, FK.TimeOfClass.[DayOfWeek], FK.TimeOfClass.TimeStart, FK.TimeOfClass.TimeEnd" +
                "FROM FK.Teacherr" +
                "INNER JOIN FK.ClassHa" +
                "ON FK.Teacherr.ID = FK.ClassHa.OstadID" +
                "INNER JOIN FK.Dars" +
                "ON FK.ClassHa.DarsID = FK.Dars.ID" +
                "INNER JOIN FK.TimeOfClass" +
                "ON FK.ClassHa.ID = FK.TimeOfClass.ClassHaID";

            DataGrideList.DataSource = Cls_DataLayer.ExecuteDataTable(Command);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

            Student_Main.Show();
        }

        private void DorosEra_eShode_Load(object sender, EventArgs e)
        {
            GetDataTable();

            //فقط تابع آدرس را ارسال کردیم
            Action AC = Address;

            if (AC != null)
            {
                AC();
            }
        }
    }
}
