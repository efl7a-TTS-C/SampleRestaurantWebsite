using BethanysPieShop.Contracts;
using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.App_Data
{
    public class PieRepositorySQL : IPieRepository
    {
        internal AppDbContext context;
        internal DbSet<Pie> dbSet;

        public PieRepositorySQL(AppDbContext context)
        {
            this.context = context;
            this.dbSet = context.Pies;

            if (!this.dbSet.Any())
            {
                var pies = new Pie[]
                {
                new Pie { Name = "Cheesecake", Description = "Pastry donut pudding jelly beans candy canes cupcake.", Price = 18.95, IsInStock = true, Category = Category.Pie},
                new Pie { Name = "Strawberry Pie", Description = "Dessert carrot cake pastry gummi bears jujubes topping cupcake muffin halvah.", Price = 15.95, IsInStock = true, Category = Category.Pie},
                new Pie { Name = "Rhubarb Pie", Description = "Jelly brownie cotton candy lollipop jelly jujubes topping sugar plum. ", Price = 15.95, IsInStock = true, Category = Category.Pie},
                new Pie { Name = "Pumpkin Pie", Description = "Danish caramels gummies carrot cake. ", Price = 13.95, IsInStock = true, Category = Category.Pie},
                new Pie { Name = "Blueberry Pie", Description = "Toffee dragée apple pie powder cupcake carrot cake bonbon cupcake. Sesame snaps icing apple pie.", Price = 15.95, IsInStock = true, Category = Category.Pie}
                };
                foreach (Pie pie in pies)
                {
                    this.dbSet.Add(pie);
                }
                this.context.SaveChanges();
            }
        }

        public Pie AddPie(Pie pie)
        {
            dbSet.Add(pie);
            return pie;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public IEnumerable<Pie> GetAllPies()
        {
            return dbSet;
        }

        public Pie GetPieById(int id)
        {
            return dbSet.SingleOrDefault(p => p.Id == id);
        }

        public void UpdatePie(Pie pie)
        {
            dbSet.Attach(pie);
            context.Entry(pie).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var pie = dbSet.Find(id);
            if (context.Entry(pie).State == EntityState.Detached)
                dbSet.Attach(pie);
            dbSet.Remove(pie);
        }
    }
}
