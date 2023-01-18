using Alquiler_Peliculas.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Alquiler_Peliculas.Controllers
{
    [ApiController]
    [Route("Alquiler")]
    public class PeliculaController : ControllerBase
    {
        private static List<Pelicula> ListaPelicula = new List<Pelicula>
        {
            new Pelicula
            {
                IdPelicula = 1,
                Nombre = "El hombre que araña",
                Duracion = "2h",
                Precio = 12
            },

            new Pelicula
            {
                IdPelicula = 2,
                Nombre = "El venon",
                Duracion = "2h 30min",
                Precio = 15
            }
        };
        /*
        [HttpGet(Name = "BuscarPelicula")]
        public Pelicula BuscarPelicula(int id)
        {
            return ListaPelicula.Single(x => x.IdPelicula == id);
        }
        */

        [HttpGet(Name = "GetPelicula")]
        public IEnumerable<Pelicula> Get()
        {
            return ListaPelicula;
        }
    }
}
