using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuWanluWeb._1_Core.Entities
{
    public class SalesGrowth
    {
        public string NamaPakaian { get; set; }
        public int QtyThisMonth { get; set; }
        public int QtyLastMonth { get; set; }
        public int KenaikanPenjualan { get; set; }
    }
}
