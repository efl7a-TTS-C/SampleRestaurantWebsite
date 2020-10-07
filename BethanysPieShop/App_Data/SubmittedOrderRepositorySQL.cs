using BethanysPieShop.Contracts;
using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.App_Data
{
    public class SubmittedOrderRepositorySQL : IRepository<SubmittedOrder>
    {
        internal AppDbContext context;
        internal DbSet<SubmittedOrder> dbSet;

        public SubmittedOrderRepositorySQL(AppDbContext context)
        {
            this.context = context;
            this.dbSet = context.SubmittedOrders;
        }

        public SubmittedOrder AddItem(SubmittedOrder order)
        {
            dbSet.Add(order);
            return order;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public IEnumerable<SubmittedOrder> GetAllItems()
        {
            return dbSet;
        }

        public SubmittedOrder GetItemById(string id)
        {
            return dbSet.SingleOrDefault(p => p.Id == id);
        }

        public void UpdateItem(SubmittedOrder order)
        {
            dbSet.Attach(order);
            context.Entry(order).State = EntityState.Modified;
        }

        public void Delete(string id)
        {
            var order = dbSet.Find(id);
            if (context.Entry(order).State == EntityState.Detached)
                dbSet.Attach(order);
            dbSet.Remove(order);
        }
    }
}

