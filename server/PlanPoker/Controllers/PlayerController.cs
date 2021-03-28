using DataService.Models;
using DataService.Repositories;
using Microsoft.AspNetCore.Mvc;
using PlanPoker.Services;
using System;

namespace PlanPoker.Controllers
{
    public class PlayerController
    {
        private readonly PlayerServices services;

        public PlayerController()
        {
            this.services = new PlayerServices(new PlayerMemoryRepository(new PlayerContext()));
        }

        [HttpPost]
        public void Create(string name)
        {
            this.services.Create(name);
        }

        [HttpPost]
        public void ChangeName(Guid id, string name)
        {
            this.services.ChangeName(id, name);
        }
    }
}
