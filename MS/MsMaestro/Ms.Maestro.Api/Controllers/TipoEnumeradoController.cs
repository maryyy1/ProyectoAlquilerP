﻿using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;
using MongoDB.Driver;
using dominio = Ms.Maestro.Dominio.Entidades;
using Ms.Maestro.Api.Routes;
using Ms.Maestro.Aplicacion.TipoEnumerado;
using static Ms.Maestro.Api.Routes.ApiRoutes;
using Ms.Maestro.Dominio.Entidades;
using System;
using Serilog;

namespace Ms.Tarjeta.Api.Controllers
{
    [ApiController]
    public class TipoEnumeradoController : ControllerBase
    {
        private readonly ITipoEnumeradoService _service;

        public TipoEnumeradoController(ITipoEnumeradoService service)
        {
            try
            {
                _service = service;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            
        }

        [HttpGet(RouteTipoEnumerado.GetAll)]
        public IEnumerable<dominio.TipoEnumerado> ListarTiposEnumerados()
        {
            try
            {
                var listaTipoEnumerado = _service.ListarTiposEnumerados();
                return listaTipoEnumerado;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        [HttpGet(RouteTipoEnumerado.GetById)]
        public dominio.TipoEnumerado BuscarTipoEnumerado(int id)
        {
            try
            {
                var objTipoEnumerado = _service.TipoEnumerado(id);
                return objTipoEnumerado;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        [HttpPost(RouteTipoEnumerado.Create)]
        public ActionResult<dominio.TipoEnumerado> CrearTipoEnumerado(dominio.TipoEnumerado tipoEnumerado)
        {
            try
            {
                _service.RegistrarTipoEnumerado(tipoEnumerado);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
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

        [HttpDelete(RouteTipoEnumerado.Delete)]
        public ActionResult<dominio.TipoEnumerado> EliminarTipoEnumerado(int id)
        {
            try
            {
                _service.Eliminar(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }
    }
}
