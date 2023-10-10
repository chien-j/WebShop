using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebShop.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName(" Tên danh mục")]
        public string ?Name { get; set; }
        [Required]
        [Range(0, 150, ErrorMessage = "Không thể lớn hơn 150")]
        [DisplayName(" Thứ tự hiển thị danh mục")]

        public int DisplayOrder { get; set; }
    }
}
