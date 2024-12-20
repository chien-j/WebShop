

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
    public class Topic_treeRepository : Repository<Topic_tree>, ITopic_treeRepository
    {
        private ApplicationDbContext _db;
        public Topic_treeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Topic_tree obj)
        {
            _db.Topic_trees.Update(obj);
        }
    }
}
