﻿using BlackJack.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Interfaces
{
    public interface IGameService
    {
        GameViewModel StartGame(PlayerViewModel playerVM, int countOfBots);
        void DeleteGame(Guid gameId);
        GameViewModel GetGame(Guid gameId);
        IEnumerable<GameViewModel> GetGamesForPlayer(string playerId);
        IEnumerable<GameViewModel> GetGames();
        void StopGame();
        void PlaceABet(PlayerViewModel playerVM, decimal bet);
        PlayerStepViewModel Hit(PlayerViewModel playerVM, string gameId);
        void Stand(PlayerViewModel playerVM, string gameId);
        void Dispose();
    }
}
