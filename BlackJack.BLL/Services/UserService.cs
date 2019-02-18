using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Models;
using BlackJack.DAL.Interfaces;
using BlackJack.BLL.Infrastructure;
using BlackJack.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace BlackJack.BLL.Services
{
    public class UserService: IUserService
    {
        private IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Register(PlayerViewModel playerVM)
        {
            Player player = new Player()
            {
                Balance = playerVM.Balance,
                Bet = playerVM.Bet,
                UserName = playerVM.UserName
            };

            Database.Players.Create(player);
        }

        public void Login(PlayerViewModel playerVM)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlayerStepViewModel> GetAllSteps(string playerId)
        {
            List<PlayerStepViewModel> pl = new List<PlayerStepViewModel>();
            foreach (var item in Database.PlayerSteps.GetAll())
            {
                if (item.PlayerId == playerId)
                {
                    pl.Add(new PlayerStepViewModel()
                    {
                        Id = item.Id,
                        Player = item.Player,
                        PlayerId = item.PlayerId,
                        Rank = item.Rank,
                        Suite = item.Suite
                    });
                }
            }
            return pl;
        }

        public IEnumerable<PlayerStepViewModel> GetAllSteps(string playerId, GameViewModel gvm)
        {
            List<PlayerStepViewModel> pl = new List<PlayerStepViewModel>();
            foreach (var item in Database.PlayerSteps.GetAll())
            {
                if (item.PlayerId == playerId && item.GameId==gvm.Id)
                {
                    pl.Add(new PlayerStepViewModel()
                    {
                        Id = item.Id,
                        Player = item.Player,
                        PlayerId = item.PlayerId,
                        Rank = item.Rank,
                        Suite = item.Suite
                    });
                }
            }
            return pl;
        }

        public void Edit(PlayerViewModel playerVM)
        {
            Player player = Database.Players.Get(new Guid(playerVM.Id));
            player.Balance = playerVM.Balance;
            player.Bet = playerVM.Bet;
            playerVM.UserName = playerVM.UserName;
            Database.Players.Update(player);
            Database.Save();
        }

        public void Delete(PlayerViewModel playerVM)
        {
            Database.Players.Delete(new Guid(playerVM.Id));
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
