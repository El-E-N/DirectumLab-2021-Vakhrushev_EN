using DataService.Models;
using System.Collections.Generic;

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
        /// <param name="voteList">Список голосований.</param>
        /// <returns>DTO обсуждения.</returns>
        public static DiscussionDTO Build(Discussion discussion, List<VoteDTO> voteList)
        {
            return new DiscussionDTO()
            {
                Id = discussion.Id,
                RoomID = discussion.RoomID,
                Name = discussion.Name,
                StartAt = discussion.StartAt,
                EndAt = discussion.EndAt,
                VoteList = voteList
            };
        }
    }
}
