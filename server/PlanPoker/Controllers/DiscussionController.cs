using DataService.Models;
using Microsoft.AspNetCore.Mvc;
using PlanPoker.Services;
using System;
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
        private readonly DiscussionService service;

        /// <summary>
        /// Конструктор с присваиванием сервиса.
        /// </summary>
        /// <param name="service">Сервисы.</param>
        public DiscussionController(DiscussionService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Создание обсуждения в конкретной комнате по ее Id.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="name">Название обсуждения.</param>
        /// <returns>Объект этого обсуждения.</returns>
        [HttpGet]
        public Discussion Create(Guid roomId, string name = "")
        {
            return this.service.Create(roomId, name);
        }

        /// <summary>
        /// Закрытие обсуждения.
        /// </summary>
        /// <param name="discussionId">Id этого обсуждения.</param>
        [HttpPost]
        public void Close(Guid discussionId)
        {
            this.service.Close(discussionId);
        }

        /// <summary>
        /// Добавление голоса в обсуждение по Id обсуждения.
        /// </summary>
        /// <param name="discussionId">Id обсуждения.</param>
        /// <param name="voteId">Id голоса.</param>
        [HttpPost]
        public void AddVote(Guid discussionId, Guid voteId)
        {
            this.service.AddVote(discussionId, voteId);
        }

        /// <summary>
        /// Возвращает список результатов.
        /// </summary>
        /// <param name="discussionId">Id обсуждения.</param>
        /// <returns>Список результатов.</returns>
        [HttpGet]
        public List<Guid> GetResults(Guid discussionId)
        {
            return this.service.GetResults(discussionId);
        }

        /// <summary>
        /// Просто для проверки работы.
        /// </summary>
        /// <returns>Все обсуждения из базы данных.</returns>
        [HttpGet]
        public IQueryable<Discussion> GetAll()
        {
            return this.service.GetAll();
        }
    }
}
