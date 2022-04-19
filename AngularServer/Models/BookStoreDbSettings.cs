﻿namespace AngularServer.Models;

public class BookStoreDbSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string BooksCollectionName { get; set; } = null!;

    public string AuthorCollectionName { get; set; } = null!;
}
