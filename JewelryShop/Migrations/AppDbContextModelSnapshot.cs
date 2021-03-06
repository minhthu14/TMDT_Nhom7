﻿// <auto-generated />
using System;
using JewelryShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JewelryShop.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JewelryShop.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Bông tai"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Dây chuyền"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Lắc tay"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Nhẫn"
                        });
                });

            modelBuilder.Entity("JewelryShop.Models.Jewelry", b =>
                {
                    b.Property<int>("JewelryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JewelryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Jewelries");

                    b.HasData(
                        new
                        {
                            JewelryId = 1,
                            CategoryId = 1,
                            Description = "",
                            ImageUrl = "~\\Images\\sanpham\\284674740971874bd11c5b.jpg",
                            Name = "Bông tai BT001",
                            Price = 356000.0,
                            Status = "Display"
                        },
                        new
                        {
                            JewelryId = 2,
                            CategoryId = 1,
                            Description = "",
                            ImageUrl = "~\\Images\\sanpham\\28467478017635ffe020fb.jpg",
                            Name = "Bông tai BT002",
                            Price = 750000.0,
                            Status = "Display"
                        },
                        new
                        {
                            JewelryId = 3,
                            CategoryId = 1,
                            Description = "",
                            ImageUrl = "~\\Images\\sanpham\\42432623515636ae3760fb.jpg",
                            Name = "Bông tai BT003",
                            Price = 600000.0,
                            Status = "Display"
                        },
                        new
                        {
                            JewelryId = 4,
                            CategoryId = 1,
                            Description = "",
                            ImageUrl = "~\\Images\\sanpham\\4261909584462d336f784b.jpg",
                            Name = "Bông tai BT004",
                            Price = 590000.0,
                            Status = "Display"
                        },
                        new
                        {
                            JewelryId = 5,
                            CategoryId = 1,
                            Description = "",
                            ImageUrl = "~\\Images\\sanpham\\42619097084234e931c3db.jpg",
                            Name = "Bông tai BT005",
                            Price = 356000.0,
                            Status = "Display"
                        },
                        new
                        {
                            JewelryId = 6,
                            CategoryId = 2,
                            Description = "",
                            ImageUrl = "~\\Images\\sanpham\\40075270425b22d40c45bb-8c4eef99-91d8-4cc0-aa94-5d6637e088bf.jpg",
                            Name = "Dây chuyền DC001",
                            Price = 520000.0,
                            Status = "Display"
                        },
                        new
                        {
                            JewelryId = 7,
                            CategoryId = 2,
                            Description = "",
                            ImageUrl = "~\\Images\\sanpham\\40285705182bfd10dd3ecb.jpg",
                            Name = "Dây chuyền DC002",
                            Price = 480000.0,
                            Status = "Display"
                        },
                        new
                        {
                            JewelryId = 8,
                            CategoryId = 2,
                            Description = "",
                            ImageUrl = "~\\Images\\sanpham\\40285705342b1a0d849cab-e31cfb39-09c2-4caa-bac6-aacea5524a68.jpg",
                            Name = "Dây chuyền DC003",
                            Price = 630000.0,
                            Status = "Display"
                        },
                        new
                        {
                            JewelryId = 9,
                            CategoryId = 2,
                            Description = "",
                            ImageUrl = "~\\Images\\sanpham\\40330998641f0b71e1ee6b-63f9135b-8f1a-483c-b381-11c7ac1af0ac.jpg",
                            Name = "Dây chuyền DC004",
                            Price = 356000.0,
                            Status = "Display"
                        },
                        new
                        {
                            JewelryId = 10,
                            CategoryId = 2,
                            Description = "",
                            ImageUrl = "~\\Images\\sanpham\\40331008911b2bc28ef06b.jpg",
                            Name = "Dây chuyền DC005",
                            Price = 356000.0,
                            Status = "Display"
                        },
                        new
                        {
                            JewelryId = 11,
                            CategoryId = 3,
                            Description = "",
                            ImageUrl = "~\\Images\\sanpham\\25460921337d235c5a2efb.jpg",
                            Name = "Lắc tay LT001",
                            Price = 510000.0,
                            Status = "Display"
                        },
                        new
                        {
                            JewelryId = 12,
                            CategoryId = 3,
                            Description = "",
                            ImageUrl = "~\\Images\\sanpham\\25460922527c5077094ecb.jpg",
                            Name = "Lắc tay LT002",
                            Price = 800000.0,
                            Status = "Display"
                        },
                        new
                        {
                            JewelryId = 13,
                            CategoryId = 3,
                            Description = "",
                            ImageUrl = "~\\Images\\sanpham\\25460926987c82da2f76eb-5fb237fb-0459-4c87-a056-04e898681418.jpg",
                            Name = "Lắc tay LT003",
                            Price = 410000.0,
                            Status = "Display"
                        },
                        new
                        {
                            JewelryId = 14,
                            CategoryId = 3,
                            Description = "",
                            ImageUrl = "~\\Images\\sanpham\\25460927087ded46a2fb3b.jpg",
                            Name = "Lắc tay LT004",
                            Price = 826000.0,
                            Status = "Display"
                        },
                        new
                        {
                            JewelryId = 15,
                            CategoryId = 3,
                            Description = "",
                            ImageUrl = "~\\Images\\sanpham\\25460927417ee818299d0b-75abee9c-e824-478a-aba8-6ef4b633173a.jpg",
                            Name = "Lắc tay LT005",
                            Price = 690000.0,
                            Status = "Display"
                        },
                        new
                        {
                            JewelryId = 16,
                            CategoryId = 3,
                            Description = "",
                            ImageUrl = "~\\Images\\sanpham\\25460927417ee818299d0b-96e38481-92f5-4490-9e67-fce7bb25a44c.jpg",
                            Name = "Lắc tay LT006",
                            Price = 800000.0,
                            Status = "Display"
                        },
                        new
                        {
                            JewelryId = 17,
                            CategoryId = 4,
                            Description = "",
                            ImageUrl = "~\\Images\\sanpham\\25458755737ce4f80ec48b.jpg",
                            Name = "Nhẫn NH001",
                            Price = 500000.0,
                            Status = "Display"
                        },
                        new
                        {
                            JewelryId = 18,
                            CategoryId = 4,
                            Description = "",
                            ImageUrl = "~\\Images\\sanpham\\25459295557c33d36a66bb.jpg",
                            Name = "Nhẫn NH002",
                            Price = 350000.0,
                            Status = "Display"
                        },
                        new
                        {
                            JewelryId = 19,
                            CategoryId = 4,
                            Description = "",
                            ImageUrl = "~\\Images\\sanpham\\25459312967ae8ec819bab-9d37d65e-fdbf-44e5-89da-c4e87107f29c.jpg",
                            Name = "Nhẫn NH003",
                            Price = 370000.0,
                            Status = "Display"
                        },
                        new
                        {
                            JewelryId = 20,
                            CategoryId = 4,
                            Description = "",
                            ImageUrl = "~\\Images\\sanpham\\26458691008bbe214d6bcb.jpg",
                            Name = "Nhẫn NH004",
                            Price = 450000.0,
                            Status = "Display"
                        },
                        new
                        {
                            JewelryId = 21,
                            CategoryId = 4,
                            Description = "",
                            ImageUrl = "~\\Images\\sanpham\\26458696828af93ff0aa0b.jpg",
                            Name = "Nhẫn NH005",
                            Price = 550000.0,
                            Status = "Display"
                        });
                });

            modelBuilder.Entity("JewelryShop.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("OrderTotal")
                        .HasColumnType("float");

                    b.Property<string>("PaymentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("JewelryShop.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("JewelryIdF")
                        .HasColumnType("int");

                    b.Property<int>("OrderIdF")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("JewelryIdF");

                    b.HasIndex("OrderIdF");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("JewelryShop.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("ShoppingCartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("JewelryId")
                        .HasColumnType("int");

                    b.Property<string>("ShoppingCartId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShoppingCartItemId");

                    b.HasIndex("JewelryId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("JewelryShop.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("JewelryShop.Models.Jewelry", b =>
                {
                    b.HasOne("JewelryShop.Models.Category", "Category")
                        .WithMany("Jewelries")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JewelryShop.Models.Order", b =>
                {
                    b.HasOne("JewelryShop.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("JewelryShop.Models.OrderDetail", b =>
                {
                    b.HasOne("JewelryShop.Models.Jewelry", "Jewelry")
                        .WithMany()
                        .HasForeignKey("JewelryIdF")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JewelryShop.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderIdF")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JewelryShop.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("JewelryShop.Models.Jewelry", "Jewelry")
                        .WithMany()
                        .HasForeignKey("JewelryId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
