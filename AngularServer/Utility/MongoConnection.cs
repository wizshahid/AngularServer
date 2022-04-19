using AngularServer.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AngularServer.Utility;

public class MongoConnection : IMongoConnection
{
    private readonly BookStoreDbSettings settings;

    public MongoConnection(IOptions<BookStoreDbSettings> options)
    {
        settings = options.Value;
    }
    public IMongoCollection<T> GetCollection<T>(Func<BookStoreDbSettings, string> collection) where T : class
    {
        var client = new MongoClient(settings.ConnectionString);
        var db = client.GetDatabase(settings.DatabaseName);
        return db.GetCollection<T>(collection(settings));
    }
}
