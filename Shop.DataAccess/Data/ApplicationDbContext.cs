using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Models;
using Shop.Models.Models;
using WebShop.Models;

namespace WebShop.Data
{
    public class ApplicationDbContext:IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderHeader> orderHeaders { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Bánh Ngọt", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Bánh sinh nhật", DisplayOrder = 2 },
                new Category { Id = 3, Name = "bánh bông lan", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = 1,
                    Name = "Tech Solution",
                    StreetAddress = "123 Tech St",
                    City = "Tech City",
                    PostalCode = "12121",
                    State = "IL",
                    PhoneNumber = "6669990000"
                },
                new Company
                {
                    Id = 2,
                    Name = "Vivid Books",
                    StreetAddress = "999 Vid St",
                    City = "Vid City",
                    PostalCode = "66666",
                    State = "IL",
                    PhoneNumber = "7779990000"
                },
                new Company
                {
                    Id = 3,
                    Name = "Readers Club",
                    StreetAddress = "999 Main St",
                    City = "Lala land",
                    PostalCode = "99999",
                    State = "NY",
                    PhoneNumber = "1113335555"
                }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Bánh su kem",
                    Author = "Chang",
                    Description = "Bánh su kem là một trong những loại bánh ngọt vô cùng quen thuộc đối với người dân Việt Nam. \\r\\n\\r\\Bánh su kem là một loại bánh ngọt tráng miệng hấp dẫn khi mới ngửi hương vị giòn tan của bánh thôi thì bạn cũng đã đủ thấy thèm.. ",
                    ISBN = "SWD9999001",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Title = "Bánh Cupcake",
                    Author = "NChang",
                    Description = "Điều đặc biệt bên trong của chiếc bánh nhỏ nhỏ xinh xắn này chính là lớp kem tươi, mứt hoặc trái cây.\\r\\n\\r\\ Lớp bánh mềm xốp bên dưới hòa quyện với độ ngọt của mứt bên trên tạo ra một loại bánh không thể nào chối từ.. ",
                    ISBN = "CAW777777701",
                    ListPrice = 40,
                    Price = 30,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 3,
                    Title = "Bánh rán Dorayaki",
                    Author = "JChang",
                    Description = "Bánh rán Dorayaki gắn liền với một bộ phim hoạt hình mà tuổi thơ ai cũng đã từng xem qua đó chính là hoạt hình Doraemon. \\r\\n\\r\\Nếu bạn yêu thích chú mèo máy Doraemon thì bạn sẽ nhớ ngay là chú rất yêu món bánh này, mê đến nỗi phát cuồng lên.. ",
                    ISBN = "RITO5555501",
                    ListPrice = 55,
                    Price = 50,
                    Price50 = 40,
                    Price100 = 35,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 4,
                    Title = "Bánh Muffin",
                    Author = "AChang",
                    Description = "Được nhiều người biết đến với tên gọi khác là “bánh mì nhanh”.\\r\\n\\r\\ Mới nhìn lần đầu, người ăn sẽ khó phân biệt bánh Muffin với bánh cupcake hai loại bánh này khá giống nhau ở kích thước và hình dáng bên ngoài. Tuy nhiên, Bách hóa XANH gợi ý cho bạn cách phân biệt 2 món bánh ngon này nhé!. ",
                    ISBN = "WS3333333301",
                    ListPrice = 70,
                    Price = 65,
                    Price50 = 60,
                    Price100 = 55,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 5,
                    Title = "Bánh Pancake",
                    Author = "RChang",
                    Description = "Hay còn được gọi là bánh “kếp tầng”. Nguyên liệu chính để làm nên chiếc bánh đó chính là bột, \\r\\n\\r\\trứng, sữa và bơ được nướng hoặc rán trên chảo.. ",
                    ISBN = "SOTJ1111111101",
                    ListPrice = 30,
                    Price = 27,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 6,
                    Title = "Bánh Tiramisu",
                    Author = "LChang",
                    Description = "Một trong những loại bánh “sốt sồn sột” nhất hiện nay chính là bánh Tiramisu. Có nguồn gốc từ món bánh ngọt\\r\\n\\r\\ tráng miệng vị cà phê rất nổi tiếng của nước Ý mà ai cũng biết nên khi bắt đầu được du nhập vào Việt Nam đã chinh phục trái tim của người thưởng thức.. ",
                    ISBN = "FOT000000001",
                    ListPrice = 25,
                    Price = 23,
                    Price50 = 22,
                    Price100 = 20,
                    CategoryId = 3
                }
                );


        }
    }
}
