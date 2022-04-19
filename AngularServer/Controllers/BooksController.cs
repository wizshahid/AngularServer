using AngularServer.Interfaces;
using AngularServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService bookService;

    public BooksController(IBookService bookService)
    {
        this.bookService = bookService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Book book)
    {
        var result = await bookService.Add(book);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromRoute] string id, [FromBody] Book book)
    {
        var result = await bookService.Update(id, book);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        await bookService.Delete(id);
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        var result = await bookService.GetBook(id);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await bookService.GetAllBooks();
        return Ok(result);
    }
}
