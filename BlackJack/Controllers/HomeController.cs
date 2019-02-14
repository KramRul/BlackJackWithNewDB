using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

        public HomeController(IGameService gameService, UserManager<Player> userManager)
        {
            _gameService = gameService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> StartGame(int countOfBots, string player)
        {
            Player user = await _userManager.FindByNameAsync(player);
            if (user == null)
            {
                return NotFound();
            }
            PlayerViewModel model = new PlayerViewModel { Id = user.Id, UserName = user.UserName };
            _gameService.StartGame(model, countOfBots);
            return View();
        }

        [HttpGet]
        public IActionResult AllGames()
        {
            return View(_gameService.GetGames().ToList());//_userManager.Users.ToList()
        }

        /*[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
    }
}
