using AngularServer.Interfaces;
using AngularServer.Models;
using AngularServer.Services;
using AngularServer.Utility;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<BookStoreDbSettings>(
        builder.Configuration.GetSection(nameof(BookStoreDbSettings)));

builder.Services.AddSingleton<IMongoConnection, MongoConnection>();
builder.Services.AddSingleton<IBookService, BookService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});


var app = builder.Build();

app.UseCors("AllowOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/books", async ([FromServices] IBookService service) =>
{
    return await service.GetAllBooks();
});

app.MapGet("/books/{id}", async ([FromServices] IBookService service, string id) =>
{
    return await service.GetBook(id);
});

app.MapDelete("/books/{id}", async ([FromServices] IBookService service, string id) =>
{
    await service.Delete(id);
});

app.MapPut("/books/{id}", async ([FromServices] IBookService service, string id, Book book) =>
{
    return await service.Update(id, book);
});

app.MapPost("/books", async ([FromServices] IBookService service, Book book) =>
{
    return await service.Add(book);
});


app.Run();


