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
    class PlayerStepRepository : IRepository<PlayerStep>
    {
        private ApplicationContext db;

        public PlayerStepRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public IEnumerable<PlayerStep> GetAll()
        {
            return db.PlayerSteps.Include(p=>p.Player);
        }

        public PlayerStep Get(Guid id)
        {
            return db.PlayerSteps.Find(id);
        }

        public void Create(PlayerStep playerStep)
        {
            db.PlayerSteps.Add(playerStep);
        }

        public void Update(PlayerStep playerStep)
        {
            db.Entry(playerStep).State = EntityState.Modified;
        }
        public IEnumerable<PlayerStep> Find(Func<PlayerStep, Boolean> predicate)
        {
            return db.PlayerSteps.Where(predicate).ToList();
        }
        public void Delete(Guid id)
        {
            PlayerStep playerStep = db.PlayerSteps.Find(id);
            if (playerStep != null)
                db.PlayerSteps.Remove(playerStep);
        }
    }
}
