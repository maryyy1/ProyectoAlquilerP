namespace Ms.Cliente.Api.Routes
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

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

        public static class RouteTarjeta
        {
            // Read
            public const string GetAll = Base + "/tarjeta/all";
            public const string GetById = Base + "/tarjeta/{id}";

            // Write
            public const string Create = Base + "/tarjeta/create";
            public const string Update = Base + "/tarjeta/update";
            public const string Delete = Base + "/tarjeta/delete";
        }
    }
}

