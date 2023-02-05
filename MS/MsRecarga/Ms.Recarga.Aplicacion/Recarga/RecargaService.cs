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

        public dominio.Recarga BuscarRecarga(int idRecarga)
        {
            Expression<Func<dominio.Recarga, bool>> filter = s => s.esEliminado == false && s.RecId == idRecarga;
            var item = (_recarga.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public bool ModificarRecarga(dominio.Recarga recarga)
        {
            Expression<Func<dominio.Recarga, bool>> filter = s => s.esEliminado == false && s.RecId == recarga.RecId;
            var recargaActual = (_recarga.Context().FindAsync(filter, null).Result).FirstOrDefault();
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

        public void EliminarRecarga(int idRecarga)
        {
            Expression<Func<dominio.Recarga, bool>> filter = s => s.esEliminado == false && s.RecId == idRecarga;
            var item = (_recarga.Context().FindOneAndDelete(filter, null));
            
        }
    }
}
