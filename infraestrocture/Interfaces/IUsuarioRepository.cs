

using Domain.Entities;
using Domain.Repository;

namespace infraestrocture.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        public Usuario GetUsuarioByNameYContra(string name, string contrasena);
    }
}
