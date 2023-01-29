using MongoDB.Driver;
using Release.MongoDB.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using dominio = Ms.Pelicula.Dominio.Entidades;

namespace Ms.Pelicula.Aplicacion.Pelicula
{

    public class PeliculaService : IPeliculaService
    {
        private readonly ICollectionContext<dominio.Pelicula> _pelicula;
        private readonly IBaseRepository<dominio.Pelicula> _peliculaR;

        public PeliculaService(ICollectionContext<dominio.Pelicula> pelicula, 
                                IBaseRepository<dominio.Pelicula> peliculaR)
        {
            _pelicula = pelicula;
            _peliculaR = peliculaR;
        }

        public List<dominio.Pelicula> ListarPeliculas()
        {
            Expression<Func<dominio.Pelicula, bool>> filter = s => s.esEliminado == false;
            var items = (_pelicula.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }

        public bool RegistrarPelicula(dominio.Pelicula pelicula)
        {
            pelicula.esEliminado = false;
            pelicula.fechaCreacion =DateTime.Now;
            pelicula.esActivo = true;
            _peliculaR.InsertOne(pelicula);

            return true;
        }

        public dominio.Pelicula Pelicula(int idPelicula)
        {
            Expression<Func<dominio.Pelicula, bool>> filter = s => s.esEliminado == false && s.IdPelicula == idPelicula;
            var item = (_pelicula.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public void Eliminar(int idPelicula)
        {
            Expression<Func<dominio.Pelicula, bool>> filter = s => s.esEliminado == false && s.IdPelicula == idPelicula;
            var item = (_pelicula.Context().FindOneAndDelete(filter, null));
            
        }
    }
}
