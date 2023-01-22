using Microsoft.AspNetCore.Mvc;
using Ms.Pelicula.Aplicacion.Director.Read;
using dominio = Ms.Pelicula.Dominio.Entidades;
using Ms.Pelicula.Api.Routes;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Ms.Pelicula.Api.Controllers
{
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private DirectorQueryAll dqa = new DirectorQueryAll();

        [HttpGet(ApiRoutes.RouteDirector.GetAll)]
        public IEnumerable<dominio.Director> ListarDirectores()
        {
            var listaDirector = dqa.ListarDirectores(); 
            return listaDirector;
        }

        [HttpGet(ApiRoutes.RouteDirector.GetById)]
        public dominio.Director BuscarDirector(int id)
        {
            var objDirector = dqa.Coleccion().Find(x => x.IdDirector == id).FirstOrDefault();
            return objDirector;
        }

        [HttpPost(ApiRoutes.RouteDirector.Create)]
        public ActionResult<dominio.Director> CrearDirector(dominio.Director director)
        {
            director._id = ObjectId.GenerateNewId().ToString();
            dqa.Coleccion().InsertOne(director);
            return Ok();
        }

        [HttpPut(ApiRoutes.RouteDirector.Update)]
        public ActionResult<dominio.Director> ModificarDirector(dominio.Director director)
        {
            var objDirector = dqa.Coleccion().Find(x => x.IdDirector == director.IdDirector).FirstOrDefault();
            director._id = objDirector._id;
            dqa.Coleccion().FindOneAndReplace(x => x._id == director._id, director);
            return Ok();
        }

        [HttpDelete(ApiRoutes.RouteDirector.Delete)]
        public ActionResult<dominio.Director> EliminarDirector(int id)
        {
            dqa.Coleccion().FindOneAndDelete(x => x.IdDirector == id);
            return Ok(id);
        }
    }
}
