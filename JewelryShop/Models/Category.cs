using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên loại")]
        public string CategoryName { get; set; }
        public List<Jewelry> Jewelries { get; set; }

    }
}
