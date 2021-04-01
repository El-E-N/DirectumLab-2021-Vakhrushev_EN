using DataService.Models;

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
    }
}
