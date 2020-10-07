using BethanysPieShop.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        public List<Pie> pies;

        public PieRepository()
        {
            pies = new List<Pie>()
            {
                new Pie { Id = 0, Name = "Cheesecake", Description = "Pastry donut pudding jelly beans candy canes cupcake.", Price = 18.95, IsInStock = true, Category = Category.Pie},
                new Pie { Id = 1, Name = "Strawberry Pie", Description = "Dessert carrot cake pastry gummi bears jujubes topping cupcake muffin halvah.", Price = 15.95, IsInStock = true, Category = Category.Pie},
                new Pie { Id = 3, Name = "Rhubarb Pie", Description = "Jelly brownie cotton candy lollipop jelly jujubes topping sugar plum. ", Price = 15.95, IsInStock = true, Category = Category.Pie},
                 new Pie { Id = 4, Name = "Pumpkin Pie", Description = "Danish caramels gummies carrot cake. ", Price = 13.95, IsInStock = true, Category = Category.Pie},
            };
        }

        public Pie AddPie(Pie pie)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pie> GetAllPies()
        {
            return pies;
        }

        public Pie GetPieById(int pieId)
        {
            return pies.SingleOrDefault(p => p.Id == pieId);
        }

        public void UpdatePie(Pie pie)
        {
            throw new NotImplementedException();
        }
    }
}
