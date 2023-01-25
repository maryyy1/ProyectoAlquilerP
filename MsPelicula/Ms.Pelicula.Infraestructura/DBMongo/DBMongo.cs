using MongoDB.Driver;

namespace Ms.Pelicula.Infraestructura.DBMongo
{
    public class DBMongo
    {
        public MongoClient client;
        public IMongoDatabase db;

        public DBMongo()
        {
            client = new MongoClient("mongodb://localhost:27017");
            db = client.GetDatabase("DB_Pelicula");
        }
    }
}
