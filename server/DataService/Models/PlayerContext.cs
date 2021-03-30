using Microsoft.EntityFrameworkCore;

namespace DataService.Models
{
    public class PlayerContext : ItemContext<Player>
    {
        public PlayerContext(DbContextOptions<PlayerContext> options) : base(options) { }
    }
}
