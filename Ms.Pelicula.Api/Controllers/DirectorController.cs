using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Ms.Pelicula.Aplicacion.Director.Read;
using System.Collections.Generic;
using dominio = Ms.Pelicula.Dominio.Entidades;
using Ms.Pelicula.Api.Routes;

namespace Ms.Pelicula.Api.Controllers
{
    [ApiController]    
    public class DirectorController : ControllerBase
    {
        private DirectorQueryAll db = new DirectorQueryAll();
        
        [HttpGet(ApiRoutes.RouteDirector.GetAll)]
        public IEnumerable<dominio.Director> ListarDirector()
        {
            var listaDirector = db.ListarDirectores();
            return listaDirector;
        }

        [HttpGet(ApiRoutes.RouteDirector.GetById)]
        public dominio.Director BuscarDirector(int id)
        {
            var objDirector = db.Coleccion().Find(x => x.IdDirector == id).FirstOrDefault();
            return objDirector;
        }

        [HttpPost(ApiRoutes.RouteDirector.Create)]
        public ActionResult<dominio.Director> CrearDirector(dominio.Director director)
        {
            director._id = ObjectId.GenerateNewId().ToString();
            db.Coleccion().InsertOne(director);
            return Ok();
        }

        [HttpPut(ApiRoutes.RouteDirector.Update)]
        public ActionResult<dominio.Director> ModificarDirector(dominio.Director director)
        {
            var objDirector = db.Coleccion().Find(x => x.IdDirector == director.IdDirector).FirstOrDefault();
            director._id = objDirector._id;
            db.Coleccion().FindOneAndReplace(x => x._id == director._id, director);
            return Ok();
        }

        [HttpDelete(ApiRoutes.RouteDirector.Delete)]
        public ActionResult<dominio.Director> EliminarDirector(int id)
        {
            db.Coleccion().FindOneAndDelete(x => x.IdDirector == id);
            return Ok(id);
        }
    }
}
