

using Aplication.Core;
using Aplication.Dtos.Cliente;
using Aplication.Dtos.Usuario;
using Aplication.Models;

namespace Aplication.Contracts
{
    public interface IUsuarioServise : IBaseSrevice<UsuarioGetModel, UsuarioSaveDto, UsuarioUpdateDto>
    {
        public ServiceResult<UsuarioGetModel> GetUsuarioByNameYContra(string name, string contrasena);
    }
}
