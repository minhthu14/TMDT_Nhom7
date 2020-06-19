using JewelryShop.Models;
using JewelryShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JewelryShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IJewelryRepository _jewelryRepository;
        private readonly ShoppingCart _shoppingCart;
        //private readonly ShoppingCartItem _shoppingCartItem;
        public ShoppingCartController(IJewelryRepository jewelryRepository, ShoppingCart shoppingCart)
        {
            _jewelryRepository = jewelryRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int jewelryId)
        {
            var selectedJewelry = _jewelryRepository.GetAllJewelry.FirstOrDefault(c => c.JewelryId == jewelryId);

            if (selectedJewelry != null)
            {
                _shoppingCart.AddToCart(selectedJewelry, 1);
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult AddToShoppingCartAmount(ShoppingCartItem shoppingCartItem, int jewelryId, string Amount)
        {
            Amount = HttpContext.Request.Form["Amount"];
            var selectedJewelry = _jewelryRepository.GetAllJewelry.FirstOrDefault(c => c.JewelryId == jewelryId);
            int sl = Convert.ToInt32(Amount);
            if (selectedJewelry != null)
            {
                _shoppingCart.AddToCart(selectedJewelry, sl);
            }
            return RedirectToAction("Index");

        }

        public RedirectToActionResult RemoveFromShoppingCart(int jewelryId)
        {
            var selectedJewelry = _jewelryRepository.GetAllJewelry.FirstOrDefault(c => c.JewelryId == jewelryId);

            if (selectedJewelry != null)
            {
                _shoppingCart.RemoveFromCart(selectedJewelry);
            }

            return RedirectToAction("Index");
        }
        public RedirectToActionResult ClearCart()
        {
            _shoppingCart.ClearCart();
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveProduct(int jewelryId)
        {
            var selectedJewelry = _jewelryRepository.GetAllJewelry.FirstOrDefault(c => c.JewelryId == jewelryId);

            if (selectedJewelry != null)
            {
                _shoppingCart.ClearProduct(selectedJewelry);
            }

            return RedirectToAction("Index");
        }

    }
}



