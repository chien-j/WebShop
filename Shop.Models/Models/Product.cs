using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Shop.Models.Models;

namespace WebShop.Models
{
    public class Product
    {
        [Key] 
        public int Id { get; set; }
        [Required]

        [Display(Name = "Tên Bánh")]
        public string ?Title { get; set; }

        [Required]
        [Display(Name = "Size Bánh")]
        public string ?ISBN { get; set; }

        [Required]
        [Display(Name = "Thợ làm bánh")]
        public string? Author { get; set; }
        [Display(Name = "Thông tin chi tiết")]
        [Required] public string? Description { get; set; }
        [Required]
        [Display(Name = "Giá bán - Gốc")]
        public double ListPrice { get; set; }

        [Required]
        [Display(Name = " Giá bán ")]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Bánh Sl 50")]
        public double Price50 { get; set; }

        [Required]
        [Display(Name = "Bánh sl100")]
        public double Price100 { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        [Display(Name = "Thể loại")]
        public Category ?Category { get; set; }


        [ValidateNever]
        public List<ProductImage> ProductImages { get; set; }

        [ValidateNever]
        public List<ProductSize> ProductSizes { get; set; }

    }
}
