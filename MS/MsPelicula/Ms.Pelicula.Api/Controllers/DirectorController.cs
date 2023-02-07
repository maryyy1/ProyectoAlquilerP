using Microsoft.AspNetCore.Mvc;
using Ms.Pelicula.Aplicacion.Director;
using Serilog;
using System;
using System.Collections.Generic;
using static Ms.Pelicula.Api.Routes.ApiRoutes;
using dominio = Ms.Pelicula.Dominio.Entidades;

namespace Ms.Pelicula.Api.Controllers
{
    [ApiController]    
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorService _service;

        public DirectorController(IDirectorService service)
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

        [HttpGet(RouteDirector.GetAll)]
        public IEnumerable<dominio.Director> ListarDirectores()
        {
            try
            {
                var listaDirector = _service.ListarDirectores();
                return listaDirector;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        [HttpGet(RouteDirector.GetById)]
        public dominio.Director BuscarDirector(int id)
        {
            try
            {
                var objDirector = _service.BuscarDirector(id);
                return objDirector;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        [HttpPost(RouteDirector.Create)]
        public ActionResult<dominio.Director> CrearDirector([FromBody] dominio.Director director)
        {
            try
            {
                _service.RegistrarDirector(director);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        [HttpPut(RouteDirector.Update)]
        public ActionResult<dominio.Director> ModificarDirector(dominio.Director director)
        {
            try
            {
                _service.ModificarDirector(director);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        [HttpDelete(RouteDirector.Delete)]
        public ActionResult<dominio.Director> EliminarDirector(int id)
        {
            try
            {
                _service.EliminarDirector(id);
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
