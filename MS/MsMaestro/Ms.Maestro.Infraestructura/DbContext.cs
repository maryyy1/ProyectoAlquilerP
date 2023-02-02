using MongoDB.Driver;
using Release.MongoDB.Repository;

namespace Ms.Maestro.Infraestructura
{
    public class DbContext : DataContext, IDbContext
    {
        public DbContext(MongoUrl mongoUrl) : base(mongoUrl)
        {
        }
    }
}
