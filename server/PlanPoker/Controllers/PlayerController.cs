using DataService.Models;
using Microsoft.AspNetCore.Mvc;
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
        /// <returns>Объект игрока.</returns>
        // [HttpGet("create/{name}")]
        [HttpGet]
        public Player Create(string name)
        {
            return this.service.Create(name);
        }

        /// <summary>
        /// Изменение имени игрока.
        /// </summary>
        /// <param name="playerId">Id игрока.</param>
        /// <param name="name">Новое имя игрока.</param>
        /// <returns>Игрок с измененным именем.</returns>
        [HttpGet]
        public Player ChangeName(Guid playerId, string name)
        {
            return this.service.ChangeName(playerId, name);
        }

        /// <summary>
        /// Просто для проверки работы.
        /// </summary>
        /// <returns>Все игроки из базы данных.</returns>
        // [HttpGet("getall")]
        [HttpGet]
        public IQueryable<Player> GetAll()
        {
            return this.service.GetAll();
        }
    }
}
