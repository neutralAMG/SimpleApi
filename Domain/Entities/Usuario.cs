
using Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Usuario : BaseEntity
    {
        [Key]
        public int IdUsuario { get; set; }
        public int tipo { get; set; }
        public string Contrasena { get; set; }

    }
}
