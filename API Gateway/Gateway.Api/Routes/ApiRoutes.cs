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
            public const string GetById = Base + "/pelicula/{id}";

            // Write
            public const string Create = Base + "/pelicula/create";
            public const string Delete = Base + "/pelicula/delete";
        }
        /*
        public static class RouteCliente
        {
            // Read
            public const string GetAll = Base + "/cliente/all";
            public const string GetById = Base + "/cliente/{id}";

            // Write
            public const string Create = Base + "/cliente/create";
            public const string Delete = Base + "/cliente/delete";
        }
        */
        public static class RouteAlquiler
        {
            // Read
            public const string GetAll = Base + "/alquiler/all";
            public const string GetById = Base + "/alquiler/{id}";
            // Write
            public const string Create = Base + "/alquiler/create";

        }

    }
}
