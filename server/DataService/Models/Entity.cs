using System;

namespace DataService.Models
{
    /// <summary>
    /// Сущность.
    /// </summary>
    public class Entity : IEntity
    {  
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }
    }
}
