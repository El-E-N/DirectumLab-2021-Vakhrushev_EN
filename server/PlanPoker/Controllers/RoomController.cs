using DataService.Models;
using DataService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanPoker.Services;
using System;
using System.Linq;

namespace PlanPoker.Controllers
{
    /// <summary>
    /// Контроллер комнаты.
    /// </summary>
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class RoomController
    {
        /// <summary>
        /// Сервисы комнаты.
        /// </summary>
        private readonly RoomService service;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="service">Сервисы.</param>
        public RoomController(RoomService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Создание комнаты с названием и Id создателя комнаты.
        /// </summary>
        /// <param name="name">Название комнаты.</param>
        /// <param name="creatorId">Id создателя.</param>
        /// <returns>Объект созданной комнаты.</returns>
        [HttpGet]
        public Room Create(string name, Guid creatorId)
        {
            return this.service.Create(name, creatorId);
        }

        /// <summary>
        /// Добавление игрока в комнату.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="playerId">Id добавляемого игрока.</param>
        [HttpPost]
        public void AddPlayer(Guid roomId, Guid playerId)
        {
            this.service.AddPlayer(roomId, playerId);
        }

        /// <summary>
        /// Удаление игрока из комнаты.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="playerId">Id игрока.</param>
        [HttpPost]
        public void RemovePlayer(Guid roomId, Guid playerId)
        {
            this.service.RemovePlayer(roomId, playerId);
        }

        /// <summary>
        /// Изменение ведущего комнаты.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="hostId">Id ведущего.</param>
        [HttpPost]
        public void ChangeHost(Guid roomId, Guid hostId)
        {
            this.service.ChangeHost(roomId, hostId);
        }

        /// <summary>
        /// Просто для проверки работы.
        /// </summary>
        /// <returns>Все комнаты из базы данных.</returns>
        [HttpGet]
        public IQueryable<Room> GetAll()
        {
            return this.service.GetAll();
        }
    }
}
