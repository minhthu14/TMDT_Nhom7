using JewelryShop.Models;
using JewelryShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JewelryShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;
        private readonly AppDbContext _appDbContext;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart, AppDbContext appDbContext)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
            _appDbContext = appDbContext;


        }

        public ShoppingCartViewModel ShoppingCartViewModel { get; private set; }

        [Authorize(Roles = "Customer")]
        public IActionResult Checkout()
        {
            ShoppingCartViewModel = new ShoppingCartViewModel()
            {
                Order = new Models.Order(),
                ShoppingCart = _shoppingCart,
                ListCart = _shoppingCart.GetShoppingCartItems(),
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ApplicationUser applicationUser = _appDbContext.ApplicationUsers.First(c => c.Id == claim.Value);
            //ShoppingCartViewModel.Order.ApplicationUser = applicationUser;
            foreach (var list in ShoppingCartViewModel.ListCart)
            {
                ShoppingCartViewModel.Order.OrderTotal += (list.Jewelry.Price * list.Amount);
            }
            ShoppingCartViewModel.Order.ApplicationUserId = claim.Value;
            ShoppingCartViewModel.Order.Name = applicationUser.FullName;
            ShoppingCartViewModel.Order.Address = applicationUser.Adress;
            ShoppingCartViewModel.Order.PhoneNumber = applicationUser.PhoneNumber;
            return View(ShoppingCartViewModel);
        }
        
        [Authorize(Roles = "Customer")]
        public IActionResult ShipCod()
        {
            return RedirectToAction("CheckoutShipCod");
        }
        [Authorize(Roles = "Customer")]
        public IActionResult CheckoutShipCod()
        {
            ShoppingCartViewModel = new ShoppingCartViewModel()
            {
                Order = new Models.Order(),
                ShoppingCart = _shoppingCart,
                ListCart = _shoppingCart.GetShoppingCartItems(),
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ApplicationUser applicationUser = _appDbContext.ApplicationUsers.First(c => c.Id == claim.Value);
            //ShoppingCartViewModel.Order.ApplicationUser = applicationUser;
            foreach (var list in ShoppingCartViewModel.ListCart)
            {
                ShoppingCartViewModel.Order.OrderTotal += (list.Jewelry.Price * list.Amount);
            }
            ShoppingCartViewModel.Order.ApplicationUserId = claim.Value;
            ShoppingCartViewModel.Order.Name = applicationUser.FullName;
            ShoppingCartViewModel.Order.Address = applicationUser.Adress;
            ShoppingCartViewModel.Order.PhoneNumber = applicationUser.PhoneNumber;
            return View(ShoppingCartViewModel);
        }
        [Authorize(Roles = "Customer")]
        [HttpPost]
        [ActionName("CheckoutShipCod")]
        [ValidateAntiForgeryToken]
        public IActionResult CheckoutShipCod(Models.Order order)
        {
            ShoppingCartViewModel = new ShoppingCartViewModel()
            {
                Order = new Models.Order(),
                ShoppingCart = _shoppingCart,
                ListCart = _shoppingCart.GetShoppingCartItems(),
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            foreach (var list in ShoppingCartViewModel.ListCart)
            {
                ShoppingCartViewModel.Order.OrderTotal += (list.Jewelry.Price * list.Amount);
            }
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ApplicationUser applicationUser = _appDbContext.ApplicationUsers.First(c => c.Id == claim.Value);

            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Giỏ hàng của bạn hiện tại chưa có sản phẩm nào!!!");
            }

            if (ModelState.IsValid)
            {
                ShoppingCartViewModel.Order.ApplicationUserId = claim.Value;
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(ShoppingCartViewModel);
        }
        [Authorize(Roles = "Customer")]
        public IActionResult Online()
        {
            return RedirectToAction("CheckoutPayment");
        }
        
        [Authorize(Roles = "Customer")]
        public IActionResult CheckoutPayment()
        {
            ShoppingCartViewModel = new ShoppingCartViewModel()
            {
                Order = new Models.Order(),
                ShoppingCart = _shoppingCart,
                ListCart = _shoppingCart.GetShoppingCartItems(),
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ApplicationUser applicationUser = _appDbContext.ApplicationUsers.First(c => c.Id == claim.Value);
            //ShoppingCartViewModel.Order.ApplicationUser = applicationUser;
            foreach (var list in ShoppingCartViewModel.ListCart)
            {
                ShoppingCartViewModel.Order.OrderTotal += (list.Jewelry.Price * list.Amount);
            }
            ShoppingCartViewModel.Order.ApplicationUserId = claim.Value;
            ShoppingCartViewModel.Order.Name = applicationUser.FullName;
            ShoppingCartViewModel.Order.Address = applicationUser.Adress;
            ShoppingCartViewModel.Order.PhoneNumber = applicationUser.PhoneNumber;
            return View(ShoppingCartViewModel);
        }
        [Authorize(Roles = "Customer")]
        [HttpPost]
        [ActionName("CheckoutPayment")]
        [ValidateAntiForgeryToken]
        public IActionResult CheckoutPayment(Models.Order order,string stripeToken)
        {
            ShoppingCartViewModel = new ShoppingCartViewModel()
            {
                Order = new Models.Order(),
                ShoppingCart = _shoppingCart,
                ListCart = _shoppingCart.GetShoppingCartItems(),
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            foreach (var list in ShoppingCartViewModel.ListCart)
            {
                ShoppingCartViewModel.Order.OrderTotal += (list.Jewelry.Price * list.Amount);
            }
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ApplicationUser applicationUser = _appDbContext.ApplicationUsers.First(c => c.Id == claim.Value);

            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Giỏ hàng của bạn hiện tại chưa có sản phẩm nào!!!");
            }

            if (ModelState.IsValid)
            {
                ShoppingCartViewModel.Order.ApplicationUserId = claim.Value;
                _orderRepository.CreateOrderPayment(order);
                if (stripeToken == null)
                {

                }
                else
                {
                    var options = new ChargeCreateOptions
                    {
                        Amount = Convert.ToInt32(_shoppingCart.GetShoppingCartTotal()),
                        Currency = "vnd",
                        Description = "Order ID : " + order.OrderId,
                        Source = stripeToken
                    };
                    var services = new ChargeService();
                    Charge charge = services.Create(options);
                    if (charge.BalanceTransactionId != null)
                    {
                        order.TransactionId = charge.BalanceTransactionId;
                    }
                    if (charge.Status.ToLower() == "succeeded")
                    {
                        _shoppingCart.ClearCart();
                    }
                }
                return RedirectToAction("CheckoutComplete");
            }

            return View(ShoppingCartViewModel);
        }
        [Authorize(Roles = "Customer")]
        public IActionResult CheckoutComplete()
        {
            return View();
        }

        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> OrderHistory()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            OrderListVM orderListVM = new OrderListVM()
            {
                Orders = new List<OrderDetailsListVM>()

            };
            List<Models.Order> OrderHeaderList = await _appDbContext.Orders.Include(o => o.ApplicationUser).Where(u => u.ApplicationUserId == claim.Value).ToListAsync();

            foreach (Models.Order item in OrderHeaderList)
            {
                OrderDetailsListVM individual = new OrderDetailsListVM
                {
                    Order = item,
                    OrderDetails = await _appDbContext.OrderDetails.Where(o => o.OrderIdF == item.OrderId).ToListAsync()
                };
                orderListVM.Orders.Add(individual);
            }
            var count = orderListVM.Orders.Count;
            orderListVM.Orders = orderListVM.Orders.OrderByDescending(p => p.Order.OrderId).ToList();           
            return View(orderListVM);
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ManageOrder(int? page)
        {
            Pager pager;
            pager = new Pager(_appDbContext.Orders.Count(), page);
            OrderListVM orderListVM = new OrderListVM()
            {
                Orders = new List<OrderDetailsListVM>(),
                //Order = _appDbContext.Orders.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager

            };
            List<Models.Order> OrderHeaderList = await _appDbContext.Orders.ToListAsync();
            foreach (Models.Order item in OrderHeaderList)
            {
                OrderDetailsListVM individual = new OrderDetailsListVM
                {
                    Order = item,
                    OrderDetails = await _appDbContext.OrderDetails.Where(o => o.OrderIdF == item.OrderId).ToListAsync()
                };
                orderListVM.Orders.Add(individual);
            }
            //var count = orderListVM.Orders.Count;
            orderListVM.Orders = orderListVM.Orders.OrderByDescending(p => p.Order.OrderId).Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
            return View(orderListVM);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SearchOrder(string searchString, int? page)
        {
            Pager pager;
            string _searchString = searchString;
            pager = new Pager(_appDbContext.Orders.Count(), page);
            if (string.IsNullOrEmpty(_searchString))
            {
                OrderListVM orderListVM = new OrderListVM()
                {
                    Orders = new List<OrderDetailsListVM>(),
                    //Order = _appDbContext.Orders.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                    Pager = pager,
                    CurrentSearch = searchString


                };
                List<Models.Order> OrderHeaderList = await _appDbContext.Orders.ToListAsync();
                foreach (Models.Order item in OrderHeaderList)
                {
                    OrderDetailsListVM individual = new OrderDetailsListVM
                    {
                        Order = item,
                        OrderDetails = await _appDbContext.OrderDetails.Where(o => o.OrderIdF == item.OrderId).ToListAsync()
                    };
                    orderListVM.Orders.Add(individual);
                }
                //var count = orderListVM.Orders.Count;
                orderListVM.Orders = orderListVM.Orders.OrderByDescending(p => p.Order.OrderId).Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
                return View(orderListVM);
            }
            else
            {
                OrderListVM orderListVM = new OrderListVM()
                {
                    Orders = new List<OrderDetailsListVM>(),
                    //Order = _appDbContext.Orders.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                    Pager = new Pager(_appDbContext.Orders.Where(o => o.Name.ToLower().Contains(_searchString.ToLower())
                                    || o.OrderStatus.ToLower().Contains(_searchString.ToLower())
                                    || o.PhoneNumber.ToLower().Contains(_searchString.ToLower())
                                    || o.OrderId.ToString().ToLower().Contains(_searchString.ToLower())
                                    || o.OrderStatus.ToLower().Contains(_searchString.ToLower())
                                    || o.PaymentType.ToLower().Contains(_searchString.ToLower())).Count(), page),
                    CurrentSearch = searchString


                };
                List<Models.Order> OrderHeaderList = await _appDbContext.Orders.ToListAsync();
                foreach (Models.Order item in OrderHeaderList)
                {
                    OrderDetailsListVM individual = new OrderDetailsListVM
                    {
                        Order = item,
                        OrderDetails = await _appDbContext.OrderDetails.Where(o => o.OrderIdF == item.OrderId).ToListAsync()
                    };
                    orderListVM.Orders.Add(individual);
                }
                //var count = orderListVM.Orders.Count;
                orderListVM.Orders = orderListVM.Orders.Where(o => o.Order.Name.ToLower().Contains(_searchString.ToLower()) 
                                    || o.Order.OrderStatus.ToLower().Contains(_searchString.ToLower())
                                    || o.Order.PhoneNumber.ToLower().Contains(_searchString.ToLower())
                                    || o.Order.OrderId.ToString().ToLower().Contains(_searchString.ToLower())
                                    || o.Order.OrderStatus.ToLower().Contains(_searchString.ToLower())
                                    || o.Order.PaymentType.ToLower().Contains(_searchString.ToLower()))
                                    .OrderByDescending(p => p.Order.OrderId).Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
                return View(orderListVM);
            }
            //return View("~/Views/Order/ManageOrder/SearchOrder.cshtml", new OrderListVM {   CurrentSearch = searchString, Pager = pager });
            


        }
        //Ds đơn hàng/Lịch sử đơn hàng đều điều hướng đến chi tiết đơn hàng
        [Authorize(Roles = "Admin,Customer")]
        public async Task<IActionResult> OrderHistoryDetail(int Id)
        {
            OrderDetailsListVM orderDetailsViewModel = new OrderDetailsListVM()
            {
                Order = await _appDbContext.Orders.Include(el => el.ApplicationUser).FirstOrDefaultAsync(m => m.OrderId == Id),
                OrderDetails = await _appDbContext.OrderDetails.Where(m => m.OrderIdF == Id).Include(j => j.Jewelry).ToListAsync(),
                
            };
            return View(orderDetailsViewModel);
        }

        //Xử lý đơn hàng
        //Đơn hàng chưa xử lý sẽ được xử lý
        [Authorize(Roles ="Admin")]
        public IActionResult StartHandling(int id)
        {
            Models.Order orderHeader = _orderRepository.GetOrderById(id);
            if(orderHeader == null)
            {
                return NotFound();
            }
            else
            {
                orderHeader.OrderStatus = RL.StatusYet;
            }
            _appDbContext.SaveChanges();
            return RedirectToAction("ManageOrder", "Order");
        }

    }
}
