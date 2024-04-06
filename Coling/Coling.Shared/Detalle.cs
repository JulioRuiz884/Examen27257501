using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coling.Shared
{
    public class Detalle
    {
        [Key]
        public int Id { get; set; }

        public int IdPedido { get; set; }

        public int IdProducto { get; set; }

        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public int Subtotal { get; set; }

        [StringLength(50)]
        public string Estado { get; set; } = null!;

        [ForeignKey("IdPedido")]
        [InverseProperty("Detalle")]
        public virtual Pedidos IdPedidoNavigation { get; set; } = null!;
        [ForeignKey("IdProducto")]
        [InverseProperty("Detalle")]
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
