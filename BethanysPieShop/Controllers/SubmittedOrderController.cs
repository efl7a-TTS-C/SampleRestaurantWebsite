using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.App_Data;
using BethanysPieShop.Contracts;
using BethanysPieShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    [Authorize]
    public class SubmittedOrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IRepository<SubmittedOrder> _orderRepo;

        public SubmittedOrderController(AppDbContext context)
        {
            _context = context;
            _orderRepo = new SubmittedOrderRepositorySQL(_context);
        }

        // GET: SubmittedOrderController
        public ActionResult Index()
        {
            return View(_orderRepo.GetAllItems());
        }

        // GET: SubmittedOrderController/Details/5
        public ActionResult Details(string id)
        {
            SubmittedOrder order = _orderRepo.GetItemById(id);
            if(order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // GET: SubmittedOrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubmittedOrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubmittedOrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SubmittedOrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubmittedOrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SubmittedOrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
