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
using BUS;
using DTO;

namespace GUI
{
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }
        List<KhachHang_DTO> lstKhachHang = new List<KhachHang_DTO>();
        private void KhachHang_Load(object sender, EventArgs e)
        {
            lstKhachHang = KhachHang_BUS.LoadMaKhachHang();
            dgvKhachHang.DataSource = lstKhachHang;

            Header();
        }
        public void Header()
        {
            dgvKhachHang.Columns["makh"].HeaderText = "Mã Khách Hàng";
            dgvKhachHang.Columns["tenkh"].HeaderText = "Tên Khách Hàng";
            dgvKhachHang.Columns["diachikh"].HeaderText = "Địa Chỉ";
            dgvKhachHang.Columns["lienhe"].HeaderText = "Số Liên Hệ";

            dgvKhachHang.Columns["tong"].Visible=false;

            dgvKhachHang.ReadOnly = true;
        }
        public void ResetTextBox()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtdiachikh.Text = "";
            txtlienhe.Text = "";
            txtMaKH.Focus();
        }
        public bool CheckNhap()
        {
            Boolean kQ = true;
            if (txtMaKH.Text.Trim() == "")
            {
                kQ = false;
                txtMaKH.Focus();
            }
            else if (txtTenKH.Text.Trim() == "")
            {
                kQ = false;
                txtTenKH.Focus();
            }
            else if (txtdiachikh.Text.Trim() == "")
            {
                kQ = false;
                txtdiachikh.Focus();
            }
            else if (txtlienhe.Text.Trim() == "")
            {
                kQ = false;
                txtlienhe.Focus();
            }
            return kQ;
        }


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

        private void loạiHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoaiHang lh = new LoaiHang();
            lh.Show();
            this.Hide();
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

        private void bntthem_Click(object sender, EventArgs e)
        {
            if (CheckNhap() == true)
            {
                KhachHang_DTO khDTO = new KhachHang_DTO();
                khDTO.makh = txtMaKH.Text;
                khDTO.tenkh = txtTenKH.Text;
                khDTO.diachikh = txtdiachikh.Text;
                khDTO.lienhe = txtlienhe.Text;
                if (KhachHang_BUS.ThemKhachHang(khDTO) == true)
                {
                    lstKhachHang.Add(khDTO);
                    dgvKhachHang.DataSource = typeof(List<KhachHang_DTO>);
                    dgvKhachHang.DataSource = lstKhachHang;
                    dgvKhachHang.Columns["tong"].Visible = false;
                    Header();
                    ResetTextBox();
                }
                else
                {
                    MessageBox.Show("Trùng lặp mã khách hàng", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập đủ thông tin", "Thông báo");
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKhachHang.SelectedRows != null)
            {
                DataGridViewRow dr = dgvKhachHang.SelectedRows[0];
                txtMaKH.Text = dr.Cells["makh"].Value.ToString();
                txtTenKH.Text = dr.Cells["tenkh"].Value.ToString();
                txtdiachikh.Text = dr.Cells["diachikh"].Value.ToString();
                txtlienhe.Text = dr.Cells["lienhe"].Value.ToString();
            }
        }

        private void bntsua_Click(object sender, EventArgs e)
        {
            if (CheckNhap() == true)
            {
                KhachHang_DTO khDTO = new KhachHang_DTO();
                khDTO.makh = txtMaKH.Text;
                khDTO.tenkh = txtTenKH.Text;
                khDTO.diachikh = txtdiachikh.Text;
                khDTO.lienhe = txtlienhe.Text;
                if (KhachHang_BUS.CapNhatKhachHang(khDTO) == true)
                {
                    dgvKhachHang.DataSource = KhachHang_BUS.LoadMaKhachHang();
                    dgvKhachHang.Columns["tong"].Visible = false;
                    Header();
                    ResetTextBox();
                }
                else
                {
                    MessageBox.Show("Trùng lặp mã khách hàng", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập đủ thông tin", "Thông báo");
            }
        }

        private void bntxoa_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text;
            if (KhachHang_BUS.XoaKhachHang(maKH) == true)
            {
                //LoaiHang_DTO lhDTODelete = lstLoaiHang.Single(n => n.maloaihang == maLH);
                //lstLoaiHang.Remove(lhDTODelete);
                dgvKhachHang.DataSource = KhachHang_BUS.LoadMaKhachHang();
                dgvKhachHang.Columns["tong"].Visible = false;
                Header();
            }
            else
            {
                if (MessageBox.Show("Xóa thất bại do ảnh hưởng dữ liệu của khách hàng: " + txtMaKH.Text + "tại bảng Chi Tiết Hóa Đơn. Bạn có muốn tới bảng Chi Tiết Hóa Đơn. ?", "Cảnh báo", MessageBoxButtons.YesNo).ToString() == "Yes")
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
                dgvKhachHang.DataSource = KhachHang_BUS.LoadMaKhachHang();
                dgvKhachHang.Columns["tong"].Visible = false;
            }
            else
            {
                lstKhachHang = KhachHang_BUS.TimKhachHang(txttimkiem.Text);
                if (lstKhachHang != null)
                {
                    dgvKhachHang.DataSource = typeof(List<LoaiHang_DTO>);
                    dgvKhachHang.DataSource = lstKhachHang;
                    dgvKhachHang.Columns["tong"].Visible = false;
                    Header();
                }
                else
                {
                    MessageBox.Show("Không tim thấy khách hàng", "Thông báo");
                }
            }
        }
    }
}
