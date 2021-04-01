using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.Models;

namespace PlanPoker.Services
{
    /// <summary>
    /// Сервис карт.
    /// </summary>
    public class CardService
    {
        /// <summary>
        /// Репозиторий с картами.
        /// </summary>
        private readonly IRepository<Card> repository;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="repository">Репозиторий с голосованиями.</param>
        public CardService(IRepository<Card> repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Создание голоса.
        /// </summary>
        /// <param name="cardId">Id выбранной карты.</param>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="playerId">Id игрока.</param>
        /// <param name="discussionId">Id обсуждения.</param>
        /// <returns></returns>
        public Card Create(Guid id, int? value, string name)
        {
            this.repository.Create(new Card(id, value, name));
            this.repository.Save();
            return this.repository.Get(id);
        }

        /// <summary>
        /// Просто для проверки работы.
        /// </summary>
        /// <returns>Все голоса из базы данных.</returns>
        public IQueryable<Card> GetAll()
        {
            return this.repository.GetAll();
        }
    }
}
