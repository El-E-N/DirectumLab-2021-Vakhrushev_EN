using Microsoft.AspNetCore.Mvc;
using PlanPoker.DTO;
using PlanPoker.DTO.Builders;
using PlanPoker.Services;
using System.Linq;

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

        /// <summary>
        /// Получение всех оценок.
        /// </summary>
        /// <returns>Все оценки.</returns>
        public IQueryable<CardDTO> GetCards()
        {
            return this.service.GetCards()
                .Select(card => CardDTOBuilder.Build(card));
        }
    }
}
