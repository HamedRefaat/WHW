namespace WHW
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.button1 = new System.Windows.Forms.Button();
            this.username = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.visualStyler1 = new SkinSoft.VisualStyler.VisualStyler(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visualStyler1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.button1.ForeColor = System.Drawing.Color.Navy;
            this.button1.Location = new System.Drawing.Point(92, 346);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 51);
            this.button1.TabIndex = 0;
            this.button1.Text = "Login!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // username
            // 
            this.username.Font = new System.Drawing.Font("Tahoma", 15F);
            this.username.ForeColor = System.Drawing.Color.Gray;
            this.username.Location = new System.Drawing.Point(227, 242);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(269, 32);
            this.username.TabIndex = 1;
            this.username.Text = "User name";
            this.username.TextChanged += new System.EventHandler(this.username_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20F);
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(86, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 20F);
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(86, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 33);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 15F);
            this.textBox1.ForeColor = System.Drawing.Color.Gray;
            this.textBox1.Location = new System.Drawing.Point(227, 299);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new System.Drawing.Size(269, 32);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "password";
            this.textBox1.UseSystemPasswordChar = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::WHW.Properties.Resources._10585726_1522807327948743_1628956611_n;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(561, 227);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.button2.ForeColor = System.Drawing.Color.Navy;
            this.button2.Location = new System.Drawing.Point(322, 346);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(174, 51);
            this.button2.TabIndex = 6;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // visualStyler1
            // 
            this.visualStyler1.HostForm = this;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(561, 411);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.username);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(577, 450);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visualStyler1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private SkinSoft.VisualStyler.VisualStyler visualStyler1;
    }
}