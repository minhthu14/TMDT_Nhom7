using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryShop.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        void CreateOrderPayment(Order order);

        Order GetOrderById(int orderId);
    }
}
