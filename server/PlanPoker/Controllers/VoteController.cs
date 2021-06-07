using DataService.Models;
using Microsoft.AspNetCore.Mvc;
using PlanPoker.DTO;
using PlanPoker.DTO.Builders;
using PlanPoker.Services;
using System;

public class ElementForVoteCreate
{
    public string cardId { get; set; }
    public string roomHash { get; set; }
    public string playerId { get; set; }
    public string discussionId { get; set; }
}

public class ElementForVoteChangeCard
{
    public string voteId { get; set; }
    public string cardId { get; set; }
}

namespace PlanPoker.Controllers
{
    /// <summary>
    /// Контроллер голоса.
    /// </summary>
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class VoteController
    {
        /// <summary>
        /// Сервисы голоса.
        /// </summary>
        private readonly VoteService voteService;

        /// <summary>
        /// Сервис карт.
        /// </summary>
        private readonly CardService cardService;
        
        /// <summary>
        /// Сервис обсуждений.
        /// </summary>
        private readonly DiscussionService discussionService;

        private readonly RoomService roomService;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="voteService">Сервисы оценок.</param>
        /// <param name="cardService">Сервисы карт.</param>
        public VoteController(VoteService voteService, CardService cardService, DiscussionService discussionService, RoomService roomService)
        {
            this.voteService = voteService;
            this.cardService = cardService;
            this.discussionService = discussionService;
            this.roomService = roomService;
        }

        /// <summary>
        /// Создание оценки.
        /// </summary>
        /// <param name="cardId">Id карты, которой проголосовали.</param>
        /// <param name="roomId">Id комнаты. в которой проголосовали.</param>
        /// <param name="playerId">Id игрока, котрый проголосовал.</param>
        /// <param name="discussionId">Id обсуждения, на которое проголосовали.</param>
        /// <returns>Оценка.</returns>
        [HttpPost]
        public VoteDTO Create(ElementForVoteCreate body)
        {
            var roomHashGuid = Guid.Parse(body.roomHash.Replace(" ", string.Empty));
            var room = this.roomService.GetByHash(roomHashGuid);
            var playerGuid = Guid.Parse(body.playerId.Replace(" ", string.Empty));
            var discussionGuid = Guid.Parse(body.discussionId.Replace(" ", string.Empty));
            Vote vote;
            if (body.cardId != null)
            {
                var cardGuid = Guid.Parse(body.cardId.Replace(" ", string.Empty));
                vote = this.voteService.Create(cardGuid, room.Id, playerGuid, discussionGuid);
            }
            else
                vote = this.voteService.Create(null, room.Id, playerGuid, discussionGuid);
            this.discussionService.AddVote(vote.DiscussionId, vote.Id);
            return VoteDTOBuilder.Build(vote, this.cardService);
        }

        [HttpPost]
        public void Delete([FromBody] string voteId)
        {
            var voteGuid = Guid.Parse(voteId.Replace(" ", string.Empty));
            var vote = this.voteService.GetById(voteGuid);
            this.discussionService.RemoveVote(vote.DiscussionId, voteGuid);
            this.voteService.Delete(voteGuid);
        }

        /// <summary>
        /// Изменение выбора.
        /// </summary>
        /// <param name="voteId">Id оценки.</param>
        /// <param name="cardId">Id карты.</param>
        /// <returns>Оценка.</returns>
        [HttpPost]
        public VoteDTO ChangeCard(ElementForVoteChangeCard body)
        {
            var voteGuid = Guid.Parse(body.voteId.Replace(" ", string.Empty));
            var cardGuid = Guid.Parse(body.cardId.Replace(" ", string.Empty));
            var vote = this.voteService.ChangeCard(voteGuid, cardGuid);
            return VoteDTOBuilder.Build(vote, this.cardService);
        }
    }
}
