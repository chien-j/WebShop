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
    public class ProductSize
    {
        public int Id { get; set; }

        [Required]
        public string Size { get; set; }
        [Required]
        public double Price { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product {  get; set; }

    }
}
