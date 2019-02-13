using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Models;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Services
{
    public class DealerService : IDealerService
    {
        private IUnitOfWork Database { get; set; }

        public DealerService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Register(PlayerViewModel playerVM)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlayerStepViewModel> GetAllSteps(string playerId)
        {
            throw new NotImplementedException();
        }

        public void Login(PlayerViewModel playerVM)
        {
            throw new NotImplementedException();
        }

        public void Edit(PlayerViewModel playerVM)
        {
            throw new NotImplementedException();
        }

        public void Delete(PlayerViewModel playerVM)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Create(DealerViewModel dealerVM)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DealerStepViewModel> GetAllSteps(Guid dealerId)
        {
            throw new NotImplementedException();
        }

        public void Edit(DealerViewModel dealerVM)
        {
            throw new NotImplementedException();
        }

        public void Delete(DealerViewModel dealerVM)
        {
            throw new NotImplementedException();
        }
    }
}
