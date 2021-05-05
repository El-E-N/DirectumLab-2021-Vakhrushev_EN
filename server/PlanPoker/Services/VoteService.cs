using DataService.Models;
using DataService.Repositories;
using System;
using System.Linq;

namespace PlanPoker.Services
{
    /// <summary>
    /// Сервис голосований.
    /// </summary>
    public class VoteService
    {
        /// <summary>
        /// Репозиторий с голосованиями.
        /// </summary>
        private readonly VoteMemoryRepository repository;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="repository">Репозиторий с голосованиями.</param>
        public VoteService(VoteMemoryRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Создание голоса.
        /// </summary>
        /// <param name="cardId">Id выбранной карты.</param>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="playerId">Id игрока.</param>
        /// <param name="discussionId">Id обсуждения.</param>
        /// <returns>Голос.</returns>
        public Vote Create(Guid cardId, Guid roomId, Guid playerId, Guid discussionId) 
        {
            var id = Guid.NewGuid();
            this.repository.Create(id, cardId, roomId, playerId, discussionId);
            return this.repository.Get(id);
        }

        /// <summary>
        /// Изменение выбора.
        /// </summary>
        /// <param name="voteId">Id оценки.</param>
        /// <param name="cardId">Id карты.</param>
        public void ChangeCard(Guid voteId, Guid cardId)
        {
            var discussionId = this.repository.Get(voteId).DiscussionId;
            var playerId = this.repository.Get(voteId).PlayerId;
            var roomId = this.repository.Get(voteId).RoomId;
            var vote = new Vote(voteId, cardId, roomId, playerId, discussionId);
            this.repository.Save(vote);
        }

        /// <summary>
        /// Получить оценку по id.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Оценка.</returns>
        public Vote GetVote(Guid id)
        {
            return this.repository.Get(id);
        }

        /// <summary>
        /// Получение всех оценок.
        /// </summary>
        /// <returns>Все голоса из базы данных.</returns>
        public IQueryable<Vote> GetAllVote()
        {
            return this.repository.GetItems();
        }
    }
}
