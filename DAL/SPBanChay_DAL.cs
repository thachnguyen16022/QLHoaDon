using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class SPBanChay_DAL
    {
        public static List<SPBanChay_DTO> LoadSPBanChay()
        {
            string sChuoiTruyVan = @"SELECT MatHang.tenmh,LoaiHang.tenloaihang,NhaCungCap.tenncc,SUM(ChiTietHD.soluong) as soluongban,(MatHang.dongia*SUM(ChiTietHD.soluong)) as tongthu FROM MatHang,LoaiHang,NhaCungCap,ChiTietHD WHERE MatHang.maloaihang=LoaiHang.maloaihang AND mathang.mancc=NhaCungCap.mancc AND ChiTietHD.mamh=MatHang.mamh GROUP BY MatHang.tenmh,LoaiHang.tenloaihang,NhaCungCap.tenncc,MatHang.dongia ORDER BY soluongban DESC";
            DataTable dt = new DataTable();
            dt = KetNoi_DAL.TruyVanDataReader(sChuoiTruyVan);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<SPBanChay_DTO> lstSPBanChayDTO = new List<SPBanChay_DTO>();
                SPBanChay_DTO spbcDTO;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    spbcDTO = new SPBanChay_DTO();
                    spbcDTO.tenmh = dt.Rows[i]["tenmh"].ToString();
                    spbcDTO.tenloaihang = dt.Rows[i]["tenloaihang"].ToString();
                    spbcDTO.tenncc = dt.Rows[i]["tenncc"].ToString();
                    spbcDTO.soluongban = Convert.ToInt32(dt.Rows[i]["soluongban"].ToString());
                    spbcDTO.tongthu = Convert.ToInt32(dt.Rows[i]["tongthu"].ToString());
                    lstSPBanChayDTO.Add(spbcDTO);
                }
                return lstSPBanChayDTO;
            }
            return null;
        }
    }
}
