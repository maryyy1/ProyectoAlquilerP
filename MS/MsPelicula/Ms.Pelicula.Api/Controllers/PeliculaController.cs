using Microsoft.AspNetCore.Mvc;
using Ms.Pelicula.Aplicacion.Pelicula;
using Serilog;
using System;
using System.Collections.Generic;
using static Ms.Pelicula.Api.Routes.ApiRoutes;
using dominio = Ms.Pelicula.Dominio.Entidades;

namespace Ms.Pelicula.Api.Controllers
{
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly IPeliculaService _service;

        public PeliculaController(IPeliculaService service)
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

        [HttpGet(RoutePelicula.GetAll)]
        public IEnumerable<dominio.Pelicula> ListarPeliculas()
        {
            try
            {
                var listaPelicula = _service.ListarPeliculas();
                return listaPelicula;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        [HttpGet(RoutePelicula.GetById)]
        public dominio.Pelicula BuscarPelicula(int id)
        {
            try
            {
                var objPelicula = _service.BuscarPelicula(id);
                return objPelicula;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        [HttpPost(RoutePelicula.Create)]
        public ActionResult<dominio.Pelicula> CrearPelicula(dominio.Pelicula pelicula)
        {
            try
            {
                _service.RegistrarPelicula(pelicula);

                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        [HttpPut(RoutePelicula.Update)]
        public ActionResult<dominio.Pelicula> ModificarPelicula(dominio.Pelicula pelicula)
        {
            try
            {
                _service.ModificarPelicula(pelicula);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        [HttpDelete(RoutePelicula.Delete)]
        public ActionResult<dominio.Pelicula> EliminarPelicula(int id)
        {
            try
            {
                _service.EliminarPelicula(id);
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
