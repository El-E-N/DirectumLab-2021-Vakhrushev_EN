using System;

namespace DataService.Models
{
    /// <summary>
    /// Игрок.
    /// </summary>
    public class Player : Entity
    {
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Player()
        {
            this.Id = Guid.NewGuid();
            this.Token = Guid.NewGuid().ToString();
            this.Name = "Player" + this.Id;
        }

        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="id">Id игрока.</param>
        /// <param name="name">Имя игрока.</param>
        /// <param name="token">Токен игрока.</param>
        public Player(Guid id, string name, string token)
        {
            this.Id = id;
            this.Token = token;
            if (name != string.Empty)
                this.Name = name;
            else
                this.Name = "Player" + this.Id;
        }

        /// <summary>
        /// Токен для браузера.
        /// </summary>
        /// <remarks>Для подтверждения, что он нужный игрок.</remarks>
        public string Token { get; set; }

        /// <summary>
        /// Имя игрока.
        /// </summary>
        public string Name { get; set; } 
    }
}
