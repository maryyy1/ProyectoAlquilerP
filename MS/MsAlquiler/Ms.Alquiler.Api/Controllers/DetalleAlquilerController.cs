using Microsoft.AspNetCore.Mvc;
using Ms.Alquiler.Aplicacion.DetalleAlquiler;
using Serilog;
using System;
using System.Collections.Generic;
using static Ms.Alquiler.Api.Routes.ApiRoutes;
using dominio = Ms.Alquiler.Dominio.Entidades;

namespace Ms.Alquiler.Api.Controllers
{
    [ApiController]
    public class DetalleAlquilerController : ControllerBase
    {
        private readonly IDetalleAlquilerService _service;

        public DetalleAlquilerController(IDetalleAlquilerService service)
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

        [HttpGet(RouteDetalleAlquiler.GetAll)]
        public IEnumerable<dominio.DetalleAlquiler> ListarDetallesAlquileres()
        {
            try
            {
                var listaDetalleAlquiler = _service.ListarDetallesAlquileres();
                return listaDetalleAlquiler;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        [HttpGet(RouteDetalleAlquiler.GetById)]
        public dominio.DetalleAlquiler BuscarDetalleAlquiler(int id)
        {
            try
            {
                var objDetalleAlquiler = _service.BuscarDetalleAlquiler(id);
                return objDetalleAlquiler;

            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        [HttpPost(RouteDetalleAlquiler.Create)]
        public ActionResult<dominio.DetalleAlquiler> CrearDetalleAlquiler(dominio.DetalleAlquiler detalleAlquiler)
        {
            try
            {
                _service.RegistrarDetalleAlquiler(detalleAlquiler);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        [HttpPut(RouteDetalleAlquiler.Update)]
        public ActionResult<dominio.Alquiler> ModificarDetalleAlquiler(dominio.DetalleAlquiler detalleAlquiler)
        {
            try
            {
                _service.ModificarDetalleAlquiler(detalleAlquiler);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        [HttpDelete(RouteDetalleAlquiler.Delete)]
        public ActionResult<dominio.DetalleAlquiler> EliminarDetalleAlquiler(int id)
        {
            try
            {
                _service.EliminarDetalleAlquiler(id);
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
