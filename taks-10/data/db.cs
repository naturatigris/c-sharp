using Book.Models;
using Microsoft.EntityFrameworkCore;

namespace Book.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<BookModel> Books { get; set; }
    }
}
