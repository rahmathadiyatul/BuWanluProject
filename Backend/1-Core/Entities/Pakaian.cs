using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuWanluWeb._1_Core.Entities
{
    public class Pakaian
    {
        public int PakaianID { get; set; }
        public string Nama { get; set; }
        public decimal Harga { get; set; }
        public string Image { get; set; }
    }
}
