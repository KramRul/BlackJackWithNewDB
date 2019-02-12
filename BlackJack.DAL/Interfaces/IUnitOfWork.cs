using BlackJack.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Game> Games { get; }
        IRepository<Player> Players { get; }
        IRepository<Bot> Bots { get; }
        IRepository<Dealer> Dealers { get; }
        IRepository<DealerStep> DealerSteps { get; }
        IRepository<BotStep> BotSteps { get; }
        IRepository<PlayerStep> PlayerSteps { get; }
        void Save();
    }
}
