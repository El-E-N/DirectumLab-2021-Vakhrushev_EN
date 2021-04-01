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
        /// Создание карты.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="value">Значение.</param>
        /// <param name="name">Название.</param>
        /// <returns>Карта.</returns>
        public Card Create(Guid id, int? value, string name)
        {
            this.repository.Create(new Card(id, value, name));
            this.repository.Save();
            return this.repository.Get(id);
        }

        /// <summary>
        /// Получение карты по id.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Карта.</returns>
        public Card Get(Guid id)
        {
            return this.repository.Get(id);
        }

        /// <summary>
        /// Получение всех карт.
        /// </summary>
        /// <returns>Все голоса из базы данных.</returns>
        public IQueryable<Card> GetCards()
        {
            return this.repository.GetAll();
        }
    }
}
