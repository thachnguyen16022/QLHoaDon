using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUS
{
    public class InHD_BUS
    {
        public static List<InHD_DTO> LoadInHD(string tukhoa)
        {
            return InHD_DAL.LoadInHD(tukhoa);
        }
    }
}
