using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.DAL.Entities
{
    public class Dealer
    {
        public Guid Id { get; set; }

        public Guid GameId { get; set; }

        public Game Game { get; set; }
    }
}
