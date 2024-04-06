using Coling.Shared;
using Google.Protobuf.Collections;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Coling.API.Afiliados.Contratos
{
    public interface Iejercicios
    {
        public Task<bool> RegistrarPedidoConDetalle(Pedidos pedido);
        public Task<List<reporte1>> ListarDetallePedido();
        public Task<List<Pedidos>> Listar3PedidosVendidos();
        public Task<bool> ModificarPedidoConDetalle(Pedidos pedidos, int id);
        public Task<bool> EliminarClienteConPedidos(int id);
        public Task<List<Producto>> ProductosMasVendidos(DateTime fechaInicio, DateTime fechaFin);
    }

    public class reporte1
    {
        public string? nombreCliente { get; set; }
        public DateTime? fechaPedido { get; set; }
        public string? nombreProducto { get; set; }
        public decimal total { get; set; }
    }
}
