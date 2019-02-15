using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Models;
using BlackJack.DAL.Entities;
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

        public void Create(DealerViewModel dealerVM)
        {
            Database.Dealers.Create(new Dealer() { Id = dealerVM.Id });
            Database.Save();
        }

        public IEnumerable<DealerViewModel> GetAllDealers()
        {
            List<DealerViewModel> pl = new List<DealerViewModel>();
            foreach (var item in Database.Dealers.GetAll())
            {
                pl.Add(new DealerViewModel()
                {
                    Id = item.Id
                });
            }           
            return pl;
        }

        public IEnumerable<DealerStepViewModel> GetAllSteps(Guid dealerId)
        {
            List<DealerStepViewModel> pl = new List<DealerStepViewModel>();
            foreach (var item in Database.DealerSteps.GetAll())
            {
                if (item.DealerId == dealerId)
                {
                    pl.Add(new DealerStepViewModel()
                    {
                        Id = item.Id,
                        Dealer = item.Dealer,
                        DealerId = item.DealerId,
                        Suite = item.Suite,
                        Rank = item.Rank
                    });
                }
            }
            return pl;
        }

        public void Edit(DealerViewModel dealerVM)
        {
            Dealer dealer = Database.Dealers.Get(dealerVM.Id);
            dealer.Id = dealerVM.Id;
            Database.Dealers.Update(dealer);
            Database.Save();
        }

        public void Delete(Guid dealerId)
        {
            Database.Dealers.Delete(dealerId);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
