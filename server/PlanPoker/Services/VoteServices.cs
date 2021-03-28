using DataService.Models;
using DataService.Repositories;
using System;

namespace PlanPoker.Services
{
    public class VoteServices
    {
        private readonly VoteMemoryRepository repository;

        public VoteServices(VoteMemoryRepository repository)
        {
            this.repository = repository;
        }

        public void Create(Guid cardId, Guid roomId, Guid playerId, Guid discussionId) 
        {
            var id = Guid.NewGuid();
            this.repository.Create(new Vote(id, cardId, roomId, playerId, discussionId));
        }

        public void ChangeCard(Guid voteId, Guid cardId) 
        {
            this.repository.Get(voteId).CardID = cardId;
        }
    }
}
