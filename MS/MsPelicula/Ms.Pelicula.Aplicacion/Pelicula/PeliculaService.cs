using MongoDB.Driver;
using Release.MongoDB.Repository;
using Serilog;
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
            try
            {
                Expression<Func<dominio.Pelicula, bool>> filter = s => s.esEliminado == false;
                var items = (_pelicula.Context().FindAsync(filter, null).Result).ToList();

                return items;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        public bool RegistrarPelicula(dominio.Pelicula pelicula)
        {
            try
            {
                pelicula.esEliminado = false;
                pelicula.fechaCreacion = DateTime.Now;
                pelicula.esActivo = true;
                _peliculaR.InsertOne(pelicula);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return false;
        }

        public dominio.Pelicula BuscarPelicula(int idPelicula)
        {
            try
            {
                Expression<Func<dominio.Pelicula, bool>> filter = s => s.esEliminado == false && s.PelId == idPelicula;
                var item = (_pelicula.Context().FindAsync(filter, null).Result).FirstOrDefault();
                return item;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        public bool ModificarPelicula(dominio.Pelicula pelicula)
        {
            try
            {
                dominio.Pelicula peliculaActual = BuscarPelicula(pelicula.PelId);
                if (peliculaActual != null)
                {
                    peliculaActual.PelNombre = pelicula.PelNombre;
                    peliculaActual.PelDuracion = pelicula.PelDuracion;
                    peliculaActual.PelPrecio = pelicula.PelPrecio;
                    peliculaActual.fechaModificacion = pelicula.fechaModificacion;
                    _peliculaR.UpdateOne(peliculaActual.id, peliculaActual);
                    return true;
                }
            }
            catch(Exception ex)
            {
                Log.Error("Exception: " + ex);
            }                                   
            return false;
        }

        public void EliminarPelicula(int idPelicula)
        {
            try
            {
                Expression<Func<dominio.Pelicula, bool>> filter = s => s.esEliminado == false && s.PelId == idPelicula;
                var item = (_pelicula.Context().FindOneAndDelete(filter, null));
            }
            catch(Exception ex)
            {
                Log.Error("Exception: " + ex);
            }            
        }
    }
}
