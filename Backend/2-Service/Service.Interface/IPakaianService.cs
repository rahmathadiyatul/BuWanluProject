using BuWanluWeb._1_Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuWanluWeb._2_Service.Service.Interface
{
    public interface IPakaianService
    {
        public Task<List<Pakaian>> GetData();
        public Task<Pakaian> GetDataOrderByPrice(string urutan);
    }
}
