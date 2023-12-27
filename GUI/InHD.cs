using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI
{
    public partial class InHD : Form
    {
        public InHD()
        {
            InitializeComponent();
        }
        List<InHD_DTO> lstInHD = new List<InHD_DTO>();
        public void Header()
        {
            dgvInHD.Columns["tenmh"].HeaderText = "Tên Mặt Hàng";
            dgvInHD.Columns["dongiaban"].HeaderText = "Đơn Giá Bán";
            dgvInHD.Columns["soluong"].HeaderText = "Số Lượng";

            dgvInHD.ReadOnly = true;
        }
        private void InHD_Load(object sender, EventArgs e)
        {
            cbomahd.DataSource = HoaDon_BUS.LoadHoaDon();
            cbomahd.DisplayMember = "mahd";
            cbomahd.ValueMember = "mahd";

            if (dgvInHD != null)
            {
                lstInHD = InHD_BUS.LoadInHD(cbomahd.SelectedValue.ToString());
                dgvInHD.DataSource = lstInHD;
                Header();
            }
            else
            {
                MessageBox.Show("Mã hóa đơn hiện trống", "Thông báo");
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void cbomahd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvInHD != null)
            {
                lstInHD = InHD_BUS.LoadInHD(cbomahd.SelectedValue.ToString());
                dgvInHD.DataSource = lstInHD;
            }
            else
            {
                MessageBox.Show("Mã hóa đơn hiện trống", "Thông báo");
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Hóa Đơn Thanh Toán", new System.Drawing.Font("Arial", 18, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(300, 20));
            e.Graphics.DrawString("Số Hóa Đơn:" +cbomahd.SelectedValue.ToString() , new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, 80));
            e.Graphics.DrawString("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, 120));
            e.Graphics.DrawString("STT", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(20, 140));
            e.Graphics.DrawString("Tên mặt hàng", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(150, 140));
            e.Graphics.DrawString("Số lượng", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(450, 140));
            e.Graphics.DrawString("Giá", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(650, 140));
            e.Graphics.DrawString("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, 160));
            int vitriy = 190;
            int tong = 0;
            int stt = 1;
            foreach (var i in lstInHD)
            {
                e.Graphics.DrawString(stt.ToString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, vitriy));
                e.Graphics.DrawString(i.tenmh, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(150, vitriy));
                e.Graphics.DrawString(i.soluong.ToString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(450, vitriy));
                e.Graphics.DrawString(i.dongiaban.ToString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(650, vitriy));
                tong += i.dongiaban;
                stt++;
                vitriy += 20;
            }
            e.Graphics.DrawString("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, vitriy));
            e.Graphics.DrawString("Tổng tiền: "+tong.ToString() +" VNĐ", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(550, vitriy+30));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            hd.Show();
            this.Hide();
        }
    }
}
