namespace Ms.Pelicula.Infraestructura.DBSetting
{
    public class DBSetting : IDBSettings
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Collection { get; set; }
    }

    public interface IDBSettings
    {
        string Server { get; set; }
        string Database { get; set; }
        string Collection { get; set; }
    }
}
