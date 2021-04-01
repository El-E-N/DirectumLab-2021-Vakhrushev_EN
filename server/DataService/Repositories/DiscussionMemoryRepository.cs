using DataService.Models;
using DataService.Models.Contexts;

namespace DataService.Repositories
{
    /// <summary>
    /// Репозиторий обсуждений.
    /// </summary>
    public class DiscussionMemoryRepository : MemoryRepository<Discussion>
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context">Контекст.</param>
        public DiscussionMemoryRepository(DiscussionContext context) : base(context) 
        {
        }
    }
}
