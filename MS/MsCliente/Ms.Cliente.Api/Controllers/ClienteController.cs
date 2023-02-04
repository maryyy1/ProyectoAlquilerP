using Microsoft.AspNetCore.Mvc;
using Ms.Cliente.Aplicacion.Cliente;
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
            _service = service;
        }

        [HttpGet(RouteCliente.GetAll)]
        public IEnumerable<dominio.Cliente> ListarClientes()
        {
            var listaCliente = _service.ListarClientes();
            return listaCliente ;
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
                Console.WriteLine("Error: " + ex);
                Console.ReadKey();
            }
            return null;
        }

        [HttpPost(RouteCliente.Create)]
        public ActionResult<dominio.Cliente> CrearCliente(dominio.Cliente cliente)
        {
            _service.RegistrarCliente(cliente);

            return Ok();
        }

        //[HttpPut(RouteProducto.Update)]
        //public ActionResult<dominio.Producto> ModificarProducto(dominio.Producto producto)
        //{
        //    #region Conexión a base de datos
        //    var client = new MongoClient("mongodb://localhost:27017");
        //    var database = client.GetDatabase("TDB_productos");
        //    var collection = database.GetCollection<dominio.Producto>("producto");
        //    #endregion

        //    collection.FindOneAndReplace(x => x._id == producto._id, producto);

        //    //var oldProducto = collection.Find(x => x.IdProducto == producto.IdProducto).FirstOrDefault();
        //    //oldProducto.Nombre = producto.Nombre;
        //    //oldProducto.Precio = producto.Precio;
        //    //oldProducto.Cantidad = producto.Cantidad;
        //    //collection.ReplaceOne(x=>x.IdProducto == oldProducto.IdProducto, oldProducto);


        //    //Producto productoModificado = listaProducto.Single(x => x.IdProducto == producto.IdProducto);
        //    //productoModificado.Nombre = producto.Nombre;
        //    //productoModificado.Cantidad = producto.Cantidad;
        //    //productoModificado.Precio= producto.Precio;
        //    //return CreatedAtAction("ModificarProducto", productoModificado);
        //    return Ok();
        //}

        [HttpDelete(RouteCliente.Delete)]
        public ActionResult<dominio.Cliente> EliminarCliente(int id)
        {
            _service.EliminarCliente(id);
            return Ok(id);
        }
    }
}
