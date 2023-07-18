using Microsoft.EntityFrameworkCore;

namespace Webgentle.BookStore.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options) { 

        }
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-AN0ID1G\\SQLEXPRESS;Database=BookStore;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
