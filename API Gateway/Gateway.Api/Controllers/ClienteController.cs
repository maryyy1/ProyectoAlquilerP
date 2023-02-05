using Microsoft.AspNetCore.Mvc;
using static Gateway.Api.Routes.ApiRoutes;
using System.Collections.Generic;
using Clientes = Gateway.Aplicacion.ClientesClient;
using Gateway.Aplicacion.ClientesClient;
using System.Threading.Tasks;
using Serilog;
using System;

namespace Gateway.Api.Controllers
{
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly Clientes.IClient _clientesClient;

        public ClienteController(Clientes.IClient clientesClient)
        {
            _clientesClient = clientesClient;
        }

        [HttpGet(RouteCliente.GetAll)]
        public Task<ICollection<Clientes.Cliente>> ListarPeliculas()
        {
            var listaCliente = _clientesClient.ApiV1ClienteAllAsync();
            return listaCliente;
        }

        [HttpGet(RouteCliente.GetById)]
        public Task<Clientes.Cliente> BuscarCliente(int id)
        {
            try
            {
                var objCliente = _clientesClient.ApiV1ClienteAsync(id);
                return objCliente;
            }
            catch (ApiException ex)
            {
                Log.Error("Exception: " + ex);
            }

            return null;
        }


        [HttpPost(RouteCliente.Create)]
        public void CrearCliente(Clientes.Cliente cliente)
        {
            try
            {
                _clientesClient.ApiV1ClienteCreateAsync(cliente);
            }
            catch (ApiException ex)
            {
                Log.Error("Exception: " + ex);
            }
        }

        [HttpPut(RouteCliente.Update)]
        public void ModificarPelicula(Clientes.Cliente cliente)
        {
            try
            {
                _clientesClient.ApiV1ClienteUpdateAsync(cliente);
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
        }

        [HttpDelete(RouteCliente.Delete)]
        public void EliminarCliente(int id)
        {
            try
            {
                _clientesClient.ApiV1ClienteDeleteAsync(id);
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
        }
    }
}