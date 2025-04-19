using Book.Data;
using Book.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Book API",
        Version = "v1"
    });
});


builder.Services.AddDbContext<DBContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionMiddleware>();


app.MapGet("/books", async (IBookService service, ILogger<Program> logger) =>
{
    logger.LogInformation("Fetching all books");
    return await service.GetAllBooksAsync();
});

app.MapPost("/books/add", async (IBookService service, string name, decimal price, ILogger<Program> logger) =>
{
    var newBook = await service.AddBookAsync(name, price);
    logger.LogInformation("Added book: {Book}", newBook);
    return Results.Created($"/books/{newBook.Id}", newBook);
});

app.MapPut("/books/update/{id}", async (IBookService service, int id, string name, decimal price, ILogger<Program> logger) =>
{
    var updatedBook = await service.UpdateBookAsync(id, name, price);
    if (updatedBook == null)
    {
        logger.LogWarning("Book with ID {Id} not found", id);
        return Results.NotFound("Book not found");
    }

    logger.LogInformation("Updated book with ID {Id}", id);
    return Results.Ok(updatedBook);
});

app.MapDelete("/books/delete/{id}", async (IBookService service, int id, ILogger<Program> logger) =>
{
    var deleted = await service.DeleteBookAsync(id);
    if (!deleted)
    {
        logger.LogWarning("Book with ID {Id} not found for deletion", id);
        return Results.NotFound("Book not found");
    }

    logger.LogInformation("Deleted book with ID {Id}", id);
    return Results.Ok($"Book with ID {id} deleted successfully.");
});


app.Run();
