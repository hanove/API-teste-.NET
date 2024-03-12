var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var books = new List<Book>
{
    new Book(1, "O mito de Sísifo", "Albert Camus", 1942, "Filosofia"),
    new Book(2, "O estrangeiro", "Albert Camus", 1942, "Ficção Filosófica"),
    new Book(3, "Inferno", "Dan Brown", 2013, "Ficção"),
    new Book(4, "O Hobbit", "J. R. R. Tolkien", 1937, "Fantasia"),
    new Book(5, "O anticristo", "Friedrich Nietzsche", 1895, "Filosofia")
};

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/books", () => {
    return books;
});

app.MapGet("/books/{id}", (int id) => {
    return books.FirstOrDefault(x => x.ID == id, null);
});

app.MapPost("/books", (Book book) => {
    books.Add(book);
    return book;
});

app.MapPut("/books/{id}", (int id, Book book) => {
    var index = books.FindIndex(x => x.ID == id);
    books[index] = book;
    return book;
});

app.MapDelete("/books/{id}", (int id) => {
    var book = books.FirstOrDefault(x => x.ID == id, null);
    if (book != null)
    {
        books.Remove(book);
    }
    return id;
});

app.Run();
