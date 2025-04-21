using Book.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;
namespace taks_10.Tests;

public class BookServiceTests
{
    private readonly BookService _service;
    private readonly DBContext _context;

    public BookServiceTests()
    {
        var options = new DbContextOptionsBuilder<DBContext>()
            .UseInMemoryDatabase(databaseName: "BookTestDb")
            .Options;

        _context = new DBContext(options);
        _service = new BookService(_context);
    }

    [Fact]
    public async Task AddBookAsync_Should_Add_Book()
    {
        var book = await _service.AddBookAsync("Test Book", 99);

        Assert.NotNull(book);
        Assert.Equal("Test Book", book.Name);
        Assert.Equal(99, book.Price);
    }

    [Fact]
    public async Task DeleteBookAsync_Should_Return_False_If_Not_Exists()
    {
        var result = await _service.DeleteBookAsync(999);
        Assert.False(result);
    }

    [Fact]
    public async Task GetAllBooksAsync_Should_Return_List()
    {
        await _service.AddBookAsync("A", 10);
        var books = await _service.GetAllBooksAsync();

        Assert.True(books.Count >= 1);
    }
    [Fact]
public async Task UpdateBookAsync_Should_Update_Existing_Book()
{
    var book = await _service.AddBookAsync("Original", 20);
    var updated = await _service.UpdateBookAsync(book.Id, "Updated", 50);

    Assert.NotNull(updated);
    Assert.Equal("Updated", updated.Name);
    Assert.Equal(50, updated.Price);
}
[Fact]
public async Task DeleteBookAsync_Should_Delete_Existing_Book()
{
    var book = await _service.AddBookAsync("To Delete", 40);
    var result = await _service.DeleteBookAsync(book.Id);

    Assert.True(result);
    var books = await _service.GetAllBooksAsync();
    Assert.DoesNotContain(books, b => b.Id == book.Id);
}

}
