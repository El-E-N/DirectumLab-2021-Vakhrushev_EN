using DataService.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlanPoker.DTO.Builders
{
    /// <summary>
    /// Создатель DTO карты.
    /// </summary>
    public static class CardDTOBuilder
    {
        /// <summary>
        /// Получение DTO карты.
        /// </summary>
        /// <param name="card">Карта.</param>
        /// <returns>DTO карты.</returns>
        public static CardDTO Build(Card card)
        {
            return new CardDTO()
            {
                Id = card.Id,
                Value = card.Value,
                Name = card.Name
            };
        }

        /// <summary>
        /// Получение списка из DTO карт.
        /// </summary>
        /// <param name="cards">Карты.</param>
        /// <returns>Список из DTO карт.</returns>
        public static IEnumerable<CardDTO> BuildList(IEnumerable<Card> cards)
        {
            return cards.Select(card => CardDTOBuilder.Build(card));
        }
    }
}
