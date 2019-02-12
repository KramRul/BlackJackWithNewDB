using BlackJack.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.BLL.Models
{
    public class HandViewModel
    {
        public Guid Id { get; set; }

        public int PlayerId { get; set; }

        public Player Player { get; set; }
    }
}
