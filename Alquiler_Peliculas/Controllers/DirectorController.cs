using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Ms.Pelicula.Api.Routes;
using Ms.Pelicula.Aplicacion.Director.Read;
using System.Collections.Generic;
using static Ms.Pelicula.Api.Routes.ApiRoutes;
using dominio = Ms.Pelicula.Dominio.Entidades;

namespace Ms.Pelicula.Api.Controllers
{
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private DirectorQueryAll db = new DirectorQueryAll();   

        [HttpGet(RouteDirector.GetAll)]
        public IEnumerable<dominio.Director> ListarDirector()
        {
            var listaDirector = db.ListarDirectores();
            return listaDirector;
        }

        [HttpGet(RouteDirector.GetById)]
        public dominio.Director BuscarDirector(int id)
        {
            var objDirector = db.Coleccion().Find(x => x.IdDirector == id).FirstOrDefault();

            return objDirector;
        }

        [HttpPost(RouteDirector.Create)]
        public ActionResult<dominio.Director> CrearDirector(dominio.Director director)
        {
            director._id = ObjectId.GenerateNewId().ToString();
            db.Coleccion().InsertOne(director);

            return Ok();
        }

        [HttpPut(RouteDirector.Update)]
        public ActionResult<dominio.Director> ModificarDirector(dominio.Director director)
        {
            db.Coleccion().FindOneAndReplace(x => x._id == director._id, director);

            return Ok();
        }

        [HttpDelete(RouteDirector.Delete)]
        public ActionResult<dominio.Director> EliminarDirector(int id)
        {
            db.Coleccion().FindOneAndDelete(x => x.IdDirector == id);

            return Ok(id);
        }
    }
}
