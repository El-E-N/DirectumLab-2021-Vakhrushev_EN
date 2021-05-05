using Microsoft.AspNetCore.Mvc;
using PlanPoker.DTO;
using PlanPoker.DTO.Builders;
using PlanPoker.Services;
using System;
using System.Collections.Generic;

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
        /// Конструктор.
        /// </summary>
        /// <param name="voteService">Сервисы оценок.</param>
        /// <param name="cardService">Сервисы карт.</param>
        public VoteController(VoteService voteService, CardService cardService)
        {
            this.voteService = voteService;
            this.cardService = cardService;
        }

        /// <summary>
        /// Создание оценки.
        /// </summary>
        /// <param name="cardId">Id карты, которой проголосовали.</param>
        /// <param name="roomId">Id комнаты. в которой проголосовали.</param>
        /// <param name="playerId">Id игрока, котрый проголосовал.</param>
        /// <param name="discussionId">Id обсуждения, на которое проголосовали.</param>
        /// <returns>Оценка.</returns>
        [HttpGet]
        public VoteDTO Create(string cardId, string roomId, string playerId, string discussionId)
        {
            var cardGuid = Guid.Parse(cardId.Replace(" ", string.Empty));
            var roomGuid = Guid.Parse(roomId.Replace(" ", string.Empty));
            var playerGuid = Guid.Parse(playerId.Replace(" ", string.Empty));
            var discussionGuid = Guid.Parse(discussionId.Replace(" ", string.Empty));

            var vote = this.voteService.Create(cardGuid, roomGuid, playerGuid, discussionGuid);
            return VoteDTOBuilder.Build(vote, this.cardService);
        }

        /// <summary>
        /// Изменение выбора.
        /// </summary>
        /// <param name="voteId">Id оценки.</param>
        /// <param name="cardId">Id карты.</param>
        [HttpPost]
        public void ChangeCard(string voteId, string cardId)
        {
            var voteGuid = Guid.Parse(voteId.Replace(" ", string.Empty));
            var cardGuid = Guid.Parse(cardId.Replace(" ", string.Empty));
            this.voteService.ChangeCard(voteGuid, cardGuid);
        }

        /// <summary>
        /// Просто для проверки работы.
        /// </summary>
        /// <returns>Все голоса из базы данных.</returns>
        [HttpGet]
        public IEnumerable<VoteDTO> GetAllVote()
        {
            var voteArray = this.voteService.GetAllVote();
            return VoteDTOBuilder.BuildList(voteArray, this.cardService);
        }
    }
}
