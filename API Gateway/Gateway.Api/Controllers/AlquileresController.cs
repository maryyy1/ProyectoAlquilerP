
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Gateway.Api.Routes.ApiRoutes;
using System.Collections.Generic;
using Alquileres = Gateway.Aplicacion.AlquileresClient;
//using Gateway.Aplicacion.Peliculas.Request;
using System.Threading.Tasks;

namespace Gateway.Api.NewFolder
{
    [ApiController]
    public class AlquilerController : ControllerBase
    {
        private readonly Alquileres.IClient _alquileresClient;

        public AlquilerController(Alquileres.IClient alquileresClient)
        {
            _alquileresClient = alquileresClient;
        }

        [HttpGet(RouteAlquiler.GetAll)]
        public Task<ICollection<Alquileres.Alquiler>> ListarAlquileres()
        {
            var listaAlquiler = _alquileresClient.ApiV1AlquilerAllAsync();
            return listaAlquiler;
        }

        [HttpGet(RouteAlquiler.GetById)]
        public Task<Alquileres.Alquiler> BuscarAlquiler(int id)
        {
            var objAlquiler = _alquileresClient.ApiV1AlquilerAsync(id);
            return objAlquiler;
        }

        [HttpPost(RouteAlquiler.Create)]
        public void CrearAlquiler(Alquileres.Alquiler alquiler)
        {
            _alquileresClient.ApiV1AlquilerCreateAsync(alquiler);
        }

    }
}
