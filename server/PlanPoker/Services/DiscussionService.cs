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
        public DiscussionService(DiscussionMemoryRepository repository) { this.repository = repository; }

        /// <summary>
        /// Создание обсуждения.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="name">Название комнаты.</param>
        /// <returns>Созданную комнату.</returns>
        public Discussion Create(Guid roomId, string name) 
        {
            var id = Guid.NewGuid();
            this.repository.Create(id, roomId, name, new List<Guid> { });
            return this.repository.Get(id);
        }

        /// <summary>
        /// Получение обсуждения по id.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Обсуждение.</returns>
        public Discussion GetById(Guid id) => this.repository.Get(id);

        /// <summary>
        /// Закрытие обсуждения и запись окончания.
        /// </summary>
        /// <param name="discussionId">Id обсуждения.</param>
        public Discussion Close(Guid discussionId) 
        {
            var discussion = this.repository.Get(discussionId);
            var name = discussion.Name;
            var startAt = discussion.StartAt;
            var roomId = discussion.RoomId;
            var voteIds = discussion.VoteIds;
            var listVoteIds = new List<Guid>(voteIds);
            var item = new Discussion(discussionId, roomId, name, startAt, DateTime.Now, listVoteIds);
            this.repository.Save(item);
            return this.repository.Get(discussionId);
        }

        /// <summary>
        /// Добавление голоса в обсуждение. Если он существует, то происходи замена.
        /// </summary>
        /// <param name="discussionId">Id обсуждения.</param>
        /// <param name="voteId">Id голоса.</param>
        public Discussion AddVote(Guid discussionId, Guid voteId) 
        {
            var discussion = this.repository.Get(discussionId);
            var name = discussion.Name;
            var startAt = discussion.StartAt;
            var roomId = discussion.RoomId;
            var voteIds = discussion.VoteIds;
            voteIds.Add(voteId);
            var listVoteIds = new List<Guid>(voteIds);
            var item = new Discussion(discussionId, roomId, name, startAt, DateTime.Now, listVoteIds);
            this.repository.Save(item);
            return this.repository.Get(discussionId);
        }

        /// <summary>
        /// Возвращает список оценок.
        /// </summary>
        /// <param name="discussionId">Id обсуждения.</param>
        /// <returns>Список Id оценок.</returns>
        public ICollection<Guid> GetVoteIds(Guid discussionId) => this.repository.Get(discussionId).VoteIds;

        /// <summary>
        /// Возвращает список обсуждений.
        /// </summary>
        /// <returns>Все обсуждения из базы данных.</returns>
        public IQueryable<Discussion> GetDiscussions() => this.repository.GetItems();
    }
}
