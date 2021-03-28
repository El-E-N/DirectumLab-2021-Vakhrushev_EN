using DataService.Models;

namespace DataService.Repositories
{
    public class PlayerMemoryRepository : MemoryRepository<Player>
    {
        public PlayerMemoryRepository(PlayerContext context) : base(context) { }
    }
}
