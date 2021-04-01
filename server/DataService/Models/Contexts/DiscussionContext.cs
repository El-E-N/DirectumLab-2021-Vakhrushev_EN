using Microsoft.EntityFrameworkCore;

namespace DataService.Models.Contexts
{
    /// <summary>
    /// Контекст обсуждений.
    /// </summary>
    public class DiscussionContext : ItemContext<Discussion>
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="options">Опции контекста.</param>
        public DiscussionContext(DbContextOptions<DiscussionContext> options) : base(options) 
        {
        }
    }
}