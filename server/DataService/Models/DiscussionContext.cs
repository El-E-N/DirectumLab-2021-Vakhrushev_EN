using Microsoft.EntityFrameworkCore;

namespace DataService.Models
{
    public class DiscussionContext : ItemContext<Discussion>
    {
        public DiscussionContext(DbContextOptions<DiscussionContext> options) : base(options) { }
    }
}