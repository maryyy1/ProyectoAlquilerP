using Microsoft.AspNetCore.Mvc;
using Ms.Alquiler.Aplicacion.Alquiler;
using System.Collections.Generic;
using static Ms.Alquiler.Api.Routes.ApiRoutes;
using dominio = Ms.Alquiler.Dominio.Entidades;

namespace Ms.Alquiler.Api.Controllers
{
    [ApiController]
    public class AlquilerController : ControllerBase
    {
        private readonly IAlquilerService _service;

        public AlquilerController(IAlquilerService service)
        {
            _service = service;
        }

        [HttpGet(RouteAlquiler.GetAll)]
        public IEnumerable<dominio.Alquiler> ListarAlquileres()
        {
            var listaAlquiler = _service.ListarAlquileres();
            return listaAlquiler;
        }

        [HttpGet(RouteAlquiler.GetById)]
        public dominio.Alquiler BuscarAlquiler(int id)
        {
            var objAlquiler = _service.Alquiler(id);
            return objAlquiler;
        }

        [HttpPost(RouteAlquiler.Create)]
        public ActionResult<dominio.Alquiler> CrearAlquiler(dominio.Alquiler alquiler)
        {
            _service.RegistrarAlquiler(alquiler);

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

        [HttpDelete(RouteAlquiler.Delete)]
        public ActionResult<dominio.Alquiler> EliminarAlquiler(int id)
        {
            _service.Eliminar(id);
            return Ok(id);
        }
    }
}
