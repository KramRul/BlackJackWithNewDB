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
    public class PlayerRepository:IRepository<Player>
    {
        private ApplicationContext db;

        public PlayerRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public IEnumerable<Player> GetAll()
        {
            return db.Users;
        }

        public Player Get(Guid id)
        {
            return db.Users.Find(id);
        }

        public void Create(Player player)
        {
            db.Users.Add(player);
        }

        public void Update(Player player)
        {
            db.Entry(player).State = EntityState.Modified;
        }

        public IEnumerable<Player> Find(Func<Player, Boolean> predicate)
        {
            return db.Users.Where(predicate).ToList();
        }

        public void Delete(Guid id)
        {
            Player player = db.Users.Find(id);
            if (player != null)
                db.Users.Remove(player);
        }
    }
}
