using DataService.Models;

namespace DataService.Repositories
{
    public class RoomMemoryRepository : MemoryRepository<Room>
    {
        public RoomMemoryRepository(RoomContext context) : base(context) { }
    }
}
