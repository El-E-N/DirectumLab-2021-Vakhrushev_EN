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
        /// Сервисы карт.
        /// </summary>
        private readonly CardService cardService;

        /// <summary>
        /// Сервисы обсуждений.
        /// </summary>
        private readonly DiscussionService discussionService;

        /// <summary>
        /// Сервисы голосов.
        /// </summary>
        private readonly VoteService voteService;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="roomService">Сервисы комнат.</param>
        /// <param name="playerService">Сервисы игроков.</param>
        public RoomController(RoomService roomService, PlayerService playerService, CardService cardService, DiscussionService discussionService, VoteService voteService)
        {
            this.roomService = roomService;
            this.playerService = playerService;
            this.voteService = voteService;
            this.cardService = cardService;
            this.discussionService = discussionService;
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
            return RoomDTOBuilder.Build(room, this.playerService, this.cardService, this.discussionService, this.voteService);
        }

        public void Delete(string roomId)
        {
            var roomGuid = Guid.Parse(roomId.Replace(" ", string.Empty));
            this.roomService.Delete(roomGuid);
        }

        /// <summary>
        /// Получение комнаты по хэшу.
        /// </summary>
        /// <param name="hash">Хэш.</param>
        /// <returns>Комната.</returns>
        [HttpGet]
        public RoomDTO GetByHash(string hash)
        {
            Guid hashGuid;

            try
            { hashGuid = Guid.Parse(hash.Replace(" ", string.Empty)); }
            catch
            { return null; }

            var room = this.roomService.GetByHash(hashGuid);
            
            return room != null ?
                RoomDTOBuilder.Build(room, this.playerService, this.cardService, this.discussionService, this.voteService) :
                null;
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
            return RoomDTOBuilder.Build(room, this.playerService, this.cardService, this.discussionService, this.voteService);
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
            return RoomDTOBuilder.Build(room, this.playerService, this.cardService, this.discussionService, this.voteService);
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
            return RoomDTOBuilder.Build(room, this.playerService, this.cardService, this.discussionService, this.voteService);
        }

        /// <summary>
        /// Получение всех комнат.
        /// </summary>
        /// <returns>Все комнаты из базы данных.</returns>
        [HttpGet]
        public IEnumerable<RoomDTO> GetRooms()
        {
            var rooms = new List<Room>(this.roomService.GetRooms());
            return RoomDTOBuilder.BuildList(rooms, this.playerService, this.cardService, this.discussionService, this.voteService);
        }
    }
}
