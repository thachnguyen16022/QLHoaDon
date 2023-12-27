using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUS
{
    public class SPBanChay_BUS
    {
        public static List<SPBanChay_DTO> LoadSPBanChay()
        {
            return SPBanChay_DAL.LoadSPBanChay();
        }
    }
}
