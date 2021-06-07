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

namespace PlanPoker.Controllers
{
    /// <summary>
    /// Контроллер обсуждения.
    /// </summary>
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class DiscussionController
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
        public DiscussionDTO Create(ElementForDiscussionCreate body)
        {
            var roomHashGuid = Guid.Parse(body.roomHash.Replace(" ", string.Empty));
            var room = this.roomService.GetByHash(roomHashGuid);
            var discussion = this.discussionService.Create(room.Id, body.name);
            return DiscussionDTOBuilder.Build(discussion, this.voteService, this.cardService);
        }

        /// <summary>
        /// Закрытие обсуждения.
        /// </summary>
        /// <param name="discussionId">Id этого обсуждения.</param>
        /// <returns>Обсуждение.</returns>
        [HttpPost]
        public DiscussionDTO Close([FromBody] string discussionId)
        {
            var discussionGuid = Guid.Parse(discussionId.Replace(" ", string.Empty));
            var discussion = this.discussionService.Close(discussionGuid);
            return DiscussionDTOBuilder.Build(discussion, this.voteService, this.cardService);
        }

        [HttpPost]
        public DiscussionDTO SetName(ElementForDiscussionSetName body)
        {
            var discussionGuid = Guid.Parse(body.discussionId.Replace(" ", string.Empty));
            var discussion = this.discussionService.SetName(discussionGuid, body.name);
            return DiscussionDTOBuilder.Build(discussion, this.voteService, this.cardService);
        }

        [HttpPost]
        public void Delete([FromBody] string discussionId)
        {
            var discussionGuid = Guid.Parse(discussionId.Replace(" ", string.Empty));
            this.discussionService.Delete(discussionGuid);
        }
    }
}
