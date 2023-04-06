using BuWanluWeb._3_Data.Data.Interface;

namespace BuWanluWeb._3_Data.Data
{
    public class PakaianRepository : IPakaianRepository
    {
        public string GetPakaian()
        {
            var result = "SELECT * FROM PAKAIAN";
            return result;
        }

        public string GetPakaianOrderByPrice(string urutan)
        {
            var result = string.Format("SELECT TOP 1 * FROM PAKAIAN ORDER BY HARGA {0};", urutan);
            return result;
        }
    }
}
