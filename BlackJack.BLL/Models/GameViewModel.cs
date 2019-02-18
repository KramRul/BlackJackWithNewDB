using BlackJack.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Models
{
    public class GameViewModel
    {
        public Guid Id { get; set; }

        public GameState GameState { get; set; }

        public Player Player { get; set; }

        public Dealer Dealer { get; set; }
    }
}
