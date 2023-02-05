using MongoDB.Driver;
using Release.MongoDB.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using dominio = Ms.Alquiler.Dominio.Entidades;

namespace Ms.Alquiler.Aplicacion.Alquiler
{

    public class AlquilerService : IAlquilerService
    {
        private readonly ICollectionContext<dominio.Alquiler> _alquiler;
        private readonly IBaseRepository<dominio.Alquiler> _alquilerR;

        public AlquilerService(ICollectionContext<dominio.Alquiler> alquiler,
                                IBaseRepository<dominio.Alquiler> clienteR)
        {
            _alquiler = alquiler;
            _alquilerR = clienteR;
        }

        public List<dominio.Alquiler> ListarAlquileres()
        {
            Expression<Func<dominio.Alquiler, bool>> filter = s => s.esEliminado == false;
            var items = (_alquiler.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }

        public bool RegistrarAlquiler(dominio.Alquiler alquiler)
        {
            alquiler.esEliminado = false;
            alquiler.fechaCreacion = DateTime.Now;
            alquiler.esActivo = true;

            _alquilerR.InsertOne(alquiler);

            return true;
        }

        public dominio.Alquiler BuscarAlquiler (int idAlquiler)
        {
            Expression<Func<dominio.Alquiler, bool>> filter = s => s.esEliminado == false && s.IdAlquiler == idAlquiler;
            var item = (_alquiler.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public void EliminarAlquiler(int idAlquiler)
        {
            Expression<Func<dominio.Alquiler, bool>> filter = s => s.esEliminado == false && s.IdAlquiler == idAlquiler;
            var item = (_alquiler.Context().FindOneAndDelete(filter, null));

        }

        public bool ModificarAlquiler(dominio.Alquiler alquiler)
        {
            Expression<Func<dominio.Alquiler, bool>> filter = s => s.esEliminado == false && s.IdAlquiler == alquiler.IdAlquiler;
            var peliculaActual = (_alquiler.Context().FindAsync(filter, null).Result).FirstOrDefault();
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
    }
}

