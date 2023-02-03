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

        public dominio.Pelicula BuscarPelicula(int idPelicula)
        {
            Expression<Func<dominio.Pelicula, bool>> filter = s => s.esEliminado == false && s.IdPelicula == idPelicula;
            var item = (_pelicula.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public bool ModificarPelicula(dominio.Pelicula pelicula)
        {
            Expression<Func<dominio.Pelicula, bool>> filter = s => s.esEliminado == false && s.IdPelicula == pelicula.IdPelicula;
            var peliculaActual = (_pelicula.Context().FindAsync(filter, null).Result).FirstOrDefault();
            //    collection.FindOneAndReplace(x => x._id == producto._id, producto);

            //    //var oldProducto = collection.Find(x => x.IdProducto == producto.IdProducto).FirstOrDefault();
            //    //oldProducto.Nombre = producto.Nombre;
            //    //oldProducto.Precio = producto.Precio;
            //    //oldProducto.Cantidad = producto.Cantidad;
            //    //collection.ReplaceOne(x=>x.IdProducto == oldProducto.IdProducto, oldProducto);


            //    //Producto productoModificado = listaProducto.Single(x => x.IdProducto == producto.IdProducto);
            //    //productoModificado.Nombre = producto.Nombre;
            //    //productoModificado.Cantidad = producto.Cantidad;
            //    //productoModificado.Precio= producto.Precio;
            //_peliculaR.UpdateOne();
            return true;
        }

        public void EliminarPelicula(int idPelicula)
        {
            Expression<Func<dominio.Pelicula, bool>> filter = s => s.esEliminado == false && s.IdPelicula == idPelicula;
            var item = (_pelicula.Context().FindOneAndDelete(filter, null));
            
        }
    }
}
