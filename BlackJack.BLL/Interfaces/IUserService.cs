using BlackJack.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Interfaces
{
    public interface IUserService
    {
        void Register(PlayerViewModel playerVM);

        IEnumerable<PlayerStepViewModel> GetAllSteps(string playerId);

        void Login(PlayerViewModel playerVM);

        void Edit(PlayerViewModel playerVM);

        void Delete(PlayerViewModel playerVM);

        void Dispose();
    }
}
