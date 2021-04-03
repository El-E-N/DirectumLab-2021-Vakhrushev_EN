﻿using System;

namespace DataService.Models
{
    /// <summary>
    /// Интерфейс сущности.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }
    }
}
