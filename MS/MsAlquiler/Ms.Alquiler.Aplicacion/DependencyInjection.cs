using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Driver;
using Release.MongoDB.Repository;
using Ms.Alquiler.Aplicacion.Alquiler;
using Ms.Alquiler.Aplicacion.DetalleAlquiler;
using Ms.Alquiler.Infraestructura;
using dominio = Ms.Alquiler.Dominio.Entidades;

namespace Ms.Alquiler.Aplicacion
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicacion(this IServiceCollection services, IConfiguration configuration) 
        {
            #region Mongo

            string cs = configuration.GetSection("DBSettings:ConnectionString").Value;
            var dbUrl = new MongoUrl(cs);

            services.AddScoped<IDbContext>(x => new DbContext(dbUrl));

            //Entidades            
            services.TryAddScoped<ICollectionContext<dominio.Alquiler>>(x => new CollectionContext<dominio.Alquiler>(x.GetService<IDbContext>()));
            services.TryAddScoped<ICollectionContext<dominio.DetalleAlquiler>>(x => new CollectionContext<dominio.DetalleAlquiler>(x.GetService<IDbContext>()));

            //Como Repo
            services.TryAddScoped<IBaseRepository<dominio.Alquiler>>(x => new BaseRepository<dominio.Alquiler>(x.GetService<IDbContext>()));
            services.TryAddScoped<IBaseRepository<dominio.DetalleAlquiler>>(x => new BaseRepository<dominio.DetalleAlquiler>(x.GetService<IDbContext>()));

            #endregion

            #region Servicios

            services.AddScoped<IAlquilerService, AlquilerService>();
            services.AddScoped<IDetalleAlquilerService, DetalleAlquilerService>();

            #endregion

            return services;
        }

    }
}
