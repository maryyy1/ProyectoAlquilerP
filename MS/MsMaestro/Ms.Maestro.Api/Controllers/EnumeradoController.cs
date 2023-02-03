using Microsoft.AspNetCore.Mvc;
using Ms.Maestro.Aplicacion.Enumerado;
using System;
using System.Collections.Generic;
using static Ms.Maestro.Api.Routes.ApiRoutes;
using dominio = Ms.Maestro.Dominio.Entidades;

namespace Ms.Maestro.Api.Controllers
{
    [ApiController]
    public class EnumeradoController : ControllerBase
    {
        private readonly IEnumeradoService _service;

        public EnumeradoController(IEnumeradoService service)
        {
            _service = service;
        }

        [HttpGet(RouteEnumerado.GetAll)]
        public IEnumerable<dominio.Enumerado> ListarEnumerados()
        {
            var listaEnumerado = _service.ListarEnumerados();
            return listaEnumerado;
        }

        [HttpGet(RouteEnumerado.GetById)]
        public dominio.Enumerado BuscarEnumerado(int id)
        {
            try
            {
                var objEnumerado = _service.Enumerado(id);
                return objEnumerado;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                Console.ReadKey();
            }
            return null;
        }

        [HttpPost(RouteEnumerado.Create)]
        public ActionResult<dominio.Enumerado> CrearEnumerado(dominio.Enumerado enumerado)
        {
            _service.RegistrarEnumerado(enumerado);

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

        [HttpDelete(RouteEnumerado.Delete)]
        public ActionResult<dominio.Enumerado> EliminarEnumerado(int id)
        {
            _service.Eliminar(id);
            return Ok(id);
        }
    }
}
