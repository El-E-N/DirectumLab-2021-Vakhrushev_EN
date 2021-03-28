using DataService.Models;
using DataService.Repositories;
using Microsoft.AspNetCore.Mvc;
using PlanPoker.Services;
using System;
using System.Collections.Generic;

namespace PlanPoker.Controllers
{
    public class DiscussionController
    {
        private readonly DiscussionServices services;

        public DiscussionController()
        {
            this.services = new DiscussionServices(new DiscussionMemoryRepository(new DiscussionContext()));
        }

        [HttpPost]
        public void Create(Guid roomId, string name)
        {
            this.services.Create(roomId, name);
        }

        [HttpPost]
        public void Close(Guid discussionId)
        {
            this.services.Close(discussionId);
        }

        [HttpPost]
        public void AddVote(Guid discussionId, Guid voteId)
        {
            this.services.AddVote(discussionId, voteId);
        }

        [HttpPost]
        public List<Guid> GetResults(Guid discussionId)
        {
            return this.services.GetResults(discussionId);
        }
    }
}
