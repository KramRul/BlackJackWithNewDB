using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.DAL.Entities
{
    public enum GameState : int
    {
        Unknown,
        PlayerWon,
        DealerWon,
        Draw
    }
}
