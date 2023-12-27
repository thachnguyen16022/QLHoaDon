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
    public partial class NhaCungCap : Form
    {
        public NhaCungCap()
        {
            InitializeComponent();
        }
        List<NhaCungCap_DTO> lstNCC = new List<NhaCungCap_DTO>();
        List<MatHangDaNhap> lstMHDN = new List<MatHangDaNhap>();
        public void Header()
        {
            dgvNCC.Columns["mancc"].HeaderText = "Mã NCC";
            dgvNCC.Columns["tencc"].HeaderText = "Tên NCC";
            dgvNCC.Columns["diachincc"].HeaderText = "Địa Chỉ";
            dgvNCC.Columns["dienthoai"].HeaderText = "Liên Hệ";

            dgvNCC.ReadOnly = true;
        }
        public void ResetTextBox()
        {
            txtmancc.Text = "";
            txttenncc.Text = "";
            txtdiachi.Text = "";
            txtlienhe.Text = "";
            txttimkiem.Text = "";
            txtmancc.Focus();
        }
        public bool CheckNhap()
        {
            Boolean kQ = true;
            if (txtmancc.Text.Trim() == "")
            {
                kQ = false;
                txtmancc.Focus();
            }
            else if (txttenncc.Text.Trim() == "")
            {
                kQ = false;
                txttenncc.Focus();
            }
            else if (txtdiachi.Text.Trim() == "")
            {
                kQ = false;
                txtdiachi.Focus();
            }
            else if (txtlienhe.Text.Trim() == "")
            {
                kQ = false;
                txtlienhe.Focus();
            }
            return kQ;
        }
        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            lstNCC = NhaCungCap_BUS.LoadNCC();
            dgvNCC.DataSource = lstNCC;

            Header();
        }

        private void bntthem_Click(object sender, EventArgs e)
        {
            if (CheckNhap() == true)
            {
                NhaCungCap_DTO nccDTO = new NhaCungCap_DTO();
                nccDTO.mancc = txtmancc.Text;
                nccDTO.tencc = txttenncc.Text;
                nccDTO.diachincc = txtdiachi.Text;
                nccDTO.dienthoai = txtlienhe.Text;
                if (NhaCungCap_BUS.ThemNCC(nccDTO) == true)
                {
                    lstNCC.Add(nccDTO);
                    dgvNCC.DataSource = typeof(List<NhaCungCap_DTO>);
                    dgvNCC.DataSource = lstNCC;
                    Header();

                    ResetTextBox();
                }
                else
                {
                    MessageBox.Show("Mã nhà cung cấp đã tồn tại!", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Xin hãy nhập đủ thông tin", "Thông báo");
            }
        }

        private void bntsua_Click(object sender, EventArgs e)
        {
            if (CheckNhap() == true)
            {
                NhaCungCap_DTO nccDTO = new NhaCungCap_DTO();
                nccDTO.mancc = txtmancc.Text;
                nccDTO.tencc = txttenncc.Text;
                nccDTO.diachincc = txtdiachi.Text;
                nccDTO.dienthoai = txtlienhe.Text;
                if (NhaCungCap_BUS.CapNhatNCC(nccDTO) == true)
                {
                    dgvNCC.DataSource = NhaCungCap_BUS.LoadNCC();
                    Header();

                    MessageBox.Show("Đã cập nhật thông tin ncc với mã: " + txtmancc.Text, "Thông báo");
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

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNCC.SelectedRows != null)
            {
                DataGridViewRow dr = dgvNCC.SelectedRows[0];
                txtmancc.Text = dr.Cells["mancc"].Value.ToString();
                txttenncc.Text = dr.Cells["tencc"].Value.ToString();
                txtdiachi.Text = dr.Cells["diachincc"].Value.ToString();
                txtlienhe.Text = dr.Cells["dienthoai"].Value.ToString();
            }
        }

        private void bntxoa_Click(object sender, EventArgs e)
        {
            string maNCC = txtmancc.Text;
            if (NhaCungCap_BUS.XoaNCC(maNCC) == true)
            {
                NhaCungCap_DTO nccDTODelete = lstNCC.Single(n => n.mancc == maNCC);
                lstNCC.Remove(nccDTODelete);
                dgvNCC.DataSource = NhaCungCap_BUS.LoadNCC();
                Header();

                ResetTextBox();
            }
            else
            {
                if (MessageBox.Show("Xóa thất bại do ảnh hưởng dữ liệu của Nhà Cung Cấp: " + txttenncc.Text + "tại bảng Mặt Hàng. Bạn có muốn tới bảng Mặt Hàng ?", "Cảnh báo", MessageBoxButtons.YesNo).ToString() == "Yes")
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
                dgvNCC.DataSource = NhaCungCap_BUS.LoadNCC();
            }
            else
            {
                lstNCC = NhaCungCap_BUS.TimNCC(txttimkiem.Text);
                if (lstNCC != null)
                {
                    dgvNCC.DataSource = typeof(List<NhaCungCap_DTO>);
                    dgvNCC.DataSource = lstNCC;
                    Header();

                    MessageBox.Show("Tim thay nhà cung cấp", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Không tim thấy nhà cung cấp", "Thông báo");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtmancc.Text.Trim() == "")
            {
                MessageBox.Show("Mời chọn Nhà cung cấp ở bảng nhà cung cấp", "Thông báo");
            }
            else
            {
                lstMHDN = NhaCungCap_BUS.loadMHDN(txtmancc.Text);
                if (lstMHDN != null)
                {
                    lbltenncc.Text = txttenncc.Text;
                    dgvdanhap.DataSource = typeof(List<MatHangDaNhap>);
                    dgvdanhap.DataSource = lstMHDN;
                    //Header();
                }
                else
                {
                    MessageBox.Show("Chưa nhập hàng ở nhà cung cấp này!", "Thông báo");
                }
            }
        }

        private void btnquaylai_Click(object sender, EventArgs e)
        {
            MatHang mh = new MatHang();
            mh.Show();
            this.Hide();
        }
    }
}
