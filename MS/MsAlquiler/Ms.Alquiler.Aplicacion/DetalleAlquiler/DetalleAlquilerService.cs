using MongoDB.Driver;
using Release.MongoDB.Repository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using dominio = Ms.Alquiler.Dominio.Entidades;

namespace Ms.Alquiler.Aplicacion.DetalleAlquiler
{

    public class DetalleAlquilerService : IDetalleAlquilerService
    {
        private readonly ICollectionContext<dominio.DetalleAlquiler> _detalleAlquiler;
        private readonly IBaseRepository<dominio.DetalleAlquiler> _detalleAlquilerR;

        public DetalleAlquilerService(ICollectionContext<dominio.DetalleAlquiler> detalleAlquiler,
                                IBaseRepository<dominio.DetalleAlquiler> detalleAlquilerR)
        {
            _detalleAlquiler = detalleAlquiler;
            _detalleAlquilerR = detalleAlquilerR;
        }

        public List<dominio.DetalleAlquiler> ListarDetallesAlquileres()
        {
            try
            {
                Expression<Func<dominio.DetalleAlquiler, bool>> filter = s => s.esEliminado == false;
                var items = (_detalleAlquiler.Context().FindAsync(filter, null).Result).ToList();
                return items;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        public bool RegistrarDetalleAlquiler(dominio.DetalleAlquiler detalleAlquiler)
        {
            try
            {
                detalleAlquiler.esEliminado = false;
                detalleAlquiler.fechaCreacion = DateTime.Now;
                detalleAlquiler.esActivo = true;

                _detalleAlquilerR.InsertOne(detalleAlquiler);

                return true;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return false;
        }

        public dominio.DetalleAlquiler BuscarDetalleAlquiler (int idDetalleAlquiler)
        {
            try
            {
                Expression<Func<dominio.DetalleAlquiler, bool>> filter = s => s.esEliminado == false && s.DetAlqId == idDetalleAlquiler;
                var item = (_detalleAlquiler.Context().FindAsync(filter, null).Result).FirstOrDefault();
                return item;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        public bool ModificarDetalleAlquiler(dominio.DetalleAlquiler detalleAlquiler)
        {
            try
            {
                dominio.DetalleAlquiler detAlqActual = BuscarDetalleAlquiler(detalleAlquiler.DetAlqId);
                if (detAlqActual != null)
                {
                    detAlqActual.DetAlqIdPel = detalleAlquiler.DetAlqIdPel;
                    detAlqActual.fechaModificacion = detalleAlquiler.fechaModificacion;
                    _detalleAlquilerR.UpdateOne(detAlqActual.id, detAlqActual);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return false;
        }

        public void EliminarDetalleAlquiler(int idDetalleAlquiler)
        {
            try
            {
                Expression<Func<dominio.DetalleAlquiler, bool>> filter = s => s.esEliminado == false && s.DetAlqId == idDetalleAlquiler;
                var item = (_detalleAlquiler.Context().FindOneAndDelete(filter, null));
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
        }
    }
}

