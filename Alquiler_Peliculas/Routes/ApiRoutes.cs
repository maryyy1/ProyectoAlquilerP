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
    }
}
