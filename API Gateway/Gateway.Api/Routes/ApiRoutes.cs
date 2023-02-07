namespace Gateway.Api.Routes
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class RoutePelicula
        {
            // Read
            public const string GetAll = Base + "/pelicula/all";
            public const string GetById = Base + "/pelicula/search";

            // Write
            public const string Create = Base + "/pelicula/create";
            public const string Update = Base + "/pelicula/update";
            public const string Delete = Base + "/pelicula/delete";
        }
        
        public static class RouteCliente
        {
            // Read
            public const string GetAll = Base + "/cliente/all";
            public const string GetById = Base + "/cliente/search";

            // Write
            public const string Create = Base + "/cliente/create";
            public const string Update = Base + "/cliente/update";
            public const string Delete = Base + "/cliente/delete";
        }
        
        public static class RouteAlquiler
        {
            // Read
            public const string GetAll = Base + "/alquiler/all";
            public const string GetById = Base + "/alquiler/search";
            // Write
            public const string Alquilar = Base + "/alquiler/alquilar";
            public const string Create = Base + "/alquiler/create";
            public const string Update = Base + "/alquiler/update";
            public const string Delete = Base + "/alquiler/delete";

        }

        public static class RouteRecarga
        {
            // Read
            public const string GetAll = Base + "/recarga/all";
            public const string GetById = Base + "/recarga/search";
            // Write
            public const string Create = Base + "/recarga/create";
            public const string Recargar = Base + "/recarga/recargar";
            public const string Update = Base + "/recarga/update";
            public const string Delete = Base + "/recarga/delete";

        }

    }
}
