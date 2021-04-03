using DataService.Models;
using PlanPoker.Services;
using System.Collections.Generic;
using System.Linq;

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
                discussion.VoteIds.Select(id => voteService.GetVote(id)),
                cardService);
            return new DiscussionDTO()
            {
                Id = discussion.Id,
                RoomID = discussion.RoomId,
                Name = discussion.Name,
                StartAt = discussion.StartAt,
                EndAt = discussion.EndAt,
                VoteList = voteList
            };
        }

        /// <summary>
        /// Получение списка DTO обсуждений.
        /// </summary>
        /// <param name="discussions">Обсуждения.</param>
        /// <param name="voteService">Сервис оценки.</param>
        /// <param name="cardService">Сервис карт.</param>
        /// <returns>Список DTO обсуждений.</returns>
        public static IEnumerable<DiscussionDTO> BuildList(IEnumerable<Discussion> discussions, VoteService voteService, CardService cardService)
        {
            return discussions.Select(discussion => Build(discussion, voteService, cardService));
        }
    }
}
