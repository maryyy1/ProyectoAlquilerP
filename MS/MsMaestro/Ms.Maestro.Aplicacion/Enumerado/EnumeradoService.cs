using MongoDB.Driver;
using Release.MongoDB.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using dominio = Ms.Maestro.Dominio.Entidades;

namespace Ms.Maestro.Aplicacion.Enumerado
{

    public class EnumeradoService : IEnumeradoService
    {
        private readonly ICollectionContext<dominio.Enumerado> _enumerado;
        private readonly IBaseRepository<dominio.Enumerado> _enumeradoR;

        public EnumeradoService(ICollectionContext<dominio.Enumerado> enumerado,
                                IBaseRepository<dominio.Enumerado> enumeradoR)
        {
            _enumerado = enumerado;
            _enumeradoR = enumeradoR;
        }

        public List<dominio.Enumerado> ListarEnumerados()
        {
            Expression<Func<dominio.Enumerado, bool>> filter = s => s.esEliminado == false;
            var items = (_enumerado.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }

        public bool RegistrarEnumerado(dominio.Enumerado enumerado)
        {
            enumerado.esEliminado = false;
            enumerado.fechaCreacion = DateTime.Now;
            enumerado.esActivo = true;

            _enumeradoR.InsertOne(enumerado);

            return true;
        }

        public dominio.Enumerado Enumerado (int idEnumerado)
        {
            Expression<Func<dominio.Enumerado, bool>> filter = s => s.esEliminado == false && s.IdEnumerado == idEnumerado;
            var item = (_enumerado.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public void Eliminar(int idEnumerado)
        {
            Expression<Func<dominio.Enumerado, bool>> filter = s => s.esEliminado == false && s.IdEnumerado == idEnumerado;
            var item = (_enumerado.Context().FindOneAndDelete(filter, null));

        }
    }
}

