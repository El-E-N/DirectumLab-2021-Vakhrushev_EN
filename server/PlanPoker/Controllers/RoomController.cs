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
    public class RoomController
    {
        private readonly RoomService services;

        public RoomController(RoomService services)
        {
            this.services = services;
        }

        [HttpPost("create/{name&creatorId}")]
        public Room Create(string name, Guid creatorId)
        {
            return this.services.Create(name, creatorId);
        }

        [HttpPost("addplayer/{roomId&playerId}")]
        public void AddPlayer(Guid roomId, Guid playerId)
        {
            this.services.AddPlayer(roomId, playerId);
        }

        [HttpPost("removeplayer/{roomId&playerId}")]
        public void RemovePlayer(Guid roomId, Guid playerId)
        {
            this.services.RemovePlayer(roomId, playerId);
        }

        [HttpPost("getall")]
        public IQueryable<Room> GetAll()
        {
            return this.services.GetAll();
        }
    }
}
