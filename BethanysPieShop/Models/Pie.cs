using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class Pie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public bool IsPieOfTheWeek { get; set; }
        public bool IsInStock { get; set; }
        public Category Category { get; set; }

    }
}
