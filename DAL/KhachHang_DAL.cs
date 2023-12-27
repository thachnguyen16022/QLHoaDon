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
    public class KhachHang_DAL
    {
        public static List<KhachHang_DTO> LoadKhachHang()
        {
            string sChuoiTruyVan = @"SELECT KhachHang.makh , KhachHang.tenkh , KhachHang.diachikh , KhachHang.lienhe, SUM((ChiTietHD.soluong*MatHang.dongia)) as tong FROM ChiTietHD,MatHang,KhachHang,HoaDon WHERE KhachHang.makh=HoaDon.makh AND ChiTietHD.mamh=MatHang.mamh AND ChiTietHD.mahd=HoaDon.mahd GROUP BY KhachHang.makh , KhachHang.tenkh , KhachHang.diachikh , KhachHang.lienhe";
            DataTable dt = new DataTable();
            dt = KetNoi_DAL.TruyVanDataReader(sChuoiTruyVan);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<KhachHang_DTO> lstKhachHangDTO = new List<KhachHang_DTO>();
                KhachHang_DTO khDTO;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    khDTO = new KhachHang_DTO();
                    khDTO.makh = dt.Rows[i]["makh"].ToString();
                    khDTO.tenkh = dt.Rows[i]["tenkh"].ToString();
                    khDTO.diachikh = dt.Rows[i]["diachikh"].ToString();
                    khDTO.lienhe = dt.Rows[i]["lienhe"].ToString();
                    khDTO.Tong= Convert.ToInt32(dt.Rows[i]["tong"].ToString());
                    lstKhachHangDTO.Add(khDTO);
                }
                return lstKhachHangDTO;
            }
            return null;
        }
        public static List<KhachHang_DTO> LoadMaKhachHang()
        {
            string sChuoiTruyVan = @"SELECT * FROM KhachHang";
            DataTable dt = new DataTable();
            dt = KetNoi_DAL.TruyVanDataReader(sChuoiTruyVan);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<KhachHang_DTO> lstKhachHangDTO = new List<KhachHang_DTO>();
                KhachHang_DTO khDTO;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    khDTO = new KhachHang_DTO();
                    khDTO.makh = dt.Rows[i]["makh"].ToString();
                    khDTO.tenkh = dt.Rows[i]["tenkh"].ToString();
                    khDTO.diachikh = dt.Rows[i]["diachikh"].ToString();
                    khDTO.lienhe = dt.Rows[i]["lienhe"].ToString();
                    lstKhachHangDTO.Add(khDTO);
                }
                return lstKhachHangDTO;
            }
            return null;
        }
        public static bool ThemKhachHang(KhachHang_DTO khDTO)
        {
            string sChuoiTruyVan = string.Format("INSERT INTO KhachHang VALUES ('{0}',N'{1}',N'{2}','{3}')", khDTO.makh, khDTO.tenkh, khDTO.diachikh, khDTO.lienhe);
            bool ketQua = KetNoi_DAL.TruyVanExcuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }
        public static bool CapNhatKhachHang(KhachHang_DTO khDTO)
        {
            string sChuoiTruyVan = string.Format("UPDATE KhachHang SET tenkh=N'{0}',diachikh=N'{1}',lienhe='{2}' WHERE makh='{3}'", khDTO.tenkh, khDTO.diachikh, khDTO.lienhe, khDTO.makh);
            bool ketQua = KetNoi_DAL.TruyVanExcuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }
        public static bool XoaKhachHang(string maKH)
        {
            string sChuoiTruyVan = string.Format("DELETE FROM KhachHang WHERE makh='{0}'", maKH);
            bool ketQua = KetNoi_DAL.TruyVanExcuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }
        public static List<KhachHang_DTO> TimKhachHang(string tuKhoa)
        {
            string sChuoiTruyVan = string.Format(@"Select * From KhachHang WHERE tenkh LIKE N'%{0}%'", tuKhoa);
            DataTable dt = new DataTable();
            dt = KetNoi_DAL.TruyVanDataReader(sChuoiTruyVan);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<KhachHang_DTO> lstKhachHangDTO = new List<KhachHang_DTO>();
                KhachHang_DTO khDTO;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    khDTO = new KhachHang_DTO();
                    khDTO.makh = dt.Rows[i]["makh"].ToString();
                    khDTO.tenkh = dt.Rows[i]["tenkh"].ToString();
                    khDTO.diachikh = dt.Rows[i]["diachikh"].ToString();
                    khDTO.lienhe = dt.Rows[i]["lienhe"].ToString();
                    lstKhachHangDTO.Add(khDTO);
                }
                return lstKhachHangDTO;
            }
            return null;
        }
        public static List<KhachHang_DTO> TimKhachHangtong(string tuKhoa)
        {
            string sChuoiTruyVan = string.Format(@"SELECT KhachHang.makh , KhachHang.tenkh , KhachHang.diachikh , KhachHang.lienhe, SUM((ChiTietHD.soluong*MatHang.dongia)) as tong FROM ChiTietHD,MatHang,KhachHang,HoaDon WHERE KhachHang.makh=HoaDon.makh AND ChiTietHD.mamh=MatHang.mamh AND ChiTietHD.mahd=HoaDon.mahd AND tenkh LIKE N'%{0}%' GROUP BY KhachHang.makh , KhachHang.tenkh , KhachHang.diachikh , KhachHang.lienhe", tuKhoa);
            DataTable dt = new DataTable();
            dt = KetNoi_DAL.TruyVanDataReader(sChuoiTruyVan);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<KhachHang_DTO> lstKhachHangDTO = new List<KhachHang_DTO>();
                KhachHang_DTO khDTO;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    khDTO = new KhachHang_DTO();
                    khDTO.makh = dt.Rows[i]["makh"].ToString();
                    khDTO.tenkh = dt.Rows[i]["tenkh"].ToString();
                    khDTO.diachikh = dt.Rows[i]["diachikh"].ToString();
                    khDTO.lienhe = dt.Rows[i]["lienhe"].ToString();
                    khDTO.Tong = Convert.ToInt32(dt.Rows[i]["tong"].ToString());
                    lstKhachHangDTO.Add(khDTO);
                }
                return lstKhachHangDTO;
            }
            return null;
        }
    }
}
