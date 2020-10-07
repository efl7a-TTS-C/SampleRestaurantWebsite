using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class SubmittedOrder : BaseEntity
    {
        public string CustomerId { get; set; }
        public DateTime TimeSubmitted { get; set; }
        public DateTime EstimatedShippingDate { get; set; }
        public List<OrderItem> items { get; set; }
        public double Total { get; set; }

    }
}
