using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;
using MongoDB.Driver;
using dominio = Ms.Alquiler.Dominio.Entidades;
using Ms.Alquiler.Api.Routes;
using Ms.Alquiler.Aplicacion.DetalleAlquiler;
using static Ms.Alquiler.Api.Routes.ApiRoutes;
using Ms.Alquiler.Dominio.Entidades;
using System;

namespace Ms.Alquiler.Api.Controllers
{
    [ApiController]
    public class DetalleAlquilerController : ControllerBase
    {
        private readonly IDetalleAlquilerService _service;

        public DetalleAlquilerController(IDetalleAlquilerService service)
        {
            _service = service;
        }

        [HttpGet(RouteDetalleAlquiler.GetAll)]
        public IEnumerable<dominio.DetalleAlquiler> ListarDetallesAlquileres()
        {
            var listaDetalleAlquiler = _service.ListarDetallesAlquileres();
            return listaDetalleAlquiler;
        }

        [HttpGet(RouteDetalleAlquiler.GetById)]
        public dominio.DetalleAlquiler BuscarDetalleAlquiler(int id)
        {
            try
            {
                var objDetalleAlquiler = _service.DetalleAlquiler(id);
                return objDetalleAlquiler;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                Console.ReadKey();
            }
            return null;
        }

        [HttpPost(RouteDetalleAlquiler.Create)]
        public ActionResult<dominio.DetalleAlquiler> CrearDetalleAlquiler(dominio.DetalleAlquiler detalleAlquiler)
        {
            _service.RegistrarDetalleAlquiler(detalleAlquiler);
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

        [HttpDelete(RouteDetalleAlquiler.Delete)]
        public ActionResult<dominio.DetalleAlquiler> EliminarDetalleAlquiler(int id)
        {
            _service.Eliminar(id);
            return Ok(id);
        }
    }
}
