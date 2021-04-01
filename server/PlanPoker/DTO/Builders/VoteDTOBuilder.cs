using DataService.Models;

namespace PlanPoker.DTO.Builders
{
    /// <summary>
    /// Создатель DTO оценки.
    /// </summary>
    public static class VoteDTOBuilder
    {
        /// <summary>
        /// Создание экземпляра DTO оценки.
        /// </summary>
        /// <param name="vote">Оценка.</param>
        /// <param name="card">Карта.</param>
        /// <returns>DTO оценки.</returns>
        public static VoteDTO Build(Vote vote, Card card)
        {
            return new VoteDTO()
            {
                Id = vote.Id,
                Card = card,
                RoomID = vote.RoomID,
                PlayerID = vote.PlayerID,
                DiscussionID = vote.DiscussionID
            };
        }
    }
}
