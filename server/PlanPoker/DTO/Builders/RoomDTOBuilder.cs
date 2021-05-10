using DataService.Models;
using PlanPoker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

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
        /// <param name="playerService">Сервис игроков.</param>
        /// <returns>Экземпляр DTO комнаты.</returns>
        public static RoomDTO Build(Room room, PlayerService playerService)
        {
            var players = PlayerDTOBuilder.BuildList(
                new List<Player>(JsonSerializer.Deserialize<List<Guid>>(room.PlayersIds).Select(el => playerService.GetById(el)))
                );
            return new RoomDTO()
            {
                Id = room.Id,
                Hash = room.Hash,
                Name = room.Name,
                HostId = room.HostId,
                CreatorId = room.CreatorId,
                Players = players
            };
        }

        /// <summary>
        /// Создание списка DTO комнат.
        /// </summary>
        /// <param name="rooms">Комнаты.</param>
        /// <param name="playerService">Сервис игроков.</param>
        /// <returns>Список DTO комнат.</returns>
        public static ICollection<RoomDTO> BuildList(List<Room> rooms, PlayerService playerService)
        {
            return new List<RoomDTO>(rooms.Select(room => Build(room, playerService)));
        }
    }
}
