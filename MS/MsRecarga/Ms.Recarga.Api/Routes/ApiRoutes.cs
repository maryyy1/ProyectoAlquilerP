namespace Ms.Recarga.Api.Routes
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class RouteRecarga
        {
            // Read
            public const string GetAll = Base + "/recarga/all";
            public const string GetById = Base + "/recarga/{id}";

            // Write
            public const string Create = Base + "/recarga/create";
            public const string Update = Base + "/recarga/update";
            public const string Delete = Base + "/recarga/delete";
        }

    }
}
