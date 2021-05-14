using System;
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

        /// <summary>
        /// Создание оценки.
        /// </summary>
        /// <param name="id">Id оценки.</param>
        /// <param name="cardId">Id карты.</param>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="playerId">Id игрока.</param>
        /// <param name="discussionId">Id обсуждения.</param>
        public void Create(Guid id, Guid? cardId, Guid roomId, Guid playerId, Guid discussionId)
        {
            this.Db.Items.Add(new Vote(id, cardId, roomId, playerId, discussionId));
            this.Db.SaveChanges();
        }
    }
}
