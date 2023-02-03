using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Gateway.Api.Routes.ApiRoutes;
using System.Collections.Generic;
using Peliculas = Gateway.Aplicacion.PeliculasClient;
//using Gateway.Aplicacion.Peliculas.Request;
using System.Threading.Tasks;

namespace Gateway.Api.Controllers
{
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly Peliculas.IClient _peliculasClient;

        public PeliculaController(Peliculas.IClient peliculasClient)
        {
            _peliculasClient = peliculasClient;
        }

        [HttpGet(RoutePelicula.GetAll)]
        public Task<ICollection<Peliculas.Pelicula>> ListarPeliculas()
        {
            var listaPelicula = _peliculasClient.ApiV1PeliculaAllAsync();
            return listaPelicula;
        }

        [HttpGet(RoutePelicula.GetById)]
        public Task<Peliculas.Pelicula> BuscarPelicula(int id)
        {
            var objPelicula = _peliculasClient.ApiV1PeliculaAsync(id);
            return objPelicula;
        }

        [HttpPost(RoutePelicula.Create)]
        public ActionResult<Task<Peliculas.Pelicula>> CrearPelicula(Peliculas.Pelicula pelicula)
        {
            _peliculasClient.ApiV1PeliculaCreateAsync(pelicula);

            return Ok();
        }

        [HttpDelete(RoutePelicula.Delete)]
        public ActionResult<Task<Peliculas.Pelicula>> EliminarPelicula(int id)
        {
            _peliculasClient.ApiV1PeliculaDeleteAsync(id);
            return Ok(id);
        }
    }
}
