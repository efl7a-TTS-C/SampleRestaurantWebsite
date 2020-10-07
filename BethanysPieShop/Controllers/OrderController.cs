using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.App_Data;
using BethanysPieShop.Contracts;
using BethanysPieShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IPieRepository _pieRepo;
        private readonly Order _order;

        public OrderController(IPieRepository repo, Order order)
        {
            _pieRepo = repo;
            _order = order;
        }
        public IActionResult Index()
        {
            IEnumerable<OrderItem> items = _order.GetOrderItems();
            return View(items);
        }

        public RedirectToActionResult AddToOrder(int pieId)
        {
            Pie pieToAdd = _pieRepo.GetPieById(pieId);
            if (pieToAdd != null)
            {
                _order.AddToOrder(pieToAdd);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromOrder(int pieId)
        {
            Pie pieToRemove = _pieRepo.GetPieById(pieId);
            if (pieToRemove != null)
            {
                _order.RemoveFromOrder(pieToRemove);
            }
            return RedirectToAction("Index");
        }
    }
}
