using Microsoft.AspNetCore.Mvc;
using Ms.Recarga.Aplicacion.Recarga;
using Serilog;
using System;
using System.Collections.Generic;
using static Ms.Recarga.Api.Routes.ApiRoutes;
using dominio = Ms.Recarga.Dominio.Entidades;


namespace Ms.Recarga.Api.Controllers
{
    [ApiController]
    public class RecargaController : ControllerBase
    {
        private readonly IRecargaService _service;

        public RecargaController(IRecargaService service)
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

        [HttpGet(RouteRecarga.GetAll)]
        public IEnumerable<dominio.Recarga> ListarRecargas()
        {
            try
            {
                var listaRecarga = _service.ListarRecargas();
                return listaRecarga;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }

            return null;
        }

        [HttpGet(RouteRecarga.GetById)]
        public dominio.Recarga BuscarRecarga(int id)
        {
            try
            {
                var objRecarga = _service.BuscarRecarga(id);
                return objRecarga;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }

            return null;
        }

        [HttpPost(RouteRecarga.Create)]
        public ActionResult<dominio.Recarga> CrearRecarga(dominio.Recarga recarga)
        {
            try
            {
                _service.RegistrarRecarga(recarga);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }

            return null;
        }

        [HttpPut(RouteRecarga.Update)]
        public ActionResult<dominio.Recarga> ModificarRecarga(dominio.Recarga recarga)
        {
            try
            {
                _service.ModificarRecarga(recarga);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        [HttpDelete(RouteRecarga.Delete)]
        public ActionResult<dominio.Recarga> EliminarRecarga(int id)
        {
            try
            {
                _service.EliminarRecarga(id);
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
