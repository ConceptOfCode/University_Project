using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_Project
{
    class Cls_SignUp:Cls_DataLayer
    {
        #region Instance
        string Command;
        Boolean CheckInsertANDUpdate;
        #endregion

        
        #region توابع سازنده
        public Cls_SignUp()
        {

        }

        public Cls_SignUp(Boolean BL)
        {
            this.CheckInsertANDUpdate = BL;
        }
        #endregion


        public void Insert(string Email,string PassEmail,string PasswordID)
        {
            OpenConnection();

            if (CheckInsertANDUpdate == false)
            {
                Command = "INSERT INTO STD.LoginLayer (Password, Email, PassEmail) VALUES ('" + PasswordID + "','" + Email + "','" + PassEmail + "')";
            }
            if (CheckInsertANDUpdate == true)
            {
                Command = "INSERT INTO TCH.LoginLayer (Email, PassEmail, Password) VALUES ('" + Email + "','" + PassEmail + "','" + PasswordID + "')";
            }


            ExecuteNoneQuery(Command);

            CloseConnection();
        }

        public void Update(string NewPass,string Email,string PassEmail)
        {
            if (CheckInsertANDUpdate == false)
            {
                Command = "UPDATE STD.LoginLayer SET Password=@Pa WHERE Email=@Em";
            }
            else
            {
                Command = "UPDATE TCH.LoginLayer SET Password=@Pa WHERE Email=@Em";
            }

                cmd.Parameters.AddWithValue("@Pa", NewPass);
                cmd.Parameters.AddWithValue("@Em", Email);

            OpenConnection();

            ExecuteNoneQuery(Command);

            CloseConnection();
        }
    }
}
