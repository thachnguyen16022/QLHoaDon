using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class SPBanChay : Form
    {
        public SPBanChay()
        {
            InitializeComponent();
        }
        List<SPBanChay_DTO> lstSPBanChay = new List<SPBanChay_DTO>();
        public void Header()
        {
            dgvspbc.Columns["tenmh"].HeaderText = "Tên Mặt Hàng";
            dgvspbc.Columns["tenloaihang"].HeaderText = "Tên Loại Hàng";
            dgvspbc.Columns["tenncc"].HeaderText = "Tên NCC";
            dgvspbc.Columns["soluongban"].HeaderText = "Đã Bán";
            dgvspbc.Columns["tongthu"].HeaderText = "Tổng Thu";

            dgvspbc.ReadOnly = true;
        }
        private void SPBanChay_Load(object sender, EventArgs e)
        {
            lstSPBanChay = SPBanChay_BUS.LoadSPBanChay();
            dgvspbc.DataSource = lstSPBanChay;

            Header();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MatHang mh = new MatHang();
            mh.Show();
            this.Hide();
        }
    }
}
