using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUS
{
    public class LoaiHang_BUS
    {
        public static List<LoaiHang_DTO> LoadLoaiHang()
        {
            return LoaiHang_DAL.LoadLoaiHang();
        }
        public static bool ThemLoaiHang(LoaiHang_DTO lhDTO)
        {
            bool ketQua = LoaiHang_DAL.ThemLoaiHang(lhDTO);
            return ketQua;
        }
        public static bool CapNhatLoaiHang(LoaiHang_DTO lhDTO)
        {
            bool ketQua = LoaiHang_DAL.CapNhatLoaiHang(lhDTO);
            return ketQua;
        }
        public static bool XoaLoaiHang(string maLH)
        {
            bool ketQua=LoaiHang_DAL.XoaLoaiHang(maLH);
            return ketQua;
        }
        public static List<LoaiHang_DTO> TimLoaiHang(string tuKhoa)
        {
            return LoaiHang_DAL.TimLoaiHang(tuKhoa);
        }
    }
}
