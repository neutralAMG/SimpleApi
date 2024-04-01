

namespace Aplication.Models
{
    public class UsuarioGetModel
    {
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public DateTime Fecha_creacion { get; set; }
        public int IdUsuario { get; set; }
        public int tipo { get; set; }
        public string Contrasena { get; set; }
    }
}
