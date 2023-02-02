using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Driver;
using Release.MongoDB.Repository;
using Ms.Recarga.Aplicacion.Recarga;
using Ms.Recarga.Infraestructura;
using dominio = Ms.Recarga.Dominio.Entidades;

namespace Ms.Recarga.Aplicacion
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
            services.TryAddScoped<ICollectionContext<dominio.Recarga>>(x => new CollectionContext<dominio.Recarga>(x.GetService<IDbContext>()));

            //Como Repo
            services.TryAddScoped<IBaseRepository<dominio.Recarga>>(x => new BaseRepository<dominio.Recarga>(x.GetService<IDbContext>()));

            #endregion

            #region Servicios

            services.AddScoped<IRecargaService, RecargaService>();

            #endregion

            return services;
        }

    }
}
