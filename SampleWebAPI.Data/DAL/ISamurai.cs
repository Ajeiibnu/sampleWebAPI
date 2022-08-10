using SampleWebAPI.Domain;

namespace SampleWebAPI.Data.DAL
{
    public interface ISamurai : ICrud<Samurai>
    {
        Task<IEnumerable<Samurai>> GetByName(string name);
        Task<IEnumerable<Samurai>> GetSamuraiWithQuotes();
        Task<IEnumerable<Samurai>> GetSamuraiWithSwords();
    }
}
