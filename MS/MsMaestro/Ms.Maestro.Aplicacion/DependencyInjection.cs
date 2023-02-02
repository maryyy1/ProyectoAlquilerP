using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Driver;
using Release.MongoDB.Repository;
using Ms.Maestro.Aplicacion.Enumerado;
using Ms.Maestro.Aplicacion.TipoEnumerado;
using Ms.Maestro.Infraestructura;
using dominio = Ms.Maestro.Dominio.Entidades;

namespace Ms.Maestro.Aplicacion
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
            services.TryAddScoped<ICollectionContext<dominio.Enumerado>>(x => new CollectionContext<dominio.Enumerado>(x.GetService<IDbContext>()));
            services.TryAddScoped<ICollectionContext<dominio.TipoEnumerado>>(x => new CollectionContext<dominio.TipoEnumerado>(x.GetService<IDbContext>()));

            //Como Repo
            services.TryAddScoped<IBaseRepository<dominio.Enumerado>>(x => new BaseRepository<dominio.Enumerado>(x.GetService<IDbContext>()));
            services.TryAddScoped<IBaseRepository<dominio.TipoEnumerado>>(x => new BaseRepository<dominio.TipoEnumerado>(x.GetService<IDbContext>()));

            #endregion

            #region Servicios

            services.AddScoped<IEnumeradoService, EnumeradoService>();
            services.AddScoped<ITipoEnumeradoService, TipoEnumeradoService>();

            #endregion

            return services;
        }

    }
}
