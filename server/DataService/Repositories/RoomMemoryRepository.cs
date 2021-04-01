using DataService.Models;
using DataService.Models.Contexts;

namespace DataService.Repositories
{
    /// <summary>
    /// Репозиторий комнат.
    /// </summary>
    public class RoomMemoryRepository : MemoryRepository<Room>
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context">Контекст.</param>
        public RoomMemoryRepository(RoomContext context) : base(context) { }
    }
}
