using DataService.Models;
using DataService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanPoker.Services
{
    /// <summary>
    /// Сервисы обсуждения.
    /// </summary>
    public class DiscussionService
    {
        /// <summary>
        /// Репозиторий сервиса обсуждений.
        /// </summary>
        private readonly DiscussionMemoryRepository repository;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="repository">Репозиторий обсуждения.</param>
        public DiscussionService(DiscussionMemoryRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Создание обсуждения.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="name">Название комнаты.</param>
        /// <returns>Созданную комнату.</returns>
        public Discussion Create(string roomId, string name) 
        {
            var id = Guid.NewGuid();
            this.repository.Create(id, Guid.Parse(roomId.Replace(" ", string.Empty)), name);
            return this.repository.Get(id);
        }

        /// <summary>
        /// Закрытие обсуждения и запись окончания.
        /// </summary>
        /// <param name="discussionId">Id обсуждения.</param>
        public void Close(string discussionId) 
        {
            this.repository.Get(Guid.Parse(discussionId.Replace(" ", string.Empty))).EndAt = DateTime.Now;
        }

        /// <summary>
        /// Добавление голоса в обсуждение. Если он существует, то происходи замена.
        /// </summary>
        /// <param name="discussionId">Id обсуждения.</param>
        /// <param name="voteId">Id голоса.</param>
        public void AddVote(string discussionId, string voteId) 
        {
            this.repository.Get(Guid.Parse(discussionId.Replace(" ", string.Empty))).VoteIds.Add(Guid.Parse(voteId.Replace(" ", string.Empty)));
            this.repository.SaveChanges();
        }

        /// <summary>
        /// Возвращает список оценок.
        /// </summary>
        /// <param name="discussionId">Id обсуждения.</param>
        /// <returns>Список Id оценок.</returns>
        public ICollection<Guid> GetVoteIds(string discussionId) 
        {
            return this.repository.Get(Guid.Parse(discussionId.Replace(" ", string.Empty))).VoteIds;
        }

        /// <summary>
        /// Получение обсуждения.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Обсуждение.</returns>
        public Discussion GetDiscussion(string id)
        {
            return this.repository.Get(Guid.Parse(id.Replace(" ", string.Empty)));
        }

        /// <summary>
        /// Возвращает список обсуждений.
        /// </summary>
        /// <returns>Все обсуждения из базы данных.</returns>
        public IQueryable<Discussion> GetDiscussions()
        {
            return this.repository.GetItems();
        }
    }
}
