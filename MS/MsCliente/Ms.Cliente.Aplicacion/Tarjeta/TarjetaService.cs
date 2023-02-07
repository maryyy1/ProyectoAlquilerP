using MongoDB.Driver;
using Release.MongoDB.Repository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using dominio = Ms.Cliente.Dominio.Entidades;

namespace Ms.Cliente.Aplicacion.Tarjeta
{

    public class TarjetaService : ITarjetaService
    {
        private readonly ICollectionContext<dominio.Tarjeta> _tarjeta;
        private readonly IBaseRepository<dominio.Tarjeta> _tarjetaR;

        public TarjetaService(ICollectionContext<dominio.Tarjeta> tarjeta, 
                                IBaseRepository<dominio.Tarjeta> tarjetaR)
        {
            _tarjeta = tarjeta;
            _tarjetaR = tarjetaR;
        }

        public List<dominio.Tarjeta> ListarTarjetas()
        {
            try
            {
                Expression<Func<dominio.Tarjeta, bool>> filter = s => s.esEliminado == false;
                var items = (_tarjeta.Context().FindAsync(filter, null).Result).ToList();

                return items;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        public bool RegistrarTarjeta(dominio.Tarjeta tarjeta)
        {
            try
            {
                tarjeta.esEliminado = false;
                tarjeta.fechaCreacion = DateTime.Now;
                tarjeta.esActivo = true;
                _tarjetaR.InsertOne(tarjeta);

                return true;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return false;
        }

        public dominio.Tarjeta BuscarTarjeta(int idTarjeta)
        {
            try
            {
                Expression<Func<dominio.Tarjeta, bool>> filter = s => s.esEliminado == false && s.TarId == idTarjeta;
                var item = (_tarjeta.Context().FindAsync(filter, null).Result).FirstOrDefault();
                return item;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        public bool ModificarTarjeta(dominio.Tarjeta tarjeta)
        {
            try
            {
                dominio.Tarjeta tarjetaActual = BuscarTarjeta(tarjeta.TarId);
                if (tarjetaActual != null)
                {
                    tarjetaActual.TarNumero = tarjeta.TarNumero;
                    tarjetaActual.TarFecVen = tarjeta.TarFecVen;
                    tarjetaActual.TarCvv = tarjeta.TarCvv;
                    tarjetaActual.TarSaldo = tarjeta.TarSaldo;
                    tarjetaActual.TarTipo = tarjeta.TarTipo;
                    tarjetaActual.fechaModificacion = tarjeta.fechaModificacion;
                    _tarjetaR.UpdateOne(tarjetaActual.id, tarjetaActual);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return false;
        }

        public void EliminarTarjeta(int idTarjeta)
        {
            try
            {
                Expression<Func<dominio.Tarjeta, bool>> filter = s => s.esEliminado == false && s.TarId == idTarjeta;
                var item = (_tarjeta.Context().FindOneAndDelete(filter, null));
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }            
        }
    }
}
