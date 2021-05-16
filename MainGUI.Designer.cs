
namespace PROJECT_HBS
{
    partial class MainGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGUI));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabUserInfor = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ShowUserInfor = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.NameInfo = new System.Windows.Forms.TextBox();
            this.PhoneInfor = new System.Windows.Forms.TextBox();
            this.EmailInfor = new System.Windows.Forms.TextBox();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabUserInfor.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1300, 27);
            this.panel2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(40, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hotel Booking - Nhóm 18";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1246, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(8, 1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1276, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // tabUserInfor
            // 
            this.tabUserInfor.Controls.Add(this.tabPage1);
            this.tabUserInfor.Controls.Add(this.tabPage2);
            this.tabUserInfor.ItemSize = new System.Drawing.Size(128, 40);
            this.tabUserInfor.Location = new System.Drawing.Point(12, 33);
            this.tabUserInfor.Name = "tabUserInfor";
            this.tabUserInfor.SelectedIndex = 0;
            this.tabUserInfor.Size = new System.Drawing.Size(1276, 660);
            this.tabUserInfor.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 44);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1268, 612);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thông tin người dùng";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.ShowUserInfor);
            this.panel1.Controls.Add(this.UpdateButton);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.NameInfo);
            this.panel1.Controls.Add(this.PhoneInfor);
            this.panel1.Controls.Add(this.EmailInfor);
            this.panel1.Controls.Add(this.LogOutButton);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.UsernameBox);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(24, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(439, 561);
            this.panel1.TabIndex = 0;
            // 
            // ShowUserInfor
            // 
            this.ShowUserInfor.Location = new System.Drawing.Point(25, 431);
            this.ShowUserInfor.Name = "ShowUserInfor";
            this.ShowUserInfor.Size = new System.Drawing.Size(383, 43);
            this.ShowUserInfor.TabIndex = 30;
            this.ShowUserInfor.Text = "Hiển Thị Thông Tin Người Dùng";
            this.ShowUserInfor.UseVisualStyleBackColor = true;
            this.ShowUserInfor.Click += new System.EventHandler(this.ShowUserInfor_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(25, 368);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(383, 43);
            this.UpdateButton.TabIndex = 29;
            this.UpdateButton.Text = "Cập Nhật Thông Tin Người Dùng";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(231, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "Đổi Mật Khẩu";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // NameInfo
            // 
            this.NameInfo.Location = new System.Drawing.Point(126, 310);
            this.NameInfo.Name = "NameInfo";
            this.NameInfo.Size = new System.Drawing.Size(282, 23);
            this.NameInfo.TabIndex = 27;
            // 
            // PhoneInfor
            // 
            this.PhoneInfor.Location = new System.Drawing.Point(126, 260);
            this.PhoneInfor.Name = "PhoneInfor";
            this.PhoneInfor.Size = new System.Drawing.Size(282, 23);
            this.PhoneInfor.TabIndex = 26;
            // 
            // EmailInfor
            // 
            this.EmailInfor.Location = new System.Drawing.Point(126, 212);
            this.EmailInfor.Name = "EmailInfor";
            this.EmailInfor.Size = new System.Drawing.Size(282, 23);
            this.EmailInfor.TabIndex = 25;
            // 
            // LogOutButton
            // 
            this.LogOutButton.Location = new System.Drawing.Point(127, 119);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(82, 23);
            this.LogOutButton.TabIndex = 24;
            this.LogOutButton.Text = "Đăng Xuất";
            this.LogOutButton.UseVisualStyleBackColor = true;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 23;
            this.label5.Text = "Họ và Tên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 15);
            this.label4.TabIndex = 22;
            this.label4.Text = "Số điện thoại";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "Email";
            // 
            // UsernameBox
            // 
            this.UsernameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UsernameBox.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UsernameBox.Location = new System.Drawing.Point(126, 71);
            this.UsernameBox.Multiline = true;
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.ReadOnly = true;
            this.UsernameBox.Size = new System.Drawing.Size(282, 41);
            this.UsernameBox.TabIndex = 20;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(25, 57);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(95, 94);
            this.pictureBox4.TabIndex = 2;
            this.pictureBox4.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(439, 39);
            this.panel3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(111, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "THÔNG TIN NGƯỜI DÙNG";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 44);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1268, 612);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tìm kiếm khách sạn";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 705);
            this.Controls.Add(this.tabUserInfor);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainGUI";
            this.Text = "MainGUI";
            this.Load += new System.EventHandler(this.MainGUI_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabUserInfor.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabUserInfor;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox NameInfo;
        private System.Windows.Forms.TextBox PhoneInfor;
        private System.Windows.Forms.TextBox EmailInfor;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.Button ShowUserInfor;
    }
}