using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Gateway.Api.Routes.ApiRoutes;
using Peliculas = Gateway.Aplicacion.PeliculasClient;
using Clientes = Gateway.Aplicacion.ClientesClient;
using Alquileres = Gateway.Aplicacion.AlquileresClient;
using Gateway.Aplicacion.Alquileres.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gateway.Api.Controllers
{
    [ApiController]
    public class AlquilerController : ControllerBase
    {
        private readonly Peliculas.IClient _peliculasClient;
        //private readonly Clientes.IClient _clientesClient;
        private readonly Alquileres.IClient _alquileresClient;

        public AlquilerController(Peliculas.IClient peliculasClient, Clientes.IClient clientesClient,Alquileres.IClient alquileresClient)
        {
            _peliculasClient = peliculasClient;
            //_clientesClient = clientesClient;
            _alquileresClient = alquileresClient;
        }

        [HttpGet(RouteAlquiler.GetAll)]
        public Task<ICollection<Alquileres.Alquiler>> ListarAlquileres()
        {
            var listaAlquiler = _alquileresClient.ApiV1AlquilerAllAsync();
            return listaAlquiler;
        }

        [HttpPost(RouteAlquiler.RegistrarAlquiler)]
        public async void RegistrarAlquiler(RegistrarAlquilerRequest request)
        {
            //_clientesClient.ApiV1ClienteAsync(request.IdCliente);
            await _peliculasClient.ApiV1PeliculaAsync(request.IdPelicula);

            //var pedido = _peliculasClient.ApiV1PeliculaUpdateStockAsync(pelicula);
            //var alquiler = await _alquileresClient.ApiV1AlquilerCreateAsync()

        }
    }
}
