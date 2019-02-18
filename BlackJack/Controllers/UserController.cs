using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BlackJack.BLL.Auth;
using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Models;
using BlackJack.BLL.Services;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

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
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Player user = new Player {UserName = model.UserName, Balance=1000, PasswordHash=model.Password};

                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Player user = new Player { UserName = model.UserName, Balance = 1000 };

                var identity = GetIdentity(model.UserName, model.PasswordHash);
                if (identity == null)
                {
                    Response.StatusCode = 400;
                    await Response.WriteAsync("Invalid username or password.");
                    ModelState.AddModelError(string.Empty, "Invalid username or password.");
                }

                JwtFactory jwtFactory = new JwtFactory();

                var encodedJwt = jwtFactory.GenerateEncodedToken(model.UserName, identity);

                var response = new
                {
                    access_token = encodedJwt,
                    username = identity.Name
                };

                // сериализация ответа
                Response.ContentType = "application/json";
                await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));

                
            }
            return View(model);
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            Player player = _userManager.Users.FirstOrDefault(x => x.UserName == username && x.PasswordHash == password);
            if (player != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, player.UserName),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, player.PasswordHash)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
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