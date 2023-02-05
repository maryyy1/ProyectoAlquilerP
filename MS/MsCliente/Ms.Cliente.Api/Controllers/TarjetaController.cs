using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Ms.Cliente.Api.Routes;
using Ms.Cliente.Aplicacion.Tarjeta;
using Serilog;
using System;
using System.Collections.Generic;
using static Ms.Cliente.Api.Routes.ApiRoutes;
using dominio = Ms.Cliente.Dominio.Entidades;

namespace Ms.Cliente.Api.Controllers
{
    [ApiController]
    public class TarjetaController : ControllerBase
    {
        private readonly ITarjetaService _service;

        public TarjetaController(ITarjetaService service)
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

        [HttpGet(RouteTarjeta.GetAll)]
        public IEnumerable<dominio.Tarjeta> ListarTarjetas()
        {
            try
            {
                var listaTarjeta = _service.ListarTarjetas();
                return listaTarjeta;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        [HttpGet(RouteTarjeta.GetById)]
        public dominio.Tarjeta BuscarTarjeta(int id)
        {
            try
            {
                var objTarjeta = _service.BuscarTarjeta(id);
                return objTarjeta;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        [HttpPost(RouteTarjeta.Create)]
        public ActionResult<dominio.Tarjeta> CrearTarjeta(dominio.Tarjeta tarjeta)
        {
            try
            {
                _service.RegistrarTarjeta(tarjeta);

                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        [HttpPut(RouteTarjeta.Update)]
        public ActionResult<dominio.Tarjeta> ModificarTarjeta(dominio.Tarjeta tarjeta)
        {
            try
            {
                _service.ModificarTarjeta(tarjeta);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        [HttpDelete(RouteTarjeta.Delete)]
        public ActionResult<dominio.Tarjeta> EliminarTarjeta(int id)
        {
            try
            {
                _service.EliminarTarjeta(id);
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
