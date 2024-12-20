using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Models;

namespace Shop.Models.ViewModels
{
    public class BlogVM
    {
        public Blog? Blog { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ? Topic_treeList { get; set; }
    }
}
