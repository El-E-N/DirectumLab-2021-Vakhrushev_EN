using Microsoft.AspNetCore.Mvc;
using PlanPoker.DTO;
using PlanPoker.DTO.Builders;
using PlanPoker.Services;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// Конструктор с присваиванием сервиса.
        /// </summary>
        /// <param name="discussionService">Сервисы обсуждения.</param>
        /// <param name="voteService">Сервисы оценок.</param>
        /// <param name="cardService">Сервисы карт.</param>
        public DiscussionController(DiscussionService discussionService, VoteService voteService, CardService cardService)
        {
            this.discussionService = discussionService;
            this.voteService = voteService;
            this.cardService = cardService;
        }

        /// <summary>
        /// Создание обсуждения в конкретной комнате по ее Id.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="name">Название обсуждения.</param>
        /// <returns>Объект DTO этого обсуждения.</returns>
        [HttpGet]
        public DiscussionDTO Create(string roomId, string name = "")
        {
            return DiscussionDTOBuilder.Build(
                this.discussionService.Create(roomId, name),
                this.voteService, 
                this.cardService);
        }

        /// <summary>
        /// Закрытие обсуждения.
        /// </summary>
        /// <param name="discussionId">Id этого обсуждения.</param>
        [HttpPost]
        public void Close(string discussionId)
        {
            this.discussionService.Close(discussionId);
        }

        /// <summary>
        /// Добавление голоса в обсуждение по Id обсуждения.
        /// </summary>
        /// <param name="discussionId">Id обсуждения.</param>
        /// <param name="voteId">Id голоса.</param>
        [HttpPost]
        public void AddVote(string discussionId, string voteId)
        {
            this.discussionService.AddVote(discussionId, voteId);
        }

        /// <summary>
        /// Возвращает список оценок.
        /// </summary>
        /// <param name="discussionId">Id обсуждения.</param>
        /// <returns>Список оценок.</returns>
        [HttpGet]
        public IEnumerable<VoteDTO> GetAllVote(string discussionId)
        {
            var discussion = this.discussionService.GetDiscussion(discussionId);
            return VoteDTOBuilder.BuildList(discussion.VoteIds.Select(id => this.voteService.GetVote(id.ToString())), this.cardService);
        }

        /// <summary>
        /// Возвращает список всех обсуждений.
        /// </summary>
        /// <returns>Все обсуждения из базы данных.</returns>
        [HttpGet]
        public IEnumerable<DiscussionDTO> GetDiscussionList()
        {
            return DiscussionDTOBuilder.BuildList(this.discussionService.GetDiscussions(), this.voteService, this.cardService);
        }
    }
}
