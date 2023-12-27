using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUS
{
    public class NhanVien_BUS
    {
        public static List<NhanVien_DTO> LoadNhanVien()
        {
            return NhanVien_DAL.LoadNhanVien();
        }
        public static bool ThemNhanVien(NhanVien_DTO nvDTO)
        {
            bool ketQua = NhanVien_DAL.ThemNhanVien(nvDTO);
            return ketQua;
        }
        public static bool CapNhatNhanVien(NhanVien_DTO nvDTO)
        {
            bool ketQua = NhanVien_DAL.CapNhatNhanVien(nvDTO);
            return ketQua;
        }
        public static bool XoaNhanVien(string maNV)
        {
            bool ketQua = NhanVien_DAL.XoaNhanVien(maNV);
            return ketQua;
        }
        public static List<NhanVien_DTO> TimNhanVien(string tuKhoa)
        {
            return NhanVien_DAL.TimNhanVien(tuKhoa); 
        }
    }
}
