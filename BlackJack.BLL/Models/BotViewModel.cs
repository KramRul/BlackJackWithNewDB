﻿using BlackJack.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Models
{
    public class BotViewModel
    {
        public Guid Id { get; set; }

        public decimal Balance { get; set; }

        public decimal Bet { get; set; }

        public Guid GameId { get; set; }

        public Game Game { get; set; }
    }
}
