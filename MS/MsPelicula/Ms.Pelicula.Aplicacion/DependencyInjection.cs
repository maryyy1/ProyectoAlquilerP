using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Driver;
using Release.MongoDB.Repository;
using Ms.Pelicula.Aplicacion.Director;
using Ms.Pelicula.Aplicacion.Pelicula;
using Ms.Pelicula.Infraestructura;
using dominio = Ms.Pelicula.Dominio.Entidades;

namespace Ms.Pelicula.Aplicacion
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
            services.TryAddScoped<ICollectionContext<dominio.Pelicula>>(x => new CollectionContext<dominio.Pelicula>(x.GetService<IDbContext>()));
            services.TryAddScoped<ICollectionContext<dominio.Director>>(x => new CollectionContext<dominio.Director>(x.GetService<IDbContext>()));

            //Como Repo
            services.TryAddScoped<IBaseRepository<dominio.Pelicula>>(x => new BaseRepository<dominio.Pelicula>(x.GetService<IDbContext>()));
            services.TryAddScoped<IBaseRepository<dominio.Director>>(x => new BaseRepository<dominio.Director>(x.GetService<IDbContext>()));

            #endregion

            #region Servicios

            services.AddScoped<IPeliculaService, PeliculaService>();
            services.AddScoped<IDirectorService, DirectorService>();

            #endregion

            return services;
        }

    }
}
