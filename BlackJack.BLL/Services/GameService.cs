using BlackJack.BLL.Infrastructure;
using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Models;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.BLL.Services
{
    public class GameService : IGameService
    {
        IUnitOfWork Database { get; set; }

        public GameService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public GameViewModel StartGame(PlayerViewModel playerVM, int countOfBots)
        {
            Player player = Database.Players.Get(Guid.Parse(playerVM.Id));

            Dealer dealer = new Dealer();
            Database.DealerSteps.Create(CreateDealerStep(dealer));
            Database.DealerSteps.Create(CreateDealerStep(dealer));
            DealerStep dealerStep = CreateDealerStep(dealer);

            Game game = new Game() { Player=player, Dealer= dealer, GameState=GameState.Unknown};

            Database.PlayerSteps.Create(CreatePlayerStep(player, game));
            Database.PlayerSteps.Create(CreatePlayerStep(player, game));

            if (countOfBots > 0)
            {
                for (int i = 0; i < countOfBots; i++)
                {
                    BotStep botStep = new BotStep() { Bot= new Bot() { Balance = 1000, Bet = 0 }, Game= game };
                    Database.BotSteps.Create(botStep);
                }
            }
           
            Database.Games.Create(game);
            Database.Players.Update(player);
            Database.Save();
            return new GameViewModel() { Id=game.Id, Dealer=game.Dealer, Player=game.Player};
        }

        public void DeleteGame(Guid gameId)
        {
            Database.Games.Delete(gameId);

            Database.Save();
        }

        public PlayerStepViewModel Hit(PlayerViewModel playerVM, string gameId)
        {
            Player player = Database.Players.Get(Guid.Parse(playerVM.Id));
            Game game = Database.Games.Get(Guid.Parse(gameId));

            Random rnd = new Random();
            var playerStep = new PlayerStep() { Player = player, PlayerId = player.Id, Rank = (Rank)rnd.Next(1, 13), Suite = (Suite)rnd.Next(1, 4), Game = game };
            Database.PlayerSteps.Create(playerStep);
            Database.Save();

            if (TotalValue(Database.PlayerSteps.GetAll().Where(p => p.PlayerId == playerVM.Id && p.GameId == game.Id)) > 21)
            {
                player.Balance -= player.Bet;
                game.GameState = GameState.DealerWon;
            }
            Database.Games.Update(game);
            Database.Players.Update(player);
            Database.Save();

            return new PlayerStepViewModel() { PlayerId = playerStep.PlayerId, GameId = playerStep.GameId, Rank = playerStep.Rank, Suite = playerStep.Suite };
        }

        private DealerStep CreateDealerStep(Dealer dealer)
        {
            Random rnd = new Random();
            return new DealerStep() { Dealer = dealer, Rank = (Rank)rnd.Next(1, 13), Suite= (Suite)rnd.Next(1, 4) };
        }

        private PlayerStep CreatePlayerStep(Player player, Game game)
        {
            Random rnd = new Random();
            return new PlayerStep() { Player = player, Rank = (Rank)rnd.Next(1, 13), Suite = (Suite)rnd.Next(1, 4), Game = game };
        }

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

        public void PlaceABet(PlayerViewModel playerVM, decimal bet)
        {
            Player player = Database.Players.Get(Guid.Parse(playerVM.Id));
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
                //GameState = GameState.PlayerWon;
            }
            else if (TotalValue(Database.DealerSteps.GetAll()) == TotalValue(Database.PlayerSteps.GetAll()))
            {
                //GameState = GameState.Draw;
            }
            else
            {
                player.Balance -= player.Bet;
                //GameState = GameState.DealerWon;
            }

            Database.Players.Update(player);
            Database.Dealers.Update(dealer);
            Database.Save();
        }

        public void StopGame()
        {
            //GameState = GameState.Unknown;
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
            foreach (var item in Database.Games.GetAll().ToList())
            {
                pl.Add(new GameViewModel()
                {
                    Id = item.Id,
                    Player = item.Player,
                    Dealer = item.Dealer
                });
            }
            return pl;
        }

        public GameViewModel GetGame(Guid gameId)
        {
            Game game = Database.Games.Get(gameId);
            return new GameViewModel()
            {
                Id = game.Id,
                Player = game.Player,
                Dealer = game.Dealer,
                GameState = game.GameState
            };
        }
    }
}
