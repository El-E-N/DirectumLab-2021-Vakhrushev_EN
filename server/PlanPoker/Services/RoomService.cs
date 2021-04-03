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
        private readonly IRepository<Room> repository;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="repository">Репозиторий комнта.</param>
        public RoomService(IRepository<Room> repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Создание комнаты.
        /// </summary>
        /// <param name="name">Название комнаты.</param>
        /// <param name="creatorId">Id создателя комнаты.</param>
        /// <returns>Созданная комната.</returns>
        public Room Create(string name, Guid creatorId) 
        {
            var id = Guid.NewGuid();
            var hash = Guid.NewGuid();
            var room = new Room(name, creatorId, id, hash);
            this.repository.Create(room);
            this.repository.Save();
            return this.repository.Get(id);
        }

        /// <summary>
        /// Добавление игрока в комнату.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="playerId">Id игрока.</param>
        public void AddPlayer(Guid roomId, Guid playerId) 
        {
            this.repository.Get(roomId).PlayersIds.Add(playerId);
            this.repository.Save();
        }

        /// <summary>
        /// Удаление игрока из комнаты.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="playerId">Id игрока.</param>
        public void RemovePlayer(Guid roomId, Guid playerId) 
        {
            this.repository.Get(roomId).PlayersIds.Remove(playerId);
            this.repository.Save();
        }

        /// <summary>
        /// Изменение ведущего комнаты.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="hostId">Id ведущего.</param>
        public void ChangeHost(Guid roomId, Guid hostId)
        {
            this.repository.Get(roomId).HostId = hostId;
            this.repository.Save();
        }

        /// <summary>
        /// Получение всех комнат.
        /// </summary>
        /// <returns>Все комнаты из базы данных.</returns>
        public IQueryable<Room> GetRooms()
        {
            return this.repository.GetAll();
        }
    }
}
