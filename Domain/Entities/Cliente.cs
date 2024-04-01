

using Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Cliente : BaseEntity
    {
        [Key]
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public decimal pago { get; set; }
    }
}
