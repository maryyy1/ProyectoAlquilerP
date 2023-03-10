using Gateway.Aplicacion.ClientesClient;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using static Gateway.Api.Routes.ApiRoutes;
using Clientes = Gateway.Aplicacion.ClientesClient;

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
            try
            {
                var listaCliente = _clientesClient.ApiV1ClienteAllAsync().Result;
                return listaCliente;
            }
            catch (ApiException ex)
            {
                Log.Error("ApiException: " + ex);
            }
            catch (AggregateException ex)
            {
                Log.Error("AggregateException: " + ex);
            }

            return null;
        }

        [HttpGet(RouteCliente.GetById)]
        public Clientes.Cliente BuscarCliente(int id)
        {
            try
            {
                var objCliente = _clientesClient.ApiV1ClienteSearchAsync(id).Result;
                return objCliente;
            }
            catch (ApiException ex)
            {
                Log.Error("ApiException: " + ex);
            }
            catch (AggregateException ex)
            {
                Log.Error("AggregateException: " + ex);
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