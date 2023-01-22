using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Ms.Pelicula.Api.Routes;
using Ms.Pelicula.Aplicacion.Pelicula.Read;
using System.Collections.Generic;
using dominio = Ms.Pelicula.Dominio.Entidades; 

namespace Alquiler_Peliculas.Controllers
{
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private PeliculaQueryAll db = new PeliculaQueryAll();

        [HttpGet(ApiRoutes.RoutePelicula.GetAll)]
        public IEnumerable<dominio.Pelicula> ListarPeliculas()
        {
            var listaPelicula = db.ListarPeliculas();
            return listaPelicula;
        }

        [HttpGet(ApiRoutes.RoutePelicula.GetById)]
        public dominio.Pelicula BuscarPelicula(int id)
        {
            var objPelicula = db.Coleccion().Find(x => x.IdPelicula == id).FirstOrDefault();
            return objPelicula;
        }

        [HttpPost(ApiRoutes.RoutePelicula.Create)]
        public ActionResult<dominio.Pelicula> CrearPelicula(dominio.Pelicula pelicula)
        {
            pelicula._id = ObjectId.GenerateNewId().ToString();
            db.Coleccion().InsertOne(pelicula);
            return Ok();
        }

        [HttpPut(ApiRoutes.RoutePelicula.Update)]
        public ActionResult<dominio.Pelicula> ModificarPelicula(dominio.Pelicula pelicula)
        {
            var objPelicula = db.Coleccion().Find(x => x.IdPelicula == pelicula.IdPelicula).FirstOrDefault();
            pelicula._id = objPelicula._id;
            db.Coleccion().FindOneAndReplace(x => x._id == pelicula._id, pelicula);
            return Ok();
        }

        [HttpDelete(ApiRoutes.RoutePelicula.Delete)]
        public ActionResult<dominio.Pelicula> EliminarPelicula(int id)
        {
            db.Coleccion().FindOneAndDelete(x => x.IdPelicula == id);
            return Ok(id);
        }
    }
}
