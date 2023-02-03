using MongoDB.Driver;
using Ms.Pelicula.Dominio.Entidades;
using Release.MongoDB.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using dominio = Ms.Pelicula.Dominio.Entidades;

namespace Ms.Pelicula.Aplicacion.Director
{

    public class DirectorService : IDirectorService
    {
        private readonly ICollectionContext<dominio.Director> _director;
        private readonly IBaseRepository<dominio.Director> _directorR;

        public DirectorService(ICollectionContext<dominio.Director> director, 
                                IBaseRepository<dominio.Director> directorR)
        {
            _director = director;
            _directorR = directorR;
        }

        public List<dominio.Director> ListarDirectores()
        {
            Expression<Func<dominio.Director, bool>> filter = s => s.esEliminado == false;
            var items = (_director.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }

        public bool RegistrarDirector(dominio.Director director)
        {
            director.esEliminado = false;
            director.fechaCreacion =DateTime.Now;
            director.esActivo = true;                   
            _directorR.InsertOne(director);

            return true;
        }

        public dominio.Director BuscarDirector(int idDirector)
        {
            Expression<Func<dominio.Director, bool>> filter = s => s.esEliminado == false && s.IdDirector == idDirector;
            var item = (_director.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public void EliminarDirector(int idDirector)
        {
            Expression<Func<dominio.Director, bool>> filter = s => s.esEliminado == false && s.IdDirector == idDirector;
            var item = (_director.Context().FindOneAndDelete(filter, null));
            
        }
    }
}
