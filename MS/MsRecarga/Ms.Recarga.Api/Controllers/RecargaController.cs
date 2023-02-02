using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Ms.Recarga.Api.Routes;
using Ms.Recarga.Aplicacion.Recarga;
using System.Collections.Generic;
using static Ms.Recarga.Api.Routes.ApiRoutes;
using dominio = Ms.Recarga.Dominio.Entidades;

namespace Ms.Recarga.Api.Controllers
{
    [ApiController]
    public class RecargaController : ControllerBase
    {
        //private PeliculaQueryAll db = new PeliculaQueryAll();
        private readonly IRecargaService _service;

        public RecargaController(IRecargaService service)
        {
            _service = service;
        }

        [HttpGet(RouteRecarga.GetAll)]
        public IEnumerable<dominio.Recarga> ListarRecargas()
        {
            var listaRecarga = _service.ListarRecargas();
            return listaRecarga;
        }

        [HttpGet(RouteRecarga.GetById)]
        public dominio.Recarga BuscarRecarga(int id)
        {
            var objRecarga = _service.Recarga(id);
            return objRecarga;
        }

        [HttpPost(RouteRecarga.Create)]
        public ActionResult<dominio.Recarga> CrearRecarga(dominio.Recarga recarga)
        {
            _service.RegistrarRecarga(recarga);

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

        [HttpDelete(RouteRecarga.Delete)]
        public ActionResult<dominio.Recarga> EliminarRecarga(int id)
        {
            _service.Eliminar(id);
            return Ok(id);
        }
    }
}
