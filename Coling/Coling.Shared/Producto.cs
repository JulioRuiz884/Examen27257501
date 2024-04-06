using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coling.Shared
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; } = null!;
        [InverseProperty("IdProductoNavigation")]
        public virtual ICollection<Detalle> Detalle { get; set; } = new List<Detalle>();
    }
}
