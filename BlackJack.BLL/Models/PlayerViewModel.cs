using BlackJack.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.BLL.Models
{
    public class PlayerViewModel : IdentityUser
    {
        public Guid GameId { get; set; }

        public Game Game { get; set; }

        public decimal Balance { get; set; }

        public decimal Bet { get; set; }
    }
}
