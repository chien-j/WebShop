using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Shop.Models.Models;

namespace WebShop.Models
{
    public class Blog
    {
        [Key] 
        public int Id { get; set; }


        [Required]
        [Display(Name = "Tiêu đề")]
        public string? Title { get; set; }

        [Display(Name = "Tóm tắt")]
        public string? Summary { get; set; }

        [Display(Name = "Phần mở đầu")]
        public string? Introduction { get; set; }

        [Required]
        [Display(Name = "Phần thân bài ")]
        public string ? Body { get; set; }

        [Required]
        [Display(Name = " Phần kết luận:")]
        public string? Conclusion { get; set; }

        [Required]
        [Display(Name = "Tác giả ")]
         public string? TacGia { get; set; }
        

        [Required]
        [Display(Name = " ngày xuất bản ")]
        public string? Byline { get; set; }


        public int Topic_treeId { get; set; }
        [ForeignKey("Topic_treeId")]
        [ValidateNever]
        [Display(Name = "Thể loại blog")]
        public Topic_tree? Topic_tree { get; set; }

        [ValidateNever]
        public List<BlogImage> BlogImages { get; set; }

    }
}
