using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coling.Shared
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; } = null!;
        [StringLength(50)]
        public string Apellido { get; set; } = null!;
        [InverseProperty("IdClienteNavigation")]
        public virtual ICollection<Pedidos> Pedido { get; set; } = new List<Pedidos>();
    }
}
