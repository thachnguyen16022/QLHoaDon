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
    public class KetNoi_DAL
    {
        public static SqlConnection ketNoi()
        {
            string sChuoiKetNoi = @"Data Source=DESKTOP-IUVTIEA\SQLEXPRESS;Initial Catalog=CuaHang;Integrated Security=True";
            SqlConnection conn=new SqlConnection(sChuoiKetNoi);
            conn.Open();
            return conn;
        }
        public static DataTable TruyVanDataTable(string sChuoiTruyVan)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sChuoiTruyVan, ketNoi());
                DataTable dt = new DataTable();
                da.Fill(dt);
                ketNoi().Close();
                return dt;
            }
            catch(Exception ex)
            {
                ketNoi().Close();
                return null;
            }
        }
        public static DataTable TruyVanDataReader(string sChuoiTruyVan)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sChuoiTruyVan, ketNoi());
                SqlDataReader rd= cmd.ExecuteReader();
                DataTable dt=new DataTable();
                dt.Load(rd);
                ketNoi().Close();
                return dt;
            }
            catch (Exception ex)
            {
                ketNoi().Close();
                return null;
            }
        }
        public static bool TruyVanExcuteNonQuery(string sChuoiTruyVan)
        {
            try
            {
                SqlCommand cmd=new SqlCommand(sChuoiTruyVan, ketNoi());
                int iCMD=cmd.ExecuteNonQuery();
                ketNoi().Close();
                if (iCMD > 0)
                {
                    return true;
                }
                else
                {
                    return false;   
                }
            }
            catch(Exception ex)
            {
                ketNoi().Close();
                return false;
            }
        }
        public static string TruyVanExecuteScalar(string sChuoiTruyVan)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sChuoiTruyVan, ketNoi());
                string sKQ = cmd.ExecuteScalar().ToString();
                ketNoi().Close();
                return sKQ;
            }
            catch (Exception ex)
            {
                ketNoi().Close();
                return null;
            }
        }
    }
}
