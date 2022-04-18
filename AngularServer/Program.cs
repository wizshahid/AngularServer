using AngularServer.Models;
using AngularServer.Utility;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.MapGet("/books", async () =>
{
    var collection = MongoConnection.GetBooksCollection<Book>("Books");
    return await collection.Find(x => true).ToListAsync();
});

app.MapGet("/books/{id}", async (string id) =>
{
    var collection = MongoConnection.GetBooksCollection<Book>("Books");
    return await collection.Find(x => x.Id == id).FirstOrDefaultAsync();
});

app.MapDelete("/books/{id}", async (string id) =>
{
    var collection = MongoConnection.GetBooksCollection<Book>("Books");
    return await collection.DeleteOneAsync(x => x.Id == id);
});

app.MapPut("/books/{id}", async (string id, Book book) =>
{
    var collection = MongoConnection.GetBooksCollection<Book>("Books");
    return await collection.ReplaceOneAsync(x => x.Id == id, book);
});

app.MapPost("/books", async (Book book) =>
{
    var collection = MongoConnection.GetBooksCollection<Book>("Books");
    await collection.InsertOneAsync(book);
    return book;
});


app.Run();


