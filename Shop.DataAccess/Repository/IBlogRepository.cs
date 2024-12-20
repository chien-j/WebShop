using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Models;

namespace Shop.DataAccess.Repository
{

    public interface IBlogRepository : IRepository<Blog>
    {
        void Update(Blog obj);
        void Save();
    }
}
