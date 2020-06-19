using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryShop.Models
{
    public class Jewelry
    {
        public int JewelryId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập giá sản phẩm")]
        [RegularExpression(@"^[1-9]\d{4,6}$",ErrorMessage = "Giá sản phẩm không hợp lệ")]
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public string Status { get; set; }
    }
}
