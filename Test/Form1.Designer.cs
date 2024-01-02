namespace Test
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnrabbit = new Button();
            btnredis = new Button();
            btnsql = new Button();
            txtrabbit = new TextBox();
            txtredis = new TextBox();
            txtsqlswname = new TextBox();
            txtsqlswpass = new TextBox();
            txtsqlswuname = new TextBox();
            chksqlswpass = new CheckBox();
            btnELK = new Button();
            txtELK = new TextBox();
            txtIndex = new TextBox();
            txtUname = new TextBox();
            txtPassword = new TextBox();
            txtLevel = new TextBox();
            txtMessage = new TextBox();
            btnelk_con = new Button();
            chkelk = new CheckBox();
            SuspendLayout();
            // 
            // btnrabbit
            // 
            btnrabbit.Location = new Point(40, 90);
            btnrabbit.Name = "btnrabbit";
            btnrabbit.Size = new Size(206, 81);
            btnrabbit.TabIndex = 0;
            btnrabbit.Text = "RABBITMQ";
            btnrabbit.UseVisualStyleBackColor = true;
            btnrabbit.Click += btnrabbit_Click;
            // 
            // btnredis
            // 
            btnredis.Location = new Point(337, 90);
            btnredis.Name = "btnredis";
            btnredis.Size = new Size(206, 81);
            btnredis.TabIndex = 0;
            btnredis.Text = "REDIS";
            btnredis.UseVisualStyleBackColor = true;
            btnredis.Click += btnredis_Click;
            // 
            // btnsql
            // 
            btnsql.Location = new Point(635, 90);
            btnsql.Name = "btnsql";
            btnsql.Size = new Size(206, 81);
            btnsql.TabIndex = 0;
            btnsql.Text = "MSSQL";
            btnsql.UseVisualStyleBackColor = true;
            btnsql.Click += btnsql_Click;
            // 
            // txtrabbit
            // 
            txtrabbit.Location = new Point(40, 177);
            txtrabbit.Name = "txtrabbit";
            txtrabbit.Size = new Size(206, 23);
            txtrabbit.TabIndex = 1;
            txtrabbit.Text = "Server Name / Host IP";
            txtrabbit.Click += txtrabbit_Click;
            // 
            // txtredis
            // 
            txtredis.Location = new Point(337, 177);
            txtredis.Name = "txtredis";
            txtredis.Size = new Size(206, 23);
            txtredis.TabIndex = 1;
            txtredis.Text = "Server Name / Host IP";
            txtredis.Click += txtredis_Click;
            // 
            // txtsqlswname
            // 
            txtsqlswname.Location = new Point(635, 177);
            txtsqlswname.Name = "txtsqlswname";
            txtsqlswname.Size = new Size(206, 23);
            txtsqlswname.TabIndex = 1;
            txtsqlswname.Text = "Server Name / Host IP";
            txtsqlswname.Click += txtsqlswname_Click;
            // 
            // txtsqlswpass
            // 
            txtsqlswpass.Location = new Point(741, 206);
            txtsqlswpass.Name = "txtsqlswpass";
            txtsqlswpass.Size = new Size(100, 23);
            txtsqlswpass.TabIndex = 2;
            txtsqlswpass.Text = "Password";
            txtsqlswpass.Click += txtsqlswpass_Click;
            // 
            // txtsqlswuname
            // 
            txtsqlswuname.Location = new Point(635, 206);
            txtsqlswuname.Name = "txtsqlswuname";
            txtsqlswuname.Size = new Size(100, 23);
            txtsqlswuname.TabIndex = 2;
            txtsqlswuname.Text = "Username";
            txtsqlswuname.Click += txtsqlswuname_Click;
            // 
            // chksqlswpass
            // 
            chksqlswpass.AutoSize = true;
            chksqlswpass.Location = new Point(746, 235);
            chksqlswpass.Name = "chksqlswpass";
            chksqlswpass.Size = new Size(95, 19);
            chksqlswpass.TabIndex = 3;
            chksqlswpass.Text = "Şifreyi Göster";
            chksqlswpass.UseVisualStyleBackColor = true;
            chksqlswpass.CheckedChanged += chksqlswpass_CheckedChanged_1;
            // 
            // btnELK
            // 
            btnELK.Location = new Point(337, 262);
            btnELK.Name = "btnELK";
            btnELK.Size = new Size(206, 79);
            btnELK.TabIndex = 4;
            btnELK.Text = "Elasticsearch Send Test Data";
            btnELK.UseVisualStyleBackColor = true;
            btnELK.Click += btnELK_Click;
            // 
            // txtELK
            // 
            txtELK.Location = new Point(40, 347);
            txtELK.Name = "txtELK";
            txtELK.Size = new Size(206, 23);
            txtELK.TabIndex = 5;
            txtELK.Text = "Elasticsearch URL";
            txtELK.Click += txtELK_Click;
            // 
            // txtIndex
            // 
            txtIndex.Location = new Point(337, 347);
            txtIndex.Name = "txtIndex";
            txtIndex.Size = new Size(206, 23);
            txtIndex.TabIndex = 6;
            txtIndex.Text = "Create İndex Name";
            txtIndex.Click += txtIndex_Click;
            // 
            // txtUname
            // 
            txtUname.Location = new Point(40, 376);
            txtUname.Name = "txtUname";
            txtUname.Size = new Size(100, 23);
            txtUname.TabIndex = 7;
            txtUname.Text = "Username";
            txtUname.Click += txtUname_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(146, 376);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 8;
            txtPassword.Text = "Password";
            txtPassword.Click += txtPassword_Click;
            // 
            // txtLevel
            // 
            txtLevel.Location = new Point(337, 376);
            txtLevel.Name = "txtLevel";
            txtLevel.Size = new Size(100, 23);
            txtLevel.TabIndex = 9;
            txtLevel.Text = "Level";
            txtLevel.Click += txtLevel_Click;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(443, 376);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(100, 23);
            txtMessage.TabIndex = 10;
            txtMessage.Text = "Message";
            txtMessage.Click += txtMessage_Click;
            // 
            // btnelk_con
            // 
            btnelk_con.Location = new Point(40, 262);
            btnelk_con.Name = "btnelk_con";
            btnelk_con.Size = new Size(206, 79);
            btnelk_con.TabIndex = 11;
            btnelk_con.Text = "Elasticsearch Connection";
            btnelk_con.UseVisualStyleBackColor = true;
            btnelk_con.Click += btnelk_con_Click;
            // 
            // chkelk
            // 
            chkelk.AutoSize = true;
            chkelk.Location = new Point(151, 405);
            chkelk.Name = "chkelk";
            chkelk.Size = new Size(95, 19);
            chkelk.TabIndex = 12;
            chkelk.Text = "Şifreyi Göster";
            chkelk.UseVisualStyleBackColor = true;
            chkelk.CheckedChanged += chkelk_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(905, 476);
            Controls.Add(chkelk);
            Controls.Add(btnelk_con);
            Controls.Add(txtMessage);
            Controls.Add(txtLevel);
            Controls.Add(txtPassword);
            Controls.Add(txtUname);
            Controls.Add(txtIndex);
            Controls.Add(txtELK);
            Controls.Add(btnELK);
            Controls.Add(chksqlswpass);
            Controls.Add(txtsqlswuname);
            Controls.Add(txtsqlswpass);
            Controls.Add(txtsqlswname);
            Controls.Add(txtredis);
            Controls.Add(txtrabbit);
            Controls.Add(btnsql);
            Controls.Add(btnredis);
            Controls.Add(btnrabbit);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnrabbit;
        private Button btnredis;
        private Button btnsql;
        private TextBox txtrabbit;
        private TextBox txtredis;
        private TextBox txtsqlswname;
        private TextBox txtsqlswpass;
        private TextBox txtsqlswuname;
        private CheckBox chksqlswpass;
        private Button btnELK;
        private TextBox txtELK;
        private TextBox txtIndex;
        private TextBox txtUname;
        private TextBox txtPassword;
        private TextBox txtLevel;
        private TextBox txtMessage;
        private Button btnelk_con;
        private CheckBox chkelk;
    }
}