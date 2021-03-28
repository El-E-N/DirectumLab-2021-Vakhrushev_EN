using System.Data.Entity;

namespace DataService.Models
{
    public class ItemContext<T> : DbContext
        where T : class
    {
        public ItemContext() : base("DefaultConnection")
        { }

        public DbSet<T> Items { get; set; }
    }
}
