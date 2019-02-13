using BlackJack.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Models
{
    public class PlayerStepViewModel
    {
        public Guid Id { get; set; }

        public Suite Suite { get; set; }

        public Rank Rank { get; set; }

        public string PlayerId { get; set; }

        public Player Player { get; set; }
    }
}
