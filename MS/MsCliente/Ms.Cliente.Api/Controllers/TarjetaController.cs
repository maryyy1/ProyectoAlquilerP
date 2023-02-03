using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;
using MongoDB.Driver;
using dominio = Ms.Cliente.Dominio.Entidades;
using Ms.Cliente.Api.Routes;
using Ms.Cliente.Aplicacion.Tarjeta;
using static Ms.Cliente.Api.Routes.ApiRoutes;
using Ms.Cliente.Dominio.Entidades;
using System;

namespace Ms.Tarjeta.Api.Controllers
{
    [ApiController]
    public class TarjetaController : ControllerBase
    {
        private readonly ITarjetaService _service;

        public TarjetaController(ITarjetaService service)
        {
            _service = service;
        }

        [HttpGet(RouteTarjeta.GetAll)]
        public IEnumerable<dominio.Tarjeta> ListarTarjetas()
        {
            var listaTarjeta = _service.ListarTarjetas();
            return listaTarjeta;
        }

        [HttpGet(RouteTarjeta.GetById)]
        public dominio.Tarjeta BuscarTarjeta(int id)
        {
            try
            {
                var objTarjeta = _service.Tarjeta(id);
                return objTarjeta;
            }
            catch (Exception ex)
            { 
            
            }
            return null;
        }

        [HttpPost(RouteTarjeta.Create)]
        public ActionResult<dominio.Tarjeta> CrearTarjeta(dominio.Tarjeta tarjeta)
        {
            _service.RegistrarTarjeta(tarjeta);
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

        [HttpDelete(RouteTarjeta.Delete)]
        public ActionResult<dominio.Tarjeta> EliminarTarjeta(int id)
        {
            _service.Eliminar(id);
            return Ok(id);
        }
    }
}
