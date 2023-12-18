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
        public DbSet<News> newss { get; set; }
        public DbSet<News> advise { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Bánh Kem", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Bánh sinh nhật", DisplayOrder = 2 }, 
                new Category { Id = 3, Name = "Bánh COOKIES", DisplayOrder = 4 },
                new Category { Id = 4, Name = "Bánh BISCOTTI", DisplayOrder = 5 },
                new Category { Id = 5, Name = "Bánh ECLAIR", DisplayOrder = 6 },
                new Category { Id = 6, Name = "Set quà tết", DisplayOrder = 7 },
                new Category { Id = 7, Name = "Bánh Hoa Decor", DisplayOrder = 8 }
                );

            

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Bánh sinh nhật cổ điển",
                    Description = "Bánh sinh nhật cổ điển là một trong những loại bánh ngọt vô cùng quen thuộc đối với người dân Việt Nam. ",
                    Size = "S",
                    Price = 90000,
                    CategoryId = 1
                }
                );


        }
    }
}
