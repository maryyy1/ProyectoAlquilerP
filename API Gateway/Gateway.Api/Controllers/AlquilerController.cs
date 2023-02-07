﻿using Gateway.Aplicacion.Alquileres.Request;
using Gateway.Aplicacion.AlquileresClient;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Collections.Generic;
using static Gateway.Api.Routes.ApiRoutes;
using Alquileres = Gateway.Aplicacion.AlquileresClient;
using Clientes = Gateway.Aplicacion.ClientesClient;
using Peliculas = Gateway.Aplicacion.PeliculasClient;

namespace Gateway.Api.NewFolder
{
    [ApiController]
    public class AlquilerController : ControllerBase
    {
        private Alquileres.IClient _alquileresClient;
        private readonly Clientes.IClient _clientesClient;
        private readonly Peliculas.IClient _peliculasClient;

        public AlquilerController(Alquileres.IClient alquileresClient, Clientes.IClient clientesClient,
                                    Peliculas.IClient peliculasClient)
        {
            _alquileresClient = alquileresClient;
            _clientesClient = clientesClient;
            _peliculasClient = peliculasClient;
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
                Log.Error("ApiException: " + ex);
            }
        }

        [HttpPost(RouteAlquiler.Alquilar)]
        public async void Alquilar(RegistrarAlquilerRequest request)
        {
            try
            {
                Alquileres.Alquiler alquiler = new Alquiler();
                Alquileres.DetalleAlquiler detAlquiler = new DetalleAlquiler();
                var cliente = await _clientesClient.ApiV1ClienteAsync(request.IdCliente);

                var pelicula = await _peliculasClient.ApiV1PeliculaAsync(request.IdPelicula);
                if (cliente != null && pelicula != null)
                {
                    detAlquiler.IdPelicula = pelicula.IdPelicula;
                    alquiler.IdCliente = cliente.CliId;
                    detAlquiler.IdDetalleAlquiler = request.IdDetAl;
                    alquiler.IdAlquiler = request.IdAlquiler;
                    alquiler.AlqFecIni = request.AlqFecIni;
                    alquiler.AlqFecFin = request.AlqFecFin;
                    alquiler.AlqEnlace = request.AlqEnlace;
                    await _alquileresClient.ApiV1AlquilerCreateAsync(alquiler);
                    await _alquileresClient.ApiV1DetalleAlquilerCreateAsync(detAlquiler);
                }
            }
            catch (ApiException ex)
            {
                Log.Error("ApiException: " + ex);
            }
        }

        [HttpPut(RouteAlquiler.Update)]
        public void ModificarAlquiler(Alquileres.Alquiler alquiler)
        {
            try
            {
                _alquileresClient.ApiV1AlquilerUpdateAsync(alquiler);
            }
            catch (ApiException ex)
            {
                Log.Error("ApiException: " + ex);
            }
        }

        [HttpDelete(RouteAlquiler.Delete)]
        public void EliminarAlquiler(int id)
        {
            try
            {
                _alquileresClient.ApiV1AlquilerDeleteAsync(id);
            }
            catch (ApiException ex)
            {
                Log.Error("ApiException: " + ex);
            }
        }
    }
}
