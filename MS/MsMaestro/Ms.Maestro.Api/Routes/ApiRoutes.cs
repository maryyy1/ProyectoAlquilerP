namespace Ms.Maestro.Api.Routes
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class RouteEnumerado
        {
            // Read
            public const string GetAll = Base + "/enumerado/all";
            public const string GetById = Base + "/enumerado/{id}";

            // Write
            public const string Create = Base + "/enumerado/create";
            public const string Update = Base + "/enumerado/update";
            public const string Delete = Base + "/enumerado/delete";
        }

        public static class RouteTipoEnumerado
        {
            // Read
            public const string GetAll = Base + "/tipoEnumerado/all";
            public const string GetById = Base + "/tipoEnumerado/{id}";

            // Write
            public const string Create = Base + "/tipoEnumerado/create";
            public const string Update = Base + "/tipoEnumerado/update";
            public const string Delete = Base + "/tipoEnumerado/delete";
        }
    }
}
