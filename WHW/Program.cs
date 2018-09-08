using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WHW
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Timer t = new Timer();
            t.Interval = 5000;
            t.Tick += t_Tick;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
       
            Login l = new Login();
            l.ShowDialog();
           if (l.tes)
            {
               
                Application.Run(new Form1());
            }

           else
           {
               return;
           }
        }

        static void t_Tick(object sender, EventArgs e)
        {
           
        }
    }
}
