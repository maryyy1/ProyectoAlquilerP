
namespace Gateway.Aplicacion.PeliculasClient
{
    public partial class Client
    {
        public Client(System.Net.Http.IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MsPelicula");
            _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>(CreateSerializerSettings);
        }
    }
}
