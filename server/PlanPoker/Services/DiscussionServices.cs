using DataService.Models;
using DataService.Repositories;
using System;
using System.Collections.Generic;

namespace PlanPoker.Services
{
    public class DiscussionServices
    {
        private readonly DiscussionMemoryRepository repository;

        public DiscussionServices(DiscussionMemoryRepository repository)
        {
            this.repository = repository;
        }

        public void Create(Guid roomId, string name) 
        {
            var id = Guid.NewGuid();
            this.repository.Create(new Discussion(id, roomId, name));
        }

        /// <summary>
        /// Закрытие обсуждения и запись окончания.
        /// </summary>
        public void Close(Guid discussionId) 
        {
            this.repository.Get(discussionId).EndAt = DateTime.Now;
        }

        public void AddVote(Guid discussionId, Guid voteId) 
        {
            this.repository.Get(discussionId).VoteIDs.Add(voteId);
        }

        public List<Guid> GetResults(Guid discussionId) 
        {
            return this.repository.Get(discussionId).VoteIDs;
        }
    }
}
