using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Models;

namespace Shop.DataAccess.Repository
{

    public interface ITopic_treeRepository : IRepository<Topic_tree>
    {
        void Update(Topic_tree obj);
        void Save();
    }
}
