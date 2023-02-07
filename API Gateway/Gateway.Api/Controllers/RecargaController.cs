using Microsoft.AspNetCore.Mvc;
using static Gateway.Api.Routes.ApiRoutes;
using System.Collections.Generic;
using Recargas = Gateway.Aplicacion.RecargasClient;
using Gateway.Aplicacion.RecargasClient;
using System.Threading.Tasks;
using Serilog;
using System;

namespace Gateway.Api.Controllers
{
    [ApiController]
    public class RecargaController : ControllerBase
    {
        private readonly Recargas.IClient _recargasClient;

        public RecargaController(Recargas.IClient recargasClient)
        {
            _recargasClient = recargasClient;
        }

        [HttpGet(RouteRecarga.GetAll)]
        public Task<ICollection<Recargas.Recarga>> ListarRecargas()
        {
            var listaRecarga= _recargasClient.ApiV1RecargaAllAsync();
            return listaRecarga;
        }

        [HttpGet(RouteRecarga.GetById)]
        public Task<Recargas.Recarga> BuscarRecarga(int id)
        {
            try
            {
                var objRecarga = _recargasClient.ApiV1RecargaAsync(id);
                return objRecarga;
            }
            catch (ApiException ex)
            {
                Log.Error("ApiException: " + ex);
            }

            return null;
        }


        [HttpPost(RouteRecarga.Create)]
        public void CrearRecarga(Recargas.Recarga recarga)
        {
            try
            {
                _recargasClient.ApiV1RecargaCreateAsync(recarga);
            }
            catch (ApiException ex)
            {
                Log.Error("ApiException: " + ex);
            }
        }

        [HttpPut(RouteRecarga.Update)]
        public void ModificarRecarga(Recargas.Recarga recarga)
        {
            try
            {
                _recargasClient.ApiV1RecargaUpdateAsync(recarga);
            }
            catch (ApiException ex)
            {
                Log.Error("ApiException: " + ex);
            }
        }

        [HttpDelete(RouteRecarga.Delete)]
        public void EliminarRecarga(int id)
        {
            try
            {
                _recargasClient.ApiV1RecargaDeleteAsync(id);
            }
            catch (ApiException ex)
            {
                Log.Error("ApiException: " + ex);
            }
        }
    }
}