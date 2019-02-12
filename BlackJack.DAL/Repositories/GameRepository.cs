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
    public class GameRepository : IRepository<Game>
    {
        private ApplicationContext db;

        public GameRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public IEnumerable<Game> GetAll()
        {
            return db.Games;
        }

        public Game Get(Guid id)
        {
            return db.Games.Find(id);
        }

        public void Create(Game game)
        {
            db.Games.Add(game);
        }

        public void Update(Game game)
        {
            db.Entry(game).State = EntityState.Modified;
        }
        public IEnumerable<Game> Find(Func<Game, Boolean> predicate)
        {
            return db.Games.Where(predicate).ToList();
        }
        public void Delete(Guid id)
        {
            Game game = db.Games.Find(id);
            if (game != null)
                db.Games.Remove(game);
        }
    }
}
