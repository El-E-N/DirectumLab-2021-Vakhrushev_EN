using Microsoft.AspNetCore.Mvc;
using PlanPoker.DTO;
using PlanPoker.DTO.Builders;
using PlanPoker.Services;
using System;

public class ElementForRoomCreate
{
    public string name { get; set; }
    public string creatorId { get; set; }
}

public class ElementForRoomPlayer
{
    public string roomHash { get; set; }
    public string playerId { get; set; }
}

public class RoomDtoWithToken : RoomDTO
{
    public string Token { get; set; }
}

namespace PlanPoker.Controllers
{
    /// <summary>
    /// Контроллер комнаты.
    /// </summary>
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class RoomController : ControllerBase
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
        [HttpPost]
        public RoomDtoWithToken Create(ElementForRoomCreate body)
        {
            var creatorGuid = Guid.Parse(body.creatorId.Replace(" ", string.Empty));
            var room = this.roomService.Create(body.name, creatorGuid);
            var roomDto = RoomDTOBuilder.Build(room, this.playerService, this.cardService, this.discussionService, this.voteService);
            var result = new RoomDtoWithToken()
            {
                Cards = roomDto.Cards,
                CreatorId = roomDto.CreatorId,
                CurrentPlayers = roomDto.CurrentPlayers,
                Discussions = roomDto.Discussions,
                Hash = roomDto.Hash,
                HostId = roomDto.HostId,
                Id = roomDto.Id,
                Name = roomDto.Name,
                RoomPlayers = roomDto.RoomPlayers,
                Token = Request.Headers["token"]
            };
            return result;
        }

        [HttpPost]
        public string Delete([FromBody] string roomHash)
        {
            var roomHashGuid = Guid.Parse(roomHash.Replace(" ", string.Empty));
            var room = this.roomService.GetByHash(roomHashGuid);
            this.roomService.Delete(room.Id);
            return Request.Headers["token"];
        }

        /// <summary>
        /// Получение комнаты по хэшу.
        /// </summary>
        /// <param name="hash">Хэш.</param>
        /// <returns>Комната.</returns>
        [HttpPost]
        public RoomDtoWithToken GetByHash([FromBody] string hash)
        {
            Guid hashGuid;

            try
              { hashGuid = Guid.Parse(hash.Replace(" ", string.Empty)); }
            catch
              { return null; }

            var room = this.roomService.GetByHash(hashGuid);

            if (room != null)
            {
                var roomDto = RoomDTOBuilder.Build(room, this.playerService, this.cardService, this.discussionService, this.voteService);
                var result = new RoomDtoWithToken()
                {
                    Cards = roomDto.Cards,
                    CreatorId = roomDto.CreatorId,
                    CurrentPlayers = roomDto.CurrentPlayers,
                    Discussions = roomDto.Discussions,
                    Hash = roomDto.Hash,
                    HostId = roomDto.HostId,
                    Id = roomDto.Id,
                    Name = roomDto.Name,
                    RoomPlayers = roomDto.RoomPlayers,
                    Token = Request.Headers["token"]
                };
                return result;
            }
            return null;
        }

        /// <summary>
        /// Добавление игрока в комнату.
        /// </summary>
        /// <param name="body">Тело с hash комнаты и id игрока.</param>
        /// <returns>Комната.</returns>
        [HttpPost]
        public RoomDtoWithToken AddPlayer(ElementForRoomPlayer body)
        {
            var roomHashGuid = Guid.Parse(body.roomHash.Replace(" ", string.Empty));
            var playerGuid = Guid.Parse(body.playerId.Replace(" ", string.Empty));
            var room = this.roomService.GetByHash(roomHashGuid);
            room = this.roomService.AddPlayer(room.Id, playerGuid);
            var roomDto = RoomDTOBuilder.Build(room, this.playerService, this.cardService, this.discussionService, this.voteService);
            var result = new RoomDtoWithToken()
            {
                Cards = roomDto.Cards,
                CreatorId = roomDto.CreatorId,
                CurrentPlayers = roomDto.CurrentPlayers,
                Discussions = roomDto.Discussions,
                Hash = roomDto.Hash,
                HostId = roomDto.HostId,
                Id = roomDto.Id,
                Name = roomDto.Name,
                RoomPlayers = roomDto.RoomPlayers,
                Token = Request.Headers["token"]
            };
            return result;
        }

        /// <summary>
        /// Удаление игрока из комнаты.
        /// </summary>
        /// <param name="body">Тело с hash комнаты и id игрока.</param>
        /// <returns>Комната.</returns>
        [HttpPost]
        public RoomDtoWithToken RemovePlayer(ElementForRoomPlayer body)
        {
            var roomHashGuid = Guid.Parse(body.roomHash.Replace(" ", string.Empty));
            var playerGuid = Guid.Parse(body.playerId.Replace(" ", string.Empty));
            var room = this.roomService.GetByHash(roomHashGuid);
            room = this.roomService.RemovePlayer(room.Id, playerGuid); 
            var roomDto = RoomDTOBuilder.Build(room, this.playerService, this.cardService, this.discussionService, this.voteService);
            var result = new RoomDtoWithToken()
            {
                Cards = roomDto.Cards,
                CreatorId = roomDto.CreatorId,
                CurrentPlayers = roomDto.CurrentPlayers,
                Discussions = roomDto.Discussions,
                Hash = roomDto.Hash,
                HostId = roomDto.HostId,
                Id = roomDto.Id,
                Name = roomDto.Name,
                RoomPlayers = roomDto.RoomPlayers,
                Token = Request.Headers["token"]
            };
            return result;
        }

        /// <summary>
        /// Изменение ведущего комнаты.
        /// </summary>
        /// <param name="body">Тело с hash комнаты и id игрока.</param>
        /// <returns>Комната.</returns>
        [HttpPost]
        public RoomDtoWithToken ChangeHost(ElementForRoomPlayer body)
        {
            var roomHashGuid = Guid.Parse(body.roomHash.Replace(" ", string.Empty));
            var hostGuid = Guid.Parse(body.playerId.Replace(" ", string.Empty));
            var room = this.roomService.GetByHash(roomHashGuid);
            room = this.roomService.ChangeHost(room.Id, hostGuid);
            var roomDto = RoomDTOBuilder.Build(room, this.playerService, this.cardService, this.discussionService, this.voteService);
            var result = new RoomDtoWithToken()
            {
                Cards = roomDto.Cards,
                CreatorId = roomDto.CreatorId,
                CurrentPlayers = roomDto.CurrentPlayers,
                Discussions = roomDto.Discussions,
                Hash = roomDto.Hash,
                HostId = roomDto.HostId,
                Id = roomDto.Id,
                Name = roomDto.Name,
                RoomPlayers = roomDto.RoomPlayers,
                Token = Request.Headers["token"]
            };
            return result;
        }
    }
}
