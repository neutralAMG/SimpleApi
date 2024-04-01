

using Aplication.Core;
using Aplication.Dtos.Cliente;
using Aplication.Models;

namespace Aplication.Contracts
{
    public interface IClienteService : IBaseSrevice<ClienteGetModel, ClienteSaveDto, ClienteUpdateDto>
    {
        ServiceResult<List<ClienteGetModel>> GetClienteByUsuarioId(int id);
    }
}
