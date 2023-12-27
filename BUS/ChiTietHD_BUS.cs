using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUS
{
    public class ChiTietHD_BUS
    {
        public static List<ChiTietHD_DTO> LoadChiTietHD()
        {
            return ChiTietHD_DAL.LoadChiTietHD();
        }
        public static bool ThemChiTietHD(ChiTietHD_DTO cthdDTO)
        {
            bool ketQua = ChiTietHD_DAL.ThemChiTietHD(cthdDTO);
            return ketQua;
        }
        public static bool CapNhatChiTietHD(ChiTietHD_DTO cthdDTO)
        {
            bool ketQua = ChiTietHD_DAL.CapNhatChiTietHD(cthdDTO);
            return ketQua;
        }
        public static bool XoaChiTietHD(int sTT)
        {
            bool ketQua= ChiTietHD_DAL.XoaChiTietHD(sTT);
            return ketQua;
        }
        public static List<ChiTietHD_DTO> TimChiTietHD(string tuKhoa)
        {
            return ChiTietHD_DAL.TimChiTietHD(tuKhoa);
        }
    }
}
