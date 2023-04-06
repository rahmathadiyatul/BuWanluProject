namespace BuWanluWeb._3_Data.Data.Interface
{
    public interface IPakaianRepository
    {
        public string GetPakaian();
        public string GetPakaianOrderByPrice(string urutan);
    }
}
