using BuWanluWeb._1_Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuWanluWeb._2_Service.Service.Interface
{
    public interface IPenjualanService
    {
        public Task<List<Penjualan>> GetData();
        public Task<List<TopPakaian>> GetTopPenjualanPakaian(string cabang, int bulan);
        public Task<List<TopPelanggan>> GetTopSpenders(string cabang, int bulan);
        public Task<int> GetRevenueByYear(string cabang);
        public Task<List<SalesGrowth>> GetSalesGrowth();
    }
}
