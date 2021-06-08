using DataService.Models;
using DataService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

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
            var voteIds = JsonSerializer.Deserialize<ICollection<Guid>>(discussion.VoteIds);
            var item = new Discussion(discussionId, roomId, name, startAt, DateTime.Now, voteIds);
            this.repository.Save(item);
            return this.repository.Get(discussionId);
        }

        public Discussion SetName(Guid discussionId, string name)
        {
            var discussion = this.repository.Get(discussionId);
            var startAt = discussion.StartAt;
            var endAt = discussion.EndAt;
            var roomId = discussion.RoomId;
            var voteIds = JsonSerializer.Deserialize<ICollection<Guid>>(discussion.VoteIds);
            var item = new Discussion(discussionId, roomId, name, startAt, endAt, voteIds);
            this.repository.Save(item);
            return this.repository.Get(discussionId);
        }

        /// <summary>
        /// Добавление голоса в обсуждение. Если он существует, то происходит замена.
        /// </summary>
        /// <param name="discussionId">Id обсуждения.</param>
        /// <param name="voteId">Id голоса.</param>
        public Discussion AddVote(Guid discussionId, Guid voteId) 
        {
            var discussion = this.repository.Get(discussionId);
            var name = discussion.Name;
            var startAt = discussion.StartAt;
            var endAt = discussion.EndAt;
            var roomId = discussion.RoomId;
            var voteIds = JsonSerializer.Deserialize<ICollection<Guid>>(discussion.VoteIds);
            voteIds = new List<Guid>(voteIds.Append(voteId));
            var item = new Discussion(discussionId, roomId, name, startAt, endAt, voteIds);
            this.repository.Save(item);
            return this.repository.Get(discussionId);
        }

        /// <summary>
        /// Удаление голоса из обсуждения.
        /// </summary>
        /// <param name="discussionId">Id обсуждения.</param>
        /// <param name="voteId">Id голоса.</param>
        public Discussion RemoveVote(Guid discussionId, Guid voteId)
        {
            var discussion = this.repository.Get(discussionId);
            var name = discussion.Name;
            var startAt = discussion.StartAt;
            var endAt = discussion.EndAt;
            var roomId = discussion.RoomId;
            var voteIds = JsonSerializer.Deserialize<ICollection<Guid>>(discussion.VoteIds);
            voteIds = new List<Guid>(voteIds.Where(id => id != voteId));
            var item = new Discussion(discussionId, roomId, name, startAt, endAt, voteIds);
            this.repository.Save(item);
            return this.repository.Get(discussionId);
        }

        /// <summary>
        /// Получить обсуждения одной комнаты.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <returns>Обсуждения.</returns>
        public IQueryable<Discussion> GetDiscussionsByRoomId(Guid roomId) => this.GetDiscussions().Where(discussion => discussion.RoomId == roomId);

        /// <summary>
        /// Возвращает список оценок.
        /// </summary>
        /// <param name="discussionId">Id обсуждения.</param>
        /// <returns>Список Id оценок.</returns>
        public ICollection<Guid> GetVoteIds(Guid discussionId)
        {
            var voteIds = this.repository.Get(discussionId).VoteIds;
            return JsonSerializer.Deserialize<ICollection<Guid>>(voteIds);
        }

        public void Delete(Guid discussionId)
        {
            this.repository.Delete(discussionId);
        }

        /// <summary>
        /// Возвращает список обсуждений.
        /// </summary>
        /// <returns>Все обсуждения из базы данных.</returns>
        public IQueryable<Discussion> GetDiscussions() => this.repository.GetItems();
    }
}
