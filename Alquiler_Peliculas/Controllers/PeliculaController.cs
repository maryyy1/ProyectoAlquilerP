using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Ms.Pelicula.Aplicacion.Pelicula.Read;
using System.Collections.Generic;
using static Ms.Pelicula.Api.Routes.ApiRoutes;
using dominio = Ms.Pelicula.Dominio.Entidades; 

namespace Alquiler_Peliculas.Controllers
{
    [ApiController]
    [Route("Pelicula")]
    public class PeliculaController : ControllerBase
    {
        private PeliculaQueryAll db = new PeliculaQueryAll();

        [HttpGet(RoutePelicula.GetAll)]
        public IEnumerable<dominio.Pelicula> ListarPeliculas()
        {
            var listaPelicula = db.ListarPeliculas();
            return listaPelicula;
        }

        [HttpGet(RoutePelicula.GetById)]
        public dominio.Pelicula BuscarPelicula(int id)
        {
            #region Conexión a base de datos
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("DB_Pelicula");
            var collection = database.GetCollection<dominio.Pelicula>("Pelicula");
            #endregion

            var objPelicula = collection.Find(x => x.IdPelicula == id).FirstOrDefault();

            return objPelicula;
        }

        [HttpPost(RoutePelicula.Create)]
        public ActionResult<dominio.Pelicula> CrearPelicula(dominio.Pelicula pelicula)
        {
            #region Conexión a base de datos
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("DB_Pelicula");
            var collection = database.GetCollection<dominio.Pelicula>("Pelicula");
            #endregion

            pelicula._id = ObjectId.GenerateNewId().ToString();
            collection.InsertOne(pelicula);

            return Ok();
        }

        [HttpPut(RoutePelicula.Update)]
        public ActionResult<dominio.Pelicula> ModificarPelicula(dominio.Pelicula pelicula)
        {
            #region Conexión a base de datos
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("DB_Pelicula");
            var collection = database.GetCollection<dominio.Pelicula>("Pelicula");
            #endregion

            collection.FindOneAndReplace(x => x._id == pelicula._id, pelicula);

            return Ok();
        }

        [HttpDelete(RoutePelicula.Delete)]
        public ActionResult<dominio.Pelicula> EliminarPelicula(int id)
        {
            #region Conexión a base de datos
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("DB_Pelicula");
            var collection = database.GetCollection<dominio.Pelicula>("Pelicula");
            #endregion

            collection.FindOneAndDelete(x => x.IdPelicula == id);

            return Ok(id);
        }
    }
}
