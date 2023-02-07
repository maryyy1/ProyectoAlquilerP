using Microsoft.AspNetCore.Mvc;
using static Gateway.Api.Routes.ApiRoutes;
using System.Collections.Generic;
using Alquileres = Gateway.Aplicacion.AlquileresClient;
using Gateway.Aplicacion.AlquileresClient;
using Clientes = Gateway.Aplicacion.ClientesClient;
using Peliculas = Gateway.Aplicacion.PeliculasClient;
using Serilog;
using System;
using Gateway.Aplicacion.Alquileres.Request;

namespace Gateway.Api.NewFolder
{
    [ApiController]
    public class AlquilerController : ControllerBase
    {
        private readonly Alquileres.IClient _alquileresClient;
        private readonly Clientes.IClient _clientesClient;
        private readonly Peliculas.IClient _peliculasClient;

        public AlquilerController(Alquileres.IClient alquileresClient, Clientes.IClient clientesClient,
                                    Peliculas.IClient peliculasClient)
        {
            try
            {
                _alquileresClient = alquileresClient;
                _clientesClient = clientesClient;
                _peliculasClient = peliculasClient;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
        }

        [HttpGet(RouteAlquiler.GetAll)]
        public ICollection<Alquileres.Alquiler> ListarAlquileres()
        {
            try
            {
                var listaAlquiler = _alquileresClient.ApiV1AlquilerAllAsync().Result;
                return listaAlquiler;
            }
            catch (ApiException ex)
            {
                Log.Error("ApiException: " + ex);
            }
            catch (AggregateException ex)
            {
                Log.Error("AggregateException: " + ex);
            }

            return null;
        }

        [HttpGet(RouteAlquiler.GetById)]
        public Alquileres.Alquiler BuscarAlquiler(int id)
        {
            try
            {
                var objAlquiler = _alquileresClient.ApiV1AlquilerAsync(id).Result;
                return objAlquiler;
            }
            catch (ApiException ex)
            {
                Log.Error("ApiException: " + ex);
            }
            catch (AggregateException ex)
            {
                Log.Error("AggregateException: " + ex);
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

        [HttpPost(RouteAlquiler.Alquilar)]
        public async void Alquilar(RegistrarRecargaRequest request)
        {
            try
            {
                Alquileres.Alquiler alquiler = new Alquiler();
                Alquileres.DetalleAlquiler detAlquiler = new DetalleAlquiler();
                var cliente = await _clientesClient.ApiV1ClienteSearchAsync(request.IdCliente);

                var pelicula = await _peliculasClient.ApiV1PeliculaSearchAsync(request.IdPelicula);
                if (cliente != null && pelicula != null)
                {
                    detAlquiler.DetAlqIdPel = pelicula.PelId;
                    alquiler.AlqIdCli = cliente.CliId;
                    detAlquiler.DetAlqId = request.IdDetAl;
                    alquiler.AlqId = request.IdAlquiler;
                    alquiler.AlqFecIni = request.AlqFecIni;
                    alquiler.AlqFecFin = request.AlqFecFin;
                    alquiler.AlqEnlace = request.AlqEnlace;
                    await _alquileresClient.ApiV1AlquilerCreateAsync(alquiler);
                    await _alquileresClient.ApiV1DetalleAlquilerCreateAsync(detAlquiler);
                }
            }
            catch (ApiException ex)
            {
                Log.Error("Exception: " + ex);
            }
        }

        [HttpPut(RouteAlquiler.Update)]
        public void ModificarAlquiler(Alquileres.Alquiler alquiler)
        {
            try
            {
                _alquileresClient.ApiV1AlquilerUpdateAsync(alquiler);
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
        }

        [HttpDelete(RouteAlquiler.Delete)]
        public void EliminarAlquiler(int id)
        {
            try
            {
                _alquileresClient.ApiV1AlquilerDeleteAsync(id);
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
        }
    }
}
