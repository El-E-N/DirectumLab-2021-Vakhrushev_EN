using DataService.Models;
using DataService.Models.Contexts;

namespace DataService.Repositories
{
    /// <summary>
    /// Репозиторий игроков.
    /// </summary>
    public class PlayerMemoryRepository : MemoryRepository<Player>
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context">Контекст.</param>
        public PlayerMemoryRepository(PlayerContext context) : base(context)
        { 
        }
    }
}
