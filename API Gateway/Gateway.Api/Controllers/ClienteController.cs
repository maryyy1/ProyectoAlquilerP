using Microsoft.AspNetCore.Mvc;
using static Gateway.Api.Routes.ApiRoutes;
using System.Collections.Generic;
using Clientes = Gateway.Aplicacion.ClientesClient;
using Gateway.Aplicacion.ClientesClient;
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
        public ICollection<Clientes.Cliente> ListarPeliculas()
        {
            var listaCliente = _clientesClient.ApiV1ClienteAllAsync().Result;
            return listaCliente;
        }

        [HttpGet(RouteCliente.GetById)]
        public Clientes.Cliente BuscarCliente(int id)
        {
            try
            {
                var objCliente = _clientesClient.ApiV1ClienteAsync(id).Result;
                return objCliente;
            }
            catch (ApiException ex)
            {
                Log.Error("ApiException: " + ex);
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
                Log.Error("ApiException: " + ex);
            }
        }

        [HttpPut(RouteCliente.Update)]
        public void ModificarPelicula(Clientes.Cliente cliente)
        {
            try
            {
                _clientesClient.ApiV1ClienteUpdateAsync(cliente);
            }
            catch (ApiException ex)
            {
                Log.Error("ApiException: " + ex);
            }
        }

        [HttpDelete(RouteCliente.Delete)]
        public void EliminarCliente(int id)
        {
            try
            {
                _clientesClient.ApiV1ClienteDeleteAsync(id);
            }
            catch (ApiException ex)
            {
                Log.Error("ApiException: " + ex);
            }
        }
    }
}