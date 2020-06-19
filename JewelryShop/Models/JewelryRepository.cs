using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryShop.Models
{
    public class JewelryRepository : IJewelryRepository
    {
        private readonly AppDbContext _appDbContext;
        public JewelryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Jewelry> GetAllJewelry
        {
            get
            {
                return _appDbContext.Jewelries.Include(c => c.Category).Where(j => j.Status == "Display");
            }

        }

        public IEnumerable<Jewelry> GetJewelryHome
        {
            get
            {
                return _appDbContext.Jewelries.OrderByDescending(j => j.JewelryId).Where(j => j.Status == "Display").Take(12);
            }
        }

        public Jewelry GetJewelryById(int jewelryId)
        {
            return _appDbContext.Jewelries.FirstOrDefault(j => j.JewelryId == jewelryId);
        }
        public IEnumerable<Jewelry> Jewelries => _appDbContext.Jewelries.Include(c => c.Category);
    }
}
