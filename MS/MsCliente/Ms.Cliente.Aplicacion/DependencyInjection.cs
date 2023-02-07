using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Driver;
using Ms.Cliente.Aplicacion.Cliente;
using Ms.Cliente.Aplicacion.Tarjeta;
using Ms.Cliente.Infraestructura;
using Release.MongoDB.Repository;
using dominio = Ms.Cliente.Dominio.Entidades;

namespace Ms.Cliente.Aplicacion
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
            services.TryAddScoped<ICollectionContext<dominio.Cliente>>(x => new CollectionContext<dominio.Cliente>(x.GetService<IDbContext>()));
            services.TryAddScoped<ICollectionContext<dominio.Tarjeta>>(x => new CollectionContext<dominio.Tarjeta>(x.GetService<IDbContext>()));

            //Como Repo
            services.TryAddScoped<IBaseRepository<dominio.Cliente>>(x => new BaseRepository<dominio.Cliente>(x.GetService<IDbContext>()));
            services.TryAddScoped<IBaseRepository<dominio.Tarjeta>>(x => new BaseRepository<dominio.Tarjeta>(x.GetService<IDbContext>()));

            #endregion

            #region Servicios

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ITarjetaService, TarjetaService>();

            #endregion

            return services;
        }

    }
}
