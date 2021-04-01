using DataService.Models;
using System.Collections.Generic;

namespace PlanPoker.DTO.Builders
{
    /// <summary>
    /// Создатель DTO комнаты.
    /// </summary>
    public static class RoomDTOBuilder
    {
        /// <summary>
        /// Создание экземпляра DTO комнаты.
        /// </summary>
        /// <param name="room">Комната.</param>
        /// <param name="players">Список из экземпляров игроков.</param>
        /// <returns>Экземпляр DTO комнаты.</returns>
        public static RoomDTO Build(Room room, List<PlayerDTO> players)
        {
            return new RoomDTO()
            {
                Id = room.Id,
                Hash = room.Hash,
                Name = room.Name,
                HostId = room.HostID,
                CreatorId = room.CreatorID,
                Players = players
            };
        }
    }
}
