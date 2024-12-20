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
        [DisplayName("Vị thuốc chữa bệnh ")]
        public string ?Name { get; set; }
        [Required]
        [DisplayName(" Mô Tả chi tiết")]

        public string  DisplayOrder { get; set; }
    }
}
