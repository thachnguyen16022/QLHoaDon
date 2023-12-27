using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class InHD_DAL
    {
        public static List<InHD_DTO> LoadInHD(string tuKhoa)
        {
            string sChuoiTruyVan = string.Format(@"SELECT MatHang.tenmh, (ChiTietHD.soluong * MatHang.dongia) as dongiaban , ChiTietHD.soluong FROM ChiTietHD ,HoaDon ,MatHang WHERE  HoaDon.mahd=ChiTietHD.mahd AND ChiTietHD.mamh=MatHang.mamh AND HoaDon.mahd Like '%{0}%'", tuKhoa);
            DataTable dt = new DataTable();
            dt = KetNoi_DAL.TruyVanDataReader(sChuoiTruyVan);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<InHD_DTO> lstInHD = new List<InHD_DTO>();
                InHD_DTO inhdDTO;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    inhdDTO = new InHD_DTO();
                    inhdDTO.tenmh = dt.Rows[i]["tenmh"].ToString();
                    inhdDTO.dongiaban = Convert.ToInt32(dt.Rows[i]["dongiaban"].ToString());
                    inhdDTO.soluong = Convert.ToInt32(dt.Rows[i]["soluong"].ToString());
                    lstInHD.Add(inhdDTO);
                }
                return lstInHD;
            }
            return null;
        }
    }
}
