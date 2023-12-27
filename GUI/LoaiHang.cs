using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class LoaiHang : Form
    {
        public LoaiHang()
        {
            InitializeComponent();
        }
        List<LoaiHang_DTO> lstLoaiHang = new List<LoaiHang_DTO>();
        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Hide();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
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
        public void Header()
        {
            dgvLoaiHang.Columns["maloaihang"].HeaderText = "Mã Loại Hàng";
            dgvLoaiHang.Columns["tenloaihang"].HeaderText = "Tên Loại Hàng";
            dgvLoaiHang.Columns["mota"].HeaderText = "Mô Tả";

            dgvLoaiHang.ReadOnly = true;
        }
        private void LoaiHang_Load(object sender, EventArgs e)
        {
            lstLoaiHang= LoaiHang_BUS.LoadLoaiHang();
            dgvLoaiHang.DataSource = lstLoaiHang;

            Header();
        }
        public void ResetTextBox()
        {
            txtMaLH.Text = "";
            txtTenLH.Text = "";
            txtMoTa.Text = "";
            txtMaLH.Focus();
        }
        public bool CheckNhap()
        {
            Boolean kQ = true;
            if (txtMaLH.Text.Trim() == "")
            {
                kQ = false;
                txtMaLH.Focus();
            }
            else if (txtTenLH.Text.Trim() == "")
            {
                kQ = false;
                txtTenLH.Focus();
            }
            else if (txtMoTa.Text.Trim() == "")
            {
                kQ = false;
                txtMoTa.Focus();
            }
            return kQ;
        }

        private void bntthem_Click(object sender, EventArgs e)
        {
            if (CheckNhap() == true)
            {
                LoaiHang_DTO lhDTO = new LoaiHang_DTO();
                lhDTO.maloaihang = txtMaLH.Text;
                lhDTO.tenloaihang = txtTenLH.Text;
                lhDTO.mota = txtMoTa.Text;
                if (LoaiHang_BUS.ThemLoaiHang(lhDTO) == true)
                {
                    lstLoaiHang.Add(lhDTO);
                    dgvLoaiHang.DataSource = typeof(List<LoaiHang_DTO>);
                    dgvLoaiHang.DataSource = lstLoaiHang;
                    Header();
                    ResetTextBox();
                }
                else
                {
                    MessageBox.Show("Trùng lặp mã loại hàng", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập đủ thông tin", "Thông báo");
            }
        }

        private void dgvLoaiHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLoaiHang.SelectedRows != null)
            {
                DataGridViewRow dr = dgvLoaiHang.SelectedRows[0];
                txtMaLH.Text = dr.Cells["maloaihang"].Value.ToString();
                txtTenLH.Text = dr.Cells["tenloaihang"].Value.ToString();
                txtMoTa.Text = dr.Cells["mota"].Value.ToString();
            }
        }

        private void bntsua_Click(object sender, EventArgs e)
        {
            if (CheckNhap() == true)
            {
                LoaiHang_DTO lhDTO = new LoaiHang_DTO();
                lhDTO.maloaihang = txtMaLH.Text;
                lhDTO.tenloaihang = txtTenLH.Text;
                lhDTO.mota = txtMoTa.Text;
                if (LoaiHang_BUS.CapNhatLoaiHang(lhDTO) == true)
                {
                    dgvLoaiHang.DataSource = LoaiHang_BUS.LoadLoaiHang();
                    Header();
                }
                else
                {
                    MessageBox.Show("Trùng lặp mã loại hàng", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập đủ thông tin", "Thông báo");
            }
        }

        private void bntxoa_Click(object sender, EventArgs e)
        {
            string maLH = txtMaLH.Text;
            if (LoaiHang_BUS.XoaLoaiHang(maLH) == true)
            {
                //LoaiHang_DTO lhDTODelete = lstLoaiHang.Single(n => n.maloaihang == maLH);
                //lstLoaiHang.Remove(lhDTODelete);
                dgvLoaiHang.DataSource = LoaiHang_BUS.LoadLoaiHang();
                Header();
                ResetTextBox();
            }
            else
            {
                if (MessageBox.Show("Xóa thất bại do ảnh hưởng dữ liệu của loại hàng: " + txtMaLH.Text + "tại bảng Mặt Hàng. Bạn có muốn tới bảng Mặt Hàng ?", "Cảnh báo", MessageBoxButtons.YesNo).ToString() == "Yes")
                {
                    MatHang mh = new MatHang();
                    mh.Show();
                    this.Hide();
                }
            }
        }

        private void bnttimkiem_Click(object sender, EventArgs e)
        {
            if (txttimkiem.Text.Trim() == "")
            {
                dgvLoaiHang.DataSource = LoaiHang_BUS.LoadLoaiHang();
            }
            else
            {
                lstLoaiHang = LoaiHang_BUS.TimLoaiHang(txttimkiem.Text);
                if (lstLoaiHang != null)
                {
                    dgvLoaiHang.DataSource = typeof(List<LoaiHang_DTO>);
                    dgvLoaiHang.DataSource = lstLoaiHang;
                    Header();
                }
                else
                {
                    MessageBox.Show("Không tim thấy loại hàng", "Thông báo");
                }
            }
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            hd.Show();
            this.Hide();
        }

        private void chiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChiTietHD cthd = new ChiTietHD();
            cthd.Show();
            this.Hide();
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
