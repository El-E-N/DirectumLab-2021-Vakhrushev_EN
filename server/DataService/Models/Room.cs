using System;
using System.Collections.Generic;
using System.Text.Json;

namespace DataService.Models
{
    /// <summary>
    /// Сущность комнаты для покер-планирования.
    /// </summary>
    public class Room : Entity
    {
        /// <summary>
        /// Пустой конструктор.
        /// </summary>
        public Room()
        {
        }

        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="name">Название.</param>
        /// <param name="hostId">Id ведущего.</param>
        /// <param name="creatorId">Id создателя.</param>
        /// <param name="id">Id комнаты.</param>
        /// <param name="hash">Hash комнаты.</param>
        /// <param name="playersIds">Id игроков.</param>
        public Room(string name, Guid hostId, Guid creatorId, Guid id, Guid hash, ICollection<Guid> playersIds)
        {
            this.CreatorId = creatorId;
            this.PlayersIds = JsonSerializer.Serialize<ICollection<Guid>>(playersIds);
            this.Id = id;
            this.Hash = hash;
            this.HostId = hostId;
            if (name != string.Empty)
                this.Name = name;
            else
                this.Name = "Room" + this.Id;
        }

        /// <summary>
        /// Уникальный идентификатор для браузера.
        /// </summary>
        public Guid Hash { get; set; }

        /// <summary>
        /// Название комнаты.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Id игроков.
        /// </summary>
        public string PlayersIds { get; set; }

        /// <summary>
        /// ID управляющего комнатой.
        /// </summary>
        /// <remarks>По умолчанию ID создателя.</remarks>
        public Guid HostId { get; set; }

        /// <summary>
        /// Id создателя.
        /// </summary>
        public Guid CreatorId { get; set; }
    }
}
