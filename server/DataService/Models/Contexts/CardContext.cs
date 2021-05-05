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
            this.Items.Add(new Card(new Guid(), 0, "zero"));
            this.Items.Add(new Card(new Guid(), 0.5, "zero point five"));
            this.Items.Add(new Card(new Guid(), 1, "first"));
            this.Items.Add(new Card(new Guid(), 2, "second"));
            this.Items.Add(new Card(new Guid(), 3, "third"));
            this.Items.Add(new Card(new Guid(), 5, "four"));
            this.Items.Add(new Card(new Guid(), 8, "eight"));
            this.Items.Add(new Card(new Guid(), 13, "thirteen"));
            this.Items.Add(new Card(new Guid(), 20, "twenty"));
            this.Items.Add(new Card(new Guid(), 40, "forty"));
            this.Items.Add(new Card(new Guid(), 100, "one hundred"));
            this.Items.Add(new Card(new Guid(), null, "question"));
            this.Items.Add(new Card(new Guid(), null, "infinity"));
            this.Items.Add(new Card(new Guid(), null, "coffee"));
        }
    }
}
