using JewelryShop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryShop.ViewModels
{
    public class JewelryListViewModel
    {
        public IEnumerable<Jewelry> Jewelries { get; set; }
        public string CurrentCategory { get; set; }
        public Pager Pager { get; set; }
        public Jewelry Jewelryy { get; set; }
        public IEnumerable<Category> Category { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
