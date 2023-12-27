using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUS
{
    public class KhachHang_BUS
    {
        public static List<KhachHang_DTO> LoadKhachHang()
        {
            return KhachHang_DAL.LoadKhachHang();
        }
        public static List<KhachHang_DTO> LoadMaKhachHang()
        {
            return KhachHang_DAL.LoadMaKhachHang();
        }
        public static bool ThemKhachHang(KhachHang_DTO khDTO)
        {
            bool ketQua = KhachHang_DAL.ThemKhachHang(khDTO);
            return ketQua;
        }
        public static bool CapNhatKhachHang(KhachHang_DTO khDTO)
        {
            bool ketQua = KhachHang_DAL.CapNhatKhachHang(khDTO);
            return ketQua;
        }
        public static bool XoaKhachHang(string maKH)
        {
            bool ketQua = KhachHang_DAL.XoaKhachHang(maKH);
            return ketQua;
        }
        public static List<KhachHang_DTO> TimKhachHang(string tuKhoa)
        {
            return KhachHang_DAL.TimKhachHang(tuKhoa);
        }
        public static List<KhachHang_DTO> TimKhachHangTong(string tuKhoa)
        {
            return KhachHang_DAL.TimKhachHangtong(tuKhoa);
        }
    }
}
