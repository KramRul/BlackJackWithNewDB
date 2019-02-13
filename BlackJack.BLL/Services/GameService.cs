using BlackJack.BLL.Infrastructure;
using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Models;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Services
{
    public class GameService : IGameService
    {
        public GameState GameState { get; set; }

        IUnitOfWork Database { get; set; }

        public GameService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void StartGame(PlayerViewModel playerVM, GameViewModel gameVM)
        {
            GameState = GameState.Unknown;
            Player player = Database.Players.Get(new Guid(playerVM.Id));
            Game game = Database.Games.Get(gameVM.Id);

            //???
            game.Player = player;

            Database.Games.Update(game);
            Database.Players.Update(player);
            Database.Save();
        }

        public void DeleteGame(Guid gameId)
        {
            Database.Games.Delete(gameId);

            Database.Save();
        }

        public void Hit(PlayerViewModel playerVM)
        {
            Player player = Database.Players.Get(new Guid(playerVM.Id));

            Random rnd = new Random();
            var playerStep = new PlayerStep() { Player = player, PlayerId = player.Id, Rank= (Rank)rnd.Next(1, 13), Suite = (Suite)rnd.Next(1, 4) };
            Database.PlayerSteps.Create(playerStep);
            Database.Save();

            if (TotalValue(Database.PlayerSteps.GetAll()) > 21)
            {
                player.Balance -= player.Bet;
                GameState = GameState.DealerWon;
            }
            Database.Players.Update(player);
            Database.Save();
        }

        /*private Card GetStep()
        {
            Random rnd = new Random();
            return new Card() { Rank = (Rank)rnd.Next(1, 13), Suite= (Suite)rnd.Next(1, 4) };
        }*/

        private int TotalValue(IEnumerable<PlayerStep> playerSteps)
        {
            int totalSum=0;
            foreach (var card in playerSteps)
            {
                if (card.Rank == Rank.Ace && totalSum <= 10)
                {
                    totalSum += 11;
                } else if (card.Rank == Rank.Ace && totalSum > 10 && totalSum < 21)
                {
                    totalSum += 1;
                }
                else if (card.Rank == Rank.Jack || card.Rank == Rank.King || card.Rank == Rank.Queen)
                {
                    totalSum += 10;
                }
                switch (card.Rank)
                {
                    case Rank.Two:
                        totalSum += 2;
                        break;
                    case Rank.Three:
                        totalSum += 3;
                        break;
                    case Rank.Four:
                        totalSum += 4;
                        break;
                    case Rank.Five:
                        totalSum += 5;
                        break;
                    case Rank.Six:
                        totalSum += 6;
                        break;
                    case Rank.Seven:
                        totalSum += 7;
                        break;
                    case Rank.Eight:
                        totalSum += 8;
                        break;
                    case Rank.Nine:
                        totalSum += 9;
                        break;
                    case Rank.Ten:
                        totalSum += 10;
                        break;
                }
            }
            return totalSum;
        }

        private int TotalValue(IEnumerable<DealerStep> dealerSteps)
        {
            int totalSum = 0;
            foreach (var card in dealerSteps)
            {
                if (card.Rank == Rank.Ace && totalSum <= 10)
                {
                    totalSum += 11;
                }
                else if (card.Rank == Rank.Ace && totalSum > 10 && totalSum < 21)
                {
                    totalSum += 1;
                }
                else if (card.Rank == Rank.Jack || card.Rank == Rank.King || card.Rank == Rank.Queen)
                {
                    totalSum += 10;
                }
                switch (card.Rank)
                {
                    case Rank.Two:
                        totalSum += 2;
                        break;
                    case Rank.Three:
                        totalSum += 3;
                        break;
                    case Rank.Four:
                        totalSum += 4;
                        break;
                    case Rank.Five:
                        totalSum += 5;
                        break;
                    case Rank.Six:
                        totalSum += 6;
                        break;
                    case Rank.Seven:
                        totalSum += 7;
                        break;
                    case Rank.Eight:
                        totalSum += 8;
                        break;
                    case Rank.Nine:
                        totalSum += 9;
                        break;
                    case Rank.Ten:
                        totalSum += 10;
                        break;
                }
            }
            return totalSum;
        }

        private int TotalValue(IEnumerable<BotStep> botSteps)
        {
            int totalSum = 0;
            foreach (var card in botSteps)
            {
                if (card.Rank == Rank.Ace && totalSum <= 10)
                {
                    totalSum += 11;
                }
                else if (card.Rank == Rank.Ace && totalSum > 10 && totalSum < 21)
                {
                    totalSum += 1;
                }
                else if (card.Rank == Rank.Jack || card.Rank == Rank.King || card.Rank == Rank.Queen)
                {
                    totalSum += 10;
                }
                switch (card.Rank)
                {
                    case Rank.Two:
                        totalSum += 2;
                        break;
                    case Rank.Three:
                        totalSum += 3;
                        break;
                    case Rank.Four:
                        totalSum += 4;
                        break;
                    case Rank.Five:
                        totalSum += 5;
                        break;
                    case Rank.Six:
                        totalSum += 6;
                        break;
                    case Rank.Seven:
                        totalSum += 7;
                        break;
                    case Rank.Eight:
                        totalSum += 8;
                        break;
                    case Rank.Nine:
                        totalSum += 9;
                        break;
                    case Rank.Ten:
                        totalSum += 10;
                        break;
                }
            }
            return totalSum;
        }

        public void PlaceABet(PlayerViewModel playerVM, int bet)
        {
            Player player = Database.Players.Get(new Guid(playerVM.Id));
            if (player.Balance < bet)
                throw new ValidationException("Недостаточно средств на счету", "Bet");
            else
            {
                player.Bet = bet;
                player.Balance -= bet;
                Database.Players.Update(player);
                Database.Save();
            }
        }

        public void Stand(PlayerViewModel playerVM, DealerViewModel dealerVM)
        {
            Player player = Database.Players.Get(new Guid(playerVM.Id));

            Dealer dealer = Database.Dealers.Get(dealerVM.Id);

            while (TotalValue(Database.DealerSteps.GetAll()) <= 20)
            {
                Random rnd = new Random();
                var dealerStep = new DealerStep() { Dealer = dealer, DealerId = dealer.Id, Rank = (Rank)rnd.Next(1, 13), Suite = (Suite)rnd.Next(1, 4) };
                Database.DealerSteps.Create(dealerStep);
                Database.Save();
            }

            if (TotalValue(Database.DealerSteps.GetAll()) > 21 || TotalValue(Database.PlayerSteps.GetAll()) > TotalValue(Database.DealerSteps.GetAll()))
            {
                player.Balance += player.Bet;
                GameState = GameState.PlayerWon;
            }
            else if (TotalValue(Database.DealerSteps.GetAll()) == TotalValue(Database.PlayerSteps.GetAll()))
            {
                GameState = GameState.Draw;
            }
            else
            {
                player.Balance -= player.Bet;
                GameState = GameState.DealerWon;
            }

            Database.Players.Update(player);
            Database.Dealers.Update(dealer);
            Database.Save();
        }

        public void StopGame()
        {
            GameState = GameState.Unknown;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<GameViewModel> GetGamesForPlayer(string playerId)
        {
            List<GameViewModel> pl = new List<GameViewModel>();
            foreach (var item in Database.Games.GetAll())
            {
                if (item.Player.Id == playerId)
                {
                    pl.Add(new GameViewModel()
                    {
                        Id = item.Id,
                        Player = item.Player
                    });
                }
            }
            return pl;
        }

        public IEnumerable<GameViewModel> GetGames()
        {
            List<GameViewModel> pl = new List<GameViewModel>();
            foreach (var item in Database.Games.GetAll())
            {
                pl.Add(new GameViewModel()
                {
                    Id = item.Id,
                    Player = item.Player
                });
            }
            return pl;
        }
    }
}
