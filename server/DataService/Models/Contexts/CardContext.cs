using Microsoft.EntityFrameworkCore;
using System;

namespace DataService.Models.Contexts
{
    /// <summary>
    /// Контекст карты.
    /// </summary>
    public class CardContext : ItemContext<Card>
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="options">Опции.</param>
        public CardContext(DbContextOptions<CardContext> options) : base(options) 
        {
        }
    }
}
