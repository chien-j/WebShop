using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Shop.Models.Models
{
    public class News
    {
        public int Id { get; set; }

        [Display(Name = "Tiêu Đề")]
        public string? Title { get; set; }

        [Display(Name = "Thông tin chi tiết")]
        [Required]
        public string? Description { get; set; }

        [Display(Name = "Hình ảnh")]
        
        public string ImageFile { get; set; }

        [Display(Name = "Thông tin chi tiết")]
        [Required]
        public string? Description_01 { get; set; }

        [Display(Name = "Hình ảnh 01")]
        
        public string ImageFile_01 { get; set; }


    }
}
