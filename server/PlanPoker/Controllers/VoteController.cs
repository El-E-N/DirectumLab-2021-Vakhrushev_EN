using DataService.Models;
using Microsoft.AspNetCore.Mvc;
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
        private readonly VoteService service;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="service">Сервисы.</param>
        public VoteController(VoteService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Создание голоса.
        /// </summary>
        /// <param name="cardId">Id карты, которой проголосовали.</param>
        /// <param name="roomId">Id комнаты. в которой проголосовали.</param>
        /// <param name="playerId">Id игрока, котрый проголосовал.</param>
        /// <param name="discussionId">Id обсуждения, на которое проголосовали.</param>
        /// <returns></returns>
        [HttpGet]
        public Vote Create(Guid cardId, Guid roomId, Guid playerId, Guid discussionId)
        {
            return this.service.Create(cardId, roomId, playerId, discussionId);
        }

        /// <summary>
        /// Изменение выбора.
        /// </summary>
        /// <param name="voteId">Id оценки.</param>
        /// <param name="cardId">Id карты.</param>
        [HttpPost]
        public void ChangeCard(Guid voteId, Guid cardId)
        {
            this.service.ChangeCard(voteId, cardId);
        }

        /// <summary>
        /// Просто для проверки работы.
        /// </summary>
        /// <returns>Все голоса из базы данных.</returns>
        [HttpGet]
        public IQueryable<Vote> GetAll()
        {
            return this.service.GetAll();
        }
    }
}
