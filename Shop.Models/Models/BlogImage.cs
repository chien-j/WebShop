using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Models;

namespace Shop.Models.Models
{
    public class BlogImage
    {
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }
        public int BlogId { get; set; }
        [ForeignKey(" BlogId")]
        public Blog Blog {  get; set; }

    }
}
