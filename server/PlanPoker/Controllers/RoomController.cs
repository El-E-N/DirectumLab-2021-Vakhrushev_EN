using DataService.Models;
using Microsoft.AspNetCore.Mvc;
using PlanPoker.DTO;
using PlanPoker.DTO.Builders;
using PlanPoker.Services;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public RoomDTO Create(string name, Guid creatorId)
        {
            var room = this.roomService.Create(name, creatorId);
            return RoomDTOBuilder.Build(
                room,
                (List<PlayerDTO>)room.PlayersIDs.Select(el => PlayerDTOBuilder.Build(this.playerService.Get(el))));
        }

        /// <summary>
        /// Добавление игрока в комнату.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="playerId">Id добавляемого игрока.</param>
        [HttpPost]
        public void AddPlayer(Guid roomId, Guid playerId)
        {
            this.roomService.AddPlayer(roomId, playerId);
        }

        /// <summary>
        /// Удаление игрока из комнаты.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="playerId">Id игрока.</param>
        [HttpPost]
        public void RemovePlayer(Guid roomId, Guid playerId)
        {
            this.roomService.RemovePlayer(roomId, playerId);
        }

        /// <summary>
        /// Изменение ведущего комнаты.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="hostId">Id ведущего.</param>
        [HttpPost]
        public void ChangeHost(Guid roomId, Guid hostId)
        {
            this.roomService.ChangeHost(roomId, hostId);
        }

        /// <summary>
        /// Получение всех комнат.
        /// </summary>
        /// <returns>Все комнаты из базы данных.</returns>
        [HttpGet]
        public IQueryable<RoomDTO> GetRooms()
        {
            return this.roomService.GetRooms()
                .Select(room => RoomDTOBuilder.Build(
                    room,
                    (List<PlayerDTO>)room.PlayersIDs.Select(id => PlayerDTOBuilder.Build(this.playerService.Get(id)))));
        }
    }
}
