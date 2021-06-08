using Microsoft.AspNetCore.Mvc;
using PlanPoker.DTO;
using PlanPoker.DTO.Builders;
using PlanPoker.Services;
using System;

public class ElementForDiscussionCreate
{
    public string roomHash { get; set; }
    public string name { get; set; }
}

public class ElementForDiscussionSetName
{
    public string discussionId { get; set; }
    public string name { get; set; }
}

public class DiscussionDtoWithToken : DiscussionDTO
{
    public Guid Token { get; set; }
}

namespace PlanPoker.Controllers
{
    /// <summary>
    /// Контроллер обсуждения.
    /// </summary>
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class DiscussionController : ControllerBase
    {
        /// <summary>
        /// Сервис обсуждения.
        /// </summary>
        private readonly DiscussionService discussionService;

        /// <summary>
        /// Сервис оценок.
        /// </summary>
        private readonly VoteService voteService;

        /// <summary>
        /// Сервис карт.
        /// </summary>
        private readonly CardService cardService;

        private readonly RoomService roomService;

        /// <summary>
        /// Конструктор с присваиванием сервиса.
        /// </summary>
        /// <param name="discussionService">Сервисы обсуждения.</param>
        /// <param name="voteService">Сервисы оценок.</param>
        /// <param name="cardService">Сервисы карт.</param>
        public DiscussionController(DiscussionService discussionService, VoteService voteService, CardService cardService, RoomService roomService)
        {
            this.discussionService = discussionService;
            this.voteService = voteService;
            this.cardService = cardService;
            this.roomService = roomService;
        }

        /// <summary>
        /// Создание обсуждения в конкретной комнате по ее Id.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="name">Название обсуждения.</param>
        /// <returns>Объект DTO этого обсуждения.</returns>
        [HttpPost]
        public DiscussionDtoWithToken Create(ElementForDiscussionCreate body)
        {
            var roomHashGuid = Guid.Parse(body.roomHash.Replace(" ", string.Empty));
            var tokenGuid = Guid.Parse(Request.Headers["token"].ToString().Replace(" ", string.Empty));
            var room = this.roomService.GetByHash(roomHashGuid);
            var discussion = this.discussionService.Create(room.Id, body.name);
            var discussionDto = DiscussionDTOBuilder.Build(discussion, this.voteService, this.cardService);
            var result = new DiscussionDtoWithToken()
            {
                EndAt = discussionDto.EndAt,
                StartAt = discussionDto.StartAt,
                Id = discussionDto.Id,
                Name = discussionDto.Name,
                VoteList = discussionDto.VoteList,
                Token = tokenGuid
            };
            return result;
        }

        /// <summary>
        /// Закрытие обсуждения.
        /// </summary>
        /// <param name="discussionId">Id этого обсуждения.</param>
        /// <returns>Обсуждение.</returns>
        [HttpPost]
        public DiscussionDtoWithToken Close([FromBody] string discussionId)
        {
            var discussionGuid = Guid.Parse(discussionId.Replace(" ", string.Empty));
            var tokenGuid = Guid.Parse(Request.Headers["token"].ToString().Replace(" ", string.Empty));
            var discussion = this.discussionService.Close(discussionGuid);
            var discussionDto = DiscussionDTOBuilder.Build(discussion, this.voteService, this.cardService);
            var result = new DiscussionDtoWithToken()
            {
                EndAt = discussionDto.EndAt,
                StartAt = discussionDto.StartAt,
                Id = discussionDto.Id,
                Name = discussionDto.Name,
                VoteList = discussionDto.VoteList,
                Token = tokenGuid
            };
            return result;
        }

        [HttpPost]
        public DiscussionDtoWithToken SetName(ElementForDiscussionSetName body)
        {
            var discussionGuid = Guid.Parse(body.discussionId.Replace(" ", string.Empty));
            var tokenGuid = Guid.Parse(Request.Headers["token"].ToString().Replace(" ", string.Empty));
            var discussion = this.discussionService.SetName(discussionGuid, body.name);
            var discussionDto = DiscussionDTOBuilder.Build(discussion, this.voteService, this.cardService);
            var result = new DiscussionDtoWithToken()
            {
                EndAt = discussionDto.EndAt,
                StartAt = discussionDto.StartAt,
                Id = discussionDto.Id,
                Name = discussionDto.Name,
                VoteList = discussionDto.VoteList,
                Token = tokenGuid
            };
            return result;
        }

        [HttpPost]
        public StringToken Delete([FromBody] string discussionId)
        {
            var discussionGuid = Guid.Parse(discussionId.Replace(" ", string.Empty));
            this.discussionService.Delete(discussionGuid);
            var token = Request.Headers["token"];
            return new StringToken() { Token = token };
        }
    }
}
