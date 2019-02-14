using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Models
{
    public class GameDetailsViewModel
    {
        public GameViewModel Game { get; set; }

        public IEnumerable<PlayerStepViewModel> PlayerStepVM { get; set; }

        public IEnumerable<DealerStepViewModel> DealerStepVM { get; set; }

        public IEnumerable<BotStepViewModel> BotStepVM { get; set; }
    }
}
