using Microsoft.EntityFrameworkCore;

namespace DataService.Models
{
    public class ItemContext<T> : DbContext
        where T : class
    {
        public ItemContext(DbContextOptions options) : base(options)
        { }

        public DbSet<T> Items { get; set; }
    }
}
