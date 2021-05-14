﻿using DataService.Models;
using Microsoft.AspNetCore.Mvc;
using PlanPoker.DTO;
using PlanPoker.DTO.Builders;
using PlanPoker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

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
            var roomGuid = Guid.Parse(roomId.Replace(" ", string.Empty));
            var discussion = this.discussionService.Create(roomGuid, name);
            return DiscussionDTOBuilder.Build(discussion, this.voteService, this.cardService);
        }

        /// <summary>
        /// Закрытие обсуждения.
        /// </summary>
        /// <param name="discussionId">Id этого обсуждения.</param>
        /// <returns>Обсуждение.</returns>
        [HttpGet]
        public DiscussionDTO Close(string discussionId)
        {
            var discussionGuid = Guid.Parse(discussionId.Replace(" ", string.Empty));
            var discussion = this.discussionService.Close(discussionGuid);
            return DiscussionDTOBuilder.Build(discussion, this.voteService, this.cardService);
        }

        /// <summary>
        /// Добавление голоса в обсуждение по Id обсуждения.
        /// </summary>
        /// <param name="discussionId">Id обсуждения.</param>
        /// <param name="voteId">Id голоса.</param>
        /// <returns>Обсуждение.</returns>
        [HttpGet]
        public DiscussionDTO AddVote(string discussionId, string voteId)
        {
            var discussionGuid = Guid.Parse(discussionId.Replace(" ", string.Empty));
            var voteGuid = Guid.Parse(voteId.Replace(" ", string.Empty));
            var discussion =  this.discussionService.AddVote(discussionGuid, voteGuid);
            return DiscussionDTOBuilder.Build(discussion, this.voteService, this.cardService);
        }

        /// <summary>
        /// Возвращает список оценок.
        /// </summary>
        /// <param name="discussionId">Id обсуждения.</param>
        /// <returns>Список оценок.</returns>
        [HttpGet]
        public IEnumerable<VoteDTO> GetAllVote(string discussionId)
        {
            var discussionGuid = Guid.Parse(discussionId.Replace(" ", string.Empty));
            var discussion = this.discussionService.GetById(discussionGuid);
            var voteArray = JsonSerializer.Deserialize<ICollection<Guid>>(discussion.VoteIds).Select(id => this.voteService.GetById(id));
            return VoteDTOBuilder.BuildList(voteArray, this.cardService);
        }

        /// <summary>
        /// Получить обсуждения одной комнаты.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <returns>Обсуждения.</returns>
        [HttpGet]
        public IEnumerable<DiscussionDTO> GetDiscussionsByRoomId(string roomId)
        {
            var roomGuid = Guid.Parse(roomId.Replace(" ", string.Empty));
            var discussions = this.discussionService.GetDiscussionsByRoomId(roomGuid);
            return DiscussionDTOBuilder.BuildList(new List<Discussion>(discussions), this.voteService, this.cardService);
        }

        /// <summary>
        /// Возвращает список всех обсуждений.
        /// </summary>
        /// <returns>Все обсуждения из базы данных.</returns>
        [HttpGet]
        public IEnumerable<DiscussionDTO> GetDiscussionList()
        {
            var discussions = new List<Discussion>(this.discussionService.GetDiscussions());
            return DiscussionDTOBuilder.BuildList(discussions, this.voteService, this.cardService);
        }
    }
}
