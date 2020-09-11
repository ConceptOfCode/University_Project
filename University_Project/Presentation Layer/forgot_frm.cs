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
    public partial class forgot_frm : Form
    {
                                
                           #region Instanc
        Cls_SignUp SignUp;


        public event Action AddressAction;

        string HashPasswordEmail;
        string HashNewPassword;
        Boolean CheckUser;
#endregion
        
        public forgot_frm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Cmb_AccessType.SelectedIndex == 1)
            {
                CheckUser = true;
            }

            HashPasswordEmail = Cls_Hash.MakeHash(Txt_PasswordEmail.Text);
            HashNewPassword = Cls_Hash.MakeHash(Txt_NewPassword.Text);

            SignUp = new Cls_SignUp(this.CheckUser);
            try
            {
                //به جای فرستادن کل فرم فقط خود تابع آدرس را فرستادیم

                Action AC = AddressAction;
                if (AC != null)
                {
                    AC();
                }
                
                SignUp.Update(HashNewPassword, Txt_Email.Text, HashPasswordEmail);
            }

            #region exception
            catch (SystemException se)
            {
                MessageBox.Show(se.Message);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
