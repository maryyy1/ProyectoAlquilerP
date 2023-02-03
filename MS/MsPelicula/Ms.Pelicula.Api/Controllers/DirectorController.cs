using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Ms.Pelicula.Aplicacion.Director;
using static Ms.Pelicula.Api.Routes.ApiRoutes;
using System.Collections.Generic;
using dominio = Ms.Pelicula.Dominio.Entidades;
using Ms.Pelicula.Api.Routes;

namespace Ms.Pelicula.Api.Controllers
{
    [ApiController]    
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorService _service;

        public DirectorController(IDirectorService service)
        {
            _service = service;
        }

        [HttpGet(RouteDirector.GetAll)]
        public IEnumerable<dominio.Director> ListarDirectores()
        {
            var listaDirector = _service.ListarDirectores();
            return listaDirector;
        }

        [HttpGet(RouteDirector.GetById)]
        public dominio.Director BuscarDirector(int id)
        {
            var objDirector = _service.BuscarDirector(id);
            return objDirector;
        }

        [HttpPost(RouteDirector.Create)]
        public ActionResult<dominio.Director> CrearDirector([FromBody] dominio.Director director)
        {
            _service.RegistrarDirector(director);
            return Ok();
        }

        //[HttpPut(RouteCategoria.Update)]
        //public ActionResult<dominio.Categoria> ModificarCategoria(dominio.Categoria producto)
        //{
        //    #region Conexión a base de datos
        //    var client = new MongoClient("mongodb://localhost:27017");
        //    var database = client.GetDatabase("TDB_productos");
        //    var collection = database.GetCollection<dominio.Categoria>("producto");
        //    #endregion

        //    collection.FindOneAndReplace(x => x._id == producto._id, producto);

        //    //var oldCategoria = collection.Find(x => x.IdCategoria == producto.IdCategoria).FirstOrDefault();
        //    //oldCategoria.Nombre = producto.Nombre;
        //    //oldCategoria.Precio = producto.Precio;
        //    //oldCategoria.Cantidad = producto.Cantidad;
        //    //collection.ReplaceOne(x=>x.IdCategoria == oldCategoria.IdCategoria, oldCategoria);


        //    //Categoria productoModificado = listaCategoria.Single(x => x.IdCategoria == producto.IdCategoria);
        //    //productoModificado.Nombre = producto.Nombre;
        //    //productoModificado.Cantidad = producto.Cantidad;
        //    //productoModificado.Precio= producto.Precio;
        //    //return CreatedAtAction("ModificarCategoria", productoModificado);
        //    return Ok();
        //}

        [HttpDelete(RouteDirector.Delete)]
        public ActionResult<dominio.Director> EliminarDirector(int id)
        {
            _service.EliminarDirector(id);
            return Ok(id);
        }
    }
}
