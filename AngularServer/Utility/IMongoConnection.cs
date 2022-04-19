using AngularServer.Models;
using MongoDB.Driver;

namespace AngularServer.Utility;

public interface IMongoConnection
{
    IMongoCollection<T> GetCollection<T>(Func<BookStoreDbSettings, string> collection) where T : class;
}