namespace WHW
{
    partial class Changepassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Changepassword));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.oldname = new System.Windows.Forms.TextBox();
            this.oldpass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.newnam = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.newpass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cnewpass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(373, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 96);
            this.button1.TabIndex = 0;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "User name";
            // 
            // oldname
            // 
            this.oldname.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oldname.Location = new System.Drawing.Point(187, 17);
            this.oldname.Multiline = true;
            this.oldname.Name = "oldname";
            this.oldname.Size = new System.Drawing.Size(163, 28);
            this.oldname.TabIndex = 2;
            // 
            // oldpass
            // 
            this.oldpass.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oldpass.Location = new System.Drawing.Point(187, 51);
            this.oldpass.Name = "oldpass";
            this.oldpass.PasswordChar = '*';
            this.oldpass.Size = new System.Drawing.Size(163, 27);
            this.oldpass.TabIndex = 4;
            this.oldpass.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // newnam
            // 
            this.newnam.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newnam.Location = new System.Drawing.Point(187, 85);
            this.newnam.Multiline = true;
            this.newnam.Name = "newnam";
            this.newnam.Size = new System.Drawing.Size(163, 28);
            this.newnam.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "New user name";
            // 
            // newpass
            // 
            this.newpass.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newpass.Location = new System.Drawing.Point(187, 121);
            this.newpass.Name = "newpass";
            this.newpass.PasswordChar = '*';
            this.newpass.Size = new System.Drawing.Size(163, 27);
            this.newpass.TabIndex = 8;
            this.newpass.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "New passwprd";
            // 
            // cnewpass
            // 
            this.cnewpass.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cnewpass.Location = new System.Drawing.Point(187, 158);
            this.cnewpass.Name = "cnewpass";
            this.cnewpass.PasswordChar = '*';
            this.cnewpass.Size = new System.Drawing.Size(163, 27);
            this.cnewpass.TabIndex = 10;
            this.cnewpass.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Confirm new password";
            // 
            // Changepassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(516, 207);
            this.Controls.Add(this.cnewpass);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.newpass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.newnam);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.oldpass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.oldname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Changepassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Changepassword";
            this.Load += new System.EventHandler(this.Changepassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox oldname;
        private System.Windows.Forms.TextBox oldpass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox newnam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox newpass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cnewpass;
        private System.Windows.Forms.Label label5;
    }
}