using Api2Postgresql.Models;

namespace Api2Postgresql.Repository
{
    public interface AutosInterface
    {
        // CRUD
        Task <bool> CreateAsync (Autos auto);
        Task<bool> UpdateAsync (Autos auto);
        Task<bool> DeleteAsync (int id);
        Task<Autos> GetByAsync (int id);
        Task<IEnumerable<Autos>> GetAllAsync();
    }
}
