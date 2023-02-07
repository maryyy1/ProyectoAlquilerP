using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Release.MongoDB.Repository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using dominio = Ms.Alquiler.Dominio.Entidades;

namespace Ms.Alquiler.Aplicacion.Alquiler
{

    public class AlquilerService : IAlquilerService
    {
        private readonly ICollectionContext<dominio.Alquiler> _alquiler;
        private readonly IBaseRepository<dominio.Alquiler> _alquilerR;

        public AlquilerService(ICollectionContext<dominio.Alquiler> alquiler,
                                IBaseRepository<dominio.Alquiler> clienteR)
        {
            _alquiler = alquiler;
            _alquilerR = clienteR;
        }

        public List<dominio.Alquiler> ListarAlquileres()
        {
            try
            {
                Expression<Func<dominio.Alquiler, bool>> filter = s => s.esEliminado == false;
                var items = (_alquiler.Context().FindAsync(filter, null).Result).ToList();
                return items;
            }
            catch(Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        public bool RegistrarAlquiler(dominio.Alquiler alquiler)
        {
            try
            {
                alquiler.esEliminado = false;
                alquiler.fechaCreacion = DateTime.Now;
                alquiler.esActivo = true;

                _alquilerR.InsertOne(alquiler);

                return true;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return false;
        }

        public dominio.Alquiler BuscarAlquiler (int idAlquiler)
        {
            try
            {
                Expression<Func<dominio.Alquiler, bool>> filter = s => s.esEliminado == false && s.AlqId == idAlquiler;
                var item = (_alquiler.Context().FindAsync(filter, null).Result).FirstOrDefault();
                return item;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        public void EliminarAlquiler(int idAlquiler)
        {
            try
            {
                Expression<Func<dominio.Alquiler, bool>> filter = s => s.esEliminado == false && s.AlqId == idAlquiler;
                var item = (_alquiler.Context().FindOneAndDelete(filter, null));
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
        }

        public bool ModificarAlquiler(dominio.Alquiler alquiler)
        {
            try
            {
                dominio.Alquiler alquilerActual = BuscarAlquiler(alquiler.AlqId);
                if (alquilerActual != null)
                {
                    alquilerActual.AlqFecIni = alquiler.AlqFecIni;
                    alquilerActual.AlqFecFin = alquiler.AlqFecFin;
                    alquilerActual.AlqEnlace = alquiler.AlqEnlace;
                    alquilerActual.fechaModificacion = alquiler.fechaModificacion;
                    _alquilerR.UpdateOne(alquilerActual.id, alquilerActual);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return false;
        }
    }
}

