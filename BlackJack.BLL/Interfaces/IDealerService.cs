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

        void Edit(DealerViewModel dealerVM);

        void Delete(DealerViewModel dealerVM);

        void Dispose();
    }
}
