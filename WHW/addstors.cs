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
    public partial class addstors : Form
    {
      public  string[] Stores;
     

        List<string> s = new List<string>();
        OleDbCommand old = new OleDbCommand();

        System.Data.OleDb.OleDbConnection conn = new
            System.Data.OleDb.OleDbConnection();

       
 
        public addstors()
        {
            InitializeComponent();
            // additional required properties for your database.
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                @"Data source=StoresDB.mdb";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            label1.Text = "Stores names";
            Stores = textBox1.Text.Split(',');
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Stroe name";
            label2.Visible = false;
            s.Add(textBox1.Text);
        }

        private void addstors_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            radioButton2.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form1.fild = true;
            Form1.once = true;

            try
            {
                conn.Open();

            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to data source\n"+ex.Message);
            }
            if (textBox1.Text != "")
            {
                if (radioButton2.Checked)
                {

                    Stores = textBox1.Text.Split(',');

                    foreach (string name in Stores)
                    {

                        string query = "insert into Storesname ([sname]) values(@name);";

                        using (var command = new System.Data.OleDb.OleDbCommand(query, conn))
                        {

                            command.Parameters.AddWithValue("@name", name);
                            command.ExecuteNonQuery();

                        }


                    }

                    MessageBox.Show("Added Successfully");
                    conn.Close();
                   
                }
                else
                {

                    string query = "insert into Storesname ([sname]) values(@name);";

                    using (var command = new System.Data.OleDb.OleDbCommand(query, conn))
                    {

                        command.Parameters.AddWithValue("@name", textBox1.Text);
                        command.ExecuteNonQuery();

                        textBox1.Text = "";
                    }


                }
            }
            conn.Close();

            textBox1.Text = "";
            
           
        }
    }
}
