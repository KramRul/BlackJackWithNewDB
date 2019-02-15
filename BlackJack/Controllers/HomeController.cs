using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.BLL.Infrastructure;
using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Models;
using BlackJack.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameService _gameService;
        private readonly UserManager<Player> _userManager;
        private readonly IUserService _userService;
        private readonly IDealerService _dealerService;
        private readonly IBotService _botService;

        public HomeController(IGameService gameService, UserManager<Player> userManager, IUserService userService, IDealerService dealerService, IBotService botService)
        {
            _gameService = gameService;
            _userManager = userManager;
            _userService = userService;
            _dealerService = dealerService;
            _botService = botService;
        }

        public IActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> StartGame(int countOfBots, string player)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (player == null) throw new ValidationException("Имя не должно быть пустым","");
                    Player user = await _userManager.FindByNameAsync(player);
                    if (user == null)
                    {
                        return RedirectToAction("Register", "User");
                    }
                    PlayerViewModel model = new PlayerViewModel { Id = user.Id, UserName = user.UserName, Balance=user.Balance, Bet=user.Bet};
                    GameViewModel gVM = _gameService.StartGame(model, countOfBots);
                    GameDetailsViewModel gameDetailsVM = new GameDetailsViewModel()
                    {
                        Game = gVM,
                        DealerStepVM = _dealerService.GetAllSteps(gVM.Dealer.Id),
                        PlayerStepVM = _userService.GetAllSteps(gVM.Player.Id)
                    };
                    return View(gameDetailsVM);//StartGame
                }
                return View();
            }
            catch (ValidationException ex)
            {
                return RedirectToAction("Index", "Home", ex.Property);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpGet]
        public IActionResult StartGame(GameViewModel gameVM)
        {
            try
            {
                return View(gameVM);
            }
            catch (ValidationException ex)
            {
                return RedirectToAction("Index", "Home", ex.Property);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public void PlaceABet(decimal Bet, string Id, string UserName, decimal Balance)
        {
            try
            {
                Console.WriteLine(Bet);
                Console.WriteLine(Id);
                PlayerViewModel VM = new PlayerViewModel() { Id = Id, UserName = UserName, Balance = Balance, Bet = Bet };
                _gameService.PlaceABet(VM, Bet);
                //return RedirectToAction("StartGame", "Home", VM);
            }
            catch (ValidationException ex)
            {
                //return RedirectToAction("Index", "Home", ex.Property);
            }
            catch
            {
                //return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public IActionResult Hit(string Id)
        {
            try
            {
                /*PlayerViewModel VM = new PlayerViewModel() { Id = Id, UserName = UserName, Balance = Balance, Bet = Bet };
                _gameService.PlaceABet(VM, Bet);*/
                return RedirectToAction("StartGame", "Home"/*, VM*/);
            }
            catch (ValidationException ex)
            {
                return RedirectToAction("Index", "Home", ex.Property);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpGet]
        public IActionResult AllGames()
        {
            return View(_gameService.GetGames().ToList());//_userManager.Users.ToList()
        }

        [HttpGet]
        public IActionResult Details(Guid Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    GameViewModel game = _gameService.GetGame(Id);
                    if (game != null)
                    {
                        GameDetailsViewModel VM = new GameDetailsViewModel()
                        {
                            Game = game,
                            PlayerStepVM = _userService.GetAllSteps(game.Player.Id).ToList(),
                            DealerStepVM = _dealerService.GetAllSteps(Id).ToList(),
                            BotStepVM = _botService.GetAllSteps(Id).ToList()
                        };

                        return View(VM);
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _gameService.DeleteGame(Id);
                    return RedirectToAction("AllGames");
                }
                else
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        /*[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
    }
}
