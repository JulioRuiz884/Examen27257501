using Coling.API.Afiliados.Contratos;
using Coling.Shared;
using Google.Protobuf.Collections;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coling.API.Afiliados.Implementacion
{
    public class ejercicios : Iejercicios
    {
        private readonly Contexto contexto;

        public ejercicios(Contexto contexto)
        {
            this.contexto = contexto;
        }

        //1.- Realizar un Endpoint para que registre un pedido con su respectivo detalle(que deje insertar el pedido y detalle)
        public async Task<bool> RegistrarPedidoConDetalle(Pedidos pedido)
        {
            try
            {
                contexto.Pedidos.Add(pedido);
                foreach (var detalle in pedido.Detalle)
                {
                    detalle.IdPedido = pedido.IdPedido;
                    contexto.Detalles.Add(detalle);
                }
                await contexto.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        //2.- listar el siguiente reporte nombre del cliente, fecha de pedido, nombre del producto y su total
        public async Task<List<reporte1>> ListarDetallePedido()
        {
            return await contexto.Detalles
                .Select(y => new reporte1
                {
                    nombreCliente = y.IdPedidoNavigation.IdClienteNavigation.Nombre,
                    fechaPedido = y.IdPedidoNavigation.Fecha,
                    nombreProducto = y.IdProductoNavigation.Nombre,
                    total = y.IdPedidoNavigation.Total,
                })
                .ToListAsync();
        }
        //3.- Realizar el siguiente reporte identificar los 3 pedidos mas solicitados
        public async Task<List<Pedidos>> Listar3PedidosVendidos()
        {
            return await contexto.Pedidos.OrderByDescending(p => p.Detalle
                                                              .Sum(d => d.Cantidad))
                                                              .Take(3)
                                                              .ToListAsync();
        }

        //4.- Realizar un endpoint para actualizar un pedido y su respectivo detalle
        public Task<bool> ModificarPedidoConDetalle(Pedidos pedidos, int id)
        {
            throw new NotImplementedException();
        }
        //5.- Realizar un Endpoint para realizar un eliminado en cascada del cliente
        public async Task<bool> EliminarClienteConPedidos(int id)
        {
            try
            {
                var cliente = await contexto.Cliente.FindAsync(id);
                if (cliente == null)
                {
                    return false;
                }
                contexto.Cliente.Remove(cliente);
                await contexto.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<List<Producto>> ProductosMasVendidos(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }

        //6.- realizar un Endpoint que determine cuales son los productos mas vendidos segun un rango de fechas como parametro
        //public async Task<List<Producto>> ProductosMasVendidos(DateTime fechaInicio, DateTime fechaFin)
        //{
        //    return await contexto.Detalles.Where(x => x.IdPedidoNavigation.Fecha >= fechaInicio && x.IdPedidoNavigation.Fecha <= fechaFin)
        //                                                        .GroupBy(x => new { x.IdProducto, x.IdProductoNavigation.Nombre })
        //                                                        .Select(g => new ejercicio6
        //                                                        {
        //                                                            idProducto = g.Key.IdProducto,
        //                                                            nombreProducto = g.Key.Nombre,
        //                                                            cantidad = g.Sum(x => x.Cantidad)
        //                                                        })
        //                                                        .OrderByDescending(x => x.cantidad)
        //                                                        .Take(3)
        //                                                        .ToListAsync();
        //}


        public class ejercicio1
        {
            public string? nombreCliente { get; set; }
            public DateTime? fechaPedido { get; set; }
            public string? nombreProducto { get; set; }
            public decimal total { get; set; }
        }
        public class ejercicio6
        {
            public int idProducto { get; set; }
            public string? nombreProducto { get; set; }
            public int cantidad { get; set; }
        }

    }
}
