using BlackJack.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Interfaces
{
    public interface IBotService
    {
        void Create(BotViewModel botVM);

        BotViewModel GetBot(Guid botId);

        IEnumerable<BotStepViewModel> GetAllSteps(Guid botId);

        IEnumerable<BotViewModel> GetAllBots();

        void Edit(BotViewModel botVM);

        void Delete(Guid botId);

        void Dispose();
    }
}
