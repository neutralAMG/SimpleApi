

using Aplication.Core;

namespace Aplication.Dtos.Cliente
{
    public class ClienteSaveDto : ClienteBaseDto
    {
        public ClienteSaveDto()
        {
            Fecha_creacion = DateTime.Now;
        }
        public int IdUsuario { get; set; }
        public DateTime Fecha_creacion { get; set; }
    }
}
