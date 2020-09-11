using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace University_Project
{
    class Cls_Hash
    {
        public static string MakeHash(string Password)
        {
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();

            MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Password));
            byte[] Result = MD5.Hash;

            StringBuilder SB = new StringBuilder();
            for (int i = 1; i < Result.Length; i++)
            {
                SB.Append(Result[i].ToString("x2"));
            }

            return SB.ToString();
        }
    }
}
