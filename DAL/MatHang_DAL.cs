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
    public class MatHang_DAL
    {
        public static List<MatHang_DTO> LoadMatHang()
        {
            string sChuoiTruyVan = @"SELECT * FROM MatHang";
            DataTable dt = new DataTable();
            dt = KetNoi_DAL.TruyVanDataReader(sChuoiTruyVan);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<MatHang_DTO> lstMatHangDTO = new List<MatHang_DTO>();
                MatHang_DTO mhDTO;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    mhDTO = new MatHang_DTO();
                    mhDTO.mamh = dt.Rows[i]["mamh"].ToString();
                    mhDTO.tenmh = dt.Rows[i]["tenmh"].ToString();
                    mhDTO.mancc = dt.Rows[i]["mancc"].ToString();
                    mhDTO.donvi = dt.Rows[i]["donvi"].ToString();
                    mhDTO.dongia = Convert.ToInt32(dt.Rows[i]["dongia"].ToString());
                    mhDTO.maloaihang = dt.Rows[i]["maloaihang"].ToString();
                    mhDTO.ngaynhap = Convert.ToDateTime(dt.Rows[i]["ngaynhap"].ToString());
                    lstMatHangDTO.Add(mhDTO);
                }
                return lstMatHangDTO;
            }
            return null;
        }
        public static bool ThemMatHang(MatHang_DTO mhDTO)
        {
            string sChuoiTruyVan = string.Format("INSERT INTO MatHang VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", mhDTO.mamh,mhDTO.tenmh, mhDTO.mancc, mhDTO.donvi, mhDTO.dongia, mhDTO.maloaihang, mhDTO.ngaynhap);
            bool ketQua = KetNoi_DAL.TruyVanExcuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }
        public static bool CapNhatMatHang(MatHang_DTO mhDTO)
        {
            string sChuoiTruyVan = string.Format("UPDATE MatHang SET tenmh='{0}',mancc='{1}',donvi='{2}',dongia='{3}',maloaihang='{4}',ngaynhap='{5}' WHERE mamh='{6}'", mhDTO.tenmh, mhDTO.mancc, mhDTO.donvi, mhDTO.dongia, mhDTO.maloaihang, mhDTO.ngaynhap, mhDTO.mamh);
            bool ketQua = KetNoi_DAL.TruyVanExcuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }
        public static bool XoaMatHang(string maMH)
        {
            string sChuoiTruyVan = string.Format("DELETE FROM MatHang WHERE mamh='{0}'", maMH);
            bool ketQua = KetNoi_DAL.TruyVanExcuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }
        public static List<MatHang_DTO> TimMatHang(string tuKhoa)
        {
            string sChuoiTruyVan = string.Format(@"Select * From MatHang WHERE tenmh Like N'%{0}%'",tuKhoa);
            DataTable dt = new DataTable();
            dt = KetNoi_DAL.TruyVanDataReader(sChuoiTruyVan);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<MatHang_DTO> lstMatHangDTO = new List<MatHang_DTO>();
                MatHang_DTO mhDTO;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    mhDTO = new MatHang_DTO();
                    mhDTO.mamh = dt.Rows[i]["mamh"].ToString();
                    mhDTO.tenmh = dt.Rows[i]["tenmh"].ToString();
                    mhDTO.mancc = dt.Rows[i]["mancc"].ToString();
                    mhDTO.donvi = dt.Rows[i]["donvi"].ToString();
                    mhDTO.dongia = Convert.ToInt32(dt.Rows[i]["dongia"].ToString());
                    mhDTO.maloaihang = dt.Rows[i]["maloaihang"].ToString();
                    mhDTO.ngaynhap = Convert.ToDateTime(dt.Rows[i]["ngaynhap"].ToString());
                    lstMatHangDTO.Add(mhDTO);
                }
                return lstMatHangDTO;
            }
            return null;
        }
    }
}
