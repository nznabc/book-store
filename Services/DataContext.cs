using Microsoft.EntityFrameworkCore;
using Models;

namespace Services
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContext) : base(dbContext)
        {

        }

        public DbSet<Book> Books { get; set; } = null!;
    }
}
