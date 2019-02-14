using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Models;
using BlackJack.DAL.Interfaces;
using BlackJack.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Services
{
    public class BotService : IBotService
    {
        private IUnitOfWork Database { get; set; }

        public BotService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Create(BotViewModel botVM)
        {
            Database.Bots.Create(new Bot() { Id = botVM.Id, Balance = botVM.Balance, Bet = botVM.Bet });
            Database.Save();
        }

        public void Delete(Guid botId)
        {
            Database.Bots.Delete(botId);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void Edit(BotViewModel botVM)
        {
            Bot bot = Database.Bots.Get(botVM.Id);
            bot.Id = botVM.Id;
            bot.Balance = botVM.Balance;
            bot.Bet = botVM.Bet;
            Database.Bots.Update(bot);
            Database.Save();
        }

        public IEnumerable<BotViewModel> GetAllBots()
        {
            List<BotViewModel> pl = new List<BotViewModel>();
            foreach (var item in Database.Bots.GetAll())
            {
                pl.Add(new BotViewModel()
                {
                    Id = item.Id,
                    Balance = item.Balance,
                    Bet = item.Bet
                });
            }
            return pl;
        }

        public IEnumerable<BotStepViewModel> GetAllSteps(Guid botId)
        {
            List<BotStepViewModel> pl = new List<BotStepViewModel>();
            foreach (var item in Database.BotSteps.GetAll())
            {
                if (item.BotId == botId)
                {
                    pl.Add(new BotStepViewModel()
                    {
                        Id = item.Id,
                        Suite = item.Suite,
                        Rank = item.Rank,
                        Bot = item.Bot,
                        BotId = item.BotId,
                        Game = item.Game,
                        GameId = item.GameId
                    });
                }
            }
            return pl;
        }

        public BotViewModel GetBot(Guid botId)
        {
            Bot bot = Database.Bots.Get(botId);
            if (bot != null)
                return new BotViewModel()
                {
                    Id = bot.Id,
                    Balance = bot.Balance,
                    Bet = bot.Bet
                };
            else return null;
        }
    }
}
