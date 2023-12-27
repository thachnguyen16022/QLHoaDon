using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUS
{
    public class HoaDon_BUS
    {
        public static List<HoaDon_DTO> LoadHoaDon()
        {
            return HoaDon_DAL.LoadHoaDon();
        }
        public static bool ThemHoaDon(HoaDon_DTO hdDTO)
        {
            bool ketQua = HoaDon_DAL.ThemHoaDon(hdDTO);
            return ketQua;
        }
        public static bool CapNhatHoaDon(HoaDon_DTO hdDTO)
        {
            bool ketQua = HoaDon_DAL.CapNhatHoaDon(hdDTO);
            return ketQua;
        }
        public static bool XoaHoaDon(string maHD)
        {
            bool ketQua=HoaDon_DAL.XoaHoaDon(maHD);
            return ketQua;  
        }
        public static List<HoaDon_DTO> TimHoaDon(string tuKhoa)
        {
            return HoaDon_DAL.TimHoaDon(tuKhoa);
        }
    }
}
