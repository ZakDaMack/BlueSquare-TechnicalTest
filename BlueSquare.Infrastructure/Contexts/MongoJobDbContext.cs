using BlueSquare.Infrastructure.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BlueSquare.Infrastructure.Contexts
{
    public class MongoJobDbContext : IMongoJobDbContext
    {
        private IMongoDatabase _mongoDb { get; }
        private MongoClient _mongoClient { get; }

        public MongoJobDbContext(IOptions<MongoOptions> mongoOptions)
        {
            _mongoClient = new MongoClient(mongoOptions.Value.ConnectionString);
            _mongoDb = _mongoClient.GetDatabase(mongoOptions.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _mongoDb.GetCollection<T>(name);
        }
    }
}
