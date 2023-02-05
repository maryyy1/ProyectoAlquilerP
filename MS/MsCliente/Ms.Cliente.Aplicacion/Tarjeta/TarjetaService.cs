using MongoDB.Driver;
using Release.MongoDB.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using dominio = Ms.Cliente.Dominio.Entidades;

namespace Ms.Cliente.Aplicacion.Tarjeta
{

    public class TarjetaService : ITarjetaService
    {
        private readonly ICollectionContext<dominio.Tarjeta> _tarjeta;
        private readonly IBaseRepository<dominio.Tarjeta> _tarjetaR;

        public TarjetaService(ICollectionContext<dominio.Tarjeta> tarjeta, 
                                IBaseRepository<dominio.Tarjeta> tarjetaR)
        {
            _tarjeta = tarjeta;
            _tarjetaR = tarjetaR;
        }

        public List<dominio.Tarjeta> ListarTarjetas()
        {
            Expression<Func<dominio.Tarjeta, bool>> filter = s => s.esEliminado == false;
            var items = (_tarjeta.Context().FindAsync(filter, null).Result).ToList();

            return items;
        }

        public bool RegistrarTarjeta(dominio.Tarjeta tarjeta)
        {
            tarjeta.esEliminado = false;
            tarjeta.fechaCreacion =DateTime.Now;
            tarjeta.esActivo = true;
            _tarjetaR.InsertOne(tarjeta);

            return true;
        }

        public dominio.Tarjeta BuscarTarjeta(int idTarjeta)
        {
            Expression<Func<dominio.Tarjeta, bool>> filter = s => s.esEliminado == false && s.TarId == idTarjeta;
            var item = (_tarjeta.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public bool ModificarTarjeta(dominio.Tarjeta tarjeta)
        {
            Expression<Func<dominio.Tarjeta, bool>> filter = s => s.esEliminado == false && s.TarId == tarjeta.TarId;
            var tarjetaActual = (_tarjeta.Context().FindAsync(filter, null).Result).FirstOrDefault();
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

        public void EliminarTarjeta(int idTarjeta)
        {
            Expression<Func<dominio.Tarjeta, bool>> filter = s => s.esEliminado == false && s.TarId == idTarjeta;
            var item = (_tarjeta.Context().FindOneAndDelete(filter, null));
            
        }
    }
}
