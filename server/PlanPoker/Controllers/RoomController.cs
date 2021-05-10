using DataService.Models;
using Microsoft.AspNetCore.Mvc;
using PlanPoker.DTO;
using PlanPoker.DTO.Builders;
using PlanPoker.Services;
using System;
using System.Collections.Generic;

namespace PlanPoker.Controllers
{
    /// <summary>
    /// Контроллер комнаты.
    /// </summary>
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class RoomController
    {
        /// <summary>
        /// Сервисы комнаты.
        /// </summary>
        private readonly RoomService roomService;

        /// <summary>
        /// Сервисы игроков.
        /// </summary>
        private readonly PlayerService playerService;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="roomService">Сервисы комнат.</param>
        /// <param name="playerService">Сервисы игроков.</param>
        public RoomController(RoomService roomService, PlayerService playerService)
        {
            this.roomService = roomService;
            this.playerService = playerService;
        }

        /// <summary>
        /// Создание комнаты с названием и Id создателя комнаты.
        /// </summary>
        /// <param name="name">Название комнаты.</param>
        /// <param name="creatorId">Id создателя.</param>
        /// <returns>Объект DTO созданной комнаты.</returns>
        [HttpGet]
        public RoomDTO Create(string name, string creatorId)
        {
            var creatorGuid = Guid.Parse(creatorId.Replace(" ", string.Empty));
            var room = this.roomService.Create(name, creatorGuid);
            return RoomDTOBuilder.Build(room, this.playerService);
        }

        /// <summary>
        /// Получение комнаты по хэшу.
        /// </summary>
        /// <param name="hash">Хэш.</param>
        /// <returns>Комната.</returns>
        [HttpGet]
        public RoomDTO GetByHash(string hash)
        {
            var hashGuid = Guid.Parse(hash.Replace(" ", string.Empty));
            var room = this.roomService.GetByHash(hashGuid);
            return RoomDTOBuilder.Build(room, this.playerService);
        }

        /// <summary>
        /// Добавление игрока в комнату.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="playerId">Id добавляемого игрока.</param>
        /// <returns>Комната.</returns>
        [HttpGet]
        public RoomDTO AddPlayer(string roomId, string playerId)
        {
            var roomGuid = Guid.Parse(roomId.Replace(" ", string.Empty));
            var playerGuid = Guid.Parse(playerId.Replace(" ", string.Empty));
            var room = this.roomService.AddPlayer(roomGuid, playerGuid);
            return RoomDTOBuilder.Build(room, this.playerService);
        }

        /// <summary>
        /// Удаление игрока из комнаты.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="playerId">Id игрока.</param>
        /// <returns>Комната.</returns>
        [HttpGet]
        public RoomDTO RemovePlayer(string roomId, string playerId)
        {
            var roomGuid = Guid.Parse(roomId.Replace(" ", string.Empty));
            var playerGuid = Guid.Parse(playerId.Replace(" ", string.Empty));
            var room = this.roomService.RemovePlayer(roomGuid, playerGuid);
            return RoomDTOBuilder.Build(room, this.playerService);
        }

        /// <summary>
        /// Изменение ведущего комнаты.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="hostId">Id ведущего.</param>
        /// <returns>Комната.</returns>
        [HttpGet]
        public RoomDTO ChangeHost(string roomId, string hostId)
        {
            var roomGuid = Guid.Parse(roomId.Replace(" ", string.Empty));
            var hostGuid = Guid.Parse(hostId.Replace(" ", string.Empty));
            var room = this.roomService.ChangeHost(roomGuid, hostGuid);
            return RoomDTOBuilder.Build(room, this.playerService);
        }

        /// <summary>
        /// Получение всех комнат.
        /// </summary>
        /// <returns>Все комнаты из базы данных.</returns>
        [HttpGet]
        public IEnumerable<RoomDTO> GetRooms()
        {
            var rooms = new List<Room>(this.roomService.GetRooms());
            return RoomDTOBuilder.BuildList(rooms, this.playerService);
        }
    }
}
