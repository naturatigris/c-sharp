using Book.Data;
using Book.Models;
using Microsoft.EntityFrameworkCore;
public interface IBookService
{
    Task<List<BookModel>> GetAllBooksAsync();
    Task<BookModel> AddBookAsync(string name, decimal price);
    Task<BookModel?> UpdateBookAsync(int id, string name, decimal price);
    Task<bool> DeleteBookAsync(int id);
}

public class BookService : IBookService
{
    private readonly DBContext _db;

    public BookService(DBContext db)
    {
        _db = db;
    }

    public async Task<List<BookModel>> GetAllBooksAsync() =>
        await _db.Books.ToListAsync();

    public async Task<BookModel> AddBookAsync(string name, decimal price)
    {
        var book = new BookModel { Name = name, Price = price };
        _db.Books.Add(book);
        await _db.SaveChangesAsync();
        return book;
    }

    public async Task<BookModel?> UpdateBookAsync(int id, string name, decimal price)
    {
        var book = await _db.Books.FindAsync(id);
        if (book == null) return null;

        book.Name = name;
        book.Price = price;
        await _db.SaveChangesAsync();
        return book;
    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        var book = await _db.Books.FindAsync(id);
        if (book == null) return false;

        _db.Books.Remove(book);
        await _db.SaveChangesAsync();
        return true;
    }
}
