using MongoDB.Driver;
using Release.MongoDB.Repository;
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
                                IBaseRepository<dominio.DetalleAlquiler> clienteR)
        {
            _detalleAlquiler = detalleAlquiler;
            _detalleAlquilerR = clienteR;
        }

        public List<dominio.DetalleAlquiler> ListarDetallesAlquileres()
        {
            Expression<Func<dominio.DetalleAlquiler, bool>> filter = s => s.esEliminado == false;
            var items = (_detalleAlquiler.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }

        public bool RegistrarDetalleAlquiler(dominio.DetalleAlquiler detalleAlquiler)
        {
            detalleAlquiler.esEliminado = false;
            detalleAlquiler.fechaCreacion = DateTime.Now;
            detalleAlquiler.esActivo = true;

            _detalleAlquilerR.InsertOne(detalleAlquiler);

            return true;
        }

        public dominio.DetalleAlquiler DetalleAlquiler (int idDetalleAlquiler)
        {
            Expression<Func<dominio.DetalleAlquiler, bool>> filter = s => s.esEliminado == false && s.IdDetalleAlquiler == idDetalleAlquiler;
            var item = (_detalleAlquiler.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public void Eliminar(int idDetalleAlquiler)
        {
            Expression<Func<dominio.DetalleAlquiler, bool>> filter = s => s.esEliminado == false && s.IdDetalleAlquiler == idDetalleAlquiler;
            var item = (_detalleAlquiler.Context().FindOneAndDelete(filter, null));

        }
    }
}

