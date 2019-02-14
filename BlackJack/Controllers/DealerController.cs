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
        private readonly IDealerService _dealerService;

        public DealerController(IDealerService dealerService)
        {
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

        [HttpGet]
        public IActionResult AllSteps(Guid Id)
        {
            return View(_dealerService.GetAllSteps(Id).ToList());
        }
    }
}