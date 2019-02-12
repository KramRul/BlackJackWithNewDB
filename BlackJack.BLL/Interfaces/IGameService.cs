using BlackJack.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Interfaces
{
    public interface IGameService
    {
        void StartGame(PlayerViewModel playerVM, GameViewModel gameVM);
        void StopGame();
        void PlaceABet(PlayerViewModel playerVM, int bet);
        void Hit(PlayerViewModel playerVM);
        void Stand(PlayerViewModel playerVM, DealerViewModel dealerVM);
        void Dispose();
    }
}
