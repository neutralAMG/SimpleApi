

namespace Domain.Core
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            Fecha_creacion = DateTime.Now;
        }
        public  string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public DateTime Fecha_creacion { get; set; }
       
    }
}
