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
            this.Items.Add(new Card(new Guid("1"), 1, "first"));
            this.Items.Add(new Card(new Guid("2"), 2, "second"));
            this.Items.Add(new Card(new Guid("3"), 3, "third"));
        }
    }
}
