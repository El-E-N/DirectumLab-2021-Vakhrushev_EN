using DataService.Models;
using Microsoft.AspNetCore.Mvc;
using PlanPoker.DTO;
using PlanPoker.DTO.Builders;
using PlanPoker.Services;
using System;
using System.Linq;

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
        public VoteDTO Create(Guid cardId, Guid roomId, Guid playerId, Guid discussionId)
        {
            var vote = this.voteService.Create(cardId, roomId, playerId, discussionId);
            return VoteDTOBuilder.Build(vote, this.cardService.Get(vote.CardID));
        }

        /// <summary>
        /// Изменение выбора.
        /// </summary>
        /// <param name="voteId">Id оценки.</param>
        /// <param name="cardId">Id карты.</param>
        [HttpPost]
        public void ChangeCard(Guid voteId, Guid cardId)
        {
            this.voteService.ChangeCard(voteId, cardId);
        }

        /// <summary>
        /// Просто для проверки работы.
        /// </summary>
        /// <returns>Все голоса из базы данных.</returns>
        [HttpGet]
        public IQueryable<VoteDTO> GetAllVote()
        {
            return this.voteService.GetAllVote()
                .Select(vote => VoteDTOBuilder.Build(vote, this.cardService.Get(vote.CardID)));
        }
    }
}
