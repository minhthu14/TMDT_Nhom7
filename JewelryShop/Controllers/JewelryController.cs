using JewelryShop.Models;
using JewelryShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryShop.Controllers
{
    public class JewelryController : Controller
    {
        private readonly IJewelryRepository _jewelryRepository;
        private readonly ICategoryRepository _categoryRepository;
        public JewelryController(IJewelryRepository jewelryRepository, ICategoryRepository categoryRepository)
        {
            _jewelryRepository = jewelryRepository;
            _categoryRepository = categoryRepository;
        }

        //public ViewResult List(string category)
        //{
        //    IEnumerable<Jewelry> jewelries;
        //    string currentCategory;
        //    if (string.IsNullOrEmpty(category))
        //    {
        //        jewelries = _jewelryRepository.GetAllJewelry.OrderBy(c => c.JewelryId);
        //        currentCategory = "All Jewelry";
        //    }
        //    else
        //    {
        //        jewelries = _jewelryRepository.GetAllJewelry.Where(c => c.Category.CategoryName == category);
        //        currentCategory = _categoryRepository.GetAllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
        //    }
        //    return View(new JewelryListViewModel
        //    {
        //        Jewelries = jewelries,
        //        CurrentCategory = currentCategory
        //    });

        //}
        [HttpGet]
        public ActionResult List(string category, int? page)
        {
            Pager pager;
            IEnumerable<Jewelry> jewelries;
            //string currentCategory;
            //if (string.IsNullOrEmpty(category))
            //{
            //    jewelries = _jewelryRepository.GetAllJewelry.OrderBy(c => c.JewelryId);
            //    //currentCategory = "All Jewelry";
            //    pager = new Pager(_jewelryRepository.GetAllJewelry.OrderBy(c => c.JewelryId).Count(), page);
            //    var viewModel = new JewelryListViewModel
            //    {
            //        Jewelries = jewelries.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
            //        CurrentCategory = "All Jewelry",
            //        Pager = pager

            //    };
            //    return View(viewModel);
            //}
            //else
            //{
            jewelries = _jewelryRepository.GetAllJewelry.Where(c => c.Category.CategoryName == category);
            pager = new Pager(_jewelryRepository.GetAllJewelry.Where(c => c.Category.CategoryName == category).Count(), page);
            //currentCategory = _categoryRepository.GetAllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            var viewModel = new JewelryListViewModel
            {
                Jewelries = jewelries.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                CurrentCategory = _categoryRepository.GetAllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName,
                Pager = pager

            };
            return View(viewModel);
            //}

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
        public ViewResult Search(string searchString, int? page)
        {
            Pager pager;
            string _searchString = searchString;
            IEnumerable<Jewelry> jewelries;
            string currentCategory = string.Empty;
            pager = new Pager(_jewelryRepository.Jewelries.OrderBy(j => j.JewelryId).Count(), page);
            if (string.IsNullOrEmpty(_searchString))
            {
                jewelries = _jewelryRepository.Jewelries.OrderBy(j => j.JewelryId).Where(j => j.Status == "Display").Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
                pager = new Pager(_jewelryRepository.Jewelries.OrderBy(j => j.JewelryId).Where(j => j.Status == "Display").Count(), page);
            }
            else
            {
                jewelries = _jewelryRepository.Jewelries.Where(j => ReplaceUnicode(j.Name).ToLower().Contains(ReplaceUnicode(_searchString).ToLower())).Where(j => j.Status == "Display").Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
                pager = new Pager(_jewelryRepository.Jewelries.Where(j => ReplaceUnicode(j.Name).ToLower().Contains(ReplaceUnicode(_searchString).ToLower())).Where(j => j.Status == "Display").Count(), page);
            }

            return View("~/Views/Jewelry/Search.cshtml", new JewelryListViewModel { Jewelries = jewelries, CurrentCategory = searchString, Pager = pager });
        }
        public IActionResult Details(int id)
        {
            var jewelry = _jewelryRepository.GetJewelryById(id);
            if (jewelry == null)
                return NotFound();
            return View(jewelry);

        }
    }
}
