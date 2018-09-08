using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WHW
{
    public partial class Login : Form
    {
        System.Data.OleDb.OleDbConnection conn = new
           System.Data.OleDb.OleDbConnection();
      public  bool tes = false;

        public Login()
        {
            InitializeComponent();

            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
              @"Data source=StoresDB.mdb";
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            string user = username.Text;
            string pass = textBox1.Text;
              

            try
            {
                conn.Open();

            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to data source\n" + ex.Message);
            }

            string searchquery = "select * from register;";

            using (var command = new System.Data.OleDb.OleDbCommand(searchquery, conn))
            {
               

                OleDbDataReader reader = null;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if ((reader["password"].ToString() == pass && reader["username"].ToString() == user))
                    {
                                               tes = true;
                      
                    
                    }
                    else
                    {
                        MessageBox.Show("invalid pass");
                    }
                }

                if (tes)
                {
                    
                    conn.Close();
                    Close();        
                }
            }

            /*   string query = "insert into Storesname ([sname]) values(@name);";

               using (var command = new System.Data.OleDb.OleDbCommand(query, conn))
               {

                   command.Parameters.AddWithValue("@name", name);
                   command.ExecuteNonQuery();
                   MessageBox.Show("Test");
               }

       */

            conn.Close();
  


        }
        Timer t = new Timer();
        index ind = new index();
        private void Login_Load(object sender, EventArgs e)
        {
            t.Interval = 3000;
            t.Tick += t_Tick;
            t.Start();
            ind.ShowDialog();
            username.GotFocus += username_GotFocus;
            username.LostFocus += username_LostFocus;
            textBox1.GotFocus += textBox1_GotFocus;
            textBox1.LostFocus += textBox1_LostFocus;
        }

        void textBox1_LostFocus(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "************";

                textBox1.ForeColor = Color.Gray;
            }
        }

        void textBox1_GotFocus(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
            textBox1.Text = "";
        }

        void username_LostFocus(object sender, EventArgs e)
        {
            if (username.Text == "")
            {
                username.Text = "User name";

                username.ForeColor = Color.Gray;
            }
        }

        void username_GotFocus(object sender, EventArgs e)
        {
            username.ForeColor = Color.Black;
            username.Text = "";
        }

        void t_Tick(object sender, EventArgs e)
        {
            t.Stop();

            ind.Close();
            t.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
         DialogResult j=   MessageBox.Show("Are you sure ?", "warning", MessageBoxButtons.YesNo);
            if(j == System.Windows.Forms.DialogResult.Yes)
            this.Close();
        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }
        
        



     
    }
}
