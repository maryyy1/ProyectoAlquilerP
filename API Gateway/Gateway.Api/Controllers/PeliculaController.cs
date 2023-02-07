using Microsoft.AspNetCore.Mvc;
using static Gateway.Api.Routes.ApiRoutes;
using System.Collections.Generic;
using Peliculas = Gateway.Aplicacion.PeliculasClient;
using Gateway.Aplicacion.PeliculasClient;
using Serilog;
using System;

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
        public ICollection<Peliculas.Pelicula> ListarPeliculas()
        {
            var listaPelicula = _peliculasClient.ApiV1PeliculaAllAsync().Result;
            return listaPelicula;
        }

        [HttpGet(RoutePelicula.GetById)]
        public Peliculas.Pelicula BuscarPelicula(int id)
        {
            try
            {
                var objPelicula = _peliculasClient.ApiV1PeliculaAsync(id).Result;
                return objPelicula;
            }
            catch (ApiException ex)
            {
                Log.Error("ApiException: " + ex);
            }

            return null;
        }


        [HttpPost(RoutePelicula.Create)]
        public void CrearAlquiler(Peliculas.Pelicula pelicula)
        {
            try
            {
                _peliculasClient.ApiV1PeliculaCreateAsync(pelicula);
            }
            catch (ApiException ex)
            {
                Log.Error("ApiException: " + ex);
            }
        }

        [HttpPut(RoutePelicula.Update)]
        public void ModificarPelicula(Peliculas.Pelicula pelicula)
        {
            try
            {
                _peliculasClient.ApiV1PeliculaUpdateAsync(pelicula);
            }
            catch (ApiException ex)
            {
                Log.Error("ApiException: " + ex);
            }
        }

        [HttpDelete(RoutePelicula.Delete)]
        public void EliminarPelicula(int id)
        {
            try
            {
                _peliculasClient.ApiV1PeliculaDeleteAsync(id);
            }
            catch (ApiException ex)
            {
                Log.Error("ApiException: " + ex);
            }
        }
    }
}