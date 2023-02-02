using MongoDB.Driver;
using Ms.Recarga.Dominio.Entidades;
using Release.MongoDB.Repository;
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
            Expression<Func<dominio.Recarga, bool>> filter = s => s.esEliminado == false;
            var items = (_recarga.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }

        public bool RegistrarRecarga(dominio.Recarga recarga)
        {
            recarga.esEliminado = false;
            recarga.fechaCreacion =DateTime.Now;
            recarga.esActivo = true;
            _recargaR.InsertOne(recarga);

            return true;
        }

        public dominio.Recarga Recarga(int idRecarga)
        {
            Expression<Func<dominio.Recarga, bool>> filter = s => s.esEliminado == false && s.IdRecarga == idRecarga;
            var item = (_recarga.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public void Eliminar(int idRecarga)
        {
            Expression<Func<dominio.Recarga, bool>> filter = s => s.esEliminado == false && s.IdRecarga == idRecarga;
            var item = (_recarga.Context().FindOneAndDelete(filter, null));
            
        }
    }
}
