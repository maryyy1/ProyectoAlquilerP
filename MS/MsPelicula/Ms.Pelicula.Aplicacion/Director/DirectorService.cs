using MongoDB.Driver;
using Release.MongoDB.Repository;
using Serilog;
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
            try
            {
                Expression<Func<dominio.Director, bool>> filter = s => s.esEliminado == false;
                var items = (_director.Context().FindAsync(filter, null).Result).ToList();
                return items;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        public bool RegistrarDirector(dominio.Director director)
        {
            try
            {
                director.esEliminado = false;
                director.fechaCreacion = DateTime.Now;
                director.esActivo = true;
                _directorR.InsertOne(director);

                return true;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return false;
        }

        public dominio.Director BuscarDirector(int idDirector)
        {
            try
            {
                Expression<Func<dominio.Director, bool>> filter = s => s.esEliminado == false && s.DirId == idDirector;
                var item = (_director.Context().FindAsync(filter, null).Result).FirstOrDefault();
                return item;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        public bool ModificarDirector(dominio.Director director)
        {
            try
            {
                dominio.Director directorActual = BuscarDirector(director.DirId);
                if (directorActual != null)
                {
                    directorActual.DirNombre = director.DirNombre;
                    directorActual.DirApePat = director.DirApePat;
                    directorActual.DirApeMat = director.DirApeMat;
                    directorActual.DirSexo = director.DirSexo;
                    directorActual.fechaModificacion = director.fechaModificacion;
                    _directorR.UpdateOne(directorActual.id, directorActual);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return false;
        }

        public void EliminarDirector(int idDirector)
        {
            try
            {
                Expression<Func<dominio.Director, bool>> filter = s => s.esEliminado == false && s.DirId == idDirector;
                var item = (_director.Context().FindOneAndDelete(filter, null));
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }       
        }
    }
}
