using JewelryShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryShop.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public double ShoppingCartTotal { get; set; }
        public IEnumerable<ShoppingCartItem> ListCart { get; set; }
        public Order Order { get; set; }
    }
}
