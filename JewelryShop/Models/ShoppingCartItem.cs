using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryShop.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public string ShoppingCartId { get; set; }
        public Jewelry Jewelry { get; set; }
        public int Amount { get; set; }
    }
}
