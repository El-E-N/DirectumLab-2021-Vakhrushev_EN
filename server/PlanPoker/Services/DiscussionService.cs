using DataService.Models;
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
        private readonly IRepository<Discussion> repository;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="repository">Репозиторий обсуждения.</param>
        public DiscussionService(IRepository<Discussion> repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Создание обсуждения.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="name">Название комнаты.</param>
        /// <returns>Созданную комнату.</returns>
        public Discussion Create(Guid roomId, string name) 
        {
            var id = Guid.NewGuid();
            this.repository.Create(new Discussion(id, roomId, name));
            this.repository.Save();
            return this.repository.Get(id);
        }

        /// <summary>
        /// Закрытие обсуждения и запись окончания.
        /// </summary>
        /// <param name="discussionId">Id обсуждения.</param>
        public void Close(Guid discussionId) 
        {
            this.repository.Get(discussionId).EndAt = DateTime.Now;
            this.repository.Save();
        }

        /// <summary>
        /// Добавление голоса в обсуждение. Если он существует, то происходи замена.
        /// </summary>
        /// <param name="discussionId">Id обсуждения.</param>
        /// <param name="voteId">Id голоса.</param>
        public void AddVote(Guid discussionId, Guid voteId) 
        {
            this.repository.Get(discussionId).VoteIDs.Add(voteId);
            this.repository.Save();
        }

        /// <summary>
        /// Возвращает список результатов.
        /// </summary>
        /// <param name="discussionId">Id обсуждения.</param>
        /// <returns>Список результатов.</returns>
        public List<Guid> GetResults(Guid discussionId) 
        {
            return this.repository.Get(discussionId).VoteIDs;
        }

        /// <summary>
        /// Просто для проверки работы.
        /// </summary>
        /// <returns>Все обсуждения из базы данных.</returns>
        public IQueryable<Discussion> GetAll()
        {
            return this.repository.GetAll();
        }
    }
}
