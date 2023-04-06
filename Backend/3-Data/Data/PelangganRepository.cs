using BuWanluWeb._3_Data.Data.Interface;

namespace BuWanluWeb._3_Data.Data
{
    public class PelangganRepository : IPelangganRepository
    {
        public string GetPelanggan()
        {
            var result = "SELECT * FROM PELANGGAN";
            return result;
        }

        public string GetDataTerlama()
        {
            var result = "SELECT TOP 1 * FROM PELANGGAN ORDER BY Tanggal_Bergabung ASC";
            return result;
        }
        public string GetDataTerbaru()
        {
            var result = "SELECT TOP 1 * FROM PELANGGAN ORDER BY Tanggal_Bergabung DESC";
            return result;
        }
    }
}
