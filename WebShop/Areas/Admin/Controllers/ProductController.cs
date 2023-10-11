using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Repository;
using Shop.DataAccess.Repository.IRepository;
using Shop.Models.ViewModels;
using Shop.Utility;
using WebShop.Data;
using WebShop.Models;

namespace WebShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitiofwork, IWebHostEnvironment webHostEnvironment)
        {
            _unitofwork = unitiofwork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index(string searchString, string category)
        {
            List<Product> objProductList = _unitofwork.Product.GetAll(includeProperties:"Category").ToList();

            //Demo sreach
            var productSR = from m in _unitofwork.Product.GetAll() select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                productSR = productSR.Where(s => s.Title!.Contains(searchString));
            }
            objProductList = productSR.ToList();
            //Demo sreach category



            return View(objProductList);
        }

        public IActionResult Upsert(int? id)
        { 

            ProductVM productVM = new()
            {
                CategoryList = _unitofwork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };
           if(id == null || id ==0)
            {
                //Create
                return View(productVM);
            }
            else
            {
                //update
                productVM.Product = _unitofwork.Product.Get(u=>u.Id == id);
                return View(productVM);

            }
        }
        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, IFormFile? file)
        {
            
            if (ModelState.IsValid)
            {
              
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file != null)
                {

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);  
                    string productPath = Path.Combine(wwwRootPath, @"images/product");

                    if(!string.IsNullOrEmpty(productVM.Product.ImggeUrl)) 
                    {
                        // xoa anh cu
                        var oldImagePath = Path.Combine(wwwRootPath, productVM.Product.ImggeUrl.TrimStart('\\'));

                        if(System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }

                    }

                    using (var  fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    productVM.Product.ImggeUrl = @"\images\product\" + fileName;
                }
                if (productVM.Product.Id == 0)
                {
                    _unitofwork.Product.Add(productVM.Product);

                }
                else
                {
                    _unitofwork.Product.Update(productVM.Product);

                }

                _unitofwork.Save();
                TempData["success"] = " Tạo mới danh mục thành công";
                return RedirectToAction("Index");
            }
            else
            {
                productVM.CategoryList = _unitofwork.Category.GetAll().Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    });
                return View(productVM);

            }
        }

        

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? ProductFromDb = _unitofwork.Product.Get(u => u.Id == id);

            if (ProductFromDb == null)
            {
                return NotFound();
            }
            return View(ProductFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Product? obj = _unitofwork.Product.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();

            }

            _unitofwork.Product.Remove(obj);
            _unitofwork.Save();
            TempData["success"] = " Đã xóa danh mục thành công";

            return RedirectToAction("Index");
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll() {
            List<Product> objProductList = _unitofwork.Product.GetAll(includeProperties: "Category").ToList();
            return Json(new { dat = objProductList });
        }

        #endregion
    }
}
