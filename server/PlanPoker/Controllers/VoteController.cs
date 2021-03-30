using DataService.Models;
using DataService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanPoker.Services;
using System;
using System.Linq;

namespace PlanPoker.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class VoteController
    {
        private readonly VoteService services;

        public VoteController(VoteService services)
        {
            this.services = services;
        }

        [HttpPost("create/{cardId&roomId&playerId&discussionId}")]
        public Vote Create(Guid cardId, Guid roomId, Guid playerId, Guid discussionId)
        {
            return this.services.Create(cardId, roomId, playerId, discussionId);
        }

        [HttpPost("getall")]
        public IQueryable<Vote> GetAll()
        {
            return this.services.GetAll();
        }
    }
}
