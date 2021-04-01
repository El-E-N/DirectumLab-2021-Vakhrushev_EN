using Microsoft.EntityFrameworkCore;

namespace DataService.Models.Contexts
{
    /// <summary>
    /// Контекст оценки.
    /// </summary>
    public class VoteContext : ItemContext<Vote> 
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="options">Опции.</param>
        public VoteContext(DbContextOptions<VoteContext> options) : base(options) { }
    }
}
