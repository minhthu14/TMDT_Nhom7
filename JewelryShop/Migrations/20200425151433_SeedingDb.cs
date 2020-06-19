using Microsoft.EntityFrameworkCore.Migrations;

namespace JewelryShop.Migrations
{
    public partial class SeedingDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Bông tai" },
                    { 2, "Dây chuyền" },
                    { 3, "Lắc tay" },
                    { 4, "Nhẫn" }
                });

            migrationBuilder.InsertData(
                table: "Jewelries",
                columns: new[] { "JewelryId", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "", "\\Images\\bongtai\\284674740971874bd11c5b.jpg", "Bông tai BT001", 356000.0 },
                    { 19, 4, "", "\\Images\\nhan\\25459312967ae8ec819bab-9d37d65e-fdbf-44e5-89da-c4e87107f29c.jpg", "Nhẫn NH003", 370000.0 },
                    { 18, 4, "", "\\Images\\nhan\\25459295557c33d36a66bb.jpg", "Nhẫn NH002", 350000.0 },
                    { 17, 4, "", "\\Images\\nhan\\25458755737ce4f80ec48b.jpg", "Nhẫn NH001", 500000.0 },
                    { 16, 4, "", "\\Images\\lactay\\25460927417ee818299d0b-96e38481-92f5-4490-9e67-fce7bb25a44c.jpg", "Lắc tay LT006", 800000.0 },
                    { 15, 3, "", "\\Images\\lactay\\25460927417ee818299d0b-75abee9c-e824-478a-aba8-6ef4b633173a.jpg", "Lắc tay LT005", 690000.0 },
                    { 14, 3, "", "\\Images\\lactay\\25460927087ded46a2fb3b.jpg", "Lắc tay LT004", 826000.0 },
                    { 13, 3, "", "\\Images\\lactay\\25460926987c82da2f76eb-5fb237fb-0459-4c87-a056-04e898681418.jpg", "Lắc tay LT003", 410000.0 },
                    { 12, 3, "", "\\Images\\lactay\\25460922527c5077094ecb.jpg", "Lắc tay LT002", 800000.0 },
                    { 20, 4, "", "\\Images\\nhan\\26458691008bbe214d6bcb.jpg", "Nhẫn NH004", 450000.0 },
                    { 11, 3, "", "\\Images\\lactay\\25460921337d235c5a2efb.jpg", "Lắc tay LT001", 510000.0 },
                    { 9, 2, "", "\\Images\\daychuyen\\40330998641f0b71e1ee6b-63f9135b-8f1a-483c-b381-11c7ac1af0ac.jpg", "Dây chuyền DC004", 356000.0 },
                    { 8, 2, "", "\\Images\\daychuyen\\40285705342b1a0d849cab-e31cfb39-09c2-4caa-bac6-aacea5524a68.jpg", "Dây chuyền DC003", 630000.0 },
                    { 7, 2, "", "\\Images\\daychuyen\\40285705182bfd10dd3ecb.jpg", "Dây chuyền DC002", 480000.0 },
                    { 6, 2, "", "\\Images\\daychuyen\\40075270425b22d40c45bb-8c4eef99-91d8-4cc0-aa94-5d6637e088bf.jpg", "Dây chuyền DC001", 520000.0 },
                    { 5, 1, "", "\\Images\\bongtai\\42619097084234e931c3db.jpg", "Bông tai BT005", 356000.0 },
                    { 4, 1, "", "\\Images\\bongtai\\4261909584462d336f784b.jpg", "Bông tai BT004", 590000.0 },
                    { 3, 1, "", "\\Images\\bongtai\\42432623515636ae3760fb.jpg", "Bông tai BT003", 600000.0 },
                    { 2, 1, "", "\\Images\\bongtai\\28467478017635ffe020fb.jpg", "Bông tai BT002", 750000.0 },
                    { 10, 2, "", "\\Images\\daychuyen\\40331008911b2bc28ef06b.jpg", "Dây chuyền DC005", 356000.0 },
                    { 21, 4, "", "\\Images\\nhan\\26458696828af93ff0aa0b.jpg", "Nhẫn NH005", 550000.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);
        }
    }
}
