using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class NhaCungCap_DAL
    {
        public static List<NhaCungCap_DTO> LoadNCC()
        {
            string sChuoiTruyVan = @"SELECT * FROM NhaCungCap";
            DataTable dt = new DataTable();
            dt = KetNoi_DAL.TruyVanDataReader(sChuoiTruyVan);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<NhaCungCap_DTO> lstNCCDTO = new List<NhaCungCap_DTO>();
                NhaCungCap_DTO nccDTO;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    nccDTO = new NhaCungCap_DTO();
                    nccDTO.mancc = dt.Rows[i]["mancc"].ToString();
                    nccDTO.tencc = dt.Rows[i]["tenncc"].ToString();
                    nccDTO.diachincc = dt.Rows[i]["diachincc"].ToString();
                    nccDTO.dienthoai = dt.Rows[i]["dienthoai"].ToString();
                    lstNCCDTO.Add(nccDTO);
                }
                return lstNCCDTO;
            }
            return null;
        }
        public static bool ThemNCC(NhaCungCap_DTO nccDTO)
        {
            string sChuoiTruyVan = string.Format("INSERT INTO NhaCungCap VALUES ('{0}','{1}','{2}','{3}')", nccDTO.mancc, nccDTO.tencc, nccDTO.diachincc, nccDTO.dienthoai);
            bool ketQua = KetNoi_DAL.TruyVanExcuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }
        public static bool CapNhatNCC(NhaCungCap_DTO nccDTO)
        {
            string sChuoiTruyVan = string.Format("UPDATE NhaCungCap SET tenncc='{0}',diachincc='{1}',dienthoai='{2}' WHERE mancc='{3}'", nccDTO.tencc, nccDTO.diachincc, nccDTO.dienthoai, nccDTO.mancc);
            bool ketQua = KetNoi_DAL.TruyVanExcuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }
        public static bool XoaNCC(string maNCC)
        {
            string sChuoiTruyVan = string.Format("DELETE FROM NhaCungCap WHERE mancc='{0}'", maNCC);
            bool ketQua = KetNoi_DAL.TruyVanExcuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }
        public static List<NhaCungCap_DTO> TimNCC(string tuKhoa)
        {
            string sChuoiTruyVan = string.Format(@"Select * From NhaCungCap WHERE tenncc Like N'%{0}%'", tuKhoa);
            DataTable dt = new DataTable();
            dt = KetNoi_DAL.TruyVanDataReader(sChuoiTruyVan);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<NhaCungCap_DTO> lstNCCDTO = new List<NhaCungCap_DTO>();
                NhaCungCap_DTO nccDTO;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    nccDTO = new NhaCungCap_DTO();
                    nccDTO.mancc = dt.Rows[i]["mancc"].ToString();
                    nccDTO.tencc = dt.Rows[i]["tenncc"].ToString();
                    nccDTO.diachincc = dt.Rows[i]["diachincc"].ToString();
                    nccDTO.dienthoai = dt.Rows[i]["dienthoai"].ToString();
                    lstNCCDTO.Add(nccDTO);
                }
                return lstNCCDTO;
            }
            return null;
        }
        public static List<MatHangDaNhap> loadMHDN(string tuKhoa)
        {
            string sChuoiTruyVan = string.Format(@"SELECT MatHang.tenmh,LoaiHang.tenloaihang,LoaiHang.mota,MatHang.ngaynhap FROM MatHang,LoaiHang,NhaCungCap WHERE NhaCungCap.mancc=MatHang.mancc AND LoaiHang.maloaihang=MatHang.maloaihang AND NhaCungCap.mancc LIKE N'%{0}%'", tuKhoa);
            DataTable dt = new DataTable();
            dt = KetNoi_DAL.TruyVanDataReader(sChuoiTruyVan);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<MatHangDaNhap> lstMHDNDTO = new List<MatHangDaNhap>();
                MatHangDaNhap mhdnDTO;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    mhdnDTO = new MatHangDaNhap();
                    mhdnDTO.tenmh = dt.Rows[i]["tenmh"].ToString();
                    mhdnDTO.tenloaihang = dt.Rows[i]["tenloaihang"].ToString();
                    mhdnDTO.mota = dt.Rows[i]["mota"].ToString();
                    mhdnDTO.ngaynhap = Convert.ToDateTime(dt.Rows[i]["ngaynhap"].ToString());
                    lstMHDNDTO.Add(mhdnDTO);
                }
                return lstMHDNDTO;
            }
            return null;
        }
    }
}
