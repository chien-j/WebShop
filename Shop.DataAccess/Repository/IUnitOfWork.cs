using Shop.DataAccess;
using Shop.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Models;

namespace Shop.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {


        ICategoryRepository Category { get; }
        IBlogRepository Blog { get; }

        ITopic_treeRepository Topic_tree { get; }
        
        IProductRepository Product { get; }
        ICompanyRepository Company { get; }
        IApplicationUserRepository ApplicationUser { get; }
        

        IProductImageRepository ProductImage { get; }
        IBlogImageRepository BlogImage { get; }






        void Save();
    }
}
