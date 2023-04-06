using BuWanluWeb._1_Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuWanluWeb._2_Service.Service.Interface
{
    public interface IPelangganService
    {
        public Task<List<Pelanggan>> GetData();
        public Task<Pelanggan> GetDataTerlama();
        public Task<Pelanggan> GetDataTerbaru();
    }
}
