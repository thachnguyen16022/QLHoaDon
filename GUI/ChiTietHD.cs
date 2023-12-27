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
    public partial class ChiTietHD : Form
    {
        public ChiTietHD()
        {
            InitializeComponent();
        }
        List<ChiTietHD_DTO> lstChiTietHD = new List<ChiTietHD_DTO>();

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Hide();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            hd.Show();
            this.Hide();
        }
        public void Header()
        {
            dgvChiTietHD.Columns["mahd"].HeaderText = "Mã Hóa Đơn";
            dgvChiTietHD.Columns["mamh"].HeaderText = "Mã Mặt Hàng";
            dgvChiTietHD.Columns["dongiaban"].HeaderText = "Đơn Giá Bán";
            dgvChiTietHD.Columns["soluong"].HeaderText = "Số Lượng";

            dgvChiTietHD.ReadOnly = true;
        }
        private void ChiTietHD_Load(object sender, EventArgs e)
        {
            lstChiTietHD = ChiTietHD_BUS.LoadChiTietHD();
            dgvChiTietHD.DataSource = lstChiTietHD;
            dgvChiTietHD.Columns[0].Visible=false;

            Header();

            cobmahd.DataSource = HoaDon_BUS.LoadHoaDon();
            cobmahd.DisplayMember = "mahd";
            cobmahd.ValueMember = "mahd";

            cobmamh.DataSource = MatHang_BUS.LoadMatHang();
            cobmamh.DisplayMember = "mamh";
            cobmamh.ValueMember = "mamh";

            int tongtien = 0;
            for ( int i = 0; i < dgvChiTietHD.Rows.Count; i++)
            {               
                tongtien += Convert.ToInt32(dgvChiTietHD.Rows[i].Cells["dongiaban"].Value.ToString());                              
            }
            lbltongtien.Text=tongtien.ToString();
        }
        public void ResetTextBox()
        {
            txtDGBan.Text = "";
            txtSL.Text = "";
            txtDGBan.Focus();
        }
        public bool CheckNhap()
        {
            Boolean kQ = true;
            if (txtSL.Text.Trim() == "")
            {
                kQ = false;
                txtSL.Focus();
            }
            return kQ;
        }

        private void bntthem_Click(object sender, EventArgs e)
        {
            if (CheckNhap() == true)
            {
                ChiTietHD_DTO cthdDTO = new ChiTietHD_DTO();
                cthdDTO.mahd = cobmahd.SelectedValue.ToString();
                cthdDTO.mamh = cobmamh.SelectedValue.ToString();
                cthdDTO.soluong = Convert.ToInt32(txtSL.Text);
                if (ChiTietHD_BUS.ThemChiTietHD(cthdDTO) == true)
                {
                    lstChiTietHD.Add(cthdDTO);
                    dgvChiTietHD.DataSource = typeof(List<ChiTietHD_DTO>);
                    dgvChiTietHD.DataSource = ChiTietHD_BUS.LoadChiTietHD();
                    Header();
                    ResetTextBox();

                    int tongtien = 0;
                    for (int i = 0; i < dgvChiTietHD.Rows.Count; i++)
                    {
                        tongtien += Convert.ToInt32(dgvChiTietHD.Rows[i].Cells["dongiaban"].Value.ToString());
                    }
                    lbltongtien.Text = tongtien.ToString();

                    dgvChiTietHD.Columns[0].Visible = false;
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập đủ thông tin", "Thông báo");
            }
        }

        private void dgvChiTietHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvChiTietHD.SelectedRows != null)
            {
                DataGridViewRow dr = dgvChiTietHD.SelectedRows[0];
                txtstt.Text= dr.Cells["stt"].Value.ToString();
                cobmahd.SelectedValue = dr.Cells["mahd"].Value.ToString();
                cobmamh.SelectedValue = dr.Cells["mamh"].Value.ToString();
                txtDGBan.Text = dr.Cells["dongiaban"].Value.ToString();
                txtSL.Text = dr.Cells["soluong"].Value.ToString();
            }
        }

        private void bntsua_Click(object sender, EventArgs e)
        {
            if (CheckNhap() == true)
            {
                ChiTietHD_DTO cthdDTO = new ChiTietHD_DTO();
                cthdDTO.stt = Convert.ToInt32(txtstt.Text);
                cthdDTO.mahd = cobmahd.SelectedValue.ToString();
                cthdDTO.mamh = cobmamh.SelectedValue.ToString();
                cthdDTO.soluong = Convert.ToInt32(txtSL.Text);
                if (ChiTietHD_BUS.CapNhatChiTietHD(cthdDTO) == true)
                {
                    dgvChiTietHD.DataSource = ChiTietHD_BUS.LoadChiTietHD();
                    Header();
                    int tongtien = 0;
                    for (int i = 0; i < dgvChiTietHD.Rows.Count; i++)
                    {
                        tongtien += Convert.ToInt32(dgvChiTietHD.Rows[i].Cells["dongiaban"].Value.ToString());
                    }
                    lbltongtien.Text = tongtien.ToString();

                    dgvChiTietHD.Columns[0].Visible = false;
                    MessageBox.Show("Sửa thông tin thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Cập Nhật thất bại", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập đủ thông tin", "Thông báo");
            }
        }
        private void bntxoa_Click(object sender, EventArgs e)
        {
            int sTT = Convert.ToInt32(txtstt.Text);
            if (ChiTietHD_BUS.XoaChiTietHD(sTT) == true)
            {
                //ChiTietHD_DTO cthdDTODelete = lstChiTietHD.Single(n => n.stt == sTT);
                //lstChiTietHD.Remove(cthdDTODelete);
                dgvChiTietHD.DataSource = ChiTietHD_BUS.LoadChiTietHD();
                Header();
                ResetTextBox();

                int tongtien = 0;
                for (int i = 0; i < dgvChiTietHD.Rows.Count; i++)
                {
                    tongtien += Convert.ToInt32(dgvChiTietHD.Rows[i].Cells["dongiaban"].Value.ToString());
                }
                lbltongtien.Text = tongtien.ToString();

                dgvChiTietHD.Columns[0].Visible = false;
            }
            else
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo");
            }
        }

        private void bnttimkiem_Click(object sender, EventArgs e)
        {
            if (txttimkiem.Text.Trim() == "")
            {
                dgvChiTietHD.DataSource = ChiTietHD_BUS.LoadChiTietHD();
            }
            else
            {
                lstChiTietHD = ChiTietHD_BUS.TimChiTietHD(txttimkiem.Text);
                if (lstChiTietHD != null)
                {
                    dgvChiTietHD.DataSource = typeof(List<ChiTietHD_DTO>);
                    dgvChiTietHD.DataSource = lstChiTietHD;
                    dgvChiTietHD.Columns[0].Visible = false;
                    Header();
                }
                else
                {
                    MessageBox.Show("Không tim thấy!!", "Thông báo");
                }
            }
        }

        private void nhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.Show();
            this.Hide();
        }

        private void mặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MatHang mh = new MatHang();
            mh.Show();
            this.Hide();
        }

        private void loạiHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoaiHang lh = new LoaiHang();
            lh.Show();
            this.Hide();
        }

        private void txtDGBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TongHop th = new TongHop();
            th.Show();
            this.Hide();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.Show();
            this.Hide();
        }
    }
}
