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
    public class ChiTietHD_DAL
    {
        public static List<ChiTietHD_DTO> LoadChiTietHD()
        {
            string sChuoiTruyVan = @"SELECT stt, ChiTietHD.mahd, ChiTietHD.mamh , ChiTietHD.soluong ,(ChiTietHD.soluong * MatHang.dongia) as dongiaban FROM MatHang, ChiTietHD WHERE MatHang.mamh = ChiTietHD.mamh";
            DataTable dt = new DataTable();
            dt = KetNoi_DAL.TruyVanDataReader(sChuoiTruyVan);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<ChiTietHD_DTO> lstChiTietHDDTO = new List<ChiTietHD_DTO>();
                ChiTietHD_DTO cthdDTO;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cthdDTO = new ChiTietHD_DTO();
                    cthdDTO.stt = Convert.ToInt32(dt.Rows[i]["stt"].ToString());
                    cthdDTO.mahd = dt.Rows[i]["mahd"].ToString();
                    cthdDTO.mamh = dt.Rows[i]["mamh"].ToString();
                    cthdDTO.soluong = Convert.ToInt32(dt.Rows[i]["soluong"].ToString());
                    cthdDTO.dongiaban = Convert.ToInt32(dt.Rows[i]["dongiaban"].ToString());
                    lstChiTietHDDTO.Add(cthdDTO);
                }
                return lstChiTietHDDTO;
            }
            return null;
        }
        public static bool ThemChiTietHD(ChiTietHD_DTO cthdDTO)
        {
            string sChuoiTruyVan = string.Format("INSERT INTO ChiTietHD(mahd,mamh,soluong) VALUES ('{0}','{1}','{2}')", cthdDTO.mahd,cthdDTO.mamh,cthdDTO.soluong);
            bool ketQua = KetNoi_DAL.TruyVanExcuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }
        public static bool CapNhatChiTietHD(ChiTietHD_DTO cthdDTO)
        {
            string sChuoiTruyVan = string.Format("UPDATE ChiTietHD SET mahd='{0}',mamh='{1}',soluong='{2}' WHERE stt='{3}'", cthdDTO.mahd, cthdDTO.mamh, cthdDTO.soluong, cthdDTO.stt);
            bool ketQua = KetNoi_DAL.TruyVanExcuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }
        public static bool XoaChiTietHD(int sTT)
        {
            string sChuoiTruyVan = string.Format("DELETE FROM ChiTietHD WHERE stt={0}",sTT);
            bool ketQua = KetNoi_DAL.TruyVanExcuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }
        public static List<ChiTietHD_DTO> TimChiTietHD(string tuKhoa)
        {
            string sChuoiTruyVan = string.Format(@"SELECT stt, ChiTietHD.mahd, ChiTietHD.mamh , ChiTietHD.soluong ,(ChiTietHD.soluong * MatHang.dongia) as dongiaban FROM MatHang, ChiTietHD WHERE MatHang.mamh = ChiTietHD.mamh AND ChiTietHD.mahd Like '%{0}%'", tuKhoa);
            DataTable dt = new DataTable();
            dt = KetNoi_DAL.TruyVanDataReader(sChuoiTruyVan);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<ChiTietHD_DTO> lstChiTietHDDTO = new List<ChiTietHD_DTO>();
                ChiTietHD_DTO cthdDTO;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cthdDTO = new ChiTietHD_DTO();
                    cthdDTO.stt = Convert.ToInt32(dt.Rows[i]["stt"].ToString());
                    cthdDTO.mahd = dt.Rows[i]["mahd"].ToString();
                    cthdDTO.mamh = dt.Rows[i]["mamh"].ToString();
                    cthdDTO.soluong = Convert.ToInt32(dt.Rows[i]["soluong"].ToString());
                    cthdDTO.dongiaban = Convert.ToInt32(dt.Rows[i]["dongiaban"].ToString());
                    lstChiTietHDDTO.Add(cthdDTO);
                }
                return lstChiTietHDDTO;
            }
            return null;
        }
    }
}
