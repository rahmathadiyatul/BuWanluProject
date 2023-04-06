using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuWanluWeb._1_Core.Entities
{
    public class TopPelanggan
    {
        public int PelangganID { get; set; }
        public string NamaPelanggan { get; set; }
        public int TotalPricePerPax { get; set; }
        public string Cabang { get; set; }
    }
}
