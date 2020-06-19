using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryShop.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }

        [Required]
        public int JewelryIdF { get; set; }
        [ForeignKey("JewelryIdF")]
        public Jewelry Jewelry { get; set; }

        [Required]
        public int OrderIdF { get; set; }
        [ForeignKey("OrderIdF")]
        public Order Order { get; set; }

        public int Amount { get; set; }
        public double Price { get; set; }
    }
}
