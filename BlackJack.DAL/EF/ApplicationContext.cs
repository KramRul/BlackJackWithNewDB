using BlackJack.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Text;

namespace BlackJack.DAL.EF
{
    public class ApplicationContext : IdentityDbContext<Player>
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Bot> Bots { get; set; }
        public DbSet<BotStep> BotSteps { get; set; }
        public DbSet<PlayerStep> PlayerSteps { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }

    
}
