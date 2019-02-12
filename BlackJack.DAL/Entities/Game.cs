using System;

namespace BlackJack.DAL.Entities
{
    public class Game
    {
        public Guid Id { get; set; }

        public Guid PlayerId { get; set; }

        public Player Player { get; set; }
    }
}