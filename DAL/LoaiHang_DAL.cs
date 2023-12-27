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
    public class LoaiHang_DAL
    {
        public static List<LoaiHang_DTO> LoadLoaiHang()
        {
            string sChuoiTruyVan = @"Select * From LoaiHang";
            DataTable dt = new DataTable();
            dt = KetNoi_DAL.TruyVanDataReader(sChuoiTruyVan);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<LoaiHang_DTO> lstLoaiHangDTO = new List<LoaiHang_DTO>();
                LoaiHang_DTO lhDTO;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lhDTO = new LoaiHang_DTO();
                    lhDTO.maloaihang = dt.Rows[i]["maloaihang"].ToString();
                    lhDTO.tenloaihang = dt.Rows[i]["tenloaihang"].ToString();
                    lhDTO.mota = dt.Rows[i]["mota"].ToString();
                    lstLoaiHangDTO.Add(lhDTO);
                }
                return lstLoaiHangDTO;
            }
            return null;
        }
        public static bool ThemLoaiHang(LoaiHang_DTO lhDTO)
        {
            string sChuoiTruyVan = string.Format("INSERT INTO LoaiHang VALUES ('{0}',N'{1}',N'{2}')", lhDTO.maloaihang, lhDTO.tenloaihang, lhDTO.mota);
            bool ketQua = KetNoi_DAL.TruyVanExcuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }
        public static bool CapNhatLoaiHang(LoaiHang_DTO lhDTO)
        {
            string sChuoiTruyVan = string.Format("UPDATE LoaiHang SET tenloaihang=N'{0}',mota=N'{1}' WHERE maloaihang='{2}'",lhDTO.tenloaihang, lhDTO.mota, lhDTO.maloaihang);
            bool ketQua = KetNoi_DAL.TruyVanExcuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }
        public static bool XoaLoaiHang(string maLH)
        {
            string sChuoiTruyVan = string.Format("DELETE FROM LoaiHang WHERE maloaihang='{0}'", maLH);
            bool ketQua = KetNoi_DAL.TruyVanExcuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }
        public static List<LoaiHang_DTO> TimLoaiHang(string tuKhoa)
        {
            string sChuoiTruyVan = string.Format(@"Select * From LoaiHang WHERE tenloaihang Like N'%{0}%'", tuKhoa);
            DataTable dt = new DataTable();
            dt = KetNoi_DAL.TruyVanDataReader(sChuoiTruyVan);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<LoaiHang_DTO> lstLoaiHangDTO = new List<LoaiHang_DTO>();
                LoaiHang_DTO lhDTO;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lhDTO = new LoaiHang_DTO();
                    lhDTO.maloaihang = dt.Rows[i]["maloaihang"].ToString();
                    lhDTO.tenloaihang = dt.Rows[i]["tenloaihang"].ToString();
                    lhDTO.mota = dt.Rows[i]["mota"].ToString();
                    lstLoaiHangDTO.Add(lhDTO);
                }
                return lstLoaiHangDTO;
            }
            return null;
        }
    }
}
