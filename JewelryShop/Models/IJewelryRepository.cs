using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryShop.Models
{
    public interface IJewelryRepository
    {
        IEnumerable<Jewelry> GetAllJewelry { get; }
        IEnumerable<Jewelry> GetJewelryHome { get; }
        IEnumerable<Jewelry> Jewelries { get; }
        Jewelry GetJewelryById(int jewelryId);

    }
}
