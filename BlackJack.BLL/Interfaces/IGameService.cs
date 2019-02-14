using BlackJack.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Interfaces
{
    public interface IGameService
    {
        void StartGame(PlayerViewModel playerVM, int countOfBots);
        void DeleteGame(Guid gameId);
        IEnumerable<GameViewModel> GetGamesForPlayer(string playerId);
        IEnumerable<GameViewModel> GetGames();
        void StopGame();
        void PlaceABet(PlayerViewModel playerVM, int bet);
        void Hit(PlayerViewModel playerVM);
        void Stand(PlayerViewModel playerVM, DealerViewModel dealerVM);
        void Dispose();
    }
}
