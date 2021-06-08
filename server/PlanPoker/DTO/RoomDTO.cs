using System;
using System.Collections.Generic;

namespace PlanPoker.DTO
{
    /// <summary>
    /// DTO комнаты.
    /// </summary>
    public class RoomDTO
    {
        /// <summary>
        /// Id комнаты.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Уникальный идентификатор для браузера.
        /// </summary>
        public Guid Hash { get; set; }

        /// <summary>
        /// Название комнаты.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Игроки.
        /// </summary>
        public ICollection<PlayerDTO> CurrentPlayers { get; set; }

        /// <summary>
        /// Все игроки, которые были в комнате.
        /// </summary>
        public ICollection<PlayerDTO> RoomPlayers { get; set; }

        /// <summary>
        /// Карты.
        /// </summary>
        public ICollection<CardDTO> Cards { get; set; }

        /// <summary>
        /// Обсуждения.
        /// </summary>
        public ICollection<DiscussionDTO> Discussions { get; set; }

        /// <summary>
        /// Управляющий комнатой.
        /// </summary>
        /// <remarks>По умолчанию ID создателя.</remarks>
        public Guid HostId { get; set; }

        /// <summary>
        /// Создатель.
        /// </summary>
        public Guid CreatorId { get; set; }
    }
}
