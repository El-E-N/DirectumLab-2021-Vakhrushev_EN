using Microsoft.AspNetCore.Mvc;
using PlanPoker.DTO;
using PlanPoker.DTO.Builders;
using PlanPoker.Services;
using System;
using System.Collections.Generic;

namespace PlanPoker.Controllers
{
    /// <summary>
    /// Контроллер карт.
    /// </summary>
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class CardController
    {
        /// <summary>
        /// Сервисы карт.
        /// </summary>
        private readonly CardService service;

        /// <summary>
        /// Конструктор игрока.
        /// </summary>
        /// <param name="service">Сервисы.</param>
        public CardController(CardService service)
        {
            this.service = service;
        }

        [HttpGet]
        public void Create(double? value, string name)
        {
            this.service.Create(value, name);
        }

        /// <summary>
        /// Получение всех оценок.
        /// </summary>
        /// <returns>Все оценки.</returns>
        [HttpGet]
        public IEnumerable<CardDTO> GetCards()
        {
            var cards = this.service.GetCards();
            return CardDTOBuilder.BuildList(cards);
        }
    }
}
