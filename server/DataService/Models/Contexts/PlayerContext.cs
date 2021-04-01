using Microsoft.EntityFrameworkCore;

namespace DataService.Models.Contexts
{
    /// <summary>
    /// Контекст игрока.
    /// </summary>
    public class PlayerContext : ItemContext<Player>
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="options">Опции.</param>
        public PlayerContext(DbContextOptions<PlayerContext> options) : base(options) 
        { 
        }
    }
}
