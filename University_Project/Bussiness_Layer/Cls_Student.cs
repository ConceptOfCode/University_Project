using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Project
{
    class Cls_Student:Cls_DataLayer
    {
        #region Instance
        String Command;

        #endregion

        public void Insert(Int64 ID, String FirstName, String LastName, Int32 Major, DateTime Date, String FatherName, Int32 Gender,Int16 RegisterUser)
        {
            OpenConnection();

            Command = "INSERT INTO STD.Student (ID, FirstName, LastName, Major, BirthDate, FatherName, Gender, RegisterUser) VALUES ('" + ID + "',N'" + FirstName + "',N'" + LastName + "','" + Major + "','" + Date + "',N'" + FatherName + "','" + Gender + "','" + RegisterUser + "')";

            ExecuteNoneQuery(Command);

            CloseConnection();
        }

        public void Update(Int64 ID, String FirstName, String LastName, Int32 Major, DateTime Date, String FatherName, Int32 Gender)
        {
            Command = "UPDATE STD.Student SET FirstName =N'" + FirstName + "', LastName =N'" + LastName + "', Major ='" + Major + "', BirthDate ='" + Date + "', FatherName =N'" + FatherName + "', Gender ='" + Gender + "'WHERE ID='" + ID + "'";

            OpenConnection();

            ExecuteNoneQuery(Command);

            CloseConnection();
        }
    }
}
