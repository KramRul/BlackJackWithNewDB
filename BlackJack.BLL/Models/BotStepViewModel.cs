using BlackJack.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Models
{
    public class BotStepViewModel
    {
        public Guid Id { get; set; }

        public Suite Suite { get; set; }

        public Rank Rank { get; set; }

        public Guid BotId { get; set; }

        public Bot Bot { get; set; }

        public Guid GameId { get; set; }

        public Game Game { get; set; }
    }
}
