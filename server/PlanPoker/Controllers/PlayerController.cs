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

public class PlayerDtoWithToken : PlayerDTO
{
    public Guid Token { get; set; }
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
        public PlayerDtoWithToken Create([FromBody] string name)
        {
            var player = this.service.Create(name);
            var playerDto = PlayerDTOBuilder.Build(player);
            var tokenGuid = Guid.Parse(player.Token.Replace(" ", string.Empty));
            var result = new PlayerDtoWithToken()
            {
                Id = playerDto.Id,
                Name = playerDto.Name,
                Token = tokenGuid
            };
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public PlayerDtoWithToken GetById([FromBody] string id)
        {
            var guid = Guid.Parse(id.Replace(" ", string.Empty));
            var player = this.service.GetById(guid);
            var playerDto = PlayerDTOBuilder.Build(player);
            var tokenGuid = Guid.Parse(player.Token.Replace(" ", string.Empty));
            var result = new PlayerDtoWithToken()
            {
                Id = playerDto.Id,
                Name = playerDto.Name,
                Token = tokenGuid
            };
            return result;
        }

        [HttpPost]
        public PlayerDtoWithToken GetByToken()
        {
            var tokenGuid = Guid.Parse(Request.Headers["token"].ToString().Replace(" ", string.Empty));
            var player = this.service.GetByToken(tokenGuid);
            var playerDto = PlayerDTOBuilder.Build(player);
            var result = new PlayerDtoWithToken()
            {
                Id = playerDto.Id,
                Name = playerDto.Name,
                Token = tokenGuid
            };
            return result;
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
        public PlayerDtoWithToken ChangeName(ElementForPlayerChangeName body)
        {
            var playerGuid = Guid.Parse(body.playerId.Replace(" ", string.Empty));
            var player = this.service.GetById(playerGuid);
            var updatingPlayer = this.service.ChangeName(playerGuid, body.name);
            var playerDto = PlayerDTOBuilder.Build(updatingPlayer);
            var tokenGuid = Guid.Parse(updatingPlayer.Token.Replace(" ", string.Empty));
            var result = new PlayerDtoWithToken()
            {
                Id = playerDto.Id,
                Name = playerDto.Name,
                Token = tokenGuid
            };
            return result;
        }
    }
}
