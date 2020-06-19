using Microsoft.EntityFrameworkCore.Migrations;

namespace JewelryShop.Migrations
{
    public partial class Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Jewelries",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 1,
                column: "ImageUrl",
                value: "\\Images\\sanpham\\284674740971874bd11c5b.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 2,
                column: "ImageUrl",
                value: "\\Images\\sanpham\\28467478017635ffe020fb.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 3,
                column: "ImageUrl",
                value: "\\Images\\sanpham\\42432623515636ae3760fb.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 4,
                column: "ImageUrl",
                value: "\\Images\\sanpham\\4261909584462d336f784b.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 5,
                column: "ImageUrl",
                value: "\\Images\\sanpham\\42619097084234e931c3db.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 6,
                column: "ImageUrl",
                value: "\\Images\\sanpham\\40075270425b22d40c45bb-8c4eef99-91d8-4cc0-aa94-5d6637e088bf.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 7,
                column: "ImageUrl",
                value: "\\Images\\sanpham\\40285705182bfd10dd3ecb.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 8,
                column: "ImageUrl",
                value: "\\Images\\sanpham\\40285705342b1a0d849cab-e31cfb39-09c2-4caa-bac6-aacea5524a68.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 9,
                column: "ImageUrl",
                value: "\\Images\\sanpham\\40330998641f0b71e1ee6b-63f9135b-8f1a-483c-b381-11c7ac1af0ac.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 10,
                column: "ImageUrl",
                value: "\\Images\\sanpham\\40331008911b2bc28ef06b.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 11,
                column: "ImageUrl",
                value: "\\Images\\sanpham\\25460921337d235c5a2efb.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 12,
                column: "ImageUrl",
                value: "\\Images\\sanpham\\25460922527c5077094ecb.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 13,
                column: "ImageUrl",
                value: "\\Images\\sanpham\\25460926987c82da2f76eb-5fb237fb-0459-4c87-a056-04e898681418.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 14,
                column: "ImageUrl",
                value: "\\Images\\sanpham\\25460927087ded46a2fb3b.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 15,
                column: "ImageUrl",
                value: "\\Images\\sanpham\\25460927417ee818299d0b-75abee9c-e824-478a-aba8-6ef4b633173a.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 16,
                column: "ImageUrl",
                value: "\\Images\\sanpham\\25460927417ee818299d0b-96e38481-92f5-4490-9e67-fce7bb25a44c.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 17,
                column: "ImageUrl",
                value: "\\Images\\sanpham\\25458755737ce4f80ec48b.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 18,
                column: "ImageUrl",
                value: "\\Images\\sanpham\\25459295557c33d36a66bb.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 19,
                column: "ImageUrl",
                value: "\\Images\\sanpham\\25459312967ae8ec819bab-9d37d65e-fdbf-44e5-89da-c4e87107f29c.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 20,
                column: "ImageUrl",
                value: "\\Images\\sanpham\\26458691008bbe214d6bcb.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 21,
                column: "ImageUrl",
                value: "\\Images\\sanpham\\26458696828af93ff0aa0b.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Jewelries");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 1,
                column: "ImageUrl",
                value: "\\Images\\bongtai\\284674740971874bd11c5b.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 2,
                column: "ImageUrl",
                value: "\\Images\\bongtai\\28467478017635ffe020fb.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 3,
                column: "ImageUrl",
                value: "\\Images\\bongtai\\42432623515636ae3760fb.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 4,
                column: "ImageUrl",
                value: "\\Images\\bongtai\\4261909584462d336f784b.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 5,
                column: "ImageUrl",
                value: "\\Images\\bongtai\\42619097084234e931c3db.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 6,
                column: "ImageUrl",
                value: "\\Images\\bongtai\\40075270425b22d40c45bb-8c4eef99-91d8-4cc0-aa94-5d6637e088bf.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 7,
                column: "ImageUrl",
                value: "\\Images\\bongtai\\40285705182bfd10dd3ecb.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 8,
                column: "ImageUrl",
                value: "\\Images\\bongtai\\40285705342b1a0d849cab-e31cfb39-09c2-4caa-bac6-aacea5524a68.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 9,
                column: "ImageUrl",
                value: "\\Images\\bongtai\\40330998641f0b71e1ee6b-63f9135b-8f1a-483c-b381-11c7ac1af0ac.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 10,
                column: "ImageUrl",
                value: "\\Images\\bongtai\\40331008911b2bc28ef06b.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 11,
                column: "ImageUrl",
                value: "\\Images\\bongtai\\25460921337d235c5a2efb.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 12,
                column: "ImageUrl",
                value: "\\Images\\bongtai\\25460922527c5077094ecb.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 13,
                column: "ImageUrl",
                value: "\\Images\\bongtai\\25460926987c82da2f76eb-5fb237fb-0459-4c87-a056-04e898681418.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 14,
                column: "ImageUrl",
                value: "\\Images\\bongtai\\25460927087ded46a2fb3b.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 15,
                column: "ImageUrl",
                value: "\\Images\\bongtai\\25460927417ee818299d0b-75abee9c-e824-478a-aba8-6ef4b633173a.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 16,
                column: "ImageUrl",
                value: "\\Images\\bongtai\\25460927417ee818299d0b-96e38481-92f5-4490-9e67-fce7bb25a44c.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 17,
                column: "ImageUrl",
                value: "\\Images\\bongtai\\25458755737ce4f80ec48b.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 18,
                column: "ImageUrl",
                value: "\\Images\\bongtai\\25459295557c33d36a66bb.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 19,
                column: "ImageUrl",
                value: "\\Images\\bongtai\\25459312967ae8ec819bab-9d37d65e-fdbf-44e5-89da-c4e87107f29c.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 20,
                column: "ImageUrl",
                value: "\\Images\\bongtai\\26458691008bbe214d6bcb.jpg");

            migrationBuilder.UpdateData(
                table: "Jewelries",
                keyColumn: "JewelryId",
                keyValue: 21,
                column: "ImageUrl",
                value: "\\Images\\bongtai\\26458696828af93ff0aa0b.jpg");
        }
    }
}
