using BethanysPieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.App_Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Pies.Any())
            {
                return;
            }

            var pies = new Pie[]
            {
                new Pie { Id = 0, Name = "Cheesecake", Description = "Pastry donut pudding jelly beans candy canes cupcake.", Price = 18.95, IsInStock = true, Category = Category.Pie},
                new Pie { Id = 1, Name = "Strawberry Pie", Description = "Dessert carrot cake pastry gummi bears jujubes topping cupcake muffin halvah.", Price = 15.95, IsInStock = true, Category = Category.Pie},
                new Pie { Id = 3, Name = "Rhubarb Pie", Description = "Jelly brownie cotton candy lollipop jelly jujubes topping sugar plum. ", Price = 15.95, IsInStock = true, Category = Category.Pie},
                 new Pie { Id = 4, Name = "Pumpkin Pie", Description = "Danish caramels gummies carrot cake. ", Price = 13.95, IsInStock = true, Category = Category.Pie},
                 new Pie { Id = 5, Name = "Blueberry Pie", Description = "Toffee dragée apple pie powder cupcake carrot cake bonbon cupcake. Sesame snaps icing apple pie.", Price = 15.95, IsInStock = true, Category = Category.Pie},
                 new Pie { Id = 6, Name = "Apple Pie", Description = "Toffee dragée apple pie powder cupcake carrot cake bonbon cupcake. Sesame snaps icing apple pie.", Price = 14.95, IsInStock = true, Category = Category.Pie}
            };

                context.Pies.AddRange(pies);
                context.SaveChanges();

        }
    }
}
