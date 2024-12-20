
using Shop.DataAccess.Repository.IRepository;
using Shop.Models;
using Shop.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Data;
using WebShop.Models;

namespace Shop.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        
        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        
        public IBlogRepository Blog { get; private set; }
        public IBlogImageRepository BlogImage { get; private set; }


        public ITopic_treeRepository Topic_tree { get; private set; }

        public IProductRepository Product { get; private set; }
        public ICompanyRepository Company { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }

        public IProductImageRepository ProductImage { get; private set; }

        


        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);

            Topic_tree = new Topic_treeRepository(_db);
            BlogImage = new BlogImageRepository(_db);
            Blog = new BlogRepository(_db);



            Product = new ProductRepository(_db);
            Company = new CompanyRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            ProductImage = new ProductImageRepository(_db);
            
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
