using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebShop.Models
{
    public class Product
    {
        [Key] 
        public int Id { get; set; }
        [Required]

        [Display(Name = "Tiêu đề")]
        public string ?Title { get; set; }

        [Required]
        [Display(Name = "Mã số tiêu chuẩn quốc tế")]
        public string ?ISBN { get; set; }

        [Required]
        [Display(Name = "Tác giả")]
        public string? Author { get; set; }
        [Display(Name = "Sự miêu tả")]
        [Required] public string? Description { get; set; }
        [Required]
        [Display(Name = "Giá bán")]
        public double ListPrice { get; set; }

        [Required]
        [Display(Name = " Giá bán ưu đãi")]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Giá bán ưu đãi trên 5 SP")]
        public double Price50 { get; set; }

        [Required]
        [Display(Name = "Giá bán ưu đãi trên 10 SP")]
        public double Price100 { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]

        public Category ?Category { get; set; }
        [ValidateNever]
        public string ?ImggeUrl {  get; set; }
    }
}
