using MongoDB.Driver;
using Release.MongoDB.Repository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using dominio = Ms.Recarga.Dominio.Entidades;

namespace Ms.Recarga.Aplicacion.Recarga
{

    public class RecargaService : IRecargaService
    {
        private readonly ICollectionContext<dominio.Recarga> _recarga;
        private readonly IBaseRepository<dominio.Recarga> _recargaR;

        public RecargaService(ICollectionContext<dominio.Recarga> recarga, 
                                IBaseRepository<dominio.Recarga> recargaR)
        {
            _recarga = recarga;
            _recargaR = recargaR;
        }

        public List<dominio.Recarga> ListarRecargas()
        {
            try
            {
                Expression<Func<dominio.Recarga, bool>> filter = s => s.esEliminado == false;
                var items = (_recarga.Context().FindAsync(filter, null).Result).ToList();
                return items;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        public bool RegistrarRecarga(dominio.Recarga recarga)
        {
            try
            {
                recarga.esEliminado = false;
                recarga.fechaCreacion = DateTime.Now;
                recarga.esActivo = true;
                _recargaR.InsertOne(recarga);

                return true;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return false;
        }

        public dominio.Recarga BuscarRecarga(int idRecarga)
        {
            try
            {
                Expression<Func<dominio.Recarga, bool>> filter = s => s.esEliminado == false && s.RecId == idRecarga;
                var item = (_recarga.Context().FindAsync(filter, null).Result).FirstOrDefault();
                return item;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        public bool ModificarRecarga(dominio.Recarga recarga)
        {
            try
            {
                dominio.Recarga recargaActual = BuscarRecarga(recarga.RecId);
                if (recargaActual != null)
                {
                    recargaActual.RecFecha = recarga.RecFecha;
                    recargaActual.RecMonto = recarga.RecMonto;
                    recargaActual.fechaModificacion = recarga.fechaModificacion;
                    _recargaR.UpdateOne(recargaActual.id, recargaActual);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return false;
        }

        public void EliminarRecarga(int idRecarga)
        {
            try
            {
                Expression<Func<dominio.Recarga, bool>> filter = s => s.esEliminado == false && s.RecId == idRecarga;
                var item = (_recarga.Context().FindOneAndDelete(filter, null));
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }            
        }
    }
}
