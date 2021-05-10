using DataService.Repositories;
using System;
using System.Linq;
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
        private readonly CardMemoryRepository repository;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="repository">Репозиторий с голосованиями.</param>
        public CardService(CardMemoryRepository repository) { this.repository = repository; }

        /// <summary>
        /// Создание карты.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="name">Название.</param>
        /// <returns>Карта.</returns>
        public Card Create(double? value, string name)
        {
            var id = Guid.NewGuid();
            this.repository.Create(id, value, name);
            return this.repository.Get(id);
        }

        /// <summary>
        /// Получение карты по id.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Карта.</returns>
        public Card Get(Guid id) => this.repository.Get(id);

        /// <summary>
        /// Получение всех карт.
        /// </summary>
        /// <returns>Все голоса из базы данных.</returns>
        public IQueryable<Card> GetCards() => this.repository.GetItems();
    }
}
