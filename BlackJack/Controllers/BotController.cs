using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.Controllers
{
    public class BotController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IBotService _botService;

        public BotController(IGameService gameService, IBotService botService)
        {
            _gameService = gameService;
            _botService = botService;
        }

        // GET: Dealer
        public ActionResult Index()
        {
            return View(_botService.GetAllBots());
        }

        // GET: Bot/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Bot/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Guid guid = Guid.NewGuid();
                    BotViewModel model = new BotViewModel() { Id = guid, Balance = 1000, Bet=0 };
                    _botService.Create(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bot/Edit/5
        public ActionResult Edit(Guid id)
        {            
            BotViewModel model = _botService.GetBot(id);
            return View(model);
        }

        // POST: Bot/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BotViewModel botVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BotViewModel _model = new BotViewModel() { Id = botVM.Id, Balance=botVM.Balance, Bet=botVM.Bet};
                    _botService.Edit(_model);
                    RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Bot/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _botService.Delete(Id);
                    return RedirectToAction("Index");
                }
                else
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult AllSteps(Guid Id)
        {
            return View(_botService.GetAllSteps(Id).ToList());
        }
    }
}