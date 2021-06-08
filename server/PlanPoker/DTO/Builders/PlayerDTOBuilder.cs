using DataService.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlanPoker.DTO.Builders
{
    /// <summary>
    /// Создатель DTO игрока.
    /// </summary>
    public static class PlayerDTOBuilder
    {
        /// <summary>
        /// Создание экземпляра DTO игрока.
        /// </summary>
        /// <param name="player">Игрок.</param>
        /// <returns>DTO игрока.</returns>
        public static PlayerDTO Build(Player player)
        {
            return new PlayerDTO()
            {
                Id = player.Id,
                Name = player.Name
            };
        }

        /// <summary>
        /// Получение списка DTO игроков.
        /// </summary>
        /// <param name="players">Игроки.</param>
        /// <returns>Список DTO игроков.</returns>
        public static ICollection<PlayerDTO> BuildList(ICollection<Player> players)
        {
            return new List<PlayerDTO>(players.Select(player => Build(player)));
        }
    }
}
