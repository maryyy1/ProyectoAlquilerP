using Microsoft.AspNetCore.Mvc;
using Ms.Alquiler.Aplicacion.Alquiler;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using static Ms.Alquiler.Api.Routes.ApiRoutes;
using dominio = Ms.Alquiler.Dominio.Entidades;

namespace Ms.Alquiler.Api.Controllers
{
    [ApiController]
    public class AlquilerController : ControllerBase
    {
        private readonly IAlquilerService _service;

        public AlquilerController(IAlquilerService service)
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

        [HttpGet(RouteAlquiler.GetAll)]
        public IEnumerable<dominio.Alquiler> ListarAlquileres()
        {
            try
            {
                var listaAlquiler = _service.ListarAlquileres();
                return listaAlquiler;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        [HttpGet(RouteAlquiler.GetById)]
        public dominio.Alquiler BuscarAlquiler(int id)
        {
            try
            {
                var objAlquiler = _service.BuscarAlquiler(id);
                return objAlquiler;
            }
            catch (Exception ex) 
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        [HttpPost(RouteAlquiler.Create)]
        public void CrearAlquiler(dominio.Alquiler alquiler)
        {
            try
            {
                _service.RegistrarAlquiler(alquiler);

                //return Ok();
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            //return null;;
        }

        [HttpPut(RouteAlquiler.Update)]
        public ActionResult<dominio.Alquiler> ModificarAlquiler(dominio.Alquiler alquiler)
        {
            try
            {
                _service.ModificarAlquiler(alquiler);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        [HttpDelete(RouteAlquiler.Delete)]
        public ActionResult<dominio.Alquiler> EliminarAlquiler(int id)
        {
            try
            {
                _service.EliminarAlquiler(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null ;
        }

    }
}
