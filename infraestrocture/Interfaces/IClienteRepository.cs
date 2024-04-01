

using Domain.Entities;
using Domain.Repository;

namespace infraestrocture.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        List<Cliente> GetClienteByUsuarioID( int id);
    }
}
