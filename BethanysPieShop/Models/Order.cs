using BethanysPieShop.App_Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class Order
    {
        private readonly AppDbContext _context;
        public string Id { get; set; }
        public List<OrderItem> items;

        private Order(AppDbContext context)
        {
            _context = context;
        }

        public static Order GetOrder(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string orderId = session.GetString("OrderId") ?? Guid.NewGuid().ToString();

            session.SetString("OrderId", orderId);

            return new Order(context) { Id = orderId };
        }

        public List<OrderItem> GetOrderItems()
        {
            return items ?? _context.OrderItems.Where(item => item.OrderId == Id).Include(s => s.Pie).ToList();


        }

        public void AddToOrder(Pie pie)
        {
            OrderItem itemToAdd = _context.OrderItems.SingleOrDefault(i => i.Pie.Id == pie.Id && i.OrderId == Id);
            if(itemToAdd == null)
            {
                itemToAdd = new OrderItem() { OrderId = Id, Pie = pie, Quantity = 1 };
                _context.OrderItems.Add(itemToAdd);
            } 
            else
            {
                itemToAdd.Quantity++;
            }
            _context.SaveChanges();
        }

        public int RemoveFromOrder(Pie pie)
        {
            OrderItem itemToRemove = _context.OrderItems.SingleOrDefault(i => i.Pie.Id == pie.Id && i.OrderId == Id);
            if (itemToRemove != null)
            {
                if(itemToRemove.Quantity > 1)
                {
                    itemToRemove.Quantity--;
                }
                else
                {
                    _context.OrderItems.Remove(itemToRemove);
                }
            }
            _context.SaveChanges();
            return itemToRemove.Quantity;
        }

        public void ClearOrder()
        {
            var orderItems = _context.OrderItems.Where(item => item.OrderId == Id);
            _context.OrderItems.RemoveRange(orderItems);
            _context.SaveChanges();
        }

        public double GetOrderTotal()
        {
            return _context.OrderItems.Where(item => item.OrderId == Id).Select(i => i.Pie.Price * i.Quantity).Sum();

        }
    }
}
