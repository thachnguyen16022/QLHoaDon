using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class DangNhap : Form
    {
        private int dem = 3;
        public DangNhap()
        {
            InitializeComponent();
        }

        private void bntdangnhap_Click(object sender, EventArgs e)
        {
            if ((txtUser.Text == "admin") && (txtPass.Text == "admin"))
            {
                TongHop th = new TongHop();
                th.Show();
                this.Hide();
            }
            else
            {
                txtUser.Focus();
                txtUser.SelectAll();
                txtPass.Text = "";
                dem--;
                MessageBox.Show("Bạn được phép nhập " + dem + " lần nữa!", "Thông báo từ Admin");

                if (dem == 0)
                {
                    MessageBox.Show("Bạn đã nhập quá 3 lần!", "Thông báo từ Admin");
                    Application.Exit();
                }
            }
        }

        private void bttnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
