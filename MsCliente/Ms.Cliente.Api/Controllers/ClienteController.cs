﻿using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Ms.Cliente.Aplicacion.Cliente.Read;
using System.Collections.Generic;
using MongoDB.Driver;
using dominio = Ms.Cliente.Dominio.Entidades;
using Ms.Cliente.Api.Routes;

namespace Ms.Cliente.Api.Controllers
{
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private ClienteQueryAll dqa = new ClienteQueryAll();

        [HttpGet(ApiRoutes.RouteCliente.GetAll)]
        public IEnumerable<dominio.Cliente> ListarClientes()
        {
            var listaCliente = dqa.ListarClientes();
            return listaCliente;
        }

        [HttpGet(ApiRoutes.RouteCliente.GetById)]
        public dominio.Cliente BuscarCliente(int id)
        {
            var objCliente = dqa.Coleccion().Find(x => x.IdCliente == id).FirstOrDefault();
            return objCliente;
        }

        [HttpPost(ApiRoutes.RouteCliente.Create)]
        public ActionResult<dominio.Cliente> CrearCliente(dominio.Cliente cliente)
        {
            cliente._id = ObjectId.GenerateNewId().ToString();
            dqa.Coleccion().InsertOne(cliente);
            return Ok();
        }

        [HttpPut(ApiRoutes.RouteCliente.Update)]
        public ActionResult<dominio.Cliente> ModificarCliente(dominio.Cliente cliente)
        {
            var objCliente = dqa.Coleccion().Find(x => x.IdCliente == cliente.IdCliente).FirstOrDefault();
            cliente._id = objCliente._id;
            dqa.Coleccion().FindOneAndReplace(x => x._id == cliente._id, cliente);
            return Ok();
        }

        [HttpDelete(ApiRoutes.RouteCliente.Delete)]
        public ActionResult<dominio.Cliente> EliminarCliente(int id)
        {
            dqa.Coleccion().FindOneAndDelete(x => x.IdCliente == id);
            return Ok(id);
        }
    }
}