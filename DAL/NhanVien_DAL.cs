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
    public class NhanVien_DAL
    {
        public static List<NhanVien_DTO> LoadNhanVien()
        {
            string sChuoiTruyVan = @"Select * From NhanVien";
            DataTable dt = new DataTable();
            dt = KetNoi_DAL.TruyVanDataReader(sChuoiTruyVan);
            if (dt != null && dt.Rows.Count>0)
            {
                List<NhanVien_DTO> lstNhanVienDTO = new List<NhanVien_DTO>();
                NhanVien_DTO nvDTO;
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    nvDTO = new NhanVien_DTO();
                    nvDTO.manv = dt.Rows[i]["manv"].ToString();
                    nvDTO.ho = dt.Rows[i]["ho"].ToString();
                    nvDTO.ten = dt.Rows[i]["ten"].ToString();
                    nvDTO.gioitinh = Convert.ToBoolean(dt.Rows[i]["gioitinh"].ToString());
                    nvDTO.diachi = dt.Rows[i]["diachi"].ToString();
                    nvDTO.dienthoai = dt.Rows[i]["dienthoai"].ToString();
                    nvDTO.luongcanban = Convert.ToInt32(dt.Rows[i]["luongcanban"].ToString());
                    nvDTO.congviec = dt.Rows[i]["congviec"].ToString();
                    lstNhanVienDTO.Add(nvDTO);
                }
                return lstNhanVienDTO;
            }
            return null;
        }
        public static bool ThemNhanVien(NhanVien_DTO nvDTO)
        {
            string sChuoiTruyVan= string.Format("INSERT INTO NhanVien VALUES ('{0}',N'{1}',N'{2}','{3}',N'{4}','{5}','{6}',N'{7}')",nvDTO.manv,nvDTO.ho,nvDTO.ten,nvDTO.gioitinh,nvDTO.diachi,nvDTO.dienthoai, nvDTO.luongcanban, nvDTO.congviec);
            bool ketQua = KetNoi_DAL.TruyVanExcuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }
        public static bool CapNhatNhanVien(NhanVien_DTO nvDTO)
        {
            string sChuoiTruyVan = string.Format("UPDATE NhanVien SET ho=N'{0}',ten=N'{1}',gioitinh='{2}',diachi=N'{3}',dienthoai='{4}',luongcanban='{5}',congviec=N'{6}' WHERE manv='{7}'", nvDTO.ho, nvDTO.ten, nvDTO.gioitinh, nvDTO.diachi, nvDTO.dienthoai, nvDTO.luongcanban, nvDTO.congviec, nvDTO.manv);
            bool ketQua = KetNoi_DAL.TruyVanExcuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }
        public static bool XoaNhanVien(string maNV)
        {
            string sChuoiTruyVan = string.Format("DELETE FROM NhanVien WHERE manv='{0}'", maNV);
            bool ketQua = KetNoi_DAL.TruyVanExcuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }
        public static List<NhanVien_DTO> TimNhanVien(string tuKhoa)
        {
            string sChuoiTruyVan = string.Format(@"Select * From NhanVien WHERE ten LIKE N'%{0}%'",tuKhoa);
            DataTable dt = new DataTable();
            dt = KetNoi_DAL.TruyVanDataReader(sChuoiTruyVan);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<NhanVien_DTO> lstNhanVienDTO = new List<NhanVien_DTO>();
                NhanVien_DTO nvDTO;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    nvDTO = new NhanVien_DTO();
                    nvDTO.manv = dt.Rows[i]["manv"].ToString();
                    nvDTO.ho = dt.Rows[i]["ho"].ToString();
                    nvDTO.ten = dt.Rows[i]["ten"].ToString();
                    nvDTO.gioitinh = Convert.ToBoolean(dt.Rows[i]["gioitinh"].ToString());
                    nvDTO.diachi = dt.Rows[i]["diachi"].ToString();
                    nvDTO.dienthoai = dt.Rows[i]["dienthoai"].ToString();
                    nvDTO.luongcanban = Convert.ToInt32(dt.Rows[i]["luongcanban"].ToString());
                    nvDTO.congviec = dt.Rows[i]["congviec"].ToString();
                    lstNhanVienDTO.Add(nvDTO);
                }
                return lstNhanVienDTO;
            }
            return null;
        }
    }
}
