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
using System.Collections;

namespace WHW
{
    public partial class Form1 : Form
    {
        Timer clock = new Timer();
        string tsremovedstor = "",fsremoedstor="";
        class stors
        {
         public   string st1, st2;
            public stors(string st1,string st2)
            {
                this.st1 = st1;
                this.st2 = st2;
            }
        }
        public static bool fild = false,once=true;
        List<stors> sto = new List<stors>();
         OleDbCommand old = new OleDbCommand();

            System.Data.OleDb.OleDbConnection conn = new
                System.Data.OleDb.OleDbConnection();
          
      
        decimal count=0, unit=0, sum=0, total=0, cash=0, depit=0;
      
        string item;
        Form1 f;
        addstors ad = new addstors();
        public Form1()
        {
            InitializeComponent();
            clock.Tick += clock_Tick;
            clock.Interval = 1000;

            // TODO: Modify the connection string and include any
            // additional required properties for your database.
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                @"Data source=StoresDB.mdb";
        }

        void clock_Tick(object sender, EventArgs e)
        {
            hh.Text = DateTime.Now.Hour.ToString();
            mm.Text = DateTime.Now.Minute.ToString();
            ss.Text = new DateTime().ToString("tt");
        }


     
        double loadsiz;
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            
            clock.Start();

            Notrich.LostFocus += Notrich_LostFocus;
            Notrich.GotFocus += Notrich_GotFocus;
            dgv.Font = new System.Drawing.Font("Arial", 11,FontStyle.Bold);
            dgv.ForeColor = Color.DarkBlue;
     
            groupBox3.Visible = false;
            fstor.SelectedText = "Select Store";
             tstore.SelectedText = "Select Store";
            dgv.Columns.Add("dtotal", "Total");
            dgv.Columns.Add("dcash", "Cash");
            dgv.Columns.Add("depit","Depit");
            too.SelectedText= "Select Operation Type";
            too.Items.Add("Transfer Money");
            too.Items.Add("Transfer Budget");
         
            addbtn.Location = new Point(850, addbtn.Location.Y);
            label2.Visible = label5.Visible = label6.Visible = label7.Visible = false;
            itemtex.Visible = counttex.Visible = unittex.Visible = sumtxt.Visible = false;
       
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());

            }
            string query = "Select sname from Storesname;";
            using (var command = new System.Data.OleDb.OleDbCommand(query, conn))
            {



                OleDbDataReader reader = null;
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    fstor.Items.Add(reader["sname"].ToString());
                    tstore.Items.Add(reader["sname"].ToString());
                }

            }


            conn.Close();


            



             dateTimePicker1.Value = DateTime.Today;
            counttex.TextAlign = HorizontalAlignment.Center;
            itemtex.TextAlign = HorizontalAlignment.Center;
            unittex.TextAlign = HorizontalAlignment.Center;
            sumtxt.TextAlign = HorizontalAlignment.Center;
            unittex.TextAlign = HorizontalAlignment.Center;
            totaltxt.TextAlign = HorizontalAlignment.Center;
            depittxt.TextAlign = HorizontalAlignment.Center;
            checktxt.TextAlign = HorizontalAlignment.Center;

         
            f = new Form1();
            loadsiz = f.Width;
            groupBox1.Width = (int)loadsiz;
           
           }

        void Notrich_GotFocus(object sender, EventArgs e)
        {
            Notrich.Text="";
            Notrich.ForeColor = Color.Black;
        }

        void Notrich_LostFocus(object sender, EventArgs e)
        {
            if (Notrich.Text == "")
            {
                Notrich.Text = "NOTES";

                Notrich.ForeColor = Color.Gray;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            groupBox1.Width = f.Width;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            button3.Location = new Point(button1.Location.X, button3.Location.Y);
            button2.Location = new Point(button1.Location.X, button2.Location.Y);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void counttex_TextChanged(object sender, EventArgs e)
        {
           /* if (counttex.Text != "" && unittex.Text != "")
            {

                count = decimal.Parse(counttex.Text);
                unit = decimal.Parse(unittex.Text);

                 sum = count * unit;
                 if (count > 9 || unit > 9)
                     total += sum - total;
                 else
                     total += sum;

                
                sumtxt.Text = sum.ToString();
                totaltxt.Text = total.ToString();
            

            }
       */
            }

        private void checktxt_TextChanged(object sender, EventArgs e)
        {
/*if (checktxt.Text != "")
            {
                cash = decimal.Parse(checktxt.Text);

                depit = total - cash;
                depittxt.Text = depit.ToString();
            
            }*/
        }

        private void sumtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void addbtn_Click(object sender, EventArgs e)
        {
       
            if (too.SelectedIndex==0)
            {

                if (totaltxt.Text == "" || checktxt.Text == "" || depittxt.Text == "")
                    MessageBox.Show("missimg data");
                else
                {
                    try
                    {
                        total = decimal.Parse( totaltxt.Text);
                        cash = decimal.Parse(checktxt.Text);
                        depit = decimal.Parse( depittxt.Text);

                        if (fstor.Text != "" && tstore.Text != "")
                        {
                            sto.Add(new stors(fstor.Text, tstore.Text));
                            dgv.Rows.Add(new string[] { total.ToString(), cash.ToString(), depit.ToString() });
                        }
                        else
                            MessageBox.Show("You must select Store, if this is the forst time using this program,\n PLZ, go to add atores and add your stores names");

                    checktxt.Text = depittxt.Text = totaltxt.Text="";

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("PLZ,enter correct Data\n " + ex.Message);
                    }
                }
            }
            else
            {
                if (itemtex.Text!=""&&unittex.Text!=""&&counttex.Text!="")
                {
                    unit = decimal.Parse(unittex.Text);
                    count = decimal.Parse(counttex.Text);
                    total= decimal.Parse( sumtxt.Text);




                    if (fstor.Text != "" && tstore.Text != "")
                    {
                        dgv.Rows.Add(new string[] { itemtex.Text, count.ToString(), unit.ToString(), total.ToString() });

                        sto.Add(new stors(fstor.Text, tstore.Text));
                    }
                    else
                        MessageBox.Show("You must select Store, if this is the forst time using this program,\n PLZ, go to add atores and add your stores names");

             
                }

            }
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
   DialogResult= MessageBox.Show("Are you really want to clear all table ? \n note:- this will not saved in data base","Clear all table", MessageBoxButtons.YesNo);
   if (DialogResult == DialogResult.Yes)
   {
       dgv.Rows.Clear();
   
   }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Are you really want to clear this row ? \n note:- this will not saved in data base", "Clear Row", MessageBoxButtons.YesNo);
            if (DialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in dgv.SelectedRows)
                {
                    dgv.Rows.Remove(item);
                }

            }

            
        
        }

        private void addStoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ad.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ad.ShowDialog();   
        }

        private void button1_Click(object sender, EventArgs e)
        {

          
           
            try
            {
                conn.Open();

            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to data source\n"+ex.ToString());
            }

            if (too.SelectedIndex == 1)
            {

                for (int i = 0; i < dgv.Rows.Count; i++)
                {


                    string fs = sto[i].st1;
                    string ts = sto[i].st2;
                   
                
                        DateTime date2 = dateTimePicker1.Value;

                    string item1 = dgv.Rows[i].Cells[0].Value.ToString();
                    decimal count1 = decimal.Parse(dgv.Rows[i].Cells[1].Value.ToString());
                    decimal unit1 = decimal.Parse(dgv.Rows[i].Cells[2].Value.ToString());
                    decimal sum1 = decimal.Parse(dgv.Rows[i].Cells[3].Value.ToString());
                    decimal chsh1 = 0;
                    string notes = Notrich.Text;


                    string query2 = "insert into storedata ([fstore],[tostore],[item],[count],[unit],[sum],[cash],[Date1],[notes]) values (@fs,@ts,@item1,@count1,@unit1,@sum1,@chsh1,@date2,@notes);";

                    using (var command = new System.Data.OleDb.OleDbCommand(query2, conn))
                    {
                        command.Parameters.AddWithValue("@fs", fs);
                        command.Parameters.AddWithValue("@ts", ts);
                        command.Parameters.AddWithValue("@item1", item1);
                        command.Parameters.AddWithValue("@count1", count1);
                        command.Parameters.AddWithValue("@unit1", unit1);
                        command.Parameters.AddWithValue("@sum1", sum1);
                        command.Parameters.AddWithValue("@chsh1", chsh1);
                        command.Parameters.AddWithValue("@date2", date2);
                        command.Parameters.AddWithValue("@notes", notes);
                        command.ExecuteNonQuery();

                    }

                }

            }
            else
            {

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    string fs = sto[i].st1;

                    string ts = sto[i].st2;
                    DateTime date2 = dateTimePicker1.Value;

                    string item1 = "";
                    decimal count1 = 0;
                    decimal unit1 = 0;
                    decimal sum1 = decimal.Parse(dgv.Rows[i].Cells[0].Value.ToString());
                    decimal chsh1 = decimal.Parse(dgv.Rows[i].Cells[1].Value.ToString());
                  
                    string notes = Notrich.Text;


                    string query2 = "insert into storedata ([fstore],[tostore],[item],[count],[unit],[sum],[cash],[Date1],[notes]) values (@fs,@ts,@item1,@count1,@unit1,@sum1,@chsh1,@date2,@notes);";

                    using (var command = new System.Data.OleDb.OleDbCommand(query2, conn))
                    {
                        command.Parameters.AddWithValue("@fs", fs);
                        command.Parameters.AddWithValue("@ts", ts);
                        command.Parameters.AddWithValue("@item1", item1);
                        command.Parameters.AddWithValue("@count1", count1);
                        command.Parameters.AddWithValue("@unit1", unit1);
                        command.Parameters.AddWithValue("@sum1", sum1);
                        command.Parameters.AddWithValue("@chsh1", chsh1);
                        command.Parameters.AddWithValue("@date2", date2);
                        command.Parameters.AddWithValue("@notes", notes);
                        command.ExecuteNonQuery();

                    }

                }


            }
              conn.Close();
              dgv.Rows.Clear();
              sto.Clear();
              Notrich.Text = "Notes";
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Changepassword c = new Changepassword();
            c.ShowDialog();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Reort r = new Reort();
            r.ShowDialog();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
        
        }

        private void fstor_MouseClick(object sender, MouseEventArgs e)
        {

            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void Notrich_TextChanged(object sender, EventArgs e)
        {
        }

        private void Notrich_Click(object sender, EventArgs e)
        {
           
            if(Notrich.Text=="NOTES")
            Notrich.Text = "";

        
        }

        private void itemtex_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void fstor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Enter(object sender, EventArgs e)
        {

           

        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {
            if (fild&&once)
            {
                fstor.Items.Clear();
                tstore.Items.Clear();
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());

                }
                string query = "Select sname from Storesname;";
                using (var command = new System.Data.OleDb.OleDbCommand(query, conn))
                {



                    OleDbDataReader reader = null;
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        fstor.Items.Add(reader["sname"].ToString());
                        tstore.Items.Add(reader["sname"].ToString());

                    }

                }


                conn.Close();



                once = false;
            }
            }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
          
        }

        private void too_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void too_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (too.Text == "Select Operation Type")
                groupBox3.Visible = false;
            else if (too.SelectedIndex == 1)
            {
                groupBox3.Visible = true;
                dgv.Rows.Clear();
                label2.Visible = label5.Visible = label6.Visible = label7.Visible = true;
                itemtex.Visible = counttex.Visible = unittex.Visible = sumtxt.Visible = true;
                totaltxt.Visible = checktxt.Visible = depittxt.Visible = false;
                label8.Visible = label10.Visible = label9.Visible = false;
                addbtn.Location = new Point(1100, addbtn.Location.Y);
                dgv.Columns.Clear();
                dgv.Columns.Add("gitem", "Item");
                dgv.Columns.Add("gcount", "Count");
                dgv.Columns.Add("gunit", "Unit Cost");
                dgv.Columns.Add("gtotal", "Total");

            }

            else
            {
                groupBox3.Visible = true;
                label2.Visible = label5.Visible = label6.Visible = label7.Visible = false;
                itemtex.Visible = counttex.Visible = unittex.Visible = sumtxt.Visible = false;
                totaltxt.Visible = checktxt.Visible = depittxt.Visible = true;
                label8.Visible = label10.Visible = label9.Visible = true;
                addbtn.Location = new Point(850, addbtn.Location.Y);
                dgv.Columns.Clear();
                dgv.Columns.Add("dtotal", "Total");
                dgv.Columns.Add("dcash", "Cash");
                dgv.Columns.Add("depit", "Depit");
                dgv.Rows.Clear();
            }
            }

        private void Form1_MouseCaptureChanged(object sender, EventArgs e)
        {
           // MessageBox.Show("Test");
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
          
        }

        private void groupBox3_MouseHover(object sender, EventArgs e)
        {
            Form1_MouseHover(sender, e);
        }

        private void addbtn_Click_1(object sender, EventArgs e)
        {
           
            addbtn_Click(sender, e);
            foreach (Control item in groupBox3.Controls)
            {
                if (item is TextBox)
                { item.Text = ""; }
            }
        }


       

        private void depittxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

      
        private void checktxt_TextChanged_2(object sender, EventArgs e)
        {

            if (totaltxt.Text != "" && checktxt.Text != "")
            {
                if (!(totaltxt.Text == "." || checktxt.Text == "."))
                {
                    total = decimal.Parse(totaltxt.Text);
                    cash = decimal.Parse(checktxt.Text);
                    depittxt.Text = (total - cash).ToString();

                }
                }
        }

        private void counttex_TextChanged_1(object sender, EventArgs e)
        {
            if (unittex.Text != "" && counttex.Text != "")
            {
                count = decimal.Parse(counttex.Text);
                unit = decimal.Parse(unittex.Text);
                total = count * unit;
                sumtxt.Text = total.ToString();
            }
        }

        private void fstor_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (tstore.Text != "Select Store")
                tstore.Text = "";
            tsremovedstor = fstor.SelectedItem.ToString();
            tstore.Items.Remove(tsremovedstor);
          
        }

        private void tstore_SelectedIndexChanged(object sender, EventArgs e)
        {
            fsremoedstor = tstore.SelectedItem.ToString();
            fstor.Items.Remove(fsremoedstor);
        }

        private void fstor_SelectionChangeCommitted(object sender, EventArgs e)
        {
          
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
          
        }

        private void fstor_Click(object sender, EventArgs e)
        {
            fstor.Items.Clear();
            tstore.Items.Clear();
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());

            }
            string query = "Select sname from Storesname;";
            using (var command = new System.Data.OleDb.OleDbCommand(query, conn))
            {



                OleDbDataReader reader = null;
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    fstor.Items.Add(reader["sname"].ToString());
                    tstore.Items.Add(reader["sname"].ToString());
                }

            }


            conn.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                groupBox5.Visible = true;
            else
            {
                groupBox5.Visible = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you want to exit?", "CLOSING", MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
                e.Cancel = true;
        }

      

      


    }
}





























































