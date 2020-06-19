using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using JewelryShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JewelryShop.Controllers
{
    [Authorize(Roles = "Admin,Customer")]
    public class AddressController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public AddressController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ApplicationUser applicationUser = _appDbContext.ApplicationUsers.First(c => c.Id == claim.Value);
            applicationUser.Id = claim.Value;
            applicationUser.Adress = applicationUser.Adress;
            return View(applicationUser);
        }
        public ActionResult EditAddress(string address)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ApplicationUser applicationUser = _appDbContext.ApplicationUsers.First(c => c.Id == claim.Value);
            applicationUser.Id = claim.Value;
            address = HttpContext.Request.Form["address"];
            if(address == "")
            {
                NotFound();
            }
            else
            {
                applicationUser.Adress = address;
                _appDbContext.SaveChanges();
            }
           
            return RedirectToAction(nameof(Index));
        }
    }
}