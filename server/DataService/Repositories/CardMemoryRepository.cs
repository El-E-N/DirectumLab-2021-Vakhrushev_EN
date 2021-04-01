using DataService.Models;
using DataService.Models.Contexts;

namespace DataService.Repositories
{
    /// <summary>
    /// Репозиторий карт.
    /// </summary>
    public class CardMemoryRepository : MemoryRepository<Card>
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context">Контекст.</param>
        public CardMemoryRepository(CardContext context) : base(context) { }
    }
}
