

using Aplication.Core;

namespace Aplication.Dtos.Usuario
{
    public class UsuarioSaveDto : UsuarioBaseDto
    {
        public UsuarioSaveDto()
        {
            Fecha_creacion = DateTime.Now;
        }
        public int tipo { get; set; }
        public DateTime Fecha_creacion { get; set; }
    }
}
