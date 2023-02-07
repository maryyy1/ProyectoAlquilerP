using Gateway.Aplicacion.RecargasClient;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Gateway.Api.Routes.ApiRoutes;
using Recargas = Gateway.Aplicacion.RecargasClient;
using Clientes = Gateway.Aplicacion.ClientesClient;
using Gateway.Aplicacion.Alquileres.Request;

namespace Gateway.Api.Controllers
{
    [ApiController]
    public class RecargaController : ControllerBase
    {
        private readonly Recargas.IClient _recargasClient;
        private readonly Clientes.IClient _clientesClient;

        public RecargaController(Recargas.IClient recargasClient,Clientes.IClient clientesClient)
        {
            _recargasClient = recargasClient;
            _clientesClient = clientesClient;
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
                var objRecarga = _recargasClient.ApiV1RecargaSearchAsync(id);
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

        [HttpPost(RouteRecarga.Recargar)]
        public void Recargar(RegistrarRecargaRequest request)
        {
            /*
            try
            {
                var cliente = _clientesClient.ApiV1ClienteSearchAsync(request.IdCliente);
                if (cliente!=null)
                {
                    Recargas.Recarga recarga;
                    recarga.RecCliId = cliente.
                    _recargasClient.ApiV1RecargaCreateAsync(recarga);
                }
                
            }
            catch (ApiException ex)
            {
                Log.Error("ApiException: " + ex);
            }*/
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