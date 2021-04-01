using DataService.Models;

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
                Name = player.Name,
                Token = player.Token
            };
        }
    }
}
