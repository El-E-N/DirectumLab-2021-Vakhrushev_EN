using DataService.Models;
using Microsoft.AspNetCore.Mvc;
using PlanPoker.DTO;
using PlanPoker.DTO.Builders;
using PlanPoker.Services;
using System;
using System.Collections.Generic;

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
        /// <returns>Объект игрока.</returns>
        /// <remarks>Не DTO, так как необходим токен.</remarks>
        [HttpGet]
        public PlayerDTO Create(string name)
        {
            var player = this.service.Create(name);
            return PlayerDTOBuilder.Build(player);
        }

        /// <summary>
        /// Получить токен игрока.
        /// </summary>
        /// <param name="id">Id игрока.</param>
        /// <returns>Токен игрока.</returns>
        [HttpGet]
        public string GetToken(string id)
        {
            var guid = Guid.Parse(id.Replace(" ", string.Empty));
            return this.service.GetToken(guid);
        }

        /// <summary>
        /// Изменение имени игрока.
        /// </summary>
        /// <param name="playerId">Id игрока.</param>
        /// <param name="name">Новое имя игрока.</param>
        /// <returns>Объект DTO игрока с измененным именем.</returns>
        [HttpGet]
        public PlayerDTO ChangeName(string playerId, string name)
        {
            var playerGuid = Guid.Parse(playerId.Replace(" ", string.Empty));
            var updatingPlayer = this.service.ChangeName(playerGuid, name);
            return PlayerDTOBuilder.Build(updatingPlayer);
        }

        /// <summary>
        /// Получить всех игроков.
        /// </summary>
        /// <returns>Все игроки из базы данных.</returns>
        [HttpGet]
        public IEnumerable<PlayerDTO> GetPlayers()
        {
            var players = this.service.GetPlayers();
            return PlayerDTOBuilder.BuildList(players);
        }
    }
}
