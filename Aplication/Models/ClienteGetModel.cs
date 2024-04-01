

namespace Aplication.Models
{
    public class ClienteGetModel
    {
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public DateTime Fecha_creacion { get; set; }
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public decimal pago { get; set; }
    }
}
