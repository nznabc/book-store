using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContext) : base(dbContext)
        {

        }

        public DbSet<Book> Books { get; set; } = null!;
    }
}
