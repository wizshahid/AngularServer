using AngularServer.Interfaces;
using AngularServer.Models;
using AngularServer.Utility;
using MongoDB.Driver;

namespace AngularServer.Services;

public class BookService : IBookService
{
    private readonly IMongoCollection<Book> booksCollection;

    public BookService(IMongoConnection mongoConnection)
    {
        booksCollection = mongoConnection.GetCollection<Book>(x => x.BooksCollectionName);
    }

    public async Task<Book> Add(Book book)
    {
        await booksCollection.InsertOneAsync(book);
        return book;
    }

    public async Task Delete(string id)
    {
        await booksCollection.DeleteOneAsync(id);
    }

    public async Task<List<Book>> GetAllBooks()
    {
        return await booksCollection.Find(x => true).ToListAsync();
    }

    public async Task<Book> GetBook(string id)
    {
        return await booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Book> Update(string id, Book book)
    {
        await booksCollection.ReplaceOneAsync(id, book);
        return book;
    }
}
