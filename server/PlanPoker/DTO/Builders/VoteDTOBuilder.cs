using DataService.Models;
using PlanPoker.Services;
using System.Collections.Generic;
using System.Linq;

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
        /// <param name="cardService">Сервис карт.</param>
        /// <returns>DTO оценки.</returns>
        public static VoteDTO Build(Vote vote, CardService cardService)
        {
            Card card;
            CardDTO cardDto;
            if (vote.CardId != null)
            {
                card = cardService.Get((System.Guid)vote.CardId);
                cardDto = CardDTOBuilder.Build(card);
            }
            else
                cardDto = null;
            return new VoteDTO()
            {
                Id = vote.Id,
                Card = cardDto,
                //RoomId = vote.RoomId,
                PlayerId = vote.PlayerId,
                DiscussionId = vote.DiscussionId
            };
        }

        /// <summary>
        /// Получение списка DTO оценок.
        /// </summary>
        /// <param name="allVote">Оценки.</param>
        /// <param name="cardService">Сервис карт.</param>
        /// <returns>Список DTO оценок.</returns>
        public static IEnumerable<VoteDTO> BuildList(IEnumerable<Vote> allVote, CardService cardService)
        {
            return allVote.Select(vote => Build(vote, cardService));
        }
    }
}
