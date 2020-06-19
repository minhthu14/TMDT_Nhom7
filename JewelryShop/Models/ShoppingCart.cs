﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JewelryShop.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext _appDbContext;
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Jewelry jewelry, int amount)
        {
            var shoppingCartItem = _appDbContext.ShoppingCartItems.SingleOrDefault(
                s => s.Jewelry.JewelryId == jewelry.JewelryId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Jewelry = jewelry,
                    Amount = amount
                };

                _appDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount+=amount;
            }

            _appDbContext.SaveChanges();
        }

        public int RemoveFromCart(Jewelry jewelry)
        {
            var shoppingCartItem = _appDbContext.ShoppingCartItems.SingleOrDefault(
               s => s.Jewelry.JewelryId == jewelry.JewelryId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _appDbContext.SaveChanges();

            return localAmount;
        }
        public int ClearProduct(Jewelry jewelry)
        {
            var shoppingCartItem = _appDbContext.ShoppingCartItems.SingleOrDefault(
               s => s.Jewelry.JewelryId == jewelry.JewelryId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                
                _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                
            }

            _appDbContext.SaveChanges();

            return localAmount;

        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _appDbContext.ShoppingCartItems.Where
                (c => c.ShoppingCartId == ShoppingCartId)
                .Include(s => s.Jewelry)
                .ToList());             
                
        }

        public void ClearCart()
        {
            var cartItems = _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId);

            _appDbContext.ShoppingCartItems.RemoveRange(cartItems);
            _appDbContext.SaveChanges();
        }

        public double GetShoppingCartTotal()
        {
            var total = _appDbContext.ShoppingCartItems.Where
                (c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Jewelry.Price * c.Amount).Sum();

            return total;
        }

    }
}
