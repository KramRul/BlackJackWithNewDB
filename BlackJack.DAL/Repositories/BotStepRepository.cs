using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.DAL.Repositories
{
    public class BotStepRepository : IRepository<BotStep>
    {
        private ApplicationContext db;

        public BotStepRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public IEnumerable<BotStep> GetAll()
        {
            return db.BotSteps;
        }

        public BotStep Get(Guid id)
        {
            return db.BotSteps.Find(id);
        }

        public void Create(BotStep botStep)
        {
            db.BotSteps.Add(botStep);
        }

        public void Update(BotStep botStep)
        {
            db.Entry(botStep).State = EntityState.Modified;
        }
        public IEnumerable<BotStep> Find(Func<BotStep, Boolean> predicate)
        {
            return db.BotSteps.Where(predicate).ToList();
        }
        public void Delete(Guid id)
        {
            BotStep botStep = db.BotSteps.Find(id);
            if (botStep != null)
                db.BotSteps.Remove(botStep);
        }
    }
}
