using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Ms.Cliente.Api.Routes;
using Ms.Cliente.Aplicacion.Cliente;
using Serilog;
using System;
using System.Collections.Generic;
using static Ms.Cliente.Api.Routes.ApiRoutes;
using dominio = Ms.Cliente.Dominio.Entidades;

namespace Ms.Cliente.Api.Controllers
{
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            try
            {
                _service = service;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            
        }

        [HttpGet(RouteCliente.GetAll)]
        public IEnumerable<dominio.Cliente> ListarClientes()
        {
            try
            {
                var listaCliente = _service.ListarClientes();
                return listaCliente;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        [HttpGet(RouteCliente.GetById)]
        public dominio.Cliente BuscarCliente(int id)
        {
            try
            {
                var objCliente = _service.BuscarCliente(id);
                return objCliente;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        [HttpPost(RouteCliente.Create)]
        public ActionResult<dominio.Cliente> CrearCliente(dominio.Cliente cliente)
        {
            try
            {
                _service.RegistrarCliente(cliente);

                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        [HttpPut(RouteCliente.Update)]
        public ActionResult<dominio.Cliente> ModificarCliente(dominio.Cliente cliente)
        {
            try
            {
                _service.ModificarCliente(cliente);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        [HttpDelete(RouteCliente.Delete)]
        public ActionResult<dominio.Cliente> EliminarCliente(int id)
        {
            try
            {
                _service.EliminarCliente(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }
    }
}
