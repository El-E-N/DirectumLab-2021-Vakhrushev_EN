using System;
using DataService.Models;
using DataService.Repositories;

namespace PlanPoker.Services
{
    public class PlayerServices
    {
        private readonly PlayerMemoryRepository repository;

        public PlayerServices(PlayerMemoryRepository repository)
        {
            this.repository = repository;
        }

        public void Create(string name) 
        {
            var token = Guid.NewGuid().ToString();
            var id = Guid.NewGuid();
            this.repository.Create(new Player(id, name, token));
        }

        public void ChangeName(Guid id, string name) 
        {
            this.repository.Get(id).Name = name;
        }
    }
}
