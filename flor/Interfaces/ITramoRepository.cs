using flor.Utilities;
using  flor.Entities;

namespace flor.Interfaces
{
    public interface ITramoRepository
    {
        Boolean InsertarBd();
        Task<Tramo> GetTramoById(int id);
    }
}
