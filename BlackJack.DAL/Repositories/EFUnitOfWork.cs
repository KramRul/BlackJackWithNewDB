using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;
        private GameRepository gameRepository;
        private PlayerStepRepository playerStepRepository;
        private BotStepRepository botStepRepository;
        private PlayerRepository playerRepository;
        private BotRepository botRepository;

        public EFUnitOfWork(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(connectionString);
            db = new ApplicationContext(optionsBuilder.Options);
        }
        public IRepository<Game> Games
        {
            get
            {
                if (gameRepository == null)
                    gameRepository = new GameRepository(db);
                return gameRepository;
            }
        }

        public IRepository<Player> Players
        {
            get
            {
                if (playerRepository == null)
                    playerRepository = new PlayerRepository(db);
                return playerRepository;
            }
        }

        public IRepository<Bot> Bots
        {
            get
            {
                if (botRepository == null)
                    botRepository = new BotRepository(db);
                return botRepository;
            }
        }

        public IRepository<PlayerStep> PlayerSteps
        {
            get
            {
                if (playerStepRepository == null)
                    playerStepRepository = new PlayerStepRepository(db);
                return playerStepRepository;
            }
        }

        public IRepository<BotStep> BotSteps
        {
            get
            {
                if (botStepRepository == null)
                    botStepRepository = new BotStepRepository(db);
                return botStepRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
