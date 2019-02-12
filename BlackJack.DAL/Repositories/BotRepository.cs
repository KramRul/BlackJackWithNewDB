using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.DAL.Repositories
{
    public class BotRepository : IRepository<Bot>
    {
        private ApplicationContext db;

        public BotRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public IEnumerable<Bot> GetAll()
        {
            return db.Bots;
        }

        public Bot Get(Guid id)
        {
            return db.Bots.Find(id);
        }

        public void Create(Bot bot)
        {
            db.Bots.Add(bot);
        }

        public void Update(Bot bot)
        {
            db.Entry(bot).State = EntityState.Modified;
        }
        public IEnumerable<Bot> Find(Func<Bot, Boolean> predicate)
        {
            return db.Bots.Where(predicate).ToList();
        }
        public void Delete(Guid id)
        {
            Bot bot = db.Bots.Find(id);
            if (bot != null)
                db.Bots.Remove(bot);
        }
    }
}