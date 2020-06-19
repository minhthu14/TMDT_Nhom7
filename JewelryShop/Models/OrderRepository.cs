using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderDate = DateTime.Now;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
            order.OrderStatus = "Chưa xử lý";
            order.PaymentType = "Thanh toán tại nhà";
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();

            var shoppingCartItems = _shoppingCart.GetShoppingCartItems();

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    Price = shoppingCartItem.Jewelry.Price,
                    JewelryIdF = shoppingCartItem.Jewelry.JewelryId,
                    OrderIdF = order.OrderId
                };

                _appDbContext.OrderDetails.Add(orderDetail);
            }

            _appDbContext.SaveChanges();
        }

        public void CreateOrderPayment(Order order)
        {
            order.OrderDate = DateTime.Now;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
            order.OrderStatus = "Chưa xử lý";
            order.PaymentType = "Thanh toán online";
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();

            var shoppingCartItems = _shoppingCart.GetShoppingCartItems();

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    Price = shoppingCartItem.Jewelry.Price,
                    JewelryIdF = shoppingCartItem.Jewelry.JewelryId,
                    OrderIdF = order.OrderId
                };

                _appDbContext.OrderDetails.Add(orderDetail);
            }

            _appDbContext.SaveChanges();
        }

        public Order GetOrderById(int orderId)
        {
            return _appDbContext.Orders.FirstOrDefault(o => o.OrderId == orderId);
        }
    }
}
