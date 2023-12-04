using Shop.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Models;

namespace Shop.DataAccess.Repository
{

    public interface IProductSizeRepository : IRepository<ProductSize>
    {
        void Update(ProductSize obj);
        void Save();
    }
}
