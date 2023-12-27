using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class MatHang_BUS
    {
        public static List<MatHang_DTO> LoadMatHang()
        {
            return MatHang_DAL.LoadMatHang();
        }
        public static bool ThemMatHang(MatHang_DTO mhDTO)
        {
            bool ketQua = MatHang_DAL.ThemMatHang(mhDTO);
            return ketQua;
        }
        public static bool CapNhatMatHang(MatHang_DTO mhDTO)
        {
            bool ketQua = MatHang_DAL.CapNhatMatHang(mhDTO);
            return ketQua;
        }
        public static bool XoaMatHang(string maMH)
        {
            bool ketQua = MatHang_DAL.XoaMatHang(maMH);
            return ketQua;
        }
        public static List<MatHang_DTO> TimMatHang(string tuKhoa)
        {
            return MatHang_DAL.TimMatHang(tuKhoa);
        }
    }
}
