using System;
using System.Collections.Generic;

namespace DataService.Models
{
    /// <summary>
    /// Сущность комнаты для покер-планирования.
    /// </summary>
    public class Room
    {
        public Room(string name, Guid creatorId, Guid id, Guid hash)
        {
            this.CreatorID = creatorId;
            this.ID = id;
            this.Hash = hash;
            this.HostID = creatorId;
            if (name != string.Empty)
                this.Name = name;
            else
                this.Name = "Room" + this.ID;
        }

        public Guid ID { get; }

        /// <summary>
        /// Уникальный идентификатор для браузера.
        /// </summary>
        public Guid Hash { get; }

        public string Name { get; }

        public List<Guid> PlayersIDs { get; }

        /// <summary>
        /// ID управляющего комнатой.
        /// </summary>
        /// <remarks>По умолчанию ID создателя.</remarks>
        public Guid HostID { get; set; }

        public Guid CreatorID { get; }
    }
}
