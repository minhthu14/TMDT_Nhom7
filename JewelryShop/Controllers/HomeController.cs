using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JewelryShop.Models;
using JewelryShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JewelryShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJewelryRepository _jewelryRepository;
        public HomeController(IJewelryRepository jewelryRepository)
        {
            _jewelryRepository = jewelryRepository;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                JewelryHome=_jewelryRepository.GetJewelryHome
            };
            return View(homeViewModel);
        }
    }
}