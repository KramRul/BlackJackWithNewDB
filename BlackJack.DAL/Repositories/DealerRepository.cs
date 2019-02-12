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
    public class DealerRepository : IRepository<Dealer>
    {
        private ApplicationContext db;

        public DealerRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public IEnumerable<Dealer> GetAll()
        {
            return db.Dealers;
        }

        public Dealer Get(Guid id)
        {
            return db.Dealers.Find(id);
        }

        public void Create(Dealer dealer)
        {
            db.Dealers.Add(dealer);
        }

        public void Update(Dealer dealer)
        {
            db.Entry(dealer).State = EntityState.Modified;
        }
        public IEnumerable<Dealer> Find(Func<Dealer, Boolean> predicate)
        {
            return db.Dealers.Where(predicate).ToList();
        }
        public void Delete(Guid id)
        {
            Dealer dealer = db.Dealers.Find(id);
            if (dealer != null)
                db.Dealers.Remove(dealer);
        }
    }
}
