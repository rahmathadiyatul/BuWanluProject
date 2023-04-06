namespace BuWanluWeb._3_Data.Data.Interface
{
    public interface IPenjualanRepository
    {
        public string GetPenjualan();
        public string GetTopPenjualanPakaian();
        public string GetTopSpenders();
        public string GetRevenueByYear();
        public string GetSalesGrowth();
    }
}
