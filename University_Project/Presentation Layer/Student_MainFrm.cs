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
    public partial class Student_MainFrm : Form
    {
        #region Instance
        Login_Layer Login_Layer;
        Information_Frm information;
        Cls_DataLayer Cls_Data;
        DataTable DT;
        DorosEra_eShode dorosEra_E;

        String Command;
        #endregion


        public Student_MainFrm(Login_Layer LG)
        {
            InitializeComponent();

            this.Login_Layer = LG;
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

            Login_Layer.Show();
        }

        private void GetDataTable()
        {
            Command = "SELECT * FROM STD.Student WHERE ID = '" + Login_Layer.CopyOfID + "'";

            DT = new DataTable();

            DT = Cls_DataLayer.ExecuteDataTable(Command);
        }

        private void ویرایشاطلاعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ویرایش اطلاعات

            GetDataTable();

            information = new Information_Frm(this.DT);
            information.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //تکمیل اطلاعات

            information = new Information_Frm();
            information.Show();

        }

        private void دروسارائهشدهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dorosEra_E = new DorosEra_eShode(this);

            dorosEra_E.Address += DorosEra_E_Address;

            dorosEra_E.Show();
            this.Hide();
        }

        //فرستادن آدرس دیتابیس به فرم ارایه شده
        private void DorosEra_E_Address()
        {
            Login_Layer = new Login_Layer();

            Login_Layer.GetAddress(@"C: \Users\HamidS\source\repos\ConnectionPath.txt");
        }
    }
}
