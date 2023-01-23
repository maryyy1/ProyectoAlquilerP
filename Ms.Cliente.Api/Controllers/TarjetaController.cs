using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;
using MongoDB.Driver;
using dominio = Ms.Cliente.Dominio.Entidades;
using Ms.Cliente.Api.Routes;
using Ms.Cliente.Aplicacion.Tarjeta.Read;

namespace Ms.Cliente.Api.Controllers
{
    [ApiController]
    public class TarjetaController : ControllerBase
    {
        private TarjetaQueryAll tqa = new TarjetaQueryAll();

        [HttpGet(ApiRoutes.RouteTarjeta.GetAll)]
        public IEnumerable<dominio.Tarjeta> ListarTarjetas()
        {
            var listaTarjeta = tqa.ListarTarjetas();
            return listaTarjeta;
        }

        [HttpGet(ApiRoutes.RouteTarjeta.GetById)]
        public dominio.Tarjeta BuscarTarjeta(int id)
        {
            var objTarjeta = tqa.Coleccion().Find(x => x.IdTarjeta == id).FirstOrDefault();
            return objTarjeta;
        }

        [HttpPost(ApiRoutes.RouteTarjeta.Create)]
        public ActionResult<dominio.Tarjeta> CrearTarjeta(dominio.Tarjeta tarjeta)
        {
            tarjeta._id = ObjectId.GenerateNewId().ToString();
            tqa.Coleccion().InsertOne(tarjeta);
            return Ok();
        }

        [HttpPut(ApiRoutes.RouteTarjeta.Update)]
        public ActionResult<dominio.Tarjeta> ModificarTarjeta(dominio.Tarjeta tarjeta)
        {
            var objTarjeta = tqa.Coleccion().Find(x => x.IdTarjeta == tarjeta.IdTarjeta).FirstOrDefault();
            tarjeta._id = objTarjeta._id;
            tqa.Coleccion().FindOneAndReplace(x => x._id == tarjeta._id, tarjeta);
            return Ok();
        }

        [HttpDelete(ApiRoutes.RouteTarjeta.Delete)]
        public ActionResult<dominio.Tarjeta> EliminarTarjeta(int id)
        {
            tqa.Coleccion().FindOneAndDelete(x => x.IdTarjeta== id);
            return Ok(id);
        }
    }
}
