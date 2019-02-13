using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Models;
using BlackJack.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.Controllers
{
    public class DealerController : Controller
    {
        private readonly UserManager<Player> _userManager;
        private readonly SignInManager<Player> _signInManager;
        private readonly IGameService _gameService;
        private readonly IUserService _userService;
        private readonly IDealerService _dealerService;

        public DealerController(UserManager<Player> userManager, SignInManager<Player> signInManager, IGameService gameService, IUserService userService, IDealerService dealerService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _gameService = gameService;
            _userService = userService;
            _dealerService = dealerService;
        }

        // GET: Dealer
        public ActionResult Index()
        {
            return View(_dealerService.GetAllDealers());
        }

        // GET: Dealer/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Dealer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Guid guid = Guid.NewGuid();
                    DealerViewModel model = new DealerViewModel() { Id=guid};
                    _dealerService.Create(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dealer/Edit/5
        public ActionResult Edit(Guid id)
        {
            DealerViewModel model = new DealerViewModel() { Id = id };
            _dealerService.Edit(model);
            return View(model);
        }

        // POST: Dealer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DealerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DealerViewModel _model = new DealerViewModel() { Id = model.Id };
                    _dealerService.Edit(_model);
                    RedirectToAction("Index");
                }
                return RedirectToAction("Index");
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
                    _dealerService.Delete(Id);
                    return RedirectToAction("Index");
                } else
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}