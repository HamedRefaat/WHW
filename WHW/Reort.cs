using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WHW
{
    public partial class Reort : Form
    {
        String notes="";
        int btninc, gbinc,gb2;
        Timer tm = new Timer();
        public static bool Checkifcolumn = false;
        int listheight = 0;
        int inc = 5;
        Timer t=new Timer();
        bool[] columnsToPrint = new bool[100];
        bool ftime = true;
        DataTable dt;
        double fstortotal=0, fstortotalchsh = 0, fstortotaldepit = 0, fstorcash = 0, fstorsum = 0, tstortotal = 0, tstortotaldepit = 0, tstorcash = 0, tstorsum = 0, tstortotalcash;

        System.Data.OleDb.OleDbConnection conn = new
            System.Data.OleDb.OleDbConnection();
        List<recive> result = new List<recive>();

        double width;
        public Reort()
        {
            InitializeComponent();
            tm.Tick += tm_Tick;
            t.Tick += t_Tick;
            // additional required properties for your database.
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                @"Data source=StoresDB.mdb";

        }

        private void Report1_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var p = "From Date: " + dateTimePicker1.Text + "\tTo Date: " + dateTimePicker2.Text + "\n\nFrom Store: " + comboBox1.Text + "\nTo Store: " + comboBox2.Text +
                "\n\n\nTotal Cash:  " + textBox1.Text + "\nTotal Depit:  " + textBox2.Text + "\nTotal:           " + textBox3.Text;

            var n = "\n\t\t Notes\n\n"+notes;
            e.Graphics.DrawString(p, new Font("Arial", 24), Brushes.Black, new PointF(50, 100));
            if(!(notes=="Notes"||notes=="NOTES"||notes==""))
            e.Graphics.DrawString(n, new Font("Arial", 24), Brushes.Red, new PointF(50, 500));
       
        
        }

        private void button2_Click(object sender, EventArgs e)
        {

            printDialog1.AllowCurrentPage = true;
            printDialog1.AllowPrintToFile = true;
            printDialog1.AllowSelection = true;
            printDialog1.AllowSomePages = true;


            printDocument1.PrintPage += printDocument1_PrintPage;

            printDialog1.Document = printDocument1;

            printPreviewDialog1.Document = printDocument1;
         printPreviewDialog1.ShowDialog();
            PrintDocument p = new PrintDocument();
            CenterToParent();
            if (printDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
            else
                MessageBox.Show("Print has bee canceld");


        }

        private void Reort_SizeChanged(object sender, EventArgs e)
        {
        }

        private void Reort_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedText = comboBox2.SelectedText = storname.SelectedText = "Select Store";
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
                    comboBox1.Items.Add(reader["sname"].ToString());
                    comboBox2.Items.Add(reader["sname"].ToString());
                    storname.Items.Add(reader["sname"].ToString());
                }

            }

         
               
            conn.Close();



            dateTimePicker1.Value = dateTimePicker2.Value = tdate.Value = fdate.Value = DateTime.Today;
            width = new Reort().Width;
            storname.Items.Add("All");
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dt = new DataTable();

            button3.Visible = button2.Visible = true;
            DateTime fdate = DateTime.Today, tdate = DateTime.Today; ;
            string fstore = "", tostore = "";
            if (comboBox1.Text != "" && comboBox2.Text != "")
            {
                fdate = dateTimePicker1.Value;
                tdate = dateTimePicker2.Value;
                fstore = comboBox1.Text;
                tostore = comboBox2.Text;

            }


            string query = "select fstore, item,count,unit,sum,cash,tostore,total,notes from storedata where Date1 <= @tdate and Date1 >= @fdate;";

            try
            {
                conn.Open();

            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to data source\n" + ex.Message);
            }




            using (var command = new System.Data.OleDb.OleDbCommand(query, conn))
            {
                command.Parameters.AddWithValue("@tdate", tdate);
                command.Parameters.AddWithValue("@fdate", fdate);



                System.Data.OleDb.OleDbDataReader reader = null;
                reader = command.ExecuteReader();


                while (reader.Read())
                {


                    if ((reader["fstore"].ToString() == fstore && reader["tostore"].ToString() == tostore) || ((reader["fstore"].ToString() == tostore && reader["tostore"].ToString() == fstore)))
                    {
                        if ((reader["fstore"].ToString() == fstore && reader["tostore"].ToString() == tostore))
                            notes = reader["notes"].ToString();

                        recive r = new recive(reader["cash"].ToString(), reader["sum"].ToString(), reader["fstore"].ToString(), reader["tostore"].ToString());
                        if (reader["item"].ToString() != "")
                        {
                           

                            dataGridView2.Rows.Add(new string[] { reader["fstore"].ToString(), reader["item"].ToString(), reader["count"].ToString(), reader["unit"].ToString(), r.sum, "Not Set", r.tostor });

                        }
                        else
                        {
                           
                            dataGridView2.Rows.Add(new string[] { reader["fstore"].ToString(), "Not Set", "Not Set", "Not Set", r.sum, r.cash, r.tostor });
                        
                        }
                        result.Add(r);
                        if (r.fstor == fstore && r.tostor == tostore)
                        {
                            fstorsum = double.Parse(r.sum);
                            fstortotal += fstorsum;
                            fstorcash = double.Parse(r.cash);
                            fstortotalchsh += fstorcash;
                        }

                        if (r.fstor == tostore && r.tostor == fstore)
                        {
                           
                            tstorsum = double.Parse(r.sum);
                            fstortotal -= tstorsum;
                            tstorcash = double.Parse(r.cash);
                            fstortotalchsh -= tstorcash;

                        }


                    }
                }


               
                textBox1.Text = (fstortotalchsh).ToString();
                textBox2.Text = (fstortotal-fstortotalchsh).ToString();
                textBox3.Text = (fstortotal ).ToString();

                fstortotalchsh = 0;
                fstortotal = 0;


            }



            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Show Details")
            {

                button3.Text = "Hide Details";
                dataGridView2.Visible = true;


            }

            else
            {

                button3.Text = "Show Details";
                dataGridView2.Rows.Clear();
            //    dataGridView2.Visible = false;


            }

        }

        private void storname_SelectedIndexChanged(object sender, EventArgs e)
        {
            ftime = true;

            dataGridView1.Rows.Clear();
            if (!(fdate.Checked && tdate.Checked))
            {
                MessageBox.Show("plz, choose the date range");
                return;
            }
            DateTime fsdat = DateTime.Today, tedat = DateTime.Today ;

            fsdat = fdate.Value;
            tedat = tdate.Value;
            printbtn2.Visible = true;
            double advance = 0, withdrawl = 0, net = 0;
            try
            {
                conn.Open();

            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to data source\n" + ex.Message);
            }
            
            
            
                string stornamestring = storname.Items[storname.SelectedIndex].ToString();
                string query;
            if (stornamestring == "All")
            {
                query = "select fstore,tostore,sum from storedata where (Date1<= @tdate and Date1>=@fdate);";
            }
            else
            {
                query = "select fstore,tostore,sum from storedata where (fstore=@fname or tostore=@fname) and (Date1<= @tdate and Date1>=@fdate);";
            }
            using (var command = new System.Data.OleDb.OleDbCommand(query, conn))
            {
                if(stornamestring!="All")
                command.Parameters.AddWithValue("@fname", stornamestring);
                command.Parameters.AddWithValue("@tdate",tedat);
                command.Parameters.AddWithValue("@fdate",fsdat);
                System.Data.OleDb.OleDbDataReader reader = null;
                reader = command.ExecuteReader();
                if (stornamestring != "All")
                {

                    while (reader.Read())
                    {
                        if (reader["fstore"].ToString() == stornamestring)
                            advance += double.Parse(reader["sum"].ToString());

                        if (reader["tostore"].ToString() == stornamestring)
                            withdrawl += double.Parse(reader["sum"].ToString());
                    }

                    net = -(advance - withdrawl);
                    dataGridView1.Rows.Add(new string[] { stornamestring, advance.ToString(), withdrawl.ToString(), net.ToString() });
                }
                else
                {
                    
                    foreach (string item in storname.Items)
                    {
                        advance = 0;
                        withdrawl = 0;
                        if(!ftime)
                        reader = command.ExecuteReader();
                            if (item != "All")
                           {
                            while (reader.Read())
                            {
                                if (reader["fstore"].ToString() == item)
                                    advance += double.Parse(reader["sum"].ToString());

                                if (reader["tostore"].ToString() == item)
                                    withdrawl += double.Parse(reader["sum"].ToString());
                            }


                            net = -(advance - withdrawl);
                            dataGridView1.Rows.Add(new string[] { item, advance.ToString(), withdrawl.ToString(), net.ToString() });
                            reader.Close();
                            ftime = false;


                        }
                    }

                }

            }

            conn.Close();


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void printbtn2_Click(object sender, EventArgs e)
        {
            printDocument2.PrintPage += printDocument2_PrintPage;
            printPreviewDialog2.Document = printDocument2;
            printPreviewDialog2.ShowDialog();
        }


        //=========================







        //=====================



        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            int rowCounter = 0;
            int z = 0;
            StringFormat str = new StringFormat();
            str.Alignment = StringAlignment.Near;
            str.LineAlignment = StringAlignment.Center;
            str.Trimming = StringTrimming.EllipsisCharacter;

            int width = 200;
            int realwidth =10;
            int height = 30;

            int realheight = 100;
            var title = "\t\tTable of Payable";
            var dat = "\t\t      From date  " + dateTimePicker1.Text + "      To Date  " + dateTimePicker2.Text;
            e.Graphics.DrawString(title, new Font("Arial", 24), Brushes.DarkBlue, new PointF(50, 2));
            e.Graphics.DrawString(dat, new Font("Arial", 15), Brushes.Red, new PointF(50, 50));
       
       

            // Please note this is where I am Printing Sunday , Monday , Tuesday.... We can also move rowCounter to 
            // the maxRowcounter loop where we are printing below 
            for (z = 0; z < dataGridView1.Columns.Count ; z++)
            {
                e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, realheight, width, height);
                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height);

                e.Graphics.DrawString(dataGridView1.Columns[z].HeaderText, dataGridView1.Font, Brushes.Black, realwidth, realheight);

                realwidth = realwidth + width;
            }

            z = 0;
            realheight = realheight + height;
            while (rowCounter < dataGridView1.Rows.Count)
            {
                realwidth = 10;

                if (dataGridView1.Rows[rowCounter].Cells[0].Value == null)
                {
                    dataGridView1.Rows[rowCounter].Cells[0].Value = "";
                }
                e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, realheight, width, height);
                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height);

                e.Graphics.DrawString(dataGridView1.Rows[rowCounter].Cells[0].Value.ToString(), dataGridView1.Font, Brushes.Black, realwidth, realheight);
                realwidth = realwidth + width;
                if (dataGridView1.Rows[rowCounter].Cells[1].Value == null)
                    dataGridView1.Rows[rowCounter].Cells[1].Value = "";

                e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, realheight, width, height);
                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height);

                e.Graphics.DrawString(dataGridView1.Rows[rowCounter].Cells[1].Value.ToString(), dataGridView1.Font, Brushes.Black, realwidth, realheight);

                realwidth = realwidth + width;

                if (dataGridView1.Rows[rowCounter].Cells[2].Value == null)
                {
                    dataGridView1.Rows[rowCounter].Cells[2].Value = "";
                }
                e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, realheight, width, height);
                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height);

                e.Graphics.DrawString(dataGridView1.Rows[rowCounter].Cells[2].Value.ToString(), dataGridView1.Font, Brushes.Black, realwidth, realheight);
                realwidth = realwidth + width;

                if (dataGridView1.Rows[rowCounter].Cells[3].Value == null)
                {
                    dataGridView1.Rows[rowCounter].Cells[3].Value = "";
                }
                e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, realheight, width, height);
                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height);

                e.Graphics.DrawString(dataGridView1.Rows[rowCounter].Cells[3].Value.ToString(), dataGridView1.Font, Brushes.Black, realwidth, realheight);
                realwidth = realwidth + width;


              
                realheight = realheight + height;
                rowCounter++;

            }



        }

        class recive
        {
            public string cash, sum;
            public string fstor, tostor;
            public recive(string cash, string sum, string fstor, string tostor)
            {
                this.cash = cash; this.sum = sum; this.fstor = fstor; this.tostor = tostor;

            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            button1_Click(sender,e);
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            btninc = 1;
            gbinc = 1;
            gb2 = 1;
            button3_Click(sender, e);
         
            tm.Interval = 100;
           
            tm.Start();
        }

        void tm_Tick(object sender, EventArgs e)
        {
            if (button3.Text == "Hide Details")
            {
                if (groupBox2.Location.Y>218)
                {
                    groupBox2.Location = new Point(groupBox2.Location.X, groupBox2.Location.Y - gb2);
                }
                if (groupBox4.Height < 300)
                    groupBox4.Height += gbinc;

                if (button2.Location.Y > 330)
                {
                    button2.Location = new Point(button2.Location.X, button2.Location.Y - btninc);
                    button3.Location = new Point(button3.Location.X, button3.Location.Y - btninc);
                }
                
                if (button2.Location.Y <= 330)
                {
                    tm.Stop();
                }

               
            }

            else
            {
                if (groupBox2.Location.Y <= 311)
                {
                    groupBox2.Location = new Point(groupBox2.Location.X, groupBox2.Location.Y + gb2);
                }
               

                if (groupBox4.Height <= 2)
                    tm.Stop();
                groupBox4.Height -= gbinc;
                if (button2.Location.Y<580)
                {
                    button2.Location = new Point(button2.Location.X, button2.Location.Y + btninc);
                    button3.Location = new Point(button3.Location.X, button3.Location.Y + btninc);
                
                }

               
            }
            gbinc += 2;
            btninc += 2;
            gb2 += 2;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void storname_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            storname_SelectedIndexChanged(sender, e);
        }

        private void printbtn2_Click_1(object sender, EventArgs e)
        {
            printbtn2_Click(sender, e);
        }

        private void Report1_Enter_1(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void tabControl1_MouseUp(object sender, MouseEventArgs e)
        {
            storname.SelectedText = "Select Stor";
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void storname_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            storname_SelectedIndexChanged_1(sender,e);

            groupBox3.Height = 182;
          
        }

        private void printbtn2_Click_2(object sender, EventArgs e)
        {
            printbtn2_Click(sender,e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text != "Select Store")
                comboBox2.Text = "";

            comboBox2.Items.Remove(comboBox1.SelectedItem.ToString());
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
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
                    comboBox1.Items.Add(reader["sname"].ToString());
                    comboBox2.Items.Add(reader["sname"].ToString());
                }

            }


            conn.Close();
        }

        private void storname_DropDown(object sender, EventArgs e)
        {
        }

        void t_Tick(object sender, EventArgs e)
        {
                    
                groupBox3.Height += inc;
               
                if (inc+182 >= listheight)
                {
                   
                    t.Stop();

                    groupBox3.Height =182+ listheight;
                }
                inc += 5;
             

        }

        private void storname_MouseDown(object sender, MouseEventArgs e)
        {


            inc = 0;
            t.Interval = 300;
            if (storname.DropDownHeight>30)
                listheight = storname.ItemHeight * storname.Items.Count;
            else
                listheight = 0;
            //MessageBox.Show(listheight.ToString());
            groupBox3.Height = 182 + listheight;
         //   t.Start();
        }

      



    }
}

