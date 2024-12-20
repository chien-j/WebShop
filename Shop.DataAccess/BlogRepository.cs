

using Shop.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebShop.Data;
using WebShop.Models;

namespace Shop.DataAccess
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        private ApplicationDbContext _db;
        public BlogRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Blog obj)
        {
            _db.Blogs.Update(obj);
        }
    }
}
