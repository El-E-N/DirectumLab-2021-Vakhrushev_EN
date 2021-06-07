using Microsoft.AspNetCore.Mvc;
using PlanPoker.DTO;
using PlanPoker.DTO.Builders;
using PlanPoker.Services;
using System;

public class ElementForPlayerChangeName
{
    public string playerId { get; set; }
    public string name { get; set; }
}

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
        [HttpPost]
        public PlayerDTO Create([FromBody] string name)
        {
            var player = this.service.Create(name);
            return PlayerDTOBuilder.Build(player);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public PlayerDTO GetById([FromBody] string id)
        {
            var guid = Guid.Parse(id.Replace(" ", string.Empty));
            var player = this.service.GetById(guid);
            return PlayerDTOBuilder.Build(player);
        }

        /// <summary>
        /// Получить токен игрока.
        /// </summary>
        /// <param name="id">Id игрока.</param>
        /// <returns>Токен игрока.</returns>
        [HttpPost]
        public string GetToken([FromBody] string id)
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
        [HttpPost]
        public PlayerDTO ChangeName(ElementForPlayerChangeName body)
        {
            var playerGuid = Guid.Parse(body.playerId.Replace(" ", string.Empty));
            var updatingPlayer = this.service.ChangeName(playerGuid, body.name);
            return PlayerDTOBuilder.Build(updatingPlayer);
        }
    }
}
