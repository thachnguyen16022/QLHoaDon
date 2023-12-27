using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NhaCungCap_BUS
    {
        public static List<NhaCungCap_DTO> LoadNCC()
        {
            return NhaCungCap_DAL.LoadNCC();
        }
        public static bool ThemNCC(NhaCungCap_DTO nccDTO)
        {
            bool ketQua = NhaCungCap_DAL.ThemNCC(nccDTO);
            return ketQua;
        }
        public static bool CapNhatNCC(NhaCungCap_DTO nccDTO)
        {
            bool ketQua = NhaCungCap_DAL.CapNhatNCC(nccDTO);
            return ketQua;
        }
        public static bool XoaNCC(string maNCC)
        {
            bool ketQua = NhaCungCap_DAL.XoaNCC(maNCC);
            return ketQua;
        }
        public static List<NhaCungCap_DTO> TimNCC(string tuKhoa)
        {
            return NhaCungCap_DAL.TimNCC(tuKhoa);
        }
        public static List<MatHangDaNhap> loadMHDN(string tuKhoa)
        {
            return NhaCungCap_DAL.loadMHDN(tuKhoa);
        }
    }
}
