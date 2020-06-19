using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryShop.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public double OrderTotal { get; set; }
        //tinh trang hoa don : da xu ly/chua xu ly
        public string OrderStatus { get; set; }

        //Hình thức thanh toán
        public string PaymentType { get; set; }

        //Ma giao dich khi thanh toan online
        public string TransactionId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string PhoneNumber { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
