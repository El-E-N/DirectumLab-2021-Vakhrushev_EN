using DataService.Models;
using DataService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

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
        public RoomService(RoomMemoryRepository repository) { this.repository = repository; }

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
            this.repository.Create(name, creatorId, creatorId, id, hash, new List<Guid> { creatorId });
            return this.repository.Get(id);
        }

        /// <summary>
        /// Получение комнаты по id.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Комната.</returns>
        public Room GetById(Guid id) => this.repository.Get(id);

        /// <summary>
        /// Получение комнаты по хэшу.
        /// </summary>
        /// <param name="hash">Хэш.</param>
        /// <returns>Комната.</returns>
        public Room GetByHash(Guid hash) => this.repository.GetByHash(hash);

        /// <summary>
        /// Добавление игрока в комнату.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="playerId">Id игрока.</param>
        public Room AddPlayer(Guid roomId, Guid playerId)
        {
            var room = this.repository.Get(roomId);
            var name = room.Name;
            var hash = room.Hash;
            var creatorId = room.CreatorId;
            var hostId = room.HostId;
            var playersIds = JsonSerializer.Deserialize<ICollection<Guid>>(room.PlayersIds);
            playersIds = new List<Guid>(playersIds.Append(playerId));
            var listPlayersIds = new List<Guid>(playersIds);
            this.repository.Save(new Room(name, hostId, creatorId, roomId, hash, listPlayersIds));
            return this.repository.Get(roomId);
        }

        /// <summary>
        /// Удаление игрока из комнаты.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="playerId">Id игрока.</param>
        public Room RemovePlayer(Guid roomId, Guid playerId) 
        {
            var room = this.repository.Get(roomId);
            var name = room.Name;
            var hash = room.Hash;
            var creatorId = room.CreatorId;
            var hostId = room.HostId;
            var playersIds = JsonSerializer.Deserialize<ICollection<Guid>>(room.PlayersIds);
            playersIds = new List<Guid>(playersIds.Where(id => id != playerId));
            this.repository.Save(new Room(name, hostId, creatorId, roomId, hash, playersIds));
            return this.repository.Get(roomId);
        }

        /// <summary>
        /// Изменение ведущего комнаты.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="hostId">Id ведущего.</param>
        public Room ChangeHost(Guid roomId, Guid hostId)
        {
            var room = this.repository.Get(roomId);
            var name = room.Name;
            var hash = room.Hash;
            var creatorId = room.CreatorId;
            var playersIds = JsonSerializer.Deserialize<ICollection<Guid>>(room.PlayersIds);
            this.repository.Save(new Room(name, hostId, creatorId, roomId, hash, playersIds));
            return this.repository.Get(roomId);
        }

        /// <summary>
        /// Получение всех комнат.
        /// </summary>
        /// <returns>Все комнаты из базы данных.</returns>
        public IQueryable<Room> GetRooms() => this.repository.GetItems();
    }
}
