using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Models
{
    public class GameStateViewModel
    {
        public GameViewModel Game { get; set; }

        public PlayerStepViewModel PlayerStepVM { get; set; }
    }
}
