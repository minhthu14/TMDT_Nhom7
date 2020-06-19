using JewelryShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryShop.ViewModels
{
    public class OrderDetailsListVM
    {
        public Order Order { get; set; }
        
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
