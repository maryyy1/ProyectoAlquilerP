using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Ms.Pelicula.Api.Routes;
using Ms.Pelicula.Aplicacion.Pelicula;
using System.Collections.Generic;
using static Ms.Pelicula.Api.Routes.ApiRoutes;
using dominio = Ms.Pelicula.Dominio.Entidades;

namespace Ms.Pelicula.Api.Controllers
{
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        //private PeliculaQueryAll db = new PeliculaQueryAll();
        private readonly IPeliculaService _service;

        public PeliculaController(IPeliculaService service)
        {
            _service = service;
        }

        [HttpGet(RoutePelicula.GetAll)]
        public IEnumerable<dominio.Pelicula> ListarPeliculas()
        {
            var listaPelicula = _service.ListarPeliculas();
            return listaPelicula;
        }

        [HttpGet(RoutePelicula.GetById)]
        public dominio.Pelicula BuscarPelicula(int id)
        {
            var objPelicula = _service.Pelicula(id);
            return objPelicula;
        }

        [HttpPost(RoutePelicula.Create)]
        public ActionResult<dominio.Pelicula> CrearPelicula(dominio.Pelicula pelicula)
        {
            _service.RegistrarPelicula(pelicula);

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

        [HttpDelete(RoutePelicula.Delete)]
        public ActionResult<dominio.Pelicula> EliminarPelicula(int id)
        {
            _service.Eliminar(id);
            return Ok(id);
        }
    }
}
