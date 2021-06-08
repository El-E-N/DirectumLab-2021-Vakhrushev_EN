using DataService.Models;
using PlanPoker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace PlanPoker.DTO.Builders
{
    /// <summary>
    /// Создатель DTO обсуждения.
    /// </summary>
    public static class DiscussionDTOBuilder
    {
        /// <summary>
        /// Создание экземпляра DTO обсуждения.
        /// </summary>
        /// <param name="discussion">Обсуждение.</param>
        /// <param name="voteService">Сервис оценки.</param>
        /// <param name="cardService">Сервис карт.</param>
        /// <returns>DTO обсуждения.</returns>
        public static DiscussionDTO Build(Discussion discussion, VoteService voteService, CardService cardService)
        {
            var voteList = VoteDTOBuilder.BuildList(
                new List<Vote>(JsonSerializer.Deserialize<List<Guid>>(discussion.VoteIds).Select(el => voteService.GetById(el))),
                cardService);
            return new DiscussionDTO()
            {
                Id = discussion.Id,
                // RoomID = discussion.RoomId,
                Name = discussion.Name,
                StartAt = discussion.StartAt,
                EndAt = discussion.EndAt,
                VoteList = new List<VoteDTO>(voteList)
            };
        }

        /// <summary>
        /// Получение списка DTO обсуждений.
        /// </summary>
        /// <param name="discussions">Обсуждения.</param>
        /// <param name="voteService">Сервис оценки.</param>
        /// <param name="cardService">Сервис карт.</param>
        /// <returns>Список DTO обсуждений.</returns>
        public static ICollection<DiscussionDTO> BuildList(List<Discussion> discussions, VoteService voteService, CardService cardService)
        {
            return new List<DiscussionDTO>(discussions.Select(discussion => Build(discussion, voteService, cardService)));
        }
    }
}
