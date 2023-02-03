using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Ms.Pelicula.Api.Routes;
using Ms.Pelicula.Aplicacion.Pelicula;
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
            _service = service;
        }

        [HttpGet(RoutePelicula.GetAll)]
        public IEnumerable<dominio.Pelicula> ListarPeliculas()
        {
            var listaPelicula = _service.ListarPeliculas();
            return listaPelicula;
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
                Console.WriteLine("Error: " + ex);
                Console.ReadKey();
            }
            return null;
        }

        [HttpPost(RoutePelicula.Create)]
        public ActionResult<dominio.Pelicula> CrearPelicula(dominio.Pelicula pelicula)
        {
            _service.RegistrarPelicula(pelicula);

            return Ok();
        }

        [HttpPut(RoutePelicula.Update)]
        public ActionResult<dominio.Pelicula> ModificarPelicula(dominio.Pelicula pelicula)
        {
            _service.ModificarPelicula(pelicula);
            return Ok();
        }

        [HttpDelete(RoutePelicula.Delete)]
        public ActionResult<dominio.Pelicula> EliminarPelicula(int id)
        {
            _service.EliminarPelicula(id);
            return Ok(id);
        }
    }
}
