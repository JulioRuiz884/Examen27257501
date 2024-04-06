using Coling.API.Afiliados.Contratos;
using Coling.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Net;

namespace Coling.API.Afiliados.Endpoint
{
    public class EjerciciosFunction
    {
        private readonly ILogger<EjerciciosFunction> _logger;
        private readonly Iejercicios iejercicios;

        public EjerciciosFunction(ILogger<EjerciciosFunction> logger, Iejercicios iejercicios)
        {
            _logger = logger;
            this.iejercicios = iejercicios;
        }

        [Function("InsertarRegistrarPedidoConDetalle")]
        public async Task<HttpResponseData> InsertarRegistrarPedidoConDetalle([HttpTrigger(AuthorizationLevel.Function, "post", Route = "insertarRegistrarPedidoConDetalle")] HttpRequestData req)
        {
            _logger.LogInformation("Ejecutando Azure Function para InsertarRegistrarPedidoConDetalle");
            try
            {
                var per = await req.ReadFromJsonAsync<Pedidos>() ?? throw new Exception("Debe ingresar una pedido con todos sus datos");
                bool seGuardo = await iejercicios.RegistrarPedidoConDetalle(per);
                if (seGuardo)
                {
                    var respuesta = req.CreateResponse(HttpStatusCode.OK);
                    return respuesta;
                }
                return req.CreateResponse(HttpStatusCode.BadRequest);

            }
            catch (Exception e)
            {
                var error = req.CreateResponse(HttpStatusCode.InternalServerError);
                await error.WriteAsJsonAsync(e.Message);
                return error;
            }

        }
        [Function("listarDetallePedido")]
        public async Task<HttpResponseData> listarDetallePedidos([HttpTrigger(AuthorizationLevel.Function, "get", Route = "listarDetallePedidos")] HttpRequestData req)
        {
            _logger.LogInformation("Ejecutando Azure Function para insertar DetallePedido");
            try
            {
                var listaPersonas = iejercicios.ListarDetallePedido();
                var respuesta = req.CreateResponse(HttpStatusCode.OK);
                await respuesta.WriteAsJsonAsync(listaPersonas.Result);
                return respuesta;
            }
            catch (Exception e)
            {
                var error = req.CreateResponse(HttpStatusCode.InternalServerError);
                await error.WriteAsJsonAsync(e.Message);
                return error;
            }

        }
        [Function("listar3PedidosVendidos")]
        public async Task<HttpResponseData> listar3PedidosVendidos([HttpTrigger(AuthorizationLevel.Function, "get", Route = "listar3PedidosVendidos")] HttpRequestData req)
        {
            _logger.LogInformation("Ejecutando Azure Function para Listar los 3 Pedidos mas Vendidos");
            try
            {
                var listaPersonas = iejercicios.Listar3PedidosVendidos();
                var respuesta = req.CreateResponse(HttpStatusCode.OK);
                await respuesta.WriteAsJsonAsync(listaPersonas.Result);
                return respuesta;
            }
            catch (Exception e)
            {
                var error = req.CreateResponse(HttpStatusCode.InternalServerError);
                await error.WriteAsJsonAsync(e.Message);
                return error;
            }

        }
        [Function("eliminarClienteConPedidos")]
        public async Task<HttpResponseData> eliminarClienteConPedidos([HttpTrigger(AuthorizationLevel.Function, "delete", Route = "eliminarClienteConPedidos/{id}")] HttpRequestData req, int id, FunctionContext context)
        {
            _logger.LogInformation("Ejecutando Azure Function para eliminar Cliente Con Pedidos");

            try
            {
                bool seElimino = await iejercicios.EliminarClienteConPedidos(id);
                if (seElimino)
                {
                    var respuesta = req.CreateResponse(HttpStatusCode.OK);
                    return respuesta;
                }
                else
                {
                    var respuesta = req.CreateResponse(HttpStatusCode.BadRequest);
                    await respuesta.WriteAsJsonAsync("El cliente no fue encontrado para eliminar");
                    return respuesta;
                }
            }
            catch (Exception e)
            {
                var error = req.CreateResponse(HttpStatusCode.InternalServerError);
                await error.WriteAsJsonAsync(e.Message);
                return error;
            }
        }
    }
}
