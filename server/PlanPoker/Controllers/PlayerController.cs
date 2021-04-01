using DataService.Models;
using Microsoft.AspNetCore.Mvc;
using PlanPoker.DTO;
using PlanPoker.DTO.Builders;
using PlanPoker.Services;
using System;
using System.Linq;

namespace PlanPoker.Controllers
{
    /// <summary>
    /// Контроллер игрока.
    /// </summary>
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class PlayerController : ControllerBase
    {
        /// <summary>
        /// Сервисы игрока.
        /// </summary>
        private readonly PlayerService service;

        /// <summary>
        /// Конструктор игрока.
        /// </summary>
        /// <param name="service">Сервисы.</param>
        public PlayerController(PlayerService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Создание игрока с именем.
        /// </summary>
        /// <param name="name">Имя игрока.</param>
        /// <returns>Объект DTO игрока.</returns>
        [HttpGet]
        public PlayerDTO Create(string name)
        {
            return PlayerDTOBuilder.Build(this.service.Create(name));
        }

        /// <summary>
        /// Изменение имени игрока.
        /// </summary>
        /// <param name="playerId">Id игрока.</param>
        /// <param name="name">Новое имя игрока.</param>
        /// <returns>Объект DTO игрока с измененным именем.</returns>
        [HttpGet]
        public PlayerDTO ChangeName(Guid playerId, string name)
        {
            return PlayerDTOBuilder.Build(this.service.ChangeName(playerId, name));
        }

        /// <summary>
        /// Получить всех игроков.
        /// </summary>
        /// <returns>Все игроки из базы данных.</returns>
        [HttpGet]
        public IQueryable<PlayerDTO> GetPlayers()
        {
            return this.service.GetPlayers()
                .Select(el => PlayerDTOBuilder.Build(el));
        }
    }
}
