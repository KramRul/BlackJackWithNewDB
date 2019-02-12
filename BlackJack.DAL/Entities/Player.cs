using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace BlackJack.DAL.Entities
{
    public class Player : IdentityUser
    {
        public Guid GameId { get; set; }

        public Game Game { get; set; }

        public decimal Balance { get; set; }

        public decimal Bet { get; set; }

        public Role Role { get; set; }
    }
}
