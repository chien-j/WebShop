using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebShop.Models
{
    public class Topic_tree
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Loại bài viết")]
        public string ?Name { get; set; }
        
    }
}
