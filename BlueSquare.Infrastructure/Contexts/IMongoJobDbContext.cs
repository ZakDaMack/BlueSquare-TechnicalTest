using MongoDB.Driver;

namespace BlueSquare.Infrastructure.Contexts
{
    public interface IMongoJobDbContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
