namespace GUI
{
    partial class NhaCungCap
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
            this.dgvNCC = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtlienhe = new System.Windows.Forms.TextBox();
            this.txtdiachi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txttenncc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtmancc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvdanhap = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.bntxoa = new System.Windows.Forms.Button();
            this.bntsua = new System.Windows.Forms.Button();
            this.bntthem = new System.Windows.Forms.Button();
            this.bnttimkiem = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lbltenncc = new System.Windows.Forms.Label();
            this.btnquaylai = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNCC)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdanhap)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNCC
            // 
            this.dgvNCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNCC.Location = new System.Drawing.Point(23, 229);
            this.dgvNCC.Name = "dgvNCC";
            this.dgvNCC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNCC.Size = new System.Drawing.Size(438, 212);
            this.dgvNCC.TabIndex = 0;
            this.dgvNCC.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNCC_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Tìm kiếm theo tên ncc";
            // 
            // txttimkiem
            // 
            this.txttimkiem.Location = new System.Drawing.Point(183, 200);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(195, 20);
            this.txttimkiem.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtlienhe);
            this.groupBox1.Controls.Add(this.txtdiachi);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txttenncc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtmancc);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 180);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // txtlienhe
            // 
            this.txtlienhe.Location = new System.Drawing.Point(134, 140);
            this.txtlienhe.Name = "txtlienhe";
            this.txtlienhe.Size = new System.Drawing.Size(191, 20);
            this.txtlienhe.TabIndex = 7;
            // 
            // txtdiachi
            // 
            this.txtdiachi.Location = new System.Drawing.Point(134, 100);
            this.txtdiachi.Name = "txtdiachi";
            this.txtdiachi.Size = new System.Drawing.Size(191, 20);
            this.txtdiachi.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(55, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Liên hệ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Địa chỉ";
            // 
            // txttenncc
            // 
            this.txttenncc.Location = new System.Drawing.Point(134, 61);
            this.txttenncc.Name = "txttenncc";
            this.txttenncc.Size = new System.Drawing.Size(191, 20);
            this.txttenncc.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tên NCC";
            // 
            // txtmancc
            // 
            this.txtmancc.Location = new System.Drawing.Point(134, 20);
            this.txtmancc.Name = "txtmancc";
            this.txtmancc.Size = new System.Drawing.Size(191, 20);
            this.txtmancc.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mã NCC";
            // 
            // dgvdanhap
            // 
            this.dgvdanhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdanhap.Location = new System.Drawing.Point(528, 76);
            this.dgvdanhap.Name = "dgvdanhap";
            this.dgvdanhap.Size = new System.Drawing.Size(438, 365);
            this.dgvdanhap.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(675, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Mặt hàng đã nhập";
            // 
            // bntxoa
            // 
            this.bntxoa.BackColor = System.Drawing.Color.Red;
            this.bntxoa.Location = new System.Drawing.Point(383, 143);
            this.bntxoa.Name = "bntxoa";
            this.bntxoa.Size = new System.Drawing.Size(87, 38);
            this.bntxoa.TabIndex = 52;
            this.bntxoa.Text = "Xóa";
            this.bntxoa.UseVisualStyleBackColor = false;
            this.bntxoa.Click += new System.EventHandler(this.bntxoa_Click);
            // 
            // bntsua
            // 
            this.bntsua.BackColor = System.Drawing.Color.Yellow;
            this.bntsua.Location = new System.Drawing.Point(383, 82);
            this.bntsua.Name = "bntsua";
            this.bntsua.Size = new System.Drawing.Size(87, 38);
            this.bntsua.TabIndex = 51;
            this.bntsua.Text = "Sửa";
            this.bntsua.UseVisualStyleBackColor = false;
            this.bntsua.Click += new System.EventHandler(this.bntsua_Click);
            // 
            // bntthem
            // 
            this.bntthem.BackColor = System.Drawing.Color.Lime;
            this.bntthem.Location = new System.Drawing.Point(383, 21);
            this.bntthem.Name = "bntthem";
            this.bntthem.Size = new System.Drawing.Size(87, 38);
            this.bntthem.TabIndex = 50;
            this.bntthem.Text = "Thêm";
            this.bntthem.UseVisualStyleBackColor = false;
            this.bntthem.Click += new System.EventHandler(this.bntthem_Click);
            // 
            // bnttimkiem
            // 
            this.bnttimkiem.Location = new System.Drawing.Point(394, 200);
            this.bnttimkiem.Name = "bnttimkiem";
            this.bnttimkiem.Size = new System.Drawing.Size(75, 23);
            this.bnttimkiem.TabIndex = 60;
            this.bnttimkiem.Text = "Tìm";
            this.bnttimkiem.UseVisualStyleBackColor = true;
            this.bnttimkiem.Click += new System.EventHandler(this.bnttimkiem_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(468, 319);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 23);
            this.button1.TabIndex = 61;
            this.button1.Text = "-->";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(559, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 17);
            this.label7.TabIndex = 62;
            this.label7.Text = "Tên nhà cung cấp:";
            // 
            // lbltenncc
            // 
            this.lbltenncc.AutoSize = true;
            this.lbltenncc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltenncc.ForeColor = System.Drawing.Color.Red;
            this.lbltenncc.Location = new System.Drawing.Point(709, 56);
            this.lbltenncc.Name = "lbltenncc";
            this.lbltenncc.Size = new System.Drawing.Size(0, 17);
            this.lbltenncc.TabIndex = 63;
            // 
            // btnquaylai
            // 
            this.btnquaylai.Location = new System.Drawing.Point(33, 461);
            this.btnquaylai.Name = "btnquaylai";
            this.btnquaylai.Size = new System.Drawing.Size(75, 23);
            this.btnquaylai.TabIndex = 64;
            this.btnquaylai.Text = "Quay Lại";
            this.btnquaylai.UseVisualStyleBackColor = true;
            this.btnquaylai.Click += new System.EventHandler(this.btnquaylai_Click);
            // 
            // NhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 501);
            this.Controls.Add(this.btnquaylai);
            this.Controls.Add(this.lbltenncc);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bnttimkiem);
            this.Controls.Add(this.bntxoa);
            this.Controls.Add(this.bntsua);
            this.Controls.Add(this.bntthem);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvdanhap);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txttimkiem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvNCC);
            this.Name = "NhaCungCap";
            this.Text = "NhaCungCap";
            this.Load += new System.EventHandler(this.NhaCungCap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNCC)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdanhap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNCC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtlienhe;
        private System.Windows.Forms.TextBox txtdiachi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txttenncc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtmancc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvdanhap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bntxoa;
        private System.Windows.Forms.Button bntsua;
        private System.Windows.Forms.Button bntthem;
        private System.Windows.Forms.Button bnttimkiem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbltenncc;
        private System.Windows.Forms.Button btnquaylai;
    }
}