using DataService.Models;
using DataService.Repositories;
using System;
using System.Linq;

namespace PlanPoker.Services
{
    /// <summary>
    /// Сервис комнаты.
    /// </summary>
    public class RoomService
    {
        /// <summary>
        /// Репозиторий комнат.
        /// </summary>
        private readonly RoomMemoryRepository repository;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="repository">Репозиторий комнта.</param>
        public RoomService(RoomMemoryRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Создание комнаты.
        /// </summary>
        /// <param name="name">Название комнаты.</param>
        /// <param name="creatorId">Id создателя комнаты.</param>
        /// <returns>Созданная комната.</returns>
        public Room Create(string name, string creatorId) 
        {
            var id = Guid.NewGuid();
            var hash = Guid.NewGuid();
            var creatorGuid = Guid.Parse(creatorId);
            this.repository.Create(name, creatorGuid, creatorGuid, id, hash);
            return this.repository.Get(id);
        }

        /// <summary>
        /// Добавление игрока в комнату.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="playerId">Id игрока.</param>
        public void AddPlayer(string roomId, string playerId)
        {
            this.repository.Get(Guid.Parse(roomId.Replace(" ", string.Empty))).PlayersIds.Add(Guid.Parse(playerId.Replace(" ", string.Empty)));
            this.repository.SaveChanges();
        }

        /// <summary>
        /// Удаление игрока из комнаты.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="playerId">Id игрока.</param>
        public void RemovePlayer(string roomId, string playerId) 
        {
            this.repository.Get(Guid.Parse(roomId.Replace(" ", string.Empty))).PlayersIds.Remove(Guid.Parse(playerId.Replace(" ", string.Empty)));
            this.repository.SaveChanges();
        }

        /// <summary>
        /// Изменение ведущего комнаты.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="hostId">Id ведущего.</param>
        public void ChangeHost(string roomId, string hostId)
        {
            var name = this.repository.Get(Guid.Parse(roomId.Replace(" ", string.Empty))).Name;
            var hash = this.repository.Get(Guid.Parse(roomId.Replace(" ", string.Empty))).Hash;
            var creatorId = this.repository.Get(Guid.Parse(roomId.Replace(" ", string.Empty))).CreatorId;
            this.repository.Save(new Room(name, Guid.Parse(hostId.Replace(" ", string.Empty)), creatorId, Guid.Parse(roomId.Replace(" ", string.Empty)), hash));
        }

        /// <summary>
        /// Получение всех комнат.
        /// </summary>
        /// <returns>Все комнаты из базы данных.</returns>
        public IQueryable<Room> GetRooms()
        {
            return this.repository.GetItems();
        }
    }
}
