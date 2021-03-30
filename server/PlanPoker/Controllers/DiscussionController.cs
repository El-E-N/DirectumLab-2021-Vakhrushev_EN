using DataService.Models;
using DataService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanPoker.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanPoker.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class DiscussionController
    {
        private readonly DiscussionService services;

        public DiscussionController(DiscussionService services)
        {
            this.services = services;
        }

        [HttpPost("create/{roomId&name}")]
        public Discussion Create(Guid roomId, string name = "")
        {
            return this.services.Create(roomId, name);
        }

        [HttpPost("close/{id}")]
        public void Close(Guid discussionId)
        {
            this.services.Close(discussionId);
        }

        [HttpPost("addvote/{discussionId&voteId}")]
        public void AddVote(Guid discussionId, Guid voteId)
        {
            this.services.AddVote(discussionId, voteId);
        }

        [HttpPost("getresults/{discussionId}")]
        public List<Guid> GetResults(Guid discussionId)
        {
            return this.services.GetResults(discussionId);
        }

        [HttpPost("getall")]
        public IQueryable<Discussion> GetAll()
        {
            return this.services.GetAll();
        }
    }
}
