using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ms.Pelicula.Infraestructura.DBMongo
{
    public class DBMongo
    {
        public MongoClient client;
        public IMongoDatabase db;

        public DBMongo()
        {
            client = new MongoClient("mongodb://localhost:27017");
            db = client.GetDatabase("TDB_productos");
        }
    }
}
