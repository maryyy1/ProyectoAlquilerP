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
            public const string GetAll = Base + "/pelicula/all";
            public const string GetById = Base + "/pelicula/search";

            // Write
            public const string Create = Base + "/pelicula/create";
            public const string Update = Base + "/pelicula/update";
            public const string Delete = Base + "/pelicula/delete";
        }

        public static class RouteDirector
        {
            // Read
            public const string GetAll = Base + "/director/all";
            public const string GetById = Base + "/director/search";

            // Write
            public const string Create = Base + "/director/create";
            public const string Update = Base + "/director/update";
            public const string Delete = Base + "/director/delete";
        }
    }
}
