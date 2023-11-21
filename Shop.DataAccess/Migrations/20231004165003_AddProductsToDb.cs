using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProductsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Bánh su kem", "Bánh su kem là một trong những loại bánh ngọt vô cùng quen thuộc đối với người dân Việt Nam. \\r\\n\\r\\Bánh su kem là một loại bánh ngọt tráng miệng hấp dẫn khi mới ngửi hương vị giòn tan của bánh thôi thì bạn cũng đã đủ thấy thèm.. ", "SWD9999001", 99.0, 90.0, 80.0, 85.0, "Bánh su kem" },
                    { 2, "Bánh Cupcake", "Điều đặc biệt bên trong của chiếc bánh nhỏ nhỏ xinh xắn này chính là lớp kem tươi, mứt hoặc trái cây.\\r\\n\\r\\ Lớp bánh mềm xốp bên dưới hòa quyện với độ ngọt của mứt bên trên tạo ra một loại bánh không thể nào chối từ.. ", "CAW777777701", 40.0, 30.0, 20.0, 25.0, "Bánh Cupcake" },
                    { 3, "Bánh rán Dorayaki", "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "RITO5555501", 55.0, 50.0, 35.0, 40.0, "Bánh rán Dorayaki" },
                    { 4, "Bánh Muffin", "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "WS3333333301", 70.0, 65.0, 55.0, 60.0, "Bánh Muffin" },
                    { 5, "Bánh Pancake", "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "SOTJ1111111101", 30.0, 27.0, 20.0, 25.0, "Bánh Pancake" },
                    { 6, "Bánh Tiramisu", "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", 25.0, 23.0, 20.0, 22.0, "Bánh Tiramisus" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
