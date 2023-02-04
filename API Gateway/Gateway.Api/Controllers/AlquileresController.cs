using Gateway.Aplicacion.AlquileresClient;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Gateway.Api.Routes.ApiRoutes;
using Alquileres = Gateway.Aplicacion.AlquileresClient;

namespace Gateway.Api.NewFolder
{
    [ApiController]
    public class AlquilerController : ControllerBase
    {
        private readonly Alquileres.IClient _alquileresClient;

        public AlquilerController(Alquileres.IClient alquileresClient)
        {
            try
            {
                _alquileresClient = alquileresClient;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
        }

        [HttpGet(RouteAlquiler.GetAll)]
        public Task<ICollection<Alquileres.Alquiler>> ListarAlquileres()
        {
            try
            {
                var listaAlquiler = _alquileresClient.ApiV1AlquilerAllAsync();
                return listaAlquiler;
            }
            catch (ApiException ex)
            {
                Log.Error("ApiException: " + ex);
            }

            return null;
        }

        [HttpGet(RouteAlquiler.GetById)]
        public Task<Alquileres.Alquiler> BuscarAlquiler(int id)
        {
            try
            {
                var objAlquiler = _alquileresClient.ApiV1AlquilerAsync(id);
                return objAlquiler;
            }
            catch (ApiException ex)
            {
                Log.Error("Exception: " + ex);
            }

            return null;
        }


        [HttpPost(RouteAlquiler.Create)]
        public void CrearAlquiler(Alquileres.Alquiler alquiler)
        {
            try
            {
                _alquileresClient.ApiV1AlquilerCreateAsync(alquiler);
            }
            catch (ApiException ex)
            {
                Log.Error("Exception: " + ex);
            }
        }
    }
}
