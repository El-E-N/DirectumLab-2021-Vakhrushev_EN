using System;
using DataService.Models;
using DataService.Repositories;

namespace PlanPoker.Services
{
    public class RoomServices
    {
        private readonly RoomMemoryRepository repository;

        public RoomServices(RoomMemoryRepository repository)
        {
            this.repository = repository;
        }

        public void Create(string name, Guid creatorId) 
        {
            var id = Guid.NewGuid();
            var hash = Guid.NewGuid();
            var room = new Room(name, creatorId, id, hash);
            this.repository.Create(room);
            this.repository.Save();
        }

        public void AddPlayer(Guid roomId, Guid playerId) 
        {
            this.repository.Get(roomId).PlayersIDs.Add(playerId);
        }

        public void ChangeHost(Guid roomId, Guid hostId) 
        {
            this.repository.Get(roomId).HostID = hostId;
        }

        public void RemovePlayer(Guid roomId, Guid playerId) 
        {
            this.repository.Get(roomId).PlayersIDs.Remove(playerId);
        }
    }
}
