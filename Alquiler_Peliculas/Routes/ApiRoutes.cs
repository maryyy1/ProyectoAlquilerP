namespace Ms.Pelicula.Api.Routes
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class RoutePelicula
        {
            // Read
            public const string GetAll = Base + "/producto/all";
            public const string GetById = Base + "/producto/{id}";

            // Write
            public const string Create = Base + "/producto/create";
            public const string Update = Base + "/producto/update";
            public const string Delete = Base + "/producto/delete";
        }

        public static class RouteDirector
        {
            // Read
            public const string GetAll = Base + "/director/all";
            public const string GetById = Base + "/director/{id}";

            // Write
            public const string Create = Base + "/director/create";
            public const string Update = Base + "/director/update";
            public const string Delete = Base + "/director/delete";
        }

        public static class RouteCliente
        {
            // Read
            public const string GetAll = Base + "/cliente/all";
            public const string GetById = Base + "/cliente/{id}";

            // Write
            public const string Create = Base + "/cliente/create";
            public const string Update = Base + "/cliente/update";
            public const string Delete = Base + "/cliente/delete";
        }
    }
}
