using System;

namespace BlackJack.DAL.Entities
{
    public class Game
    {
        public Guid Id { get; set; }

        //public string PlayerId { get; set; }

        public Player Player { get; set; }

        public Dealer Dealer { get; set; }
    }
}