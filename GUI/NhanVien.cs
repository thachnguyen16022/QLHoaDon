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
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
        }
        List<NhanVien_DTO> lstNhanVien = new List<NhanVien_DTO>();

        private void mặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loạiHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void chiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Hide();
        }

        private void mặtHàngToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MatHang mh=new MatHang();
            mh.Show();
            this.Hide();
        }

        private void loạiHàngToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LoaiHang lh = new LoaiHang();
            lh.Show();
            this.Hide();
        }
        public void Resettextbox()
        {
            txtMaNV.Text = "";
            txtHo.Text = "";
            txtTen.Text = "";
            txtDiaChi.Text = "";
            txtDT.Text = "";
            txtLuongCB.Text = "";
            txtCongViec.Text = "";
            txtMaNV.Focus();
        }
        public bool CheckNhap()
        {
            Boolean kQ = true;
            if (txtMaNV.Text.Trim() == "")
            {
                kQ = false;
                txtMaNV.Focus();
            }
            else if (txtHo.Text.Trim() == "")
            {
                kQ = false;
                txtHo.Focus();
            }
            else if (txtTen.Text.Trim() == "")
            {
                kQ = false;
                txtTen.Focus();
            }
            else if (txtDiaChi.Text.Trim() == "")
            {
                kQ = false;
                txtDiaChi.Focus();
            }
            else if (txtDT.Text.Trim() == "")
            {
                kQ = false;
                txtDT.Focus();
            }
            else if (txtLuongCB.Text.Trim() == "")
            {
                kQ = false;
                txtLuongCB.Focus();
            }
            else if (txtCongViec.Text.Trim() == "")
            {
                kQ = false;
                txtCongViec.Focus();
            }
            return kQ;
        }
        public void Header()
        {
            dgvNhanVien.Columns["manv"].HeaderText = "Mã Nhân Viên";
            dgvNhanVien.Columns["ho"].HeaderText = "Họ";
            dgvNhanVien.Columns["ten"].HeaderText = "Tên";
            dgvNhanVien.Columns["gioitinh"].HeaderText = "Giới Tính";
            dgvNhanVien.Columns["diachi"].HeaderText = "Địa Chỉ";
            dgvNhanVien.Columns["dienthoai"].HeaderText = "Điện Thoại";
            dgvNhanVien.Columns["luongcanban"].HeaderText = "Lương Căn Bản";
            dgvNhanVien.Columns["congviec"].HeaderText = "Công Việc";

            lblsonv.Text = dgvNhanVien.RowCount.ToString();

            dgvNhanVien.ReadOnly = true;
        }
        private void NhanVien_Load(object sender, EventArgs e)
        {
            lstNhanVien = NhanVien_BUS.LoadNhanVien();
            dgvNhanVien.DataSource = lstNhanVien;

            Header();
        }

        private void bntthem_Click(object sender, EventArgs e)
        {
            if (CheckNhap() == true)
            {
                NhanVien_DTO nvDTO = new NhanVien_DTO();
                nvDTO.manv = txtMaNV.Text;
                nvDTO.ho = txtHo.Text;
                nvDTO.ten = txtTen.Text;
                if (rdonam.Checked)
                {
                    nvDTO.gioitinh = true;
                }
                else
                {
                    nvDTO.gioitinh = false;
                }
                nvDTO.diachi = txtDiaChi.Text;
                nvDTO.dienthoai = txtDT.Text;
                nvDTO.luongcanban = Convert.ToInt32(txtLuongCB.Text);
                nvDTO.congviec = txtCongViec.Text;
                if (NhanVien_BUS.ThemNhanVien(nvDTO) == true)
                {
                    lstNhanVien.Add(nvDTO);
                    dgvNhanVien.DataSource = typeof(List<NhanVien_DTO>);
                    dgvNhanVien.DataSource = lstNhanVien;

                    Resettextbox();

                    Header();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại. Mã nhân viên không trùng lặp", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập đủ thông tin", "Thông báo");
            }
            
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNhanVien.SelectedRows != null)
            {
                DataGridViewRow dr = dgvNhanVien.SelectedRows[0];
                txtMaNV.Text = dr.Cells["manv"].Value.ToString();
                txtHo.Text = dr.Cells["ho"].Value.ToString();
                txtTen.Text = dr.Cells["ten"].Value.ToString();
                if ((bool)dr.Cells["gioitinh"].Value == true)
                {
                    rdonam.Checked = true;
                }
                else
                {
                    rdonu.Checked = true;
                }
                txtDiaChi.Text = dr.Cells["diachi"].Value.ToString();
                txtDT.Text = dr.Cells["dienthoai"].Value.ToString();
                txtLuongCB.Text = dr.Cells["luongcanban"].Value.ToString();
                txtCongViec.Text = dr.Cells["congviec"].Value.ToString();
            }
        }

        private void bntsua_Click(object sender, EventArgs e)
        {
            if (CheckNhap() == true)
            {
                NhanVien_DTO nvDTO = new NhanVien_DTO();
                nvDTO.manv = txtMaNV.Text;
                nvDTO.ho = txtHo.Text;
                nvDTO.ten = txtTen.Text;
                if (rdonam.Checked)
                {
                    nvDTO.gioitinh = true;
                }
                else
                {
                    nvDTO.gioitinh = false;
                }
                nvDTO.diachi = txtDiaChi.Text;
                nvDTO.dienthoai = txtDT.Text;
                nvDTO.luongcanban = Convert.ToInt32(txtLuongCB.Text);
                nvDTO.congviec = txtCongViec.Text;
                if (NhanVien_BUS.CapNhatNhanVien(nvDTO) == true)
                {
                    MessageBox.Show("Đã cập nhật thông tin cho nhân viên với mã nhân viên: "+txtMaNV.Text, "Thông báo");
                    dgvNhanVien.DataSource = NhanVien_BUS.LoadNhanVien();
                    Header();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập đủ thông tin", "Thông báo");
            }
        }

        private void bntxoa_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            if (NhanVien_BUS.XoaNhanVien(maNV) == true)
            {
                NhanVien_DTO nvDTODelete = lstNhanVien.Single(n => n.manv == maNV);
                lstNhanVien.Remove(nvDTODelete);
                dgvNhanVien.DataSource = NhanVien_BUS.LoadNhanVien();

                Resettextbox();

                Header();
            }
            else
            {
                if (MessageBox.Show("Xóa thất bại do ảnh hưởng dữ liệu của nhân viên: "+txtMaNV.Text+" tại bảng Hóa Đơn. Bạn có muốn tới bảng Hóa đơn ?", "Cảnh báo",MessageBoxButtons.YesNo).ToString() == "Yes")
                {
                    HoaDon hd = new HoaDon();
                    hd.Show();
                    this.Hide();
                }
            }
        }

        private void bnttimkiem_Click(object sender, EventArgs e)
        {
            if (txttimkiem.Text.Trim() == "")
            {
                dgvNhanVien.DataSource = NhanVien_BUS.LoadNhanVien();
                Header();
            }
            else
            {
                lstNhanVien = NhanVien_BUS.TimNhanVien(txttimkiem.Text);
                if (lstNhanVien != null)
                {
                    dgvNhanVien.DataSource = typeof(List<NhanVien_DTO>);
                    dgvNhanVien.DataSource = lstNhanVien;
                    Header();
                }
                else
                {
                    MessageBox.Show("Không tim thấy nhân viên", "Thông báo");
                }
            }
        }

        private void txtLuongCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void hóaĐơnToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            hd.Show();
            this.Hide();
        }

        private void chiTiếtHóaĐơnToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ChiTietHD cthd = new ChiTietHD();
            cthd.Show();
            this.Hide();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
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
