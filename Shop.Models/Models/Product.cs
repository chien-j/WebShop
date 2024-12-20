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
        [Display(Name = "Tên Cây")]
        public string? TenCay { get; set; }

        [Display(Name = "Tên gọi khác ( Tên gọi dân gian )")]
        public string? TenGoiKhacCay { get; set; }

        [Display(Name = "Tên Khoa Học")]
        public string? TenKhoaHoc { get; set; }

        [Required]
        [Display(Name = "Mô tả  ")]
        public string ?MoTaCay { get; set; }

        [Required]
        [Display(Name = "Đặc điểm sinh học:")]
        public string? DacDiem { get; set; }

        [Required]
        [Display(Name = "Phân bố và môi trường sống")]
         public string? PhanBo_MoiTruong { get; set; }
        

        [Required]
        [Display(Name = " Thành phần hóa học  ")]
        public string? ThanhPhan { get; set; }

        [Required]
        [Display(Name = " Công dụng - Liều lượng  ")]
        public string? CongDung { get; set; }

        [Required]
        [Display(Name = " Phần dùng làm thuốc   ")]
        public string? PhanDungLamThuoc { get; set; }

       

        [Required]
        [Display(Name = " Tính an toàn và tác dụng phụ")]
        public string? AnToan_Tacdungphu { get; set; }





        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        [Display(Name = "Thể loại")]
        public Category ?Category { get; set; }




        [ValidateNever]
        public List<ProductImage> ProductImages { get; set; }


    }
}
