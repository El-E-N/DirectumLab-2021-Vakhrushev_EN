using System;

namespace DataService.Models
{
    public class Player
    {
        public Player(Guid id, string name, string token)
        {
            this.ID = id;
            this.Token = token;
            if (name != string.Empty)
                this.Name = name;
            else
                this.Name = "Player" + this.ID;
        }

        public Guid ID { get; }

        /// <summary>
        /// Токен для браузера.
        /// </summary>
        /// <remarks>Для подтверждения, что он нужный игрок</remarks>
        public string Token { get; }

        public string Name 
        { 
            get => this.Name;

            set
            {
                if (value != string.Empty)
                    this.Name = value;
                else
                    this.Name = "Player" + this.ID;
            }
        } 
    }
}
