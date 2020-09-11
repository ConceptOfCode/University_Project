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
    public partial class SignUp_Frm : Form,IShowID
    {
                         #region instanc

        Cls_SignUp signUp;
        Cls_DataLayer DataLayer;

        string HashPassword_Email;
        string HashPassword;
        Boolean CheckUser = false;

        public event Action Address;
#endregion

        public SignUp_Frm()
        {
            InitializeComponent();
        }

        private void Btn_Exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Sabt_Click_1(object sender, EventArgs e)
        {
            if (Cmb_Jens.SelectedIndex == 1)
            {
                CheckUser = true;
            }

            signUp = new Cls_SignUp(this.CheckUser);

            HashPassword_Email = Cls_Hash.MakeHash(Txt_PassEmail.Text);
            HashPassword = Cls_Hash.MakeHash(Txt_Password2.Text);

            try
            {
                //به جای کل فرم فقط تابع ادرس را فرستادیم

                Action AC = Address;
                if (AC != null)
                {
                    AC();
                }

                if (Txt_Password.Text == Txt_Password2.Text)
                {

                    signUp.Insert(Txt_Email.Text, HashPassword_Email, HashPassword);
                }

                else
                {
                    MessageBox.Show("فیلد تکرار رمز عبور با رمز عبور برار نیست", "خطا در رمز عبور", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
    
                                   
                                      
            #region exception

            catch(NoNullAllowedException )
            {
                MessageBox.Show("شما باید توسط مدیر احراز هویت شوید.\nبرای این کار اول توسط مدیر ثبت نام کنید و بعد رمز عبور تعین کنید", "خطا در ایجاد حساب", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch(SystemException se)
            {
                MessageBox.Show(se.Message);
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion


            Ishow();
            this.Close();
        }

        //interface
        public void Ishow()
        {
            String Command;

            #region GetAddress
            String Address;
            StreamReader SR = new StreamReader(@"C: \Users\HamidS\source\repos\ConnectionPath.txt");
            Address = SR.ReadToEnd();

            SqlConnection sqlConnection = new SqlConnection(Address);
            #endregion

            #region Controler
            //چون ایمیل یکتا است پس میتوان روی آن جست و جو درست انجام داد

            if (CheckUser == false)
            {
                Command = "SELECT * FROM STD.LoginLayer WHERE Email ='" + Txt_Email.Text + "'";
            }
            else
            {
                Command = "SELECT * FROM TCH.LoginLayer WHERE Email ='" + Txt_Email.Text + "'";
            }
            #endregion

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(Command, sqlConnection);
            DataTable DT = new DataTable();
            sqlDataAdapter.Fill(DT);

            String str = DT.Rows[0][0].ToString();
            MessageBox.Show("شماره شناسایی شما" + ":" + str + "\n" + "رمز عبور شما" + ":" + Txt_Password2.Text, "اطلاعات محرمانه", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
