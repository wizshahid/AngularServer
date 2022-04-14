using MongoDB.Driver;

namespace AngularServer.Utility;

public class MongoConnection
{
   public static IMongoCollection<T> GetBooksCollection<T>(string collectionName) where T : class
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var db = client.GetDatabase("AngularServerDB");
        return db.GetCollection<T>(collectionName);
    }
}
