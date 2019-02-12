using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.DAL.Entities
{
    public class BotStep
    {
        public Guid Id { get; set; }

        public Suite Suite { get; set; }

        public Rank Rank { get; set; }

        public Guid BotId { get; set; }

        public Bot Bot { get; set; }
    }
}
