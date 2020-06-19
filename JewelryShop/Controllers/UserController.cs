using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using JewelryShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JewelryShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly AppDbContext _db;

        public UserController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(string searchString)
        {
            //Vùng cần note khi thử Thêm tài khoản Admin/Manager mới(lỡ bị sai chưa có RoleID cho user)
            //Hiển thị có Role Name
            ViewData["CurrentFilter"] = searchString;
            var userList = _db.ApplicationUsers.ToList();
            var userRole = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                userList = userList.Where(s => s.FullName.ToLower().Contains(searchString.ToLower())).ToList();
                userRole = _db.UserRoles.ToList();
                roles = _db.Roles.ToList();
            }
            else
            {
                userList = userList.ToList();
                userRole = _db.UserRoles.ToList();
                roles = _db.Roles.ToList();
            }
            foreach (var user in userList)
            {
                //Khi thêm Admin/Manager bị báo lỗi dòng này do chưa có role cho userId vừa thêm
                var roleId = userRole.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;
            }
            //End         
            
            return View(userList);
        }


        public async Task<IActionResult> Lock(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _db.ApplicationUsers.FirstOrDefaultAsync(m => m.Id == id);

            if (applicationUser == null)
            {
                return NotFound();
            }

            applicationUser.LockoutEnd = DateTime.Now.AddYears(1000);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UnLock(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _db.ApplicationUsers.FirstOrDefaultAsync(m => m.Id == id);

            if (applicationUser == null)
            {
                return NotFound();
            }

            applicationUser.LockoutEnd = DateTime.Now;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
