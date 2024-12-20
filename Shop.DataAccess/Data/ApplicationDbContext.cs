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
        public DbSet<Topic_tree> Topic_trees { get; set; }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogImage> BlogImages { get; set; }



        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        

        public DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(


                new Category { Id = 1, Name = "Chữa bệnh phụ nữ", DisplayOrder = "Cây Thuốc nam" },
                new Category { Id = 2, Name = "Mụn nhọt mẩn ngứa ", DisplayOrder = "Cây Thuốc nam" },
                new Category { Id = 3, Name = "Giun sán", DisplayOrder = "Cây Thuốc nam" },
                new Category { Id = 4, Name = "Lỵ", DisplayOrder = "Cây huốc nam" },
                new Category { Id = 5, Name = "Tiểu tiện - thông mật", DisplayOrder = "Cây Thuốc nam" },
                new Category { Id = 6, Name = "Cầm máu", DisplayOrder = "Cây Thuốc nam" },
                new Category { Id = 7, Name = "Hạ huyết áp", DisplayOrder = "Cây Thuốc nam" },
                new Category { Id = 8, Name = "Có chất độc", DisplayOrder = "Cây Thuốc nam" },
                new Category { Id = 9, Name = "Đau bụng", DisplayOrder = "Cây Thuốc nam" },
                new Category { Id = 10, Name = "nhuận tràng và tẩy", DisplayOrder = "Cây Thuốc nam" },
                new Category { Id = 12, Name = "Đắp vết thương - rắn rết cắn", DisplayOrder = "Cây Thuốc nam" },
                new Category { Id = 13, Name = "Đau dạ giày", DisplayOrder = "Cây Thuốc nam" },
                new Category { Id = 14, Name = "Tê thấp - Đau nhức", DisplayOrder = "Cây Thuốc nam" },
                new Category { Id = 15, Name = "Mắt, tai, mũi, họng, răng", DisplayOrder = "Cây Thuốc nam" },
                new Category { Id = 16, Name = "Tim", DisplayOrder = "Cây Thuốc nam" },
                new Category { Id = 17, Name = "Cảm sốt", DisplayOrder = "Cây Thuốc nam" },
                new Category { Id = 18, Name = "Ho Hen", DisplayOrder = "Cây Thuốc nam" },
                new Category { Id = 19, Name = "Thuốc ngủ, an thần, trấn kinh", DisplayOrder = "Cây Thuốc nam" },
                new Category { Id = 20, Name = "Thuốc bổ - bồi dưỡng", DisplayOrder = "Cây Thuốc nam" }

                ); 
          
            modelBuilder.Entity<Product>().HasData(


                    new Product

                    {

                        Id = 1,

                        TenCay = "Rau Má ",
                        TenGoiKhacCay = "Rau má ",
                        TenKhoaHoc = "Centella asiatica",
                        MoTaCay = "một loại thực vật thân thảo thuộc họ Hoa tán (Apiaceae). Đây là một loại rau phổ biến tại nhiều quốc gia, đặc biệt là ở châu Á, nơi nó được sử dụng rộng rãi trong ẩm thực và y học cổ truyền. ",
                        DacDiem = "Demo",
                        PhanBo_MoiTruong = " đồng bằng đến miền núi.",
                        ThanhPhan = " vitamin A, C, B1, B2 và các khoáng chất như sắt, canxi, magie.",
                        CongDung = "Dùng làm rau ăn sống, nấu canh hoặc xay làm nước ép giải nhiệt.",
                        PhanDungLamThuoc = "Lá, ngọn, rễ  ",
                        AnToan_Tacdungphu = "việc tiêu thụ rau má quá mức có thể gây ảnh hưởng đến hệ tiêu hóa hoặc gan",


                        CategoryId = 1

                    }

                );
        }
    }
}
