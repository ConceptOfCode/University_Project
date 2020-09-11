using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace University_Project
{
    public partial class Information_Frm : Form
    {
        #region Instance
        String AttachComboBox;
        Boolean IsCheck;
        Int32 EditValue;
        DataTable DT;
        DateTime dateTime;

        Cls_Student Student;
        #endregion

        
        #region توابع سازنده
        public Information_Frm(DataTable dataTable)
        {
            InitializeComponent();

            this.DT = dataTable;
        }

        public Information_Frm()
        {
            InitializeComponent();
        }
        #endregion

        public Boolean vIsCheck
        {
            get
            {
                return IsCheck;
            }
            set
            {
                IsCheck = value;
            }
        }


        private void Btn_Sabt_Click(object sender, EventArgs e)
        {
            try
            {
                Student = new Cls_Student();

                #region Insert

                if (vIsCheck == false)
                {
                    dateTime = new DateTime(Int32.Parse(Cmb_Year.Text), Cmb_Mounth.SelectedIndex + 1, Cmb_Day.SelectedIndex + 1);

                    Student.Insert(Int64.Parse(Txt_ID.Text), Txt_Name.Text, Txt_Lname.Text, Cmb_Major.SelectedIndex + 1, dateTime, Txt_FatherName.Text, Cmb_Jens.SelectedIndex + 1, 1);
                }
                #endregion

                #region Update
               
                if (vIsCheck == true)
                {
                    dateTime = new DateTime(Int32.Parse(Cmb_Year.Text), Cmb_Mounth.SelectedIndex + 1, Cmb_Day.SelectedIndex + 1);

                    Student.Update(Int64.Parse(Txt_ID.Text), Txt_Name.Text, Txt_Lname.Text, Cmb_Major.SelectedIndex + 1,dateTime, Txt_FatherName.Text, Cmb_Jens.SelectedIndex + 1);
                }

            #endregion
        }



            #region  Exception
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ارور استثنا");
            }
            #endregion

            this.Close();
        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Information_Frm_Load(object sender, EventArgs e)
        {
            if (DT==null)
            {
                #region پر کردن شماره شناسایی کاربر
                //برای اینکه دیگر کاربر برای شخص دیگری ثبت نام نکند
                //یا اطلاعات فقط برای شخصی که ثبت نام کرده ثبت شود
                //امنیت
                Txt_ID.Text = Login_Layer.CopyOfID;
                Txt_ID.Enabled = false;
                #endregion

                vIsCheck = false;
            }

            else
            {
                vIsCheck = true;

                Txt_ID.Text = DT.Rows[0][0].ToString();
                Txt_ID.Enabled = false;
                Txt_Name.Text = DT.Rows[0][1].ToString();
                Txt_Lname.Text = DT.Rows[0][2].ToString();

                //چون در دیتا بیس ایندکس یکی بیشتر ذخیره شده لازم است اینجا یکی کم شود
                //تا برای کومبو باکس قابل شناسایی باشد چون ایندکس این کنترل از صفر شروع میشود
                EditValue = Convert.ToInt32(DT.Rows[0][3]);
                EditValue--;
                Cmb_Major.SelectedIndex = EditValue;

                dateTime = (DateTime)DT.Rows[0][4];
                Cmb_Year.Text = dateTime.Year.ToString();
                EditValue = dateTime.Month;
                EditValue--;
                Cmb_Mounth.SelectedIndex = EditValue;
                EditValue = dateTime.Day;
                EditValue--;
                Cmb_Day.SelectedIndex = EditValue;

                Txt_FatherName.Text = DT.Rows[0][5].ToString();

                EditValue = Convert.ToInt32(DT.Rows[0][6]);
                EditValue--;
                Cmb_Jens.SelectedIndex = EditValue;
         
            }
        }
    }
}
