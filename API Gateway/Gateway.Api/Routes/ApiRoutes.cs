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
            public const string Update = Base + "/pelicula/update";
            public const string Delete = Base + "/pelicula/delete";
        }
        public static class RouteAlquiler
        {
            // Read
            public const string GetAll = Base + "/alquiler/all";

            // Write           
            public const string RegistrarAlquiler = Base + "/alquiler/create";

        }
    }
}
