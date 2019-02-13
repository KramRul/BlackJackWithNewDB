using BlackJack.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Interfaces
{
    public interface IDealerService
    {
        void Create(DealerViewModel dealerVM);

        IEnumerable<DealerStepViewModel> GetAllSteps(Guid dealerId);

        IEnumerable<DealerViewModel> GetAllDealers();

        void Edit(DealerViewModel dealerVM);

        void Delete(Guid dealerId);

        void Dispose();
    }
}
