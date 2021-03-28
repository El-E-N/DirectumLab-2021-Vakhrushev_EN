using DataService.Models;
using DataService.Repositories;
using Microsoft.AspNetCore.Mvc;
using PlanPoker.Services;
using System;

namespace PlanPoker.Controllers
{
    public class VoteController
    {
        private readonly VoteServices services;

        public VoteController()
        {
            this.services = new VoteServices(new VoteMemoryRepository(new VoteContext()));
        }

        [HttpPost]
        public void Create(Guid cardId, Guid roomId, Guid playerId, Guid discussionId)
        {
            this.services.Create(cardId, roomId, playerId, discussionId);
        }

        [HttpPost]
        public void ChangeCard(Guid voteId, Guid cardId)
        {
            this.services.ChangeCard(voteId, cardId);
        }
    }
}
