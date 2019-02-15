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
    public class DealerStepRepository : IRepository<DealerStep>
    {
        private ApplicationContext db;

        public DealerStepRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public IEnumerable<DealerStep> GetAll()
        {
            return db.DealerSteps.Include(d=>d.Dealer);
        }

        public DealerStep Get(Guid id)
        {
            return db.DealerSteps.Find(id);
        }

        public void Create(DealerStep dealerStep)
        {
            db.DealerSteps.Add(dealerStep);
        }

        public void Update(DealerStep dealerStep)
        {
            db.Entry(dealerStep).State = EntityState.Modified;
        }
        public IEnumerable<DealerStep> Find(Func<DealerStep, Boolean> predicate)
        {
            return db.DealerSteps.Where(predicate).ToList();
        }
        public void Delete(Guid id)
        {
            DealerStep dealerStep = db.DealerSteps.Find(id);
            if (dealerStep != null)
                db.DealerSteps.Remove(dealerStep);
        }
    }
}
