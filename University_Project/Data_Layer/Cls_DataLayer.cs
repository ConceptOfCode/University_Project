using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace University_Project
{
    class Cls_DataLayer
    {

        #region instanc
        public static SqlConnection con;
        public static SqlCommand cmd = new SqlCommand();
        public static SqlDataAdapter DA;
        public static DataTable DT;

        #endregion

        public static void OpenConnection()
        {
            con = new SqlConnection();
            con.ConnectionString = Login_Layer.Address;


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public static void ExecuteNoneQuery(string Command)
        {
            

            try
            {
                cmd.Connection = con;
                cmd.CommandText = Command;
                cmd.ExecuteNonQuery();
             }


            #region exception
            catch (NoNullAllowedException)
            {
                MessageBox.Show("یکی از فیلد ها خالی میباشد در صورتی ک شما اجازه چنین کاری ندارید", "خطا در ورود", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            catch (SyntaxErrorException se)
            {
                MessageBox.Show(se.Message);
            }

            catch (SystemException sr)
            {
                MessageBox.Show(sr.Message);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion
        }

        public static DataTable ExecuteDataTable(string Select)
        {
            try
            {
                OpenConnection();

                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = Select;

                DA = new SqlDataAdapter();
                DA.SelectCommand = cmd;

                DT = new DataTable();
                DA.Fill(DT);
            }
                          
            
                         #region EXCEPTION
            catch (SyntaxErrorException)
            {
                MessageBox.Show("دستور شما غلط املایی دارد", "syntax error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch(SqlException se)
            {
                MessageBox.Show(se.Message);
            }

            catch(SystemException Se)
            {
                MessageBox.Show(Se.Message);
            }

            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

#endregion
            return DT;
        }

        public static void CloseConnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (con.State == ConnectionState.Broken)
            {
                con.Close();
            }
        }

    }
}
