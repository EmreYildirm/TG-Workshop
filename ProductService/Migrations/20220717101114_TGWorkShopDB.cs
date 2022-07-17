using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductService.Migrations
{
    public partial class TGWorkShopDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Oyun Bilgisayarları" },
                    { 2, "İş Bilgisayarları " }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageFile", "Name", "Price", "Summary" },
                values: new object[,]
                {
                    { 1, 1, null, null, "Tulpar T7 V22.2 17,3 Gaming Laptop", 0m, null },
                    { 2, 1, null, null, "Tulpar T7 V25.1.2 17,3 Gaming Laptop", 0m, null },
                    { 3, 1, null, null, "Casper Excalibur G770.1140-8EL0T-B", 0m, null },
                    { 4, 1, null, null, "Asus ROG Strix G513IE-HN065", 0m, null },
                    { 5, 1, null, null, "MSI Katana GF76 11UE-414TR ", 0m, null },
                    { 6, 1, null, null, "MSI Bravo 15 B5DD-209XTR", 0m, null },
                    { 7, 2, null, null, "Apple MacBook Air M1", 0m, null },
                    { 8, 2, null, null, "Apple MacBook M1 Pro", 0m, null },
                    { 9, 2, null, null, "Apple MacBook Pro M2", 0m, null },
                    { 10, 2, null, null, "Apple MacBook Air M2 ", 0m, null },
                    { 11, 2, null, null, "Apple MacBook Pro", 0m, null },
                    { 12, 2, null, null, "Asus Zenbook Pro", 0m, null },
                    { 13, 2, null, null, "Dell M7760 TKNM7760RKS55M09 W-11955M", 0m, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
