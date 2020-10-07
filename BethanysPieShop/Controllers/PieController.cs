using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Contracts;
using BethanysPieShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    [Authorize]
    public class PieController : Controller
    {
        private readonly IPieRepository repo;
        public PieController(IPieRepository PieRepositorySQL)
        {
            this.repo = PieRepositorySQL;
        }
        [AllowAnonymous]
        // GET: PieController
        public ActionResult Index()
        {
            IEnumerable<Pie> pies = repo.GetAllPies();
            return View(pies);
        }
        [AllowAnonymous]
        // GET: PieController/Details/5
        public ActionResult Details(int id)
        {
            Pie pie = repo.GetPieById(id);
            return View(pie);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description,ImageUrl,Price,IsPieOfTheWeek,IsInStock,Category")] Pie pie)
        {
            if (ModelState.IsValid)
            {
                repo.AddPie(pie);
                repo.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(pie);
        }

        // GET: Admin/Edit/5
        public IActionResult Edit(int id)
        {
            var pie = repo.GetPieById(id);
            if (pie == null)
            {
                return NotFound();
            }
            return View(pie);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Description,ImageUrl,Price,IsPieOfTheWeek,IsInStock,Category")] Pie pie)
        {
            if (id != pie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                repo.UpdatePie(pie);
                repo.Commit();

                return RedirectToAction(nameof(Index));
            }
            return View(pie);
        }

        // GET: Admin/Delete/5
        public IActionResult Delete(int id)
        {
            var pie = repo.GetPieById(id);
            if (pie == null)
            {
                return NotFound();
            }

            return View(pie);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var pie = repo.GetPieById(id);
            if (pie == null)
            {
                return NotFound();
            } else
            {
                repo.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
