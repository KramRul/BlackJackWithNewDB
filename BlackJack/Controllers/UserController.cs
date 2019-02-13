using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Models;
using BlackJack.BLL.Services;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<Player> _userManager;
        private readonly SignInManager<Player> _signInManager;
        private readonly IGameService _gameService;
        private readonly IUserService _userService;

        public UserController(UserManager<Player> userManager, SignInManager<Player> signInManager, IGameService gameService, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _gameService = gameService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {            
            return View(_userManager.Users.ToList());
        }

        [HttpGet]
        public IActionResult AllGames()
        {
            return View(_gameService.GetGames().ToList());//_userManager.Users.ToList()
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(PlayerViewModel model)
        {
            if (ModelState.IsValid)
            {
                Player user = new Player {UserName = model.UserName, Balance=1000};
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            Player user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            PlayerViewModel model = new PlayerViewModel { Id = user.Id, UserName = user.UserName };
            return View(model);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PlayerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Player user = await _userManager.FindByIdAsync(model.Id);
                    if (user != null)
                    {
                        user.Id = model.Id;
                        user.UserName = model.UserName;

                        var result = await _userManager.UpdateAsync(user);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                        }
                    }
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                Player user = await _userManager.FindByIdAsync(id);

                //_gameService.DeleteGame(user.Game.Id);

                if (user != null)
                {
                    IdentityResult result = await _userManager.DeleteAsync(user);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult AllSteps(string id)
        {
            return View(_userService.GetAllSteps(id).ToList());
        }
    }
}