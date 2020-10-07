using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BethanysPieShop.App_Data;
using BethanysPieShop.Models;
using BethanysPieShop.Contracts;
using Microsoft.AspNetCore.Authorization;
using BethanysPieShop.ViewModels;

namespace BethanysPieShop.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPieRepository _pieRepo;
        private readonly IRepository<SubmittedOrder> _orderRepo;


        public AdminController(AppDbContext context)
        {
            _context = context;
            _pieRepo = new PieRepositorySQL(_context);
            _orderRepo = new SubmittedOrderRepositorySQL(_context);
        }

        // GET: Admin
        public IActionResult Index()
        {
            AdminIndexViewModel model = new AdminIndexViewModel()
            {
                Pies = _pieRepo.GetAllPies(),
                SubmittedOrders = _orderRepo.GetAllItems()
            };
            return View(model);
        }

        // GET: Admin/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Admin/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,Description,ImageUrl,Price,IsPieOfTheWeek,IsInStock,Category")] Pie pie)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(pie);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(pie);
        //}

        //// GET: Admin/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var pie = await _context.Pies.FindAsync(id);
        //    if (pie == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(pie);
        //}

        //// POST: Admin/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ImageUrl,Price,IsPieOfTheWeek,IsInStock,Category")] Pie pie)
        //{
        //    if (id != pie.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(pie);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PieExists(pie.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(pie);
        //}

        //// GET: Admin/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var pie = await _context.Pies
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (pie == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(pie);
        //}

        //// POST: Admin/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var pie = await _context.Pies.FindAsync(id);
        //    _context.Pies.Remove(pie);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool PieExists(int id)
        //{
        //    return _context.Pies.Any(e => e.Id == id);
        //}
    }
}
