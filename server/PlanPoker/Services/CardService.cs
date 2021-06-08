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
        /// Добавление стандартных карт.
        /// </summary>
        public void AddDefaultCards()
        {
            this.Create(0, "number");
            this.Create(0.5, "number");
            this.Create(1, "number");
            this.Create(2, "number");
            this.Create(3, "number");
            this.Create(5, "number");
            this.Create(8, "number");
            this.Create(13, "number");
            this.Create(20, "number");
            this.Create(40, "number");
            this.Create(100, "number");
            this.Create(null, "question");
            this.Create(null, "infinity");
            this.Create(null, "coffee");
        }

        /// <summary>
        /// Получение всех карт.
        /// </summary>
        /// <returns>Все голоса из базы данных.</returns>
        public IQueryable<Card> GetCards()
        {
            var tempCard = this.Create(1234435321234, "qwep[ewkrlq,dqw;foiw");
            this.repository.Delete(tempCard.Id);
            var cards = this.repository.GetItems();
            if (!cards.Any())
                this.AddDefaultCards();
            return this.repository.GetItems();
        }
    }
}
