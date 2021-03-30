using Microsoft.EntityFrameworkCore;

namespace DataService.Models
{
    public class RoomContext : ItemContext<Room> 
    { 
        public RoomContext(DbContextOptions<RoomContext> options) : base(options) { }
    }
}
