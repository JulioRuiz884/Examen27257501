using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coling.Shared
{
    public class Pedidos
    {
        [Key]
        public int IdPedido { get; set; }

        public int IdCliente { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? Fecha { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal Total { get; set; }

        [StringLength(50)]
        public string Estado { get; set; } = null!;

        [ForeignKey("IdCliente")]
        [InverseProperty("Pedido")]
        public virtual Cliente IdClienteNavigation { get; set; } = null!;

        [InverseProperty("IdPedidoNavigation")]
        public virtual ICollection<Detalle> Detalle { get; set; } = new List<Detalle>();
    }
}
