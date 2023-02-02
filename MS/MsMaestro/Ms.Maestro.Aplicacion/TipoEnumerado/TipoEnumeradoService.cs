using MongoDB.Driver;
using Release.MongoDB.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using dominio = Ms.Maestro.Dominio.Entidades;

namespace Ms.Maestro.Aplicacion.TipoEnumerado
{

    public class TipoEnumeradoService : ITipoEnumeradoService
    {
        private readonly ICollectionContext<dominio.TipoEnumerado> _tipoEnumerado;
        private readonly IBaseRepository<dominio.TipoEnumerado> _tipoEnumeradoR;

        public TipoEnumeradoService(ICollectionContext<dominio.TipoEnumerado> tipoEnumerado,
                                IBaseRepository<dominio.TipoEnumerado> tipoEnumeradoR)
        {
            _tipoEnumerado = tipoEnumerado;
            _tipoEnumeradoR = tipoEnumeradoR;
        }

        public List<dominio.TipoEnumerado> ListarTiposEnumerados()
        {
            Expression<Func<dominio.TipoEnumerado, bool>> filter = s => s.esEliminado == false;
            var items = (_tipoEnumerado.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }

        public bool RegistrarTipoEnumerado(dominio.TipoEnumerado tipoEnumerado)
        {
            tipoEnumerado.esEliminado = false;
            tipoEnumerado.fechaCreacion = DateTime.Now;
            tipoEnumerado.esActivo = true;

            _tipoEnumeradoR.InsertOne(tipoEnumerado);

            return true;
        }

        public dominio.TipoEnumerado TipoEnumerado (int idTipoEnumerado)
        {
            Expression<Func<dominio.TipoEnumerado, bool>> filter = s => s.esEliminado == false && s.IdTipoEnumerado == idTipoEnumerado;
            var item = (_tipoEnumerado.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public void Eliminar(int idTipoEnumerado)
        {
            Expression<Func<dominio.TipoEnumerado, bool>> filter = s => s.esEliminado == false && s.IdTipoEnumerado == idTipoEnumerado;
            var item = (_tipoEnumerado.Context().FindOneAndDelete(filter, null));

        }
    }
}

