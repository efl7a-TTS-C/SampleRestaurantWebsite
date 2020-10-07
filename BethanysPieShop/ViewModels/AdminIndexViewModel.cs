using BethanysPieShop.Contracts;
using BethanysPieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.ViewModels
{
    public class AdminIndexViewModel
    {
        public string Id { get; set; }
        public IEnumerable<Pie> Pies { get; set; }
        public IEnumerable<SubmittedOrder> SubmittedOrders { get; set; }
    }
}
