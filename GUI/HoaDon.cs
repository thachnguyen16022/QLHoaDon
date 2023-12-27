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
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
        }
        List<HoaDon_DTO> lstHoaDon = new List<HoaDon_DTO>();

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Hide();
        }

        private void loạiHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChiTietHD cthd=new ChiTietHD();
            cthd.Show();
            this.Hide();
        }
        public void Header()
        {
            dgvHoaDon.Columns["mahd"].HeaderText = "Mã Hóa Đơn";
            dgvHoaDon.Columns["manv"].HeaderText = "Mã Nhân Viên";
            dgvHoaDon.Columns["ngayhd"].HeaderText = "Ngày Thêm";
            dgvHoaDon.Columns["makh"].HeaderText = "Mã Khách Hàng";

            dgvHoaDon.ReadOnly = true;
        }
        private void HoaDon_Load(object sender, EventArgs e)
        {
            lstHoaDon= HoaDon_BUS.LoadHoaDon();
            dgvHoaDon.DataSource = lstHoaDon;

            Header();

            cobmanv.DataSource = NhanVien_BUS.LoadNhanVien();
            cobmanv.ValueMember = "manv";
            cobmanv.DisplayMember = "manv";

            cbomakh.DataSource = KhachHang_BUS.LoadMaKhachHang();
            cbomakh.ValueMember = "makh";
            cbomakh.DisplayMember = "makh";

            
        }
        public void ResetTextBox()
        {
            txtSoHD.Text = "";
            txtSoHD.Focus();          
        }
        public bool CheckNhap()
        {
            Boolean kQ = true;
            if (txtSoHD.Text.Trim() == "")
            {
                kQ = false;
                txtSoHD.Focus();
            }
            return kQ;
        }

        private void bntthem_Click(object sender, EventArgs e)
        {
            if (CheckNhap() == true)
            {
                HoaDon_DTO hdDTO = new HoaDon_DTO();
                hdDTO.mahd = txtSoHD.Text;
                hdDTO.manv = cobmanv.SelectedValue.ToString();
                hdDTO.ngayhd = Convert.ToDateTime(dtpngayhd.Text);
                hdDTO.makh = cbomakh.SelectedValue.ToString();
                if (HoaDon_BUS.ThemHoaDon(hdDTO) == true)
                {
                    lstHoaDon.Add(hdDTO);
                    dgvHoaDon.DataSource = typeof(List<HoaDon_DTO>);
                    dgvHoaDon.DataSource = lstHoaDon;
                    Header();
                    ResetTextBox();
                }
                else
                {
                    MessageBox.Show("Trùng lặp mã hóa đơn hãy kiểm tra lại ", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập đủ thông tin", "Thông báo");
            }
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHoaDon.SelectedRows != null)
            {
                DataGridViewRow dr = dgvHoaDon.SelectedRows[0];
                txtSoHD.Text = dr.Cells["mahd"].Value.ToString();
                cobmanv.SelectedValue = dr.Cells["manv"].Value.ToString();
                dtpngayhd.Text = dr.Cells["ngayhd"].Value.ToString();
                cbomakh.SelectedValue=dr.Cells["makh"].Value.ToString();
            }
        }

        private void bntsua_Click(object sender, EventArgs e)
        {
            if (CheckNhap() == true)
            {
                HoaDon_DTO hdDTO = new HoaDon_DTO();
                hdDTO.mahd = txtSoHD.Text;
                hdDTO.manv = cobmanv.SelectedValue.ToString();
                hdDTO.ngayhd = Convert.ToDateTime(dtpngayhd.Text);
                hdDTO.makh = cbomakh.SelectedValue.ToString();
                if (HoaDon_BUS.CapNhatHoaDon(hdDTO) == true)
                {
                    dgvHoaDon.DataSource = HoaDon_BUS.LoadHoaDon();
                    Header();
                    MessageBox.Show("Đã cập nhật thông tin hóa đơn với mã: "+ txtSoHD.Text, "Thông báo");
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại. Không tìm thấy mã hóa đơn", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập đủ thông tin", "Thông báo");
            }
        }

        private void bntxoa_Click(object sender, EventArgs e)
        {
            string maHD = txtSoHD.Text;
            if (HoaDon_BUS.XoaHoaDon(maHD) == true)
            {
                //HoaDon_DTO hdDTODelete = lstHoaDon.Single(n => n.mahd == maHD);
                //lstHoaDon.Remove(hdDTODelete);
                dgvHoaDon.DataSource = HoaDon_BUS.LoadHoaDon();
                Header();
                ResetTextBox();
            }
            else
            {
                if (MessageBox.Show("Xóa thất bại do ảnh hưởng dữ liệu của hóa đơn: "+txtSoHD.Text+"tại bảng Chi Tiết Hóa Đơn. Bạn có muốn tới bảng Chi Tiết Hóa đơn ?", "Cảnh báo", MessageBoxButtons.YesNo).ToString() == "Yes")
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
                dgvHoaDon.DataSource = HoaDon_BUS.LoadHoaDon();
            }
            else
            {
                lstHoaDon = HoaDon_BUS.TimHoaDon(txttimkiem.Text);
                if (lstHoaDon != null)
                {
                    dgvHoaDon.DataSource = typeof(List<HoaDon_DTO>);
                    dgvHoaDon.DataSource = lstHoaDon;
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

        private void btnInHD_Click(object sender, EventArgs e)
        {
            InHD ihd= new InHD();
            ihd.Show();
            this.Hide();
        }
    }
}
