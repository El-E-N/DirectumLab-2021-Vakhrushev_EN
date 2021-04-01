using Microsoft.EntityFrameworkCore;

namespace DataService.Models.Contexts
{
    /// <summary>
    /// Контекст комнаты.
    /// </summary>
    public class RoomContext : ItemContext<Room> 
    { 
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="options">Опции.</param>
        public RoomContext(DbContextOptions<RoomContext> options) : base(options) 
        { 
        }
    }
}
