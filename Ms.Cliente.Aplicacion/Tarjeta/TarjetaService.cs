using MongoDB.Driver;
using Release.MongoDB.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using dominio = Ms.Cliente.Dominio.Entidades;

namespace Ms.Cliente.Aplicacion.Cliente
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

        public List<dominio.Tarjeta> ListarTarjeta()
        {
            Expression<Func<dominio.Tarjeta, bool>> filter = s => s.esEliminado == false;
            var items = (_tarjeta.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }

        public bool RegistrarTarjeta(dominio.Tarjeta tarjeta)
        {
            tarjeta.esEliminado = false;
            tarjeta.fechaCreacion = DateTime.Now;
            tarjeta.esActivo = true;

            // _Pelicula.Context().InsertOne(Pelicula);                       

            var t = _tarjetaR.InsertOne(tarjeta);

            return true;
        }

        public dominio.Tarjeta Tarjeta(int idTarjeta)
        {
            Expression<Func<dominio.Tarjeta, bool>> filter = s => s.esEliminado == false && s.IdTarjeta == idTarjeta;
            var item = (_tarjeta.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public void Eliminar(int idTarjeta)
        {
            Expression<Func<dominio.Tarjeta, bool>> filter = s => s.esEliminado == false && s.IdTarjeta == idTarjeta;
            var item = (_tarjeta.Context().FindOneAndDelete(filter, null));

        }
    }
}

