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
    public partial class MatHang : Form
    {
        public MatHang()
        {
            InitializeComponent();
        }
        List<MatHang_DTO> lstMatHang=new List<MatHang_DTO>();
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Hide();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanVien nv=new NhanVien();
            nv.Show();
            this.Hide();
        }

        private void loạiHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoaiHang lh = new LoaiHang();
            lh.Show();
            this.Hide();
        }
        public void Header()
        {
            dgvMatHang.Columns["mamh"].HeaderText = "Mã Mặt Hàng";
            dgvMatHang.Columns["tenmh"].HeaderText = "Tên Mặt Hàng";
            dgvMatHang.Columns["mancc"].HeaderText = "Mã NCC";
            dgvMatHang.Columns["donvi"].HeaderText = "Đơn Vị";
            dgvMatHang.Columns["dongia"].HeaderText = "Đơn Giá";
            dgvMatHang.Columns["maloaihang"].HeaderText = "Mã LH";
            dgvMatHang.Columns["ngaynhap"].HeaderText = "Ngày nhập";

            dgvMatHang.ReadOnly = true;
        }
        private void MatHang_Load(object sender, EventArgs e)
        {
            lstMatHang= MatHang_BUS.LoadMatHang();
            dgvMatHang.DataSource = lstMatHang;

            Header();

            cobmalh.DataSource = LoaiHang_BUS.LoadLoaiHang();
            cobmalh.DisplayMember = "maloaihang";
            cobmalh.ValueMember = "maloaihang";

            cobmancc.DataSource = NhaCungCap_BUS.LoadNCC();
            cobmancc.DisplayMember = "mancc";
            cobmancc.ValueMember = "mancc";
        }
        public void ResetTextBox()
        {
            txtMaMH.Text = "";
            txtTenMH.Text = "";
            txtDVT.Text = "";
            txtDG.Text = "";
            txtMaMH.Focus();
        }
        public bool CheckNhap()
        {
            Boolean kQ = true;
            if (txtMaMH.Text.Trim() == "")
            {
                kQ = false;
                txtMaMH.Focus();
            }
            else if (txtTenMH.Text.Trim() == "")
            {
                kQ= false;
                txtTenMH.Focus();   
            }
            else if (txtDVT.Text.Trim() == "")
            {
                kQ = false;
                txtDVT.Focus();
            }
            else if (txtDG.Text.Trim() == "")
            {
                kQ = false;
                txtDG.Focus();
            }
            return kQ;
        }

        private void bntthem_Click(object sender, EventArgs e)
        {
            if (CheckNhap() == true)
            {
                MatHang_DTO mhDTO = new MatHang_DTO();
                mhDTO.mamh = txtMaMH.Text;
                mhDTO.tenmh = txtTenMH.Text;
                mhDTO.mancc = cobmancc.SelectedValue.ToString();
                mhDTO.donvi = txtDVT.Text;
                mhDTO.dongia = Convert.ToInt32(txtDG.Text);
                mhDTO.maloaihang = cobmalh.SelectedValue.ToString();
                mhDTO.ngaynhap = Convert.ToDateTime(dtpngaynhap.Text);
                if (MatHang_BUS.ThemMatHang(mhDTO) == true)
                {
                    lstMatHang.Add(mhDTO);
                    dgvMatHang.DataSource = typeof(List<MatHang_DTO>);
                    dgvMatHang.DataSource = lstMatHang;
                    Header();

                    ResetTextBox();
                }
                else
                {
                    MessageBox.Show("Mã mặt hàng đã tồn tại!", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Xin hãy nhập đủ thông tin", "Thông báo");
            }
        }

        private void bntsua_Click(object sender, EventArgs e)
        {
            if(CheckNhap() == true)
            {
                MatHang_DTO mhDTO = new MatHang_DTO();
                mhDTO.mamh = txtMaMH.Text;
                mhDTO.tenmh = txtTenMH.Text;
                mhDTO.mancc = cobmancc.SelectedValue.ToString();
                mhDTO.donvi = txtDVT.Text;
                mhDTO.dongia = Convert.ToInt32(txtDG.Text);
                mhDTO.maloaihang = cobmalh.SelectedValue.ToString();
                mhDTO.ngaynhap = Convert.ToDateTime(dtpngaynhap.Text);
                if (MatHang_BUS.CapNhatMatHang(mhDTO) == true)
                {
                    dgvMatHang.DataSource = MatHang_BUS.LoadMatHang();
                    Header();

                    MessageBox.Show("Đã cập nhật thông tin mặt hàng với mã: " + txtMaMH.Text, "Thông báo");
                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Xin hãy nhập đủ thông tin", "Thông báo");
            }
        }

        private void dgvMatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMatHang.SelectedRows != null)
            {
                DataGridViewRow dr = dgvMatHang.SelectedRows[0];
                txtMaMH.Text = dr.Cells["mamh"].Value.ToString();
                txtTenMH.Text = dr.Cells["tenmh"].Value.ToString();
                cobmancc.SelectedValue = dr.Cells["mancc"].Value.ToString();
                txtDVT.Text = dr.Cells["donvi"].Value.ToString();
                txtDG.Text = dr.Cells["dongia"].Value.ToString();
                cobmalh.SelectedValue = dr.Cells["maloaihang"].Value.ToString();
                dtpngaynhap.Text = dr.Cells["ngaynhap"].Value.ToString();
            }
        }

        private void bntxoa_Click(object sender, EventArgs e)
        {
            string maMH = txtMaMH.Text;
            if (MatHang_BUS.XoaMatHang(maMH) == true)
            {
                MatHang_DTO mhDTODelete = lstMatHang.Single(n => n.mamh == maMH);
                lstMatHang.Remove(mhDTODelete);
                dgvMatHang.DataSource = MatHang_BUS.LoadMatHang();
                Header();

                ResetTextBox();
            }
            else
            {
                if (MessageBox.Show("Xóa thất bại do ảnh hưởng dữ liệu của mặt hàng: " + txtMaMH.Text + "tại bảng Chi Tiết Hóa Đơn. Bạn có muốn tới bảng Chi Tiết Hóa đơn ?", "Cảnh báo", MessageBoxButtons.YesNo).ToString() == "Yes")
                {
                    ChiTietHD cthd = new ChiTietHD();
                    cthd.Show();
                    this.Hide();
                }
            }
        }

        private void bnttimkiem_Click(object sender, EventArgs e)
        {
            if (txttimkiem.Text.Trim() == "")
            {
                dgvMatHang.DataSource = MatHang_BUS.LoadMatHang();
            }
            else
            {
                lstMatHang = MatHang_BUS.TimMatHang(txttimkiem.Text);
                if (lstMatHang != null)
                {
                    dgvMatHang.DataSource = typeof(List<MatHang_DTO>);
                    dgvMatHang.DataSource = lstMatHang;
                    Header();

                    MessageBox.Show("Tim thay mặt hàng", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Không tim thấy mặt hàng", "Thông báo");
                }
            }
        }

        private void txtDG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoTon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            SPBanChay spbc=new SPBanChay();
            spbc.Show();
            this.Hide();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            NhaCungCap ncc = new NhaCungCap();
            ncc.Show();
            this.Hide();
        }
    }
}
