using AngularServer.Models;

namespace AngularServer.Interfaces;

public interface IBookService
{
    Task<Book> Add(Book book);

    Task<Book> Update(string id, Book book);

    Task<Book> GetBook(string id);

    Task<List<Book>> GetAllBooks();

    Task Delete(string id);
}
