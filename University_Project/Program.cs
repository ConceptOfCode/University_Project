using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_Project
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // MessageBox.Show("برای فرم ثبت نام یک طرح بهتر درست شود یا کلا حذف و داخل فرم دانشجو برده شود");
            Application.Run(new Login_Layer());
        }
    }
}
