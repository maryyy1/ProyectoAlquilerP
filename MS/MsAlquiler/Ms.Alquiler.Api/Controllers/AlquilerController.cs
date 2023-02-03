﻿using Microsoft.AspNetCore.Mvc;
using Ms.Alquiler.Aplicacion.Alquiler;
using System;
using System.Collections.Generic;
using static Ms.Alquiler.Api.Routes.ApiRoutes;
using dominio = Ms.Alquiler.Dominio.Entidades;

namespace Ms.Alquiler.Api.Controllers
{
    [ApiController]
    public class AlquilerController : ControllerBase
    {
        private readonly IAlquilerService _service;

        public AlquilerController(IAlquilerService service)
        {
            _service = service;
        }

        [HttpGet(RouteAlquiler.GetAll)]
        public IEnumerable<dominio.Alquiler> ListarAlquileres()
        {
            var listaAlquiler = _service.ListarAlquileres();
            return listaAlquiler;
        }

        [HttpGet(RouteAlquiler.GetById)]
        public dominio.Alquiler BuscarAlquiler(int id)
        {
            try
            {
                var objAlquiler = _service.BuscarAlquiler(id);
                return objAlquiler;
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Error: " + ex);
                Console.ReadKey();
            }
            return null;
        }

        [HttpPost(RouteAlquiler.Create)]
        public ActionResult<dominio.Alquiler> CrearAlquiler(dominio.Alquiler alquiler)
        {
            _service.RegistrarAlquiler(alquiler);

            return Ok();
        }

        [HttpDelete(RouteAlquiler.Delete)]
        public ActionResult<dominio.Alquiler> EliminarAlquiler(int id)
        {
            _service.EliminarAlquiler(id);
            return Ok(id);
        }
    }
}