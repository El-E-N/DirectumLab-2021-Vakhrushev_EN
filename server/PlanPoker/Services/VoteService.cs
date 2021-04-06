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
        public Vote Create(string cardId, string roomId, string playerId, string discussionId) 
        {
            var id = Guid.NewGuid();
            this.repository.Create(
                id, 
                Guid.Parse(cardId.Replace(" ", string.Empty)), 
                Guid.Parse(roomId.Replace(" ", string.Empty)), 
                Guid.Parse(playerId.Replace(" ", string.Empty)), 
                Guid.Parse(discussionId.Replace(" ", string.Empty)));
            return this.repository.Get(id);
        }

        /// <summary>
        /// Изменение выбора.
        /// </summary>
        /// <param name="voteId">Id оценки.</param>
        /// <param name="cardId">Id карты.</param>
        public void ChangeCard(string voteId, string cardId)
        {
            var discussionId = this.repository.Get(Guid.Parse(voteId.Replace(" ", string.Empty))).DiscussionId;
            var playerId = this.repository.Get(Guid.Parse(voteId.Replace(" ", string.Empty))).PlayerId;
            var roomId = this.repository.Get(Guid.Parse(voteId.Replace(" ", string.Empty))).RoomId;
            this.repository.Save(new Vote(Guid.Parse(voteId.Replace(" ", string.Empty)), Guid.Parse(cardId.Replace(" ", string.Empty)), roomId, playerId, discussionId));
        }

        /// <summary>
        /// Получить оценку по id.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Оценка.</returns>
        public Vote GetVote(string id)
        {
            return this.repository.Get(Guid.Parse(id.Replace(" ", string.Empty)));
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
