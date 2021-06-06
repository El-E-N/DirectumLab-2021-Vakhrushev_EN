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
        public static RoomDTO Build(Room room, PlayerService playerService, CardService cardService, DiscussionService discussionService, VoteService voteService)
        {
            var players = PlayerDTOBuilder.BuildList(
                new List<Player>(JsonSerializer.Deserialize<List<Guid>>(room.PlayersIds).Select(el => playerService.GetById(el)))
                );
            var cardsDto = new List<CardDTO>(CardDTOBuilder.BuildList(cardService.GetCards()));
            var discussions = new List<Discussion>(discussionService.GetDiscussionsByRoomId(room.Id));
            var discussionsDto = DiscussionDTOBuilder.BuildList(discussions, voteService, cardService);

            var allPlayers = new List<Player>();
            foreach (var discussionDTO in discussionsDto)
            {
                var tempPlayers = discussionDTO.VoteList.Select(vote => playerService.GetById(vote.PlayerId));
                allPlayers.AddRange(tempPlayers);
            }
            allPlayers = new List<Player>(allPlayers.Distinct());
            var allPlayersDto = PlayerDTOBuilder.BuildList(allPlayers);

            return new RoomDTO()
            {
                Id = room.Id,
                Hash = room.Hash,
                Name = room.Name,
                HostId = room.HostId,
                CreatorId = room.CreatorId,
                Players = players,
                AllPlayers = allPlayersDto,
                Cards = cardsDto,
                Discussions = discussionsDto
            };
        }

        /// <summary>
        /// Создание списка DTO комнат.
        /// </summary>
        /// <param name="rooms">Комнаты.</param>
        /// <param name="playerService">Сервис игроков.</param>
        /// <returns>Список DTO комнат.</returns>
        public static ICollection<RoomDTO> BuildList(List<Room> rooms, PlayerService playerService, CardService cardService, DiscussionService discussionService, VoteService voteService)
        {
            return new List<RoomDTO>(rooms.Select(room => Build(room, playerService, cardService, discussionService, voteService)));
        }
    }
}
