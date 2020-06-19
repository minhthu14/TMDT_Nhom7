using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JewelryShop.Models;
using JewelryShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace JewelryShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IJewelryRepository _jewelryRepository;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly AppDbContext _db;
        [BindProperty]
        public JewelryListViewModel JewelryListVM { get; set; }
        public ProductController(IJewelryRepository jewelryRepository, AppDbContext db, IWebHostEnvironment hostEnvironment)
        {
            _jewelryRepository = jewelryRepository;
            _db = db;
            _hostEnvironment = hostEnvironment;
            JewelryListVM = new JewelryListViewModel()
            {
                Category = _db.Categories,
                Jewelryy = new Models.Jewelry(),
                CategoryList = _db.Categories.ToList().Select(i => new SelectListItem
                {
                    Text = i.CategoryName,
                    Value = i.CategoryId.ToString()
                }),
            };
        }
        public IActionResult Index(int? page)
        {
            Pager pager;
            IEnumerable<Jewelry> jewelries;
            pager = new Pager(_db.Jewelries.Include(c => c.Category).Where(j => j.Status == "Display").Count(), page);
            jewelries = _db.Jewelries.Include(c => c.Category).Where(j => j.Status == "Display")
                .Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            var viewModel = new JewelryListViewModel
            {
                Jewelries = jewelries,
                Pager = pager

            };
            return View(viewModel);
            //pager = new Pager(_db.Jewelries.Include(c => c.Category)
            //   .Where(s => s.Name.Contains(searchString) || s.Description.Contains(searchString)
            //           || s.Category.CategoryName.Contains(searchString) || s.Status.Contains(searchString))
            //   .Count(), page);
            //jewelries = _jewelryRepository.Jewelries.OrderBy(j => j.JewelryId).Where(j => j.Status == "Display").Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            //jewelries = _db.Jewelries.Include(c => c.Category).Where(s => s.Name.Contains(searchString) || s.Description.Contains(searchString) || s.Category.CategoryName.Contains(searchString) || s.Status.Contains(searchString)).Where(j => j.Status == "Display")
            //    .Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            //productlist = _db.Jewelries.Include(c => c.Category).ToList();


        }
        private static string[] VietNamChar = new string[]
       {
           "aAeEoOuUiIdDyY",
           "áàạảãâấầậẩẫăắằặẳẵ",
           "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
           "éèẹẻẽêếềệểễ",
           "ÉÈẸẺẼÊẾỀỆỂỄ",
           "óòọỏõôốồộổỗơớờợởỡ",
           "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
           "úùụủũưứừựửữ",
           "ÚÙỤỦŨƯỨỪỰỬỮ",
           "íìịỉĩ",
           "ÍÌỊỈĨ",
           "đ",
           "Đ",
           "ýỳỵỷỹ",
           "ÝỲỴỶỸ"
       };
        public static string ReplaceUnicode(string strInput)
        {
            for (int i = 1; i < VietNamChar.Length; i++)
            {
                for (int j = 0; j < VietNamChar[i].Length; j++)
                {
                    strInput = strInput.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
                }
            }
            return strInput;
        }
        public IActionResult SearchProduct(string searchString , int? page)
        {
            Pager pager;
            IEnumerable<Jewelry> jewelries;
            string _searchString = searchString;
            string currentCategory = string.Empty;
            if (string.IsNullOrEmpty(_searchString))
            {
                pager = new Pager(_db.Jewelries.Include(c => c.Category).Where(j => j.Status == "Display").Count(), page);
                jewelries = _db.Jewelries.Include(c => c.Category).Where(j => j.Status == "Display")
                    .Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
                
                //productlist = _db.Jewelries.Include(c => c.Category).ToList();
            }
            else
            {
                pager = new Pager(_db.Jewelries.Include(c => c.Category)
                   .Where(s => s.Name.ToLower().Contains(_searchString.ToLower()) || s.Description.ToLower().Contains(_searchString.ToLower())
                           || s.Category.CategoryName.ToLower().Contains(_searchString.ToLower())).Where(j => j.Status == "Display")
                   .Count(), page);
                jewelries = _db.Jewelries.Include(c => c.Category)
                    .Where(s => s.Name.ToLower().ToLower().Contains(_searchString.ToLower()) 
                    || s.Description.ToLower().Contains(_searchString.ToLower()) 
                    || s.Status.ToLower().Contains(_searchString.ToLower()) 
                    || s.Category.CategoryName.ToLower().Contains(_searchString.ToLower()))
                    .Where(j => j.Status == "Display")
                    .Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            }
            return View("~/Views/Product/SearchProduct.cshtml", new JewelryListViewModel { Jewelries = jewelries, CurrentCategory = searchString, Pager = pager });



        }
        public IActionResult Create()
        {
            JewelryListVM.Jewelryy.Status = "Display";

            return View(JewelryListVM);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            if (!ModelState.IsValid)//neu du lieu them vao co loi se hien lai trang create
            {
                JewelryListVM.CategoryList = _db.Categories.ToList().Select(i => new SelectListItem
                {
                    Text = i.CategoryName,
                    Value = i.CategoryId.ToString()
                });
                return View(JewelryListVM);
            }

            _db.Jewelries.Add(JewelryListVM.Jewelryy);
            await _db.SaveChangesAsync();

            //Work on the image saving section

            string webRootPath = _hostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var product = await _db.Jewelries.FindAsync(JewelryListVM.Jewelryy.JewelryId);

            if (files.Count > 0)
            {
                
                string fileName = Guid.NewGuid().ToString();//ten anh 
                var uploads = Path.Combine(webRootPath, @"Images\sanpham");//duong dan anh
                var extension = Path.GetExtension(files[0].FileName);// dinh dang anh jpeg,jpg,..

                using (var filesStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(filesStream);
                }
                product.ImageUrl = @"\Images\sanpham\" + fileName + extension;//ten anh duoc them vao thu muc wwwroot/Images/sanpham
            }
            
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            JewelryListVM.Jewelryy = _db.Jewelries.Find(id.GetValueOrDefault());
            if (JewelryListVM.Jewelryy == null)
            {
                return NotFound();
            }
            return View(JewelryListVM);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPOST(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)//neu du lieu them vao co loi se hien lai trang edit
            {
                JewelryListVM.Jewelryy = _db.Jewelries.Find(id.GetValueOrDefault());
                JewelryListVM.CategoryList = _db.Categories.ToList().Select(i => new SelectListItem
                {
                    Text = i.CategoryName,
                    Value = i.CategoryId.ToString()
                });
                return View(JewelryListVM);
            }

            //Work on the image saving section

            string webRootPath = _hostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var product = await _db.Jewelries.FindAsync(JewelryListVM.Jewelryy.JewelryId);

            if (files.Count > 0)
            {
                //New Image has been uploaded
                var uploads = Path.Combine(webRootPath, @"Images\sanpham");
                var extension = Path.GetExtension(files[0].FileName);
                string fileName = Guid.NewGuid().ToString();//ten anh 
                //Delete the original file
                var imagePath = Path.Combine(webRootPath, product.ImageUrl.TrimStart('\\'));

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }

                //we will upload the new file
                using (var filesStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(filesStream);
                }
                product.ImageUrl = @"\Images\sanpham\" + fileName + extension;
            }
            else
            {
                //sửa mà ko thay ảnh
                if (JewelryListVM.Jewelryy.JewelryId != 0)
                {
                    Jewelry j = _db.Jewelries.Find(JewelryListVM.Jewelryy.JewelryId);
                    JewelryListVM.Jewelryy.ImageUrl = j.ImageUrl;
                }
            }
            product.Name = JewelryListVM.Jewelryy.Name;
            product.Description = JewelryListVM.Jewelryy.Description;
            product.Price = JewelryListVM.Jewelryy.Price;
            product.Status = JewelryListVM.Jewelryy.Status;
            product.CategoryId = JewelryListVM.Jewelryy.CategoryId;
            
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var product = _jewelryRepository.GetJewelryById(id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {   //chi doi status cua anh khi nhan nut xoa chu khong xoa trong DB,xoa hinh anh trong thu muc wwwroot
                product.Status = "NonDisplay";
                string webRootPath = _hostEnvironment.WebRootPath;
                var imagePath = Path.Combine(webRootPath, product.ImageUrl.TrimStart('\\'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}