using JewelryShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryShop.ViewModels
{
    public class OrderListVM
    {
        public IList<OrderDetailsListVM> Orders { get; set; }
        public Pager Pager { get; set; }
        public string CurrentSearch { get; set; }
        public Order Order { get; set; }


    }
}
