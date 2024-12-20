

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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.TenCay = obj.TenCay;
                objFromDb.TenGoiKhacCay = obj.TenGoiKhacCay;
                objFromDb.TenKhoaHoc = obj.TenKhoaHoc;
                objFromDb.MoTaCay = obj.MoTaCay;
                objFromDb.PhanBo_MoiTruong = obj.PhanBo_MoiTruong;
                objFromDb.ThanhPhan = obj.ThanhPhan;
                objFromDb.CongDung = obj.CongDung;
                objFromDb.PhanDungLamThuoc = obj.PhanDungLamThuoc;
                objFromDb.AnToan_Tacdungphu = obj.AnToan_Tacdungphu;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.ProductImages = obj.ProductImages;
                //if (obj.ImggeUrl != null)
                //{
                //    objFromDb.ImggeUrl = obj.ImggeUrl;
                //}
            }
        }
    }
}
