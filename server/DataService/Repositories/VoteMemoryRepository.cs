using DataService.Models;
using DataService.Models.Contexts;

namespace DataService.Repositories
{
    /// <summary>
    /// Репозиторий оценок.
    /// </summary>
    public class VoteMemoryRepository : MemoryRepository<Vote>
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context">Контекст.</param>
        public VoteMemoryRepository(VoteContext context) : base(context) 
        {
        }
    }
}
