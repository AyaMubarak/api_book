using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Core.DTO_s
{
    public class CartIteamDTO
    {
        public int IteamCode { get; set; }
        public int UnitCode
        {
            get; set;
        }
        public double Quentity { get; set; }
        public int StoreId {  get; set; }
    }
}
