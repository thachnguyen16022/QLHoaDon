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
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Security.Cryptography;
using PagedList;

namespace GUI
{
    public partial class TongHop : Form
    {
        public TongHop()
        {
            InitializeComponent();
        }
        List<NhanVien_DTO> lstNhanVien = new List<NhanVien_DTO>();
        List<MatHang_DTO> lstMatHang = new List<MatHang_DTO>();
        List<LoaiHang_DTO> lstLoaiHang = new List<LoaiHang_DTO>();
        List<HoaDon_DTO> lstHoaDon = new List<HoaDon_DTO>();
        List<ChiTietHD_DTO> lstChiTietHD = new List<ChiTietHD_DTO>();
        List<KhachHang_DTO> lstKhachHang = new List<KhachHang_DTO>();

        private void TongHop_Load(object sender, EventArgs e)
        {
            dgvTong.ReadOnly = true;
            this.dgvTong.DefaultCellStyle.SelectionBackColor = this.dgvTong.DefaultCellStyle.BackColor;
            this.dgvTong.DefaultCellStyle.SelectionForeColor = this.dgvTong.DefaultCellStyle.ForeColor;
        }
        public void LoadNV()
        {
            lstNhanVien = NhanVien_BUS.LoadNhanVien();
            dgvTong.DataSource = lstNhanVien;

            dgvTong.Columns["manv"].Width = 60;
            dgvTong.Columns["ten"].Width = 60;
            dgvTong.Columns["gioitinh"].Width = 30;
            dgvTong.Columns["congviec"].Width = 70;

            dgvTong.Columns["manv"].HeaderText = "MNV";
            dgvTong.Columns["ho"].HeaderText = "Họ";
            dgvTong.Columns["ten"].HeaderText = "Tên";
            dgvTong.Columns["gioitinh"].HeaderText = "GT";
            dgvTong.Columns["diachi"].HeaderText = "Địa Chỉ";
            dgvTong.Columns["dienthoai"].HeaderText = "Điện Thoại";
            dgvTong.Columns["luongcanban"].HeaderText = "Lương Căn Bản";
            dgvTong.Columns["congviec"].HeaderText = "Công Việc";
        }
        public void LoadMH()
        {
            lstMatHang = MatHang_BUS.LoadMatHang();
            dgvTong.DataSource = lstMatHang;

            dgvTong.Columns["mamh"].HeaderText = "Mã Mặt Hàng";
            dgvTong.Columns["tenmh"].HeaderText = "Tên Mặt Hàng";
            dgvTong.Columns["mancc"].HeaderText = "Mã NCC";
            dgvTong.Columns["donvi"].HeaderText = "Đơn Vị";
            dgvTong.Columns["dongia"].HeaderText = "Đơn Giá";
            dgvTong.Columns["maloaihang"].HeaderText = "Mã LH";
            dgvTong.Columns["ngaynhap"].HeaderText = "Ngày nhập";
        }
        public void LoadLH()
        {
            lstLoaiHang = LoaiHang_BUS.LoadLoaiHang();
            dgvTong.DataSource = lstLoaiHang;

            dgvTong.Columns["maloaihang"].HeaderText = "Mã Loại Hàng";
            dgvTong.Columns["tenloaihang"].HeaderText = "Tên Loại Hàng";
            dgvTong.Columns["mota"].HeaderText = "Mô Tả";
        }
        public void LoadHD()
        {
            lstHoaDon = HoaDon_BUS.LoadHoaDon();
            dgvTong.DataSource = lstHoaDon;

            dgvTong.Columns["mahd"].HeaderText = "Mã Hóa Đơn";
            dgvTong.Columns["manv"].HeaderText = "Mã Nhân Viên";
            dgvTong.Columns["ngayhd"].HeaderText = "Ngày Thêm";
        }
        public void LoadCTHD()
        {
            lstChiTietHD = ChiTietHD_BUS.LoadChiTietHD();
            dgvTong.DataSource = lstChiTietHD;
            dgvTong.Columns[0].Visible = false;

            dgvTong.Columns["mahd"].HeaderText = "Mã Hóa Đơn";
            dgvTong.Columns["mamh"].HeaderText = "Mã Mặt Hàng";
            dgvTong.Columns["dongiaban"].HeaderText = "Đơn Giá Bán";
            dgvTong.Columns["soluong"].HeaderText = "Số Lượng";
        }
        public void LoadKhachHang()
        {
            lstKhachHang = KhachHang_BUS.LoadKhachHang();
            dgvTong.DataSource = lstKhachHang;

            //dgvTong.Columns["makh"].HeaderText = "Mã Khách Hàng";
            dgvTong.Columns["tenkh"].HeaderText = "Tên Khách Hàng";
            dgvTong.Columns["diachikh"].HeaderText = "Địa Chỉ";
            dgvTong.Columns["lienhe"].HeaderText = "Số Liên Hệ";
            dgvTong.Columns["Tong"].HeaderText = "Tổng";
        }
        public bool CheckChon()
        {
            Boolean chon=false;
            if (cobTong.SelectedIndex == 0 || cobTong.SelectedIndex ==1 || cobTong.SelectedIndex ==2 || cobTong.SelectedIndex ==3 || cobTong.SelectedIndex ==4 || cobTong.SelectedIndex == 5)
            {
                chon=true;
            }
            return chon;
        }
        string nv = "Tìm kiếm theo tên nhân viên";
        string mh = "Tìm kiếm theo tên mặt hàng";
        string lh = "Tìm kiếm theo tên loại hàng";
        string hd = "Tìm kiếm theo mã nhân viên";
        string cthd = "Tìm kiếm theo mã hóa đơn";
        string kh = "Tìm kiếm theo tên khách hàng";
        private void cobTong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cobTong.SelectedIndex == 0)
            {
                lblTongTK.Text = nv;
                //dgvTong.Width = 800;
                LoadNV();
            }
            else if(cobTong.SelectedIndex == 1)
            {
                lblTongTK.Text = mh;
                LoadMH();
            }
            else if (cobTong.SelectedIndex == 2)
            {
                lblTongTK.Text = lh;
                LoadLH();
            }
            else if(cobTong.SelectedIndex == 3)
            {
                lblTongTK.Text = hd;
                LoadHD();
            }
            else if (cobTong.SelectedIndex == 4)
            {
                lblTongTK.Text = cthd;
                LoadCTHD();
            }
            else if (cobTong.SelectedIndex == 5)
            {
                lblTongTK.Text = kh;
                LoadKhachHang();
            }
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
            DangNhap dn = new DangNhap();
            dn.Show();
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
            if (cobTong.SelectedIndex == 0)
            {
                if (txtTongTK.Text.Trim() == "")
                {
                    this.dgvTong.DataSource = NhanVien_BUS.LoadNhanVien();
                }
                else
                {
                    lstNhanVien = NhanVien_BUS.TimNhanVien(txtTongTK.Text);
                    if (lstNhanVien != null)
                    {
                        this.dgvTong.DataSource = typeof(List<NhanVien_DTO>);
                        this.dgvTong.DataSource = lstNhanVien;

                        dgvTong.Columns["manv"].HeaderText = "Mã Nhân Viên";
                        dgvTong.Columns["ho"].HeaderText = "Họ";
                        dgvTong.Columns["ten"].HeaderText = "Tên";
                        dgvTong.Columns["gioitinh"].HeaderText = "Giới Tính";
                        dgvTong.Columns["diachi"].HeaderText = "Địa Chỉ";
                        dgvTong.Columns["dienthoai"].HeaderText = "Điện Thoại";
                        dgvTong.Columns["luongcanban"].HeaderText = "Lương Căn Bản";
                        dgvTong.Columns["congviec"].HeaderText = "Công Việc";
                    }
                    else
                    {
                        MessageBox.Show("Không tim thấy nhân viên", "Thông báo");
                    }
                }
            }
            else if(cobTong.SelectedIndex == 1)
            {
                if (txtTongTK.Text.Trim() == "")
                {
                    this.dgvTong.DataSource = MatHang_BUS.LoadMatHang();
                }
                else
                {
                    lstMatHang = MatHang_BUS.TimMatHang(txtTongTK.Text);
                    if (lstMatHang != null)
                    {
                        this.dgvTong.DataSource = typeof(List<MatHang_DTO>);
                        this.dgvTong.DataSource = lstMatHang;

                        dgvTong.Columns["mamh"].HeaderText = "Mã Mặt Hàng";
                        dgvTong.Columns["tenmh"].HeaderText = "Tên Mặt Hàng";
                        dgvTong.Columns["mancc"].HeaderText = "Mã NCC";
                        dgvTong.Columns["donvi"].HeaderText = "Đơn Vị";
                        dgvTong.Columns["dongia"].HeaderText = "Đơn Giá";
                        dgvTong.Columns["maloaihang"].HeaderText = "Mã LH";
                        dgvTong.Columns["ngaynhap"].HeaderText = "Ngày nhập";
                    }
                    else
                    {
                        MessageBox.Show("Không tim thấy mặt hàng", "Thông báo");
                    }
                }
            }
            else if (cobTong.SelectedIndex == 2)
            {
                if (txtTongTK.Text.Trim() == "")
                {
                    this.dgvTong.DataSource = LoaiHang_BUS.LoadLoaiHang();
                }
                else
                {
                    lstLoaiHang = LoaiHang_BUS.TimLoaiHang(txtTongTK.Text);
                    if (lstLoaiHang != null)
                    {
                        this.dgvTong.DataSource = typeof(List<LoaiHang_DTO>);
                        this.dgvTong.DataSource = lstLoaiHang;

                        dgvTong.Columns["maloaihang"].HeaderText = "Mã Loại Hàng";
                        dgvTong.Columns["tenloaihang"].HeaderText = "Tên Loại Hàng";
                        dgvTong.Columns["mota"].HeaderText = "Mô Tả";
                    }
                    else
                    {
                        MessageBox.Show("Không tim thấy loại hàng", "Thông báo");
                    }
                }
            }
            else if (cobTong.SelectedIndex == 3)
            {
                if (txtTongTK.Text.Trim() == "")
                {
                    this.dgvTong.DataSource = HoaDon_BUS.LoadHoaDon();
                }
                else
                {
                    lstHoaDon = HoaDon_BUS.TimHoaDon(txtTongTK.Text);
                    if (lstHoaDon != null)
                    {
                        this.dgvTong.DataSource = typeof(List<HoaDon_DTO>);
                        this.dgvTong.DataSource = lstHoaDon;

                        dgvTong.Columns["mahd"].HeaderText = "Mã Hóa Đơn";
                        dgvTong.Columns["manv"].HeaderText = "Mã Nhân Viên";
                        dgvTong.Columns["ngayhd"].HeaderText = "Ngày Thêm";
                    }
                    else
                    {
                        MessageBox.Show("Không tim thấy!!", "Thông báo");
                    }
                }
            }
            else if (cobTong.SelectedIndex == 4)
            {
                if (txtTongTK.Text.Trim() == "")
                {
                    this.dgvTong.DataSource = ChiTietHD_BUS.LoadChiTietHD();
                }
                else
                {
                    lstChiTietHD = ChiTietHD_BUS.TimChiTietHD(txtTongTK.Text);
                    if (lstChiTietHD != null)
                    {
                        this.dgvTong.DataSource = typeof(List<ChiTietHD_DTO>);
                        this.dgvTong.DataSource = lstChiTietHD;
                        this.dgvTong.Columns[0].Visible = false;

                        dgvTong.Columns["mahd"].HeaderText = "Mã Hóa Đơn";
                        dgvTong.Columns["mamh"].HeaderText = "Mã Mặt Hàng";
                        dgvTong.Columns["dongiaban"].HeaderText = "Đơn Giá Bán";
                        dgvTong.Columns["soluong"].HeaderText = "Số Lượng";
                    }
                    else
                    {
                        MessageBox.Show("Không tim thấy!!", "Thông báo");
                    }
                }
            }
            else if (cobTong.SelectedIndex == 5)
            {
                if (txtTongTK.Text.Trim() == "")
                {
                    this.dgvTong.DataSource = KhachHang_BUS.LoadKhachHang();
                }
                else
                {
                    lstKhachHang = KhachHang_BUS.TimKhachHangTong(txtTongTK.Text);
                    if (lstKhachHang != null)
                    {
                        this.dgvTong.DataSource = typeof(List<KhachHang_DTO>);
                        this.dgvTong.DataSource = lstKhachHang;

                        dgvTong.Columns["makh"].HeaderText = "Mã Khách Hàng";
                        dgvTong.Columns["tenkh"].HeaderText = "Tên Khách Hàng";
                        dgvTong.Columns["diachikh"].HeaderText = "Địa Chỉ";
                        dgvTong.Columns["lienhe"].HeaderText = "Số Liên Hệ";
                        dgvTong.Columns["tong"].HeaderText = "Tổng";
                    }
                    else
                    {
                        MessageBox.Show("Không tim thấy!!", "Thông báo");
                    }
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn bảng ở dưới", "Thông báo");
            }
        }

        public void Export_Data_To_Word(DataGridView DGV, string filename)
        {
            if (DGV.Rows.Count != 0)
            {
                int RowCount = DGV.Rows.Count;
                int ColumnCount = DGV.Columns.Count;
                Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

                //Thêm dòng
                int r = 0;
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
                    } //hết vòng lặp dòng
                } //hết vòng lặp cột

                Word.Document oDoc = new Word.Document();
                oDoc.Application.Visible = true;

                //định hướng trang
                oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;


                dynamic oRange = oDoc.Content.Application.Selection.Range;
                string oTemp = "";
                for (r = 0; r <= RowCount - 1; r++)
                {
                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        oTemp = oTemp + DataArray[r, c] + "\t";

                    }
                }

                //định dạng bảng
                oRange.Text = oTemp;

                object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
                object ApplyBorders = true;
                object AutoFit = true;
                object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

                oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                                      Type.Missing, Type.Missing, ref ApplyBorders,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);

                oRange.Select();

                oDoc.Application.Selection.Tables[1].Select();
                oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.InsertRowsAbove(1);
                oDoc.Application.Selection.Tables[1].Rows[1].Select();

                //set kiểu cho tiêu đề
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

                //thêm hàng tiêu đề thủ công
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
                }

                //kiểu của bảng 
                oDoc.Application.Selection.Tables[1].set_Style("Grid Table 4 - Accent 5");
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                //văn bản tiêu đề
                foreach (Word.Section section in oDoc.Application.ActiveDocument.Sections)
                {
                    Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
                    headerRange.Text = "Danh Sách";
                    headerRange.Font.Size = 16;
                    headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }

                //lưu file
                oDoc.SaveAs2(filename);
            }
        }
        public void Export_DataGridView_To_Excel(DataGridView DGV, string filename)
        {
            string[] Alphabit = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
                              "N", "O","P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            string Range_Letter = Alphabit[DGV.Columns.Count];
            string Range_Row = (DGV.Rows.Count + 1).ToString();

            //if (File.Exists(filename))
            //{
            //    File.Delete(filename);
            //}

            Excel.Application oApp;
            Excel.Worksheet oSheet;
            Excel.Workbook oBook;

            oApp = new Excel.Application();
            oBook = oApp.Workbooks.Add();
            oSheet = (Excel.Worksheet)oBook.Worksheets.get_Item(1);


            for (int x = 0; x < DGV.Columns.Count; x++)
            {
                // tạo cột
                oSheet.Cells[1, x + 2] = DGV.Columns[x].HeaderText;
            }


            for (int i = 0; i < DGV.Columns.Count; i++)
            {
                for (int j = 0; j < DGV.Rows.Count; j++)
                {
                    // tạo dòng
                    oSheet.Cells[j + 2, i + 2] = DGV.Rows[j].Cells[i].Value;
                }
            }

            //thêm định dạng
            Range rng1 = oSheet.get_Range("B1", Range_Letter + "1");
            rng1.Font.Size = 14;
            rng1.Font.Bold = true;
            rng1.Cells.Borders.LineStyle = XlLineStyle.xlDouble;
            rng1.Cells.Borders.Color = System.Drawing.Color.DeepSkyBlue;
            rng1.Font.Color = System.Drawing.Color.Black;
            rng1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rng1.Interior.Color = System.Drawing.Color.LightGray;

            Range rng2 = oSheet.get_Range("B2", Range_Letter + Range_Row);
            rng2.WrapText = false;
            rng2.Font.Size = 12;
            rng2.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;
            rng2.Cells.Borders.Color = System.Drawing.Color.DeepSkyBlue;
            rng2.VerticalAlignment = XlVAlign.xlVAlignCenter;
            rng2.Interior.Color = System.Drawing.Color.Azure;
            rng2.EntireColumn.AutoFit();
            rng2.EntireRow.AutoFit();

            //thêm hàng tiêu đề
            oSheet.get_Range("B1", Range_Letter + "2").EntireRow.Insert(XlInsertShiftDirection.xlShiftDown, Missing.Value);
            oSheet.Cells[1, 3] = "Danh Sách ";
            Range rng3 = oSheet.get_Range("B1", Range_Letter + "2");
            rng3.Merge(Missing.Value);
            rng3.Font.Size = 16;
            rng3.Font.Color = System.Drawing.Color.Blue;
            rng3.Font.Bold = true;
            rng3.VerticalAlignment = XlVAlign.xlVAlignCenter;
            rng3.Interior.Color = System.Drawing.Color.LightSkyBlue;


            oBook.SaveAs(filename);
            oBook.Close();
            oApp.Quit();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (CheckChon() == true)
            {
                SaveFileDialog sfd = new SaveFileDialog();

                sfd.Filter = "Word Documents (*.docx)|*.docx";

                sfd.FileName = "NhapTen.docx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {

                    Export_Data_To_Word(dgvTong, sfd.FileName);
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn bảng", "Thông báo");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(CheckChon() == true)
            {
                SaveFileDialog sfd = new SaveFileDialog();

                sfd.Title = "Export To Excel";
                sfd.Filter = "To Excel (Xlsx)|*.xlsx";
                sfd.FileName = "NhapTen";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Export_DataGridView_To_Excel(dgvTong, sfd.FileName);
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn bảng", "Thông báo");
            }
        }
        //Bitmap bmp;
        private void txtPrint_Click(object sender, EventArgs e)
        {
            if (CheckChon() == true)
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Mời chọn bảng", "Thông báo");
            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //e.Graphics.DrawImage(bmp, 0, 0);
            if (cobTong.SelectedIndex == 0)
            {
                e.Graphics.DrawString("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, 20));
                e.Graphics.DrawString("Mã NV ", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(20, 40));
                e.Graphics.DrawString("Họ", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(100, 40));
                e.Graphics.DrawString("Tên", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(180, 40));
                e.Graphics.DrawString("GT", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(300, 40));
                e.Graphics.DrawString("Địa chỉ", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(350, 40));
                e.Graphics.DrawString("SĐT", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(420, 40));
                e.Graphics.DrawString("LươngCB", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(540, 40));
                e.Graphics.DrawString("Công việc", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(680, 40));
                e.Graphics.DrawString("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, 60));
                int vitriy = 100;
                foreach (var i in lstNhanVien)
                {
                    e.Graphics.DrawString(i.manv, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, vitriy));
                    e.Graphics.DrawString(i.ho, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(100, vitriy));
                    e.Graphics.DrawString(i.ten, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(180, vitriy));
                    if (i.gioitinh == true)
                    {
                        e.Graphics.DrawString("Nam", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(300, vitriy));
                    }
                    else
                    {
                        e.Graphics.DrawString("Nữ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(300, vitriy));
                    }
                    e.Graphics.DrawString(i.diachi, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(350, vitriy));
                    e.Graphics.DrawString(i.dienthoai, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(420, vitriy));
                    e.Graphics.DrawString(i.luongcanban.ToString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(540, vitriy));
                    e.Graphics.DrawString(i.congviec, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(680, vitriy));
                    vitriy += 20;
                }
            }
            else if (cobTong.SelectedIndex == 1)
            {
                e.Graphics.DrawString("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, 20));
                e.Graphics.DrawString("Mã MH", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(20, 40));
                e.Graphics.DrawString("Tên mặt hàng", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(100, 40));
                e.Graphics.DrawString("Mã NCC", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(250, 40));
                e.Graphics.DrawString("ĐV", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(360, 40));
                e.Graphics.DrawString("Đơn giá", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(430, 40));
                e.Graphics.DrawString("Mã LH", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(520, 40));
                e.Graphics.DrawString("Ngày Nhập", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(650, 40));
                e.Graphics.DrawString("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, 60));
                int vitriy = 100;
                foreach (var i in lstMatHang)
                {
                    e.Graphics.DrawString(i.mamh, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, vitriy));
                    e.Graphics.DrawString(i.tenmh, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(100, vitriy));
                    e.Graphics.DrawString(i.mancc, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(250, vitriy));
                    e.Graphics.DrawString(i.donvi, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(360, vitriy));
                    e.Graphics.DrawString(i.dongia.ToString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(430, vitriy));
                    e.Graphics.DrawString(i.maloaihang, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(520, vitriy));
                    e.Graphics.DrawString(i.ngaynhap.ToShortDateString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(650, vitriy));
                    vitriy += 20;
                }
            }
            else if (cobTong.SelectedIndex == 2)
            {
                e.Graphics.DrawString("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, 20));
                e.Graphics.DrawString("Mã loại hàng ", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(20, 40));
                e.Graphics.DrawString("Tên loại hàng ", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(220, 40));
                e.Graphics.DrawString("Mô tả ", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(600, 40));
                e.Graphics.DrawString("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, 60));
                int vitriy = 100;
                foreach (var i in lstLoaiHang)
                {
                    e.Graphics.DrawString(i.maloaihang, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(40, vitriy));
                    e.Graphics.DrawString(i.tenloaihang, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(240, vitriy));
                    e.Graphics.DrawString(i.mota, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(620, vitriy));
                    vitriy += 20;
                }
            }
            else if (cobTong.SelectedIndex == 3)
            {
                e.Graphics.DrawString("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, 20));
                e.Graphics.DrawString("Mã hóa đơn", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(20, 40));
                e.Graphics.DrawString("Mã nhân viên", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(220, 40));
                e.Graphics.DrawString("Ngày", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(400, 40));
                e.Graphics.DrawString("Giờ", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(500, 40));
                e.Graphics.DrawString("Mã khách hàng", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(650, 40));
                e.Graphics.DrawString("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, 60));
                int vitriy = 100;
                foreach (var i in lstHoaDon)
                {
                    e.Graphics.DrawString(i.mahd, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(40, vitriy));
                    e.Graphics.DrawString(i.manv, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(240, vitriy));
                    e.Graphics.DrawString(i.ngayhd.ToShortDateString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(400, vitriy));
                    e.Graphics.DrawString(i.ngayhd.ToShortTimeString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(500, vitriy));
                    e.Graphics.DrawString(i.makh, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(650, vitriy));
                    vitriy += 20;
                }
            }
            else if (cobTong.SelectedIndex == 4)
            {
                e.Graphics.DrawString("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, 20));
                e.Graphics.DrawString("Mã hóa đơn", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(20, 40));
                e.Graphics.DrawString("Mã mặt hàng", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(430, 40));
                e.Graphics.DrawString("Đơn giá", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(570, 40));
                e.Graphics.DrawString("Số lượng", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(700, 40));
                e.Graphics.DrawString("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, 60));
                int vitriy = 100;
                foreach (var i in lstChiTietHD)
                {
                    e.Graphics.DrawString(i.mahd, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, vitriy));
                    e.Graphics.DrawString(i.mamh, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(430, vitriy));
                    e.Graphics.DrawString(i.dongiaban.ToString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(570, vitriy));
                    e.Graphics.DrawString(i.soluong.ToString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(700, vitriy));
                    vitriy += 20;
                }
            }
            else if (cobTong.SelectedIndex == 5)
            {
                e.Graphics.DrawString("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, 20));
                e.Graphics.DrawString("Mã khách hàng ", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(20, 40));
                e.Graphics.DrawString("Tên khách hàng ", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(200, 40));
                e.Graphics.DrawString("Địa chỉ ", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(430, 40));
                e.Graphics.DrawString("Số liên hệ ", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(570, 40));
                e.Graphics.DrawString("Tổng tiền", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(700, 40));
                e.Graphics.DrawString("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, 60));
                int vitriy = 100;
                foreach (var i in lstKhachHang)
                {
                    e.Graphics.DrawString(i.makh, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(40, vitriy));
                    e.Graphics.DrawString(i.tenkh, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(220, vitriy));
                    e.Graphics.DrawString(i.diachikh, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(450, vitriy));
                    e.Graphics.DrawString(i.lienhe, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(570, vitriy));
                    e.Graphics.DrawString(i.Tong.ToString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(700, vitriy));
                    vitriy += 20;
                }
            }
        }  
    }
}
