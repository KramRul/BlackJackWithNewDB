using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.DAL.Entities
{
    public class PlayerStep
    {
        public Guid Id { get; set; }

        public Suite Suite { get; set; }

        public Rank Rank { get; set; }

        public Guid PlayerId { get; set; }

        public Player Player { get; set; }
    }
}
