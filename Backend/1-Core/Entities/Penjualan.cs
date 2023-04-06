using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuWanluWeb._1_Core.Entities
{
    public class Penjualan
    {
        public int PenjualanID { get; set; }
        public string NamaPelanggan { get; set; }
        public string NamaPakaian { get; set; }
        public int Qty { get; set; }
        public decimal TotalHarga { get; set; }
        public DateTime TanggalTransaksi { get; set; }
    }
}
