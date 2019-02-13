using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Services
{
    public class BotService : IBotService
    {
        public void Create(BotViewModel botVM)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid botId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Edit(BotViewModel botVM)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BotViewModel> GetAllBots()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BotStepViewModel> GetAllSteps(Guid botId)
        {
            throw new NotImplementedException();
        }
    }
}
