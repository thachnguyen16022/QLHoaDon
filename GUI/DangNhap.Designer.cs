namespace GUI
{
    partial class DangNhap
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
            this.bntdangnhap = new System.Windows.Forms.Button();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblpass = new System.Windows.Forms.Label();
            this.lbluser = new System.Windows.Forms.Label();
            this.bttnthoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bntdangnhap
            // 
            this.bntdangnhap.BackColor = System.Drawing.Color.Red;
            this.bntdangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntdangnhap.ForeColor = System.Drawing.Color.Yellow;
            this.bntdangnhap.Location = new System.Drawing.Point(218, 137);
            this.bntdangnhap.Name = "bntdangnhap";
            this.bntdangnhap.Size = new System.Drawing.Size(108, 33);
            this.bntdangnhap.TabIndex = 27;
            this.bntdangnhap.Text = "Đăng &Nhập";
            this.bntdangnhap.UseVisualStyleBackColor = false;
            this.bntdangnhap.Click += new System.EventHandler(this.bntdangnhap_Click);
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(160, 81);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(185, 22);
            this.txtPass.TabIndex = 26;
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Location = new System.Drawing.Point(160, 41);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(185, 22);
            this.txtUser.TabIndex = 25;
            // 
            // lblpass
            // 
            this.lblpass.AutoSize = true;
            this.lblpass.BackColor = System.Drawing.Color.Transparent;
            this.lblpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpass.ForeColor = System.Drawing.Color.Blue;
            this.lblpass.Location = new System.Drawing.Point(71, 81);
            this.lblpass.Name = "lblpass";
            this.lblpass.Size = new System.Drawing.Size(83, 20);
            this.lblpass.TabIndex = 30;
            this.lblpass.Text = "Mật khẩu";
            // 
            // lbluser
            // 
            this.lbluser.AutoSize = true;
            this.lbluser.BackColor = System.Drawing.Color.Transparent;
            this.lbluser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbluser.ForeColor = System.Drawing.Color.Blue;
            this.lbluser.Location = new System.Drawing.Point(25, 41);
            this.lbluser.Name = "lbluser";
            this.lbluser.Size = new System.Drawing.Size(129, 20);
            this.lbluser.TabIndex = 29;
            this.lbluser.Text = "Tên đăng nhập";
            // 
            // bttnthoat
            // 
            this.bttnthoat.BackColor = System.Drawing.Color.Red;
            this.bttnthoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnthoat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bttnthoat.Location = new System.Drawing.Point(360, 137);
            this.bttnthoat.Name = "bttnthoat";
            this.bttnthoat.Size = new System.Drawing.Size(99, 33);
            this.bttnthoat.TabIndex = 28;
            this.bttnthoat.Text = "&Thoát";
            this.bttnthoat.UseVisualStyleBackColor = false;
            this.bttnthoat.Click += new System.EventHandler(this.bttnthoat_Click);
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.BackgroundImage = global::GUI.Properties.Resources.anh500x250;
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.bntdangnhap);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblpass);
            this.Controls.Add(this.lbluser);
            this.Controls.Add(this.bttnthoat);
            this.Name = "DangNhap";
            this.Text = "Đăng Nhập";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bntdangnhap;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblpass;
        private System.Windows.Forms.Label lbluser;
        private System.Windows.Forms.Button bttnthoat;
    }
}