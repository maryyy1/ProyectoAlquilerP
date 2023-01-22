
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Ms.Pelicula.Aplicacion.Director.Read;
using System.Collections.Generic;
using dominio = Ms.Pelicula.Dominio.Entidades;

namespace Ms.Pelicula.Api.Controllers
{
    [ApiController]    
        [HttpGet(ApiRoutes.RouteDirector.GetAll)]
    public class DirectorController : ControllerBase
    {
        private DirectorQueryAll db = new DirectorQueryAll();   
        [HttpGet(RouteDirector.GetAll)]
        public IEnumerable<dominio.Director> ListarDirector()
        {
            var listaDirector = db.ListarDirectores();
            return listaDirector;
        }
            var objDirector = db.Coleccion().Find(x => x.IdDirector == id).FirstOrDefault();
            #endregion

            var objDirector = collection.Find(x => x.IdDirector == id).FirstOrDefault();

            return objDirector;
        }

            db.Coleccion().InsertOne(director);
        {
            director._id = ObjectId.GenerateNewId().ToString();
            collection.InsertOne(director);

            return Ok();
        }
            var objDirector = db.Coleccion().Find(x => x.IdDirector == director.IdDirector).FirstOrDefault();
            director._id = objDirector._id;
            db.Coleccion().FindOneAndReplace(x => x._id == director._id, director);
            #endregion

            collection.FindOneAndReplace(x => x._id == director._id, director);

            return Ok();
        }
            db.Coleccion().FindOneAndDelete(x => x.IdDirector == id);
            #endregion

            collection.FindOneAndDelete(x => x.IdDirector == id);

            return Ok(id);
        }
    }
}
