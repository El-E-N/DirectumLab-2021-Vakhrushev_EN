using System;
using System.Collections.Generic;

namespace DataService.Models
{
    /// <summary>
    /// Сущность комнаты для покер-планирования.
    /// </summary>
    public class Room
    {
        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="name">Название.</param>
        /// <param name="creatorId">Id создателя.</param>
        /// <param name="id">Id комнаты.</param>
        /// <param name="hash">Hash комнаты.</param>
        public Room(string name, Guid creatorId, Guid id, Guid hash)
        {
            this.CreatorID = creatorId;
            this.Id = id;
            this.Hash = hash;
            this.HostID = creatorId;
            if (name != string.Empty)
                this.Name = name;
            else
                this.Name = "Room" + this.Id;
        }

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
        /// Id игроков.
        /// </summary>
        public List<Guid> PlayersIDs { get; set; }

        /// <summary>
        /// ID управляющего комнатой.
        /// </summary>
        /// <remarks>По умолчанию ID создателя.</remarks>
        public Guid HostID { get; set; }

        /// <summary>
        /// Id создателя.
        /// </summary>
        public Guid CreatorID { get; set; }
    }
}
