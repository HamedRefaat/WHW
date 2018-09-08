using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WHW
{
    public partial class Changepassword : Form
    {
        bool done = false;

        System.Data.OleDb.OleDbConnection conn = new
            System.Data.OleDb.OleDbConnection();
        public Changepassword()
        {
            InitializeComponent();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
               @"Data source=StoresDB.mdb";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(newpass.Text!="" && newnam.Text!=""&& oldpass.Text!=""&&oldname.Text!=""&&cnewpass.Text!="")
            {
            
            
            string oname, opass, nname, npass, cnpass;
            oname = oldname.Text;
            opass = oldpass.Text;
            nname = newnam.Text;
            npass = newpass.Text;
          cnpass=  cnewpass.Text;

          if (npass != cnpass)
          {
              MessageBox.Show("password don't match");

              newpass.Text = "";
              cnewpass.Text = "";
          }
          else
          {


              try
              {
                  conn.Open();

              }

              catch (Exception ex)
              {
                  MessageBox.Show("Failed to connect to data source\n"+ex.Message);
              }

            string searchquery="select username from register WHERE password = @pass ;";

            using (var command = new System.Data.OleDb.OleDbCommand(searchquery, conn))
            {
                command.Parameters.AddWithValue("@pass", opass);

                OleDbDataReader reader = null;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["username"].ToString() == oname)
                        done = true;
                }

            }


            if (done)
            {

                string q = "UPDATE  register SET  username = @nuser, [password] = @npass  WHERE (username = @ouser)";
                using (var command = new System.Data.OleDb.OleDbCommand(q, conn))
                {
                    command.Parameters.AddWithValue("@nuser", nname);
                    command.Parameters.AddWithValue("@npass", npass);
                    command.Parameters.AddWithValue("@ouser", oname);

                    command.ExecuteNonQuery();

                }

                MessageBox.Show("Your Password has been changed");
            }
            else
            {
                MessageBox.Show("invalid password");
            }
             
              conn.Close();

              Close();
          }
        
            }

        }

        private void Changepassword_Load(object sender, EventArgs e)
        {
            newnam.UseSystemPasswordChar = true;
          
        }
    }
}
