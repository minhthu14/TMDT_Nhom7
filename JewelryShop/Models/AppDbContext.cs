using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryShop.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):
            base(options)    
        { 
        
        }
        public DbSet<Jewelry> Jewelries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public object ShopppingCartItems { get; internal set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Bông tai" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Dây chuyền" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Lắc tay" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 4, CategoryName = "Nhẫn" });

            modelBuilder.Entity<Jewelry>().HasData(new Jewelry
            {
                JewelryId = 1,
                Name = "Bông tai BT001",
                Description = "",
                Price = 356000,
                ImageUrl = "~\\Images\\sanpham\\284674740971874bd11c5b.jpg",
                CategoryId = 1, 
                Status = "Display"

            });
            modelBuilder.Entity<Jewelry>().HasData(new Jewelry
            {
                JewelryId = 2,
                Name = "Bông tai BT002",
                Description = "",
                Price = 750000,
                ImageUrl = "~\\Images\\sanpham\\28467478017635ffe020fb.jpg",
                CategoryId = 1,
                Status = "Display"

            });
            modelBuilder.Entity<Jewelry>().HasData(new Jewelry
            {
                JewelryId = 3,
                Name = "Bông tai BT003",
                Description = "",
                Price = 600000,
                ImageUrl = "~\\Images\\sanpham\\42432623515636ae3760fb.jpg",
                CategoryId = 1,
                Status = "Display"

            });
            modelBuilder.Entity<Jewelry>().HasData(new Jewelry
            {
                JewelryId = 4,
                Name = "Bông tai BT004",
                Description = "",
                Price = 590000,
                ImageUrl = "~\\Images\\sanpham\\4261909584462d336f784b.jpg",
                CategoryId = 1,
                Status = "Display"

            });
            modelBuilder.Entity<Jewelry>().HasData(new Jewelry
            {
                JewelryId = 5,
                Name = "Bông tai BT005",
                Description = "",
                Price = 356000,
                ImageUrl = "~\\Images\\sanpham\\42619097084234e931c3db.jpg",
                CategoryId = 1,
                Status = "Display"

            });
            modelBuilder.Entity<Jewelry>().HasData(new Jewelry
            {
                JewelryId = 6,
                Name = "Dây chuyền DC001",
                Description = "",
                Price = 520000,
                ImageUrl = "~\\Images\\sanpham\\40075270425b22d40c45bb-8c4eef99-91d8-4cc0-aa94-5d6637e088bf.jpg",
                CategoryId = 2,
                Status = "Display"

            });
            modelBuilder.Entity<Jewelry>().HasData(new Jewelry
            {
                JewelryId = 7,
                Name = "Dây chuyền DC002",
                Description = "",
                Price = 480000,
                ImageUrl = "~\\Images\\sanpham\\40285705182bfd10dd3ecb.jpg",
                CategoryId = 2,
                Status = "Display"

            });
            modelBuilder.Entity<Jewelry>().HasData(new Jewelry
            {
                JewelryId = 8,
                Name = "Dây chuyền DC003",
                Description = "",
                Price = 630000,
                ImageUrl = "~\\Images\\sanpham\\40285705342b1a0d849cab-e31cfb39-09c2-4caa-bac6-aacea5524a68.jpg",
                CategoryId = 2,
                Status = "Display"

            });
            modelBuilder.Entity<Jewelry>().HasData(new Jewelry
            {
                JewelryId = 9,
                Name = "Dây chuyền DC004",
                Description = "",
                Price = 356000,
                ImageUrl = "~\\Images\\sanpham\\40330998641f0b71e1ee6b-63f9135b-8f1a-483c-b381-11c7ac1af0ac.jpg",
                CategoryId = 2,
                Status = "Display"

            });
            modelBuilder.Entity<Jewelry>().HasData(new Jewelry
            {
                JewelryId = 10,
                Name = "Dây chuyền DC005",
                Description = "",
                Price = 356000,
                ImageUrl = "~\\Images\\sanpham\\40331008911b2bc28ef06b.jpg",
                CategoryId = 2,
                Status = "Display"

            });
            modelBuilder.Entity<Jewelry>().HasData(new Jewelry
            {
                JewelryId = 11,
                Name = "Lắc tay LT001",
                Description = "",
                Price = 510000,
                ImageUrl = "~\\Images\\sanpham\\25460921337d235c5a2efb.jpg",
                CategoryId = 3,
                Status = "Display"

            });
            modelBuilder.Entity<Jewelry>().HasData(new Jewelry
            {
                JewelryId = 12,
                Name = "Lắc tay LT002",
                Description = "",
                Price = 800000,
                ImageUrl = "~\\Images\\sanpham\\25460922527c5077094ecb.jpg",
                CategoryId = 3,
                Status = "Display"

            });
            modelBuilder.Entity<Jewelry>().HasData(new Jewelry
            {
                JewelryId = 13,
                Name = "Lắc tay LT003",
                Description = "",
                Price = 410000,
                ImageUrl = "~\\Images\\sanpham\\25460926987c82da2f76eb-5fb237fb-0459-4c87-a056-04e898681418.jpg",
                CategoryId = 3,
                Status = "Display"

            });
            modelBuilder.Entity<Jewelry>().HasData(new Jewelry
            {
                JewelryId = 14,
                Name = "Lắc tay LT004",
                Description = "",
                Price = 826000,
                ImageUrl = "~\\Images\\sanpham\\25460927087ded46a2fb3b.jpg",
                CategoryId = 3,
                Status = "Display"

            });
            modelBuilder.Entity<Jewelry>().HasData(new Jewelry
            {
                JewelryId = 15,
                Name = "Lắc tay LT005",
                Description = "",
                Price = 690000,
                ImageUrl = "~\\Images\\sanpham\\25460927417ee818299d0b-75abee9c-e824-478a-aba8-6ef4b633173a.jpg",
                CategoryId = 3,
                Status = "Display"

            }); modelBuilder.Entity<Jewelry>().HasData(new Jewelry
            {
                JewelryId = 16,
                Name = "Lắc tay LT006",
                Description = "",
                Price = 800000,
                ImageUrl = "~\\Images\\sanpham\\25460927417ee818299d0b-96e38481-92f5-4490-9e67-fce7bb25a44c.jpg",
                CategoryId = 3,
                Status = "Display"

            }); modelBuilder.Entity<Jewelry>().HasData(new Jewelry
            {
                JewelryId = 17,
                Name = "Nhẫn NH001",
                Description = "",
                Price = 500000,
                ImageUrl = "~\\Images\\sanpham\\25458755737ce4f80ec48b.jpg",
                CategoryId = 4,
                Status = "Display"

            }); modelBuilder.Entity<Jewelry>().HasData(new Jewelry
            {
                JewelryId = 18,
                Name = "Nhẫn NH002",
                Description = "",
                Price = 350000,
                ImageUrl = "~\\Images\\sanpham\\25459295557c33d36a66bb.jpg",
                CategoryId = 4,
                Status = "Display"

            }); modelBuilder.Entity<Jewelry>().HasData(new Jewelry
            {
                JewelryId = 19,
                Name = "Nhẫn NH003",
                Description = "",
                Price = 370000,
                ImageUrl = "~\\Images\\sanpham\\25459312967ae8ec819bab-9d37d65e-fdbf-44e5-89da-c4e87107f29c.jpg",
                CategoryId = 4,
                Status = "Display"

            }); modelBuilder.Entity<Jewelry>().HasData(new Jewelry
            {
                JewelryId = 20,
                Name = "Nhẫn NH004",
                Description = "",
                Price = 450000,
                ImageUrl = "~\\Images\\sanpham\\26458691008bbe214d6bcb.jpg",
                CategoryId = 4,
                Status = "Display"

            }); modelBuilder.Entity<Jewelry>().HasData(new Jewelry
            {
                JewelryId = 21,
                Name = "Nhẫn NH005",
                Description = "",
                Price = 550000,
                ImageUrl = "~\\Images\\sanpham\\26458696828af93ff0aa0b.jpg",
                CategoryId = 4,
                Status = "Display"

            });
        }
    }
}
