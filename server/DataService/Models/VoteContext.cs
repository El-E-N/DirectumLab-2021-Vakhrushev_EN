using Microsoft.EntityFrameworkCore;

namespace DataService.Models
{
    public class VoteContext : ItemContext<Vote> 
    {
        public VoteContext(DbContextOptions<VoteContext> options) : base(options) { }
    }
}
