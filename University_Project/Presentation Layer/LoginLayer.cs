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
using System.IO;

namespace University_Project
{
    public partial class Login_Layer : Form
    {
                      #region instanc
        StreamReader SR;
        SqlConnection SqlConnection;
        SqlDataAdapter SqlDataAdapter;
        DataTable DT;

        SignUp_Frm _sign;
        forgot_frm _forgot;
        Student_MainFrm student;
        Teacher_MainFrm teacher;
        DorosEra_eShode dorosEra_E;

        public static String Address;
        public static String CopyOfID;
        string HashThisPassword;
        public bool IsEditMode;
        #endregion


        public Login_Layer()
        {
            InitializeComponent();
        }


        public void GetAddress(string Path)
        {
            SR = new StreamReader(Path);

            Address = SR.ReadToEnd();
        }

        private void CheckUser()
        {
            //این تابع فقط نتیجه جست و جو را برمیگرداند
            //و همچنین نتیجه دو جست و را برمیگرداند در دو جئول
            SqlConnection = new SqlConnection(Address);
            SqlDataAdapter = new SqlDataAdapter("SELECT COUNT(*) FROM STD.LoginLayer WHERE UserName='" +Int64.Parse( Txt_Usename.Text) + "'AND [Password]='" + HashThisPassword + "'UNION SELECT COUNT(*) FROM TCH.LoginLayer WHERE UserName='" +Int64.Parse( Txt_Usename.Text) + "'AND [Password]='" + HashThisPassword + "'", SqlConnection);

            DT = new DataTable();
            SqlDataAdapter.Fill(DT);
        }
        
        private void Btn_Login_Click(object sender, EventArgs e)
        {
                         #region ReadAddress
            GetAddress(@"C: \Users\HamidS\source\repos\ConnectionPath.txt");
#endregion               

            #region مقایسه پسوورد کاربر با انچه در دیتا بیس است

            HashThisPassword = Cls_Hash.MakeHash(Txt_Password.Text);

            CheckUser();

            //اگر نتیجه جست و درست باشد باز دوباره پسوورد کاربر را چک میکند برای فهمیدن استاد یا دانشجو بودن
            try
            {
                if (DT.Rows[1][0].ToString() == "1")
                {
                    for (int i = 0; i < Txt_Usename.Text.Length;)
                    {
                        if (Txt_Usename.Text[i] == '9')
                        {
                            student = new Student_MainFrm(this);
                            this.Hide();

                            student.Show();

                            break;
                        }

                        if (Txt_Usename.Text[i] == '8')
                        {
                            teacher = new Teacher_MainFrm();
                            this.Hide();

                            teacher.Show();

                            break;
                        }

                        else
                        {
                            MessageBox.Show("نام کاربری شما درست است ولی متاسفانه در قالب درست تولید نشده است", "خطا در ورود", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            break;
                        }
                    }
                }

                else
                {
                    MessageBox.Show("لطفا نام کاربری یا رمز عبور را دوباره چک کنید", "خطا در ورود", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            
                                                           #region Exception
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("لطفا نام کاربری یا رمز عبور را دوباره چک کنید", "خطا در ورود", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            #endregion

            #endregion

            CopyOfID = Txt_Usename.Text;
        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _sign = new SignUp_Frm();

            _sign.Address += _sign_Address;

            _sign.Show();
        }

        private void _sign_Address()
        {
            GetAddress(@"C: \Users\HamidS\source\repos\ConnectionPath.txt");
        }

        private void Login_Layer_Load(object sender, EventArgs e)
        {
        }

        private void guestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("خالی است");
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("با سلام و عرض خسته نباشید خدمت شما کاربر محترم\nبا توجه به منحصر به فرد بودن نام کاربری در دست شما این سیستم\nطوری طراحی شده است که فقط با وارد نمودن نام کاربری سیستم قادر به \nشناسایی شما میشود و وارد قسمت مربوط به شما میشود\nلذا در وارد نمودن نام کاربری خود دقت لازم را مبذول فرمایید", "راهنما سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
        }

        private void LLable_Login_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _forgot = new forgot_frm();

            _forgot.AddressAction += _forgot_AddressAction;

            _forgot.Show();

        }

        private void _forgot_AddressAction()
        {
            GetAddress(@"C: \Users\HamidS\source\repos\ConnectionPath.txt");
        }

        
       
    }
}
