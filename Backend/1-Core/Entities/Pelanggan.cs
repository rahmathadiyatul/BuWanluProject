using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuWanluWeb._1_Core.Entities
{
    public class Pelanggan
    {
        public int PelangganID { get; set; }
        public string Nama { get; set; }
        public DateTime TanggalBergabung { get; set; }
        public string Cabang { get; set; }
    }
}
