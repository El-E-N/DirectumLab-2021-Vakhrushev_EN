using DataService.Models;
using DataService.Repositories;
using Microsoft.AspNetCore.Mvc;
using PlanPoker.Services;
using System;

namespace PlanPoker.Controllers
{
    public class RoomController
    {
        private readonly RoomServices services;

        public RoomController()
        {
            this.services = new RoomServices(new RoomMemoryRepository(new RoomContext()));
        }

        [HttpPost]
        public void Create(string name, Guid creatorId)
        {
            this.services.Create(name, creatorId);
        }

        [HttpPost]
        public void AddPlayer(Guid roomId, Guid playerId)
        {
            this.services.AddPlayer(roomId, playerId);
        }
    }
}
