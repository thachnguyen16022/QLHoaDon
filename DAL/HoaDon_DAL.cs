using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class HoaDon_DAL
    {
        public static List<HoaDon_DTO> LoadHoaDon()
        {
            string sChuoiTruyVan = @"Select * From HoaDon";
            DataTable dt = new DataTable();
            dt = KetNoi_DAL.TruyVanDataReader(sChuoiTruyVan);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<HoaDon_DTO> lstHoaDonDTO = new List<HoaDon_DTO>();
                HoaDon_DTO hdDTO;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    hdDTO = new HoaDon_DTO();
                    hdDTO.mahd = dt.Rows[i]["mahd"].ToString();
                    hdDTO.manv = dt.Rows[i]["manv"].ToString();
                    hdDTO.ngayhd = Convert.ToDateTime(dt.Rows[i]["ngayhd"].ToString());
                    hdDTO.makh = dt.Rows[i]["makh"].ToString();
                    lstHoaDonDTO.Add(hdDTO);
                }
                return lstHoaDonDTO;
            }
            return null;
        }
        public static bool ThemHoaDon(HoaDon_DTO hdDTO)
        {
            string sChuoiTruyVan = string.Format("INSERT INTO HoaDon VALUES ('{0}','{1}','{2}','{3}')", hdDTO.mahd, hdDTO.manv, hdDTO.ngayhd , hdDTO.makh);
            bool ketQua = KetNoi_DAL.TruyVanExcuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }
        public static bool CapNhatHoaDon(HoaDon_DTO hdDTO)
        {
            string sChuoiTruyVan = string.Format("UPDATE HoaDon SET manv='{0}',ngayhd='{1}',makh='{2}' WHERE mahd='{3}'", hdDTO.manv, hdDTO.ngayhd, hdDTO.makh, hdDTO.mahd);
            bool ketQua = KetNoi_DAL.TruyVanExcuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }
        public static bool XoaHoaDon(string maHD)
        {
            string sChuoiTruyVan = string.Format("DELETE FROM HoaDon WHERE mahd='{0}'", maHD);
            bool ketQua = KetNoi_DAL.TruyVanExcuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }
        public static List<HoaDon_DTO> TimHoaDon(string tuKhoa)
        {
            string sChuoiTruyVan = string.Format(@"Select * From HoaDon WHERE manv Like N'%{0}%'", tuKhoa);
            DataTable dt = new DataTable();
            dt = KetNoi_DAL.TruyVanDataReader(sChuoiTruyVan);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<HoaDon_DTO> lstHoaDonDTO = new List<HoaDon_DTO>();
                HoaDon_DTO hdDTO;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    hdDTO = new HoaDon_DTO();
                    hdDTO.mahd = dt.Rows[i]["mahd"].ToString();
                    hdDTO.manv = dt.Rows[i]["manv"].ToString();
                    hdDTO.ngayhd = Convert.ToDateTime(dt.Rows[i]["ngayhd"].ToString());
                    hdDTO.makh = dt.Rows[i]["makh"].ToString();
                    lstHoaDonDTO.Add(hdDTO);
                }
                return lstHoaDonDTO;
            }
            return null;
        }
    }
    
}
