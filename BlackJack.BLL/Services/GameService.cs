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

        public void StartGame()
        {
            GameState = GameState.Unknown;
        }

        public void Hit(PlayerViewModel playerVM)
        {
            Player player = Database.Players.Get(new Guid(playerVM.Id));

            var qq = new List<Hand>();
            qq.Add(new Hand()
            {
                PlayerId = //,
                
            });

            player.Hand.Add(GetCard());
            if (TotalValue(player.Hand) > 21)
            {
                player.Balance -= player.Bet;
                GameState = GameState.DealerWon;
            }
            Database.Players.Update(player);
            Database.Save();
        }

        private Card GetCard()
        {
            Random rnd = new Random();
            return new Card() { Rank = (Rank)rnd.Next(1, 13), Suite= (Suite)rnd.Next(1, 4) };
        }

        private int TotalValue(Hand hand)
        {
            int totalSum=0;
            foreach (var card in hand.Cards)
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

        public void PlaceABet(PlayerDTO playerDTO, int bet)
        {
            Player player = Database.Players.Get(Convert.ToInt32(playerDTO.Id));
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

        public void Stand(PlayerDTO playerDTO, PlayerDTO dealerDTO)
        {
            Player player = Database.Players.Get(Convert.ToInt32(playerDTO.Id));

            Player dealer = Database.Players.Get(Convert.ToInt32(dealerDTO.Id));

            while (TotalValue(dealerDTO.Hand) <= 20)
            {
                dealer.Hand.Cards.Add(GetCard());
                Database.Players.Update(dealer);
                Database.Save();
            }

            if (TotalValue(dealer.Hand) > 21 || TotalValue(player.Hand) > TotalValue(dealer.Hand))
            {
                player.Balance += player.Bet;
                GameState = GameState.PlayerWon;
            }
            else if (TotalValue(dealer.Hand) == TotalValue(player.Hand))
            {
                GameState = GameState.Draw;
            }
            else
            {
                player.Balance -= player.Bet;
                GameState = GameState.DealerWon;
            }

            Database.Players.Update(player);
            Database.Players.Update(dealer);
            Database.Save();
        }

        public void StopGame()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
