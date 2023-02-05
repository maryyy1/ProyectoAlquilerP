using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Gateway.Aplicacion.Common;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;

namespace Gateway.Aplicacion
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicacion(this IServiceCollection services, IConfiguration configuration)
        {            
            // Clientes
            services.AddClientes(configuration);

            return services;
        }

        public static IServiceCollection AddClientes(this IServiceCollection services, IConfiguration configuration)
        {
            //CLIENT_SETTINGS
            var msSettings = new ClientSettings();
            configuration.Bind(nameof(ClientSettings), msSettings);

            #region Cliente Ms Peliculas
            
            services.AddHttpClient("MsPelicula", client =>
            {
                client.BaseAddress = new Uri(msSettings.PeliculasUrl);
            });
            
            services.AddHttpClient("MsAlquiler", client =>
            {
                client.BaseAddress = new Uri(msSettings.AlquileresUrl);
            });

            services.AddHttpClient("MsCliente", client =>
            {
                client.BaseAddress = new Uri(msSettings.ClientesUrl);
            });

            services.AddHttpClient("MsRecarga", client =>
            {
                client.BaseAddress = new Uri(msSettings.RecargasUrl);
            });

            #endregion

            services.AddTransient<PeliculasClient.IClient, PeliculasClient.Client>();
            services.AddTransient<AlquileresClient.IClient, AlquileresClient.Client>();
            services.AddTransient<ClientesClient.IClient, ClientesClient.Client>();
            services.AddTransient<RecargasClient.IClient, RecargasClient.Client>();

            return services;
        }
    }
}
